using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Structurizr
{

    /// <summary>
    /// A component (a grouping of related functionality behind an interface that runs inside a container).
    /// </summary>
    [DataContract]
    public sealed class Component : StaticStructureElement, IEquatable<Component>
    {
        
        public override Element Parent { get; set; }

        public Container Container
        {
            get
            {
                return Parent as Container;
            }
        }

        /// <summary>
        /// The technology associated with this component (e.g. Spring Bean).
        /// </summary>
        [DataMember(Name="technology", EmitDefaultValue=false)]
        public string Technology { get; set; }
          
        /// <summary>
        /// The size of this component (e.g. lines of code).
        /// </summary>
        [DataMember(Name="size", EmitDefaultValue = true)]
        public long Size { get; set; }

        /// <summary>
        /// The implementation type (e.g. a fully qualified interface/class name).
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public HashSet<CodeElement> CodeElements { get; internal set; }

        internal Component()
        {
            CodeElements = new HashSet<CodeElement>();
        }

        public override string CanonicalName
        {
            get
            {
                return Parent.CanonicalName + CanonicalNameSeparator + FormatForCanonicalName(Name);
            }
        }

        public override List<string> GetRequiredTags()
        {
            return new List<string>
            {
                Structurizr.Tags.Element,
                Structurizr.Tags.Component
            };
        }

        /// <summary>
        /// Gets the type of this component (e.g. a fully qualified interface/class name).
        /// </summary>
        public string Type
        {
            get
            {
                CodeElement codeElement = CodeElements.FirstOrDefault(ce => ce.Role == CodeElementRole.Primary);
                return codeElement?.Type;
            }

            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    CodeElements.RemoveWhere(ce => ce.Role == CodeElementRole.Primary);
                    CodeElement codeElement = new CodeElement(value);
                    codeElement.Role = CodeElementRole.Primary;
                    CodeElements.Add(codeElement);
                }
            }
        }

        public CodeElement AddSupportingType(string type)
        {
            CodeElement codeElement = new CodeElement(type);
            codeElement.Role = CodeElementRole.Supporting;
            CodeElements.Add(codeElement);

            return codeElement;
        }

        public bool Equals(Component component)
        {
            return this.Equals(component as Element);
        }

    }
}