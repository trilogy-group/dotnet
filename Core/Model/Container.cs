using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Structurizr.Model
{

    /// <summary>
    /// A container (something that can execute code or host data).
    /// </summary>
    [DataContract]
    public class Container : Element, IEquatable<Container>
    {

        public SoftwareSystem Parent { get; set; }

        public SoftwareSystem SoftwareSystem
        {
            get
            {
                return Parent;
            }
        }

        /// <summary>
        /// The technology associated with this container (e.g. Apache Tomcat).
        /// </summary>
        /// <value>The technology associated with this container (e.g. Apache Tomcat).</value>
        [DataMember(Name="technology", EmitDefaultValue=false)]
        public string Technology { get; set; }
  
        /// <summary>
        /// The set of components within this container.
        /// </summary>
        /// <value>The set of components within this container.</value>
        [DataMember(Name="components", EmitDefaultValue=false)]
        public List<Component> Components { get; set; }
  
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
                Structurizr.Model.Tags.Element,
                Structurizr.Model.Tags.Container
            };
            return tags.ToList();
        }

        public bool Equals(Container container)
        {
            return this.Equals(container as Element);
        }

    }
}
