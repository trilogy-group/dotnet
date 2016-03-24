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
    public class Component : Element, IEquatable<Component>
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
        /// The implementation type (e.g. a fully qualified interface/class name).
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }
  
        
        /// <summary>
        /// The source code path that reflects this component (e.g. a GitHub URL).
        /// </summary>
        [DataMember(Name="sourcePath", EmitDefaultValue=false)]
        public string SourcePath { get; set; }


        public override string CanonicalName
        {
            get
            {
                return Parent.CanonicalName + CanonicalNameSeparator + FormatForCanonicalName(Name);
            }
        }

        public override List<string> getRequiredTags()
        {
            string[] tags = {
                Structurizr.Tags.Element,
                Structurizr.Tags.Component
            };
            return tags.ToList();
        }

        public bool Equals(Component component)
        {
            return this.Equals(component as Element);
        }

    }
}
