﻿namespace ImmutableObjectGraph.CodeGeneration.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.MSBuild;
    using Microsoft.CodeAnalysis.Text;
    using Microsoft.ImmutableObjectGraph_SFG;
    using Task = System.Threading.Tasks.Task;

    public class GenerateCodeFromAttributes : Microsoft.Build.Utilities.Task, ICancelableTask
    {
        private readonly CancellationTokenSource cts = new CancellationTokenSource();

        [Required]
        public ITaskItem[] Compile { get; set; }

        [Required]
        public ITaskItem[] ReferencePath { get; set; }

        [Required]
        public string IntermediateOutputDirectory { get; set; }

        [Output]
        public ITaskItem[] GeneratedCompile { get; set; }

        public override bool Execute()
        {
            // Run under our own AppDomain so we can control the version of Roslyn we load.
            var appDomainSetup = new AppDomainSetup();
            appDomainSetup.ApplicationBase = Path.GetDirectoryName(this.GetType().Assembly.Location);
            var appDomain = AppDomain.CreateDomain("codegen", AppDomain.CurrentDomain.Evidence, appDomainSetup);
            try
            {
                var helper = (Helper)appDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(Helper).FullName);
                helper.Compile = this.Compile;
                helper.ReferencePath = this.ReferencePath;
                helper.IntermediateOutputDirectory = this.IntermediateOutputDirectory;
                helper.Log = this.Log;

                try
                {
                    helper.Execute();

                    // Copy the contents of the output parameters into our own. Don't just copy the reference
                    // because we're going to unload the AppDomain.
                    this.GeneratedCompile = helper.GeneratedCompile.Select(i => new TaskItem(i)).ToArray();

                    return !this.Log.HasLoggedErrors;
                }
                catch (OperationCanceledException)
                {
                    this.Log.LogMessage(MessageImportance.High, "Canceled.");
                    return false;
                }
            }
            finally
            {
                AppDomain.Unload(appDomain);
            }
        }

        public void Cancel()
        {
            cts.Cancel();
        }

        private class Helper : MarshalByRefObject
        {
            public CancellationToken CancellationToken { get; set; }

            public ITaskItem[] Compile { get; set; }

            public ITaskItem[] ReferencePath { get; set; }

            public string IntermediateOutputDirectory { get; set; }

            public ITaskItem[] GeneratedCompile { get; set; }

            public TaskLoggingHelper Log { get; set; }

            public void Execute()
            {
                Task.Run(async delegate
                {
                    var project = this.CreateProject();
                    var outputFiles = new List<ITaskItem>();

                    foreach (var inputDocument in project.Documents)
                    {
                        this.CancellationToken.ThrowIfCancellationRequested();

                        string outputFilePath = Path.Combine(this.IntermediateOutputDirectory, Path.GetFileNameWithoutExtension(inputDocument.Name) + ".generated.cs");
                        this.Log.LogMessage(MessageImportance.Normal, "{0} -> {1}", inputDocument.Name, outputFilePath);

                        var outputDocument = await DocumentTransform.TransformAsync(inputDocument, new ProgressLogger(this.Log, inputDocument.Name));

                        // Only produce a new file if the generated document is not empty.
                        var semanticModel = await outputDocument.GetSemanticModelAsync(this.CancellationToken);
                        if (!semanticModel.GetDeclarationsInSpan(TextSpan.FromBounds(0, semanticModel.SyntaxTree.Length), false, this.CancellationToken).IsEmpty)
                        {
                            var outputText = await outputDocument.GetTextAsync(this.CancellationToken);
                            using (var outputFileStream = File.OpenWrite(outputFilePath))
                            using (var outputWriter = new StreamWriter(outputFileStream))
                            {
                                outputText.Write(outputWriter);
                            }

                            var outputItem = new TaskItem(outputFilePath);
                            outputFiles.Add(outputItem);
                        }
                    }

                    this.GeneratedCompile = outputFiles.ToArray();
                }).GetAwaiter().GetResult();
            }

            private Project CreateProject()
            {
                var workspace = new CustomWorkspace();
                var project = workspace.CurrentSolution.AddProject("codegen", "codegen", "C#")
                    .WithCompilationOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                    .WithMetadataReferences(this.ReferencePath.Select(p => MetadataReference.CreateFromFile(p.ItemSpec)));

                foreach (var sourceFile in this.Compile)
                {
                    using (var stream = File.OpenRead(sourceFile.ItemSpec))
                    {
                        this.CancellationToken.ThrowIfCancellationRequested();
                        var text = SourceText.From(stream);
                        project = project.AddDocument(sourceFile.ItemSpec, text).Project;
                    }
                }

                return project;
            }
        }

        private class ProgressLogger : IProgressAndErrors
        {
            private readonly TaskLoggingHelper logger;
            private readonly string inputFilename;

            internal ProgressLogger(TaskLoggingHelper logger, string inputFilename)
            {
                this.logger = logger;
                this.inputFilename = inputFilename;
            }

            public void Error(string message, uint line, uint column)
            {
                this.logger.LogError(
                    subcategory: string.Empty,
                    errorCode: string.Empty,
                    helpKeyword: string.Empty,
                    file: inputFilename,
                    lineNumber: (int)line,
                    columnNumber: (int)column,
                    endLineNumber: -1,
                    endColumnNumber: -1,
                    message: message);
            }

            public void Report(uint progress, uint total)
            {
            }

            public void Warning(string message, uint line, uint column)
            {
                this.logger.LogWarning(
                    subcategory: string.Empty,
                    warningCode: string.Empty,
                    helpKeyword: string.Empty,
                    file: inputFilename,
                    lineNumber: (int)line,
                    columnNumber: (int)column,
                    endLineNumber: -1,
                    endColumnNumber: -1,
                    message: message);
            }
        }
    }
}
