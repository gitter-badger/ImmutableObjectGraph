﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ImmutableTree Version: 0.0.0.1
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

namespace ImmutableObjectGraph.Tests {
	using System.Diagnostics;
	using ImmutableObjectGraph;

	
	public interface IXmlNode {
		System.String LocalName { get; }
	}
	
	public abstract partial class XmlNode : IXmlNode {
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String localName;
	
		/// <summary>Initializes a new instance of the XmlNode class.</summary>
		protected XmlNode()
		{
		}
	
		/// <summary>Initializes a new instance of the XmlNode class.</summary>
		protected XmlNode(
			System.String localName)
			: base()
		{
			this.localName = localName;
		}
	
		public System.String LocalName {
			get { return this.localName; }
		}
		/// <summary>Returns a new instance with the LocalName property set to the specified value.</summary>
		public XmlNode WithLocalName(System.String value) {
			if (value == this.LocalName) {
				return this;
			}
	
			return this.With(localName: value);
		}
	
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public abstract XmlNode With(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>));
	
		public Builder ToBuilder() {
			return new Builder(this);
		}
	
	
	 
		public partial class Builder {
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private XmlNode immutable;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			protected System.String localName;
	
			internal Builder(XmlNode immutable) {
				this.immutable = immutable;
	
				this.localName = immutable.LocalName;
			}
	
			public System.String LocalName {
				get {
					return this.localName;
				}
	
				set {
					this.localName = value;
				}
			}
	
			public XmlNode ToImmutable() {
				return this.immutable = this.immutable.With(
					ImmutableObjectGraph.Optional.For(this.LocalName));
			}
		}
	}
	
	public interface IXmlElement : IXmlNode {
		System.String NamespaceName { get; }
		System.Collections.Immutable.ImmutableList<XmlNode> Children { get; }
	}
	
	public partial class XmlElement : XmlNode, IXmlElement {
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly XmlElement DefaultInstance = GetDefaultTemplate();
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String namespaceName;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.Collections.Immutable.ImmutableList<XmlNode> children;
	
		/// <summary>Initializes a new instance of the XmlElement class.</summary>
		protected XmlElement()
		{
		}
	
		/// <summary>Initializes a new instance of the XmlElement class.</summary>
		protected XmlElement(
			System.String localName,
			System.String namespaceName,
			System.Collections.Immutable.ImmutableList<XmlNode> children)
			: base(
				localName: localName)
		{
			this.namespaceName = namespaceName;
			this.children = children;
			this.Validate();
		}
	
		public static XmlElement Create(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> namespaceName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>> children = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>>)) {
			return DefaultInstance.With(
				localName: localName.GetValueOrDefault(DefaultInstance.LocalName),
				namespaceName: namespaceName.GetValueOrDefault(DefaultInstance.NamespaceName),
				children: children.GetValueOrDefault(DefaultInstance.Children));
		}
	
		public System.String NamespaceName {
			get { return this.namespaceName; }
		}
	
		public System.Collections.Immutable.ImmutableList<XmlNode> Children {
			get { return this.children; }
		}
		/// <summary>Returns a new instance with the LocalName property set to the specified value.</summary>
		public new XmlElement WithLocalName(System.String value) {
			return (XmlElement)base.WithLocalName(value);
		}
		/// <summary>Returns a new instance with the NamespaceName property set to the specified value.</summary>
		public XmlElement WithNamespaceName(System.String value) {
			if (value == this.NamespaceName) {
				return this;
			}
	
			return this.With(namespaceName: value);
		}
		/// <summary>Returns a new instance with the Children property set to the specified value.</summary>
		public XmlElement WithChildren(System.Collections.Immutable.ImmutableList<XmlNode> value) {
			if (value == this.Children) {
				return this;
			}
	
			return this.With(children: value);
		}
	
		/// <summary>Replaces the elements of the Children collection with the specified collection.</summary>
		public XmlElement WithChildren(params XmlNode[] values) {
			return this.With(children: this.Children.ResetContents(values));
		}
	
		/// <summary>Replaces the elements of the Children collection with the specified collection.</summary>
		public XmlElement WithChildren(System.Collections.Generic.IEnumerable<XmlNode> values) {
			return this.With(children: this.Children.ResetContents(values));
		}
	
		/// <summary>Adds the specified elements from the Children collection.</summary>
		public XmlElement AddChildren(System.Collections.Generic.IEnumerable<XmlNode> values) {
			return this.With(children: this.Children.AddRange(values));
		}
	
		/// <summary>Adds the specified elements from the Children collection.</summary>
		public XmlElement AddChildren(params XmlNode[] values) {
			return this.With(children: this.Children.AddRange(values));
		}
	
		/// <summary>Adds the specified element from the Children collection.</summary>
		public XmlElement AddChildren(XmlNode value) {
			return this.With(children: this.Children.Add(value));
		}
	
		/// <summary>Removes the specified elements from the Children collection.</summary>
		public XmlElement RemoveChildren(System.Collections.Generic.IEnumerable<XmlNode> values) {
			return this.With(children: this.Children.RemoveRange(values));
		}
	
		/// <summary>Removes the specified elements from the Children collection.</summary>
		public XmlElement RemoveChildren(params XmlNode[] values) {
			return this.With(children: this.Children.RemoveRange(values));
		}
	
		/// <summary>Removes the specified element from the Children collection.</summary>
		public XmlElement RemoveChildren(XmlNode value) {
			return this.With(children: this.Children.Remove(value));
		}
	
		/// <summary>Clears all elements from the Children collection.</summary>
		public XmlElement RemoveChildren() {
			return this.With(children: this.Children.Clear());
		}
	
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public override XmlNode With(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>)) {
			return this.With(
				localName: localName,
				namespaceName: default(ImmutableObjectGraph.Optional<System.String>),
				children: default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>>));
		}
		
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public virtual XmlElement With(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> namespaceName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>> children = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>>)) {
			if (
				(localName.IsDefined && localName.Value != this.LocalName) || 
				(namespaceName.IsDefined && namespaceName.Value != this.NamespaceName) || 
				(children.IsDefined && children.Value != this.Children)) {
				return new XmlElement(
					localName: localName.GetValueOrDefault(this.LocalName),
					namespaceName: namespaceName.GetValueOrDefault(this.NamespaceName),
					children: children.GetValueOrDefault(this.Children));
			} else {
				return this;
			}
		}
	
	
		public new Builder ToBuilder() {
			return new Builder(this);
		}
	
	
		public virtual XmlElementWithContent ToXmlElementWithContent(
			ImmutableObjectGraph.Optional<System.String> content = default(ImmutableObjectGraph.Optional<System.String>)) {
			XmlElementWithContent that = this as XmlElementWithContent;
			if (that != null && this.GetType().IsEquivalentTo(typeof(XmlElementWithContent))) {
				if ((!content.IsDefined || content.Value == that.Content)) {
					return that;
				}
			}
	
			return XmlElementWithContent.Create(
				localName: this.LocalName,
				namespaceName: this.NamespaceName,
				children: this.Children,
				content: content);
		}
	
	 
		/// <summary>Normalizes and/or validates all properties on this object.</summary>
		/// <exception type="ArgumentException">Thrown if any properties have disallowed values.</exception>
		partial void Validate();
	
		/// <summary>Provides defaults for fields.</summary>
		/// <param name="template">The struct to set default values on.</param>
		static partial void CreateDefaultTemplate(ref Template template);
	
		/// <summary>Returns a newly instantiated XmlElement whose fields are initialized with default values.</summary>
		private static XmlElement GetDefaultTemplate() {
			var template = new Template();
			CreateDefaultTemplate(ref template);
			return new XmlElement(
				template.LocalName, 
				template.NamespaceName, 
				template.Children);
		}
	
		public new partial class Builder : XmlNode.Builder {
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private XmlElement immutable;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			protected System.String namespaceName;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			protected ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>.Builder> children;
	
			internal Builder(XmlElement immutable) : base(immutable) {
				this.immutable = immutable;
	
				this.namespaceName = immutable.NamespaceName;
			}
	
			public System.String NamespaceName {
				get {
					return this.namespaceName;
				}
	
				set {
					this.namespaceName = value;
				}
			}
	
			public System.Collections.Immutable.ImmutableList<XmlNode>.Builder Children {
				get {
					if (!this.children.IsDefined) {
						this.children = this.immutable.children != null ? this.immutable.children.ToBuilder() : null;
					}
	
					return this.children.Value;
				}
	
				set {
					this.children = value;
				}
			}
	
			public new XmlElement ToImmutable() {
				var children = this.children.IsDefined ? (this.children.Value != null ? this.children.Value.ToImmutable() : null) : this.immutable.Children;
				return this.immutable = this.immutable.With(
					ImmutableObjectGraph.Optional.For(this.LocalName),
					ImmutableObjectGraph.Optional.For(this.NamespaceName),
					ImmutableObjectGraph.Optional.For(children));
			}
		}
	
		/// <summary>A struct with all the same fields as the containing type for use in describing default values for new instances of the class.</summary>
		private struct Template {
			internal System.String LocalName { get; set; }
	
			internal System.String NamespaceName { get; set; }
	
			internal System.Collections.Immutable.ImmutableList<XmlNode> Children { get; set; }
		}
	}
	
	public interface IXmlElementWithContent : IXmlElement {
		System.String Content { get; }
	}
	
	public partial class XmlElementWithContent : XmlElement, IXmlElementWithContent {
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly XmlElementWithContent DefaultInstance = GetDefaultTemplate();
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String content;
	
		/// <summary>Initializes a new instance of the XmlElementWithContent class.</summary>
		protected XmlElementWithContent()
		{
		}
	
		/// <summary>Initializes a new instance of the XmlElementWithContent class.</summary>
		protected XmlElementWithContent(
			System.String localName,
			System.String namespaceName,
			System.Collections.Immutable.ImmutableList<XmlNode> children,
			System.String content)
			: base(
				localName: localName,
				namespaceName: namespaceName,
				children: children)
		{
			this.content = content;
			this.Validate();
		}
	
		public static XmlElementWithContent Create(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> namespaceName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>> children = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>>),
			ImmutableObjectGraph.Optional<System.String> content = default(ImmutableObjectGraph.Optional<System.String>)) {
			return DefaultInstance.With(
				localName: localName.GetValueOrDefault(DefaultInstance.LocalName),
				namespaceName: namespaceName.GetValueOrDefault(DefaultInstance.NamespaceName),
				children: children.GetValueOrDefault(DefaultInstance.Children),
				content: content.GetValueOrDefault(DefaultInstance.Content));
		}
	
		public System.String Content {
			get { return this.content; }
		}
		/// <summary>Returns a new instance with the LocalName property set to the specified value.</summary>
		public new XmlElementWithContent WithLocalName(System.String value) {
			return (XmlElementWithContent)base.WithLocalName(value);
		}
		/// <summary>Returns a new instance with the NamespaceName property set to the specified value.</summary>
		public new XmlElementWithContent WithNamespaceName(System.String value) {
			return (XmlElementWithContent)base.WithNamespaceName(value);
		}
		/// <summary>Returns a new instance with the Children property set to the specified value.</summary>
		public new XmlElementWithContent WithChildren(System.Collections.Immutable.ImmutableList<XmlNode> value) {
			return (XmlElementWithContent)base.WithChildren(value);
		}
		/// <summary>Returns a new instance with the Content property set to the specified value.</summary>
		public XmlElementWithContent WithContent(System.String value) {
			if (value == this.Content) {
				return this;
			}
	
			return this.With(content: value);
		}
	
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public override XmlElement With(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> namespaceName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>> children = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>>)) {
			return this.With(
				localName: localName,
				namespaceName: namespaceName,
				children: children,
				content: default(ImmutableObjectGraph.Optional<System.String>));
		}
		
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public virtual XmlElementWithContent With(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> namespaceName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>> children = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<XmlNode>>),
			ImmutableObjectGraph.Optional<System.String> content = default(ImmutableObjectGraph.Optional<System.String>)) {
			if (
				(localName.IsDefined && localName.Value != this.LocalName) || 
				(namespaceName.IsDefined && namespaceName.Value != this.NamespaceName) || 
				(children.IsDefined && children.Value != this.Children) || 
				(content.IsDefined && content.Value != this.Content)) {
				return new XmlElementWithContent(
					localName: localName.GetValueOrDefault(this.LocalName),
					namespaceName: namespaceName.GetValueOrDefault(this.NamespaceName),
					children: children.GetValueOrDefault(this.Children),
					content: content.GetValueOrDefault(this.Content));
			} else {
				return this;
			}
		}
	
	
		public new Builder ToBuilder() {
			return new Builder(this);
		}
	
		public XmlElement ToXmlElement() {
			return XmlElement.Create(
				localName: this.LocalName,
				namespaceName: this.NamespaceName,
				children: this.Children);
		}
	
	 
		/// <summary>Normalizes and/or validates all properties on this object.</summary>
		/// <exception type="ArgumentException">Thrown if any properties have disallowed values.</exception>
		partial void Validate();
	
		/// <summary>Provides defaults for fields.</summary>
		/// <param name="template">The struct to set default values on.</param>
		static partial void CreateDefaultTemplate(ref Template template);
	
		/// <summary>Returns a newly instantiated XmlElementWithContent whose fields are initialized with default values.</summary>
		private static XmlElementWithContent GetDefaultTemplate() {
			var template = new Template();
			CreateDefaultTemplate(ref template);
			return new XmlElementWithContent(
				template.LocalName, 
				template.NamespaceName, 
				template.Children, 
				template.Content);
		}
	
		public new partial class Builder : XmlElement.Builder {
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private XmlElementWithContent immutable;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			protected System.String content;
	
			internal Builder(XmlElementWithContent immutable) : base(immutable) {
				this.immutable = immutable;
	
				this.content = immutable.Content;
			}
	
			public System.String Content {
				get {
					return this.content;
				}
	
				set {
					this.content = value;
				}
			}
	
			public new XmlElementWithContent ToImmutable() {
				var children = this.children.IsDefined ? (this.children.Value != null ? this.children.Value.ToImmutable() : null) : this.immutable.Children;
				return this.immutable = this.immutable.With(
					ImmutableObjectGraph.Optional.For(this.LocalName),
					ImmutableObjectGraph.Optional.For(this.NamespaceName),
					ImmutableObjectGraph.Optional.For(children),
					ImmutableObjectGraph.Optional.For(this.Content));
			}
		}
	
		/// <summary>A struct with all the same fields as the containing type for use in describing default values for new instances of the class.</summary>
		private struct Template {
			internal System.String LocalName { get; set; }
	
			internal System.String NamespaceName { get; set; }
	
			internal System.Collections.Immutable.ImmutableList<XmlNode> Children { get; set; }
	
			internal System.String Content { get; set; }
		}
	}
	
	public interface IXmlAttribute : IXmlNode {
		System.String NamespaceName { get; }
		System.String Value { get; }
	}
	
	public partial class XmlAttribute : XmlNode, IXmlAttribute {
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly XmlAttribute DefaultInstance = GetDefaultTemplate();
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String namespaceName;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String value;
	
		/// <summary>Initializes a new instance of the XmlAttribute class.</summary>
		protected XmlAttribute()
		{
		}
	
		/// <summary>Initializes a new instance of the XmlAttribute class.</summary>
		protected XmlAttribute(
			System.String localName,
			System.String namespaceName,
			System.String value)
			: base(
				localName: localName)
		{
			this.namespaceName = namespaceName;
			this.value = value;
			this.Validate();
		}
	
		public static XmlAttribute Create(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> namespaceName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> value = default(ImmutableObjectGraph.Optional<System.String>)) {
			return DefaultInstance.With(
				localName: localName.GetValueOrDefault(DefaultInstance.LocalName),
				namespaceName: namespaceName.GetValueOrDefault(DefaultInstance.NamespaceName),
				value: value.GetValueOrDefault(DefaultInstance.Value));
		}
	
		public System.String NamespaceName {
			get { return this.namespaceName; }
		}
	
		public System.String Value {
			get { return this.value; }
		}
		/// <summary>Returns a new instance with the LocalName property set to the specified value.</summary>
		public new XmlAttribute WithLocalName(System.String value) {
			return (XmlAttribute)base.WithLocalName(value);
		}
		/// <summary>Returns a new instance with the NamespaceName property set to the specified value.</summary>
		public XmlAttribute WithNamespaceName(System.String value) {
			if (value == this.NamespaceName) {
				return this;
			}
	
			return this.With(namespaceName: value);
		}
		/// <summary>Returns a new instance with the Value property set to the specified value.</summary>
		public XmlAttribute WithValue(System.String value) {
			if (value == this.Value) {
				return this;
			}
	
			return this.With(value: value);
		}
	
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public override XmlNode With(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>)) {
			return this.With(
				localName: localName,
				namespaceName: default(ImmutableObjectGraph.Optional<System.String>),
				value: default(ImmutableObjectGraph.Optional<System.String>));
		}
		
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public virtual XmlAttribute With(
			ImmutableObjectGraph.Optional<System.String> localName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> namespaceName = default(ImmutableObjectGraph.Optional<System.String>),
			ImmutableObjectGraph.Optional<System.String> value = default(ImmutableObjectGraph.Optional<System.String>)) {
			if (
				(localName.IsDefined && localName.Value != this.LocalName) || 
				(namespaceName.IsDefined && namespaceName.Value != this.NamespaceName) || 
				(value.IsDefined && value.Value != this.Value)) {
				return new XmlAttribute(
					localName: localName.GetValueOrDefault(this.LocalName),
					namespaceName: namespaceName.GetValueOrDefault(this.NamespaceName),
					value: value.GetValueOrDefault(this.Value));
			} else {
				return this;
			}
		}
	
	
		public new Builder ToBuilder() {
			return new Builder(this);
		}
	
	
	 
		/// <summary>Normalizes and/or validates all properties on this object.</summary>
		/// <exception type="ArgumentException">Thrown if any properties have disallowed values.</exception>
		partial void Validate();
	
		/// <summary>Provides defaults for fields.</summary>
		/// <param name="template">The struct to set default values on.</param>
		static partial void CreateDefaultTemplate(ref Template template);
	
		/// <summary>Returns a newly instantiated XmlAttribute whose fields are initialized with default values.</summary>
		private static XmlAttribute GetDefaultTemplate() {
			var template = new Template();
			CreateDefaultTemplate(ref template);
			return new XmlAttribute(
				template.LocalName, 
				template.NamespaceName, 
				template.Value);
		}
	
		public new partial class Builder : XmlNode.Builder {
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private XmlAttribute immutable;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			protected System.String namespaceName;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			protected System.String value;
	
			internal Builder(XmlAttribute immutable) : base(immutable) {
				this.immutable = immutable;
	
				this.namespaceName = immutable.NamespaceName;
				this.value = immutable.Value;
			}
	
			public System.String NamespaceName {
				get {
					return this.namespaceName;
				}
	
				set {
					this.namespaceName = value;
				}
			}
	
			public System.String Value {
				get {
					return this.value;
				}
	
				set {
					this.value = value;
				}
			}
	
			public new XmlAttribute ToImmutable() {
				return this.immutable = this.immutable.With(
					ImmutableObjectGraph.Optional.For(this.LocalName),
					ImmutableObjectGraph.Optional.For(this.NamespaceName),
					ImmutableObjectGraph.Optional.For(this.Value));
			}
		}
	
		/// <summary>A struct with all the same fields as the containing type for use in describing default values for new instances of the class.</summary>
		private struct Template {
			internal System.String LocalName { get; set; }
	
			internal System.String NamespaceName { get; set; }
	
			internal System.String Value { get; set; }
		}
	}
}

