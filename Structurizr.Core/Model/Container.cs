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

        public override Element Parent { get; set; }

        public SoftwareSystem SoftwareSystem
        {
            get
            {
                return Parent as SoftwareSystem;
            }
        }

        /// <summary>
        /// The technology associated with this container (e.g. Windows Service).
        /// </summary>
        [DataMember(Name="technology", EmitDefaultValue=false)]
        public string Technology { get; set; }
  
        /// <summary>
        /// The set of components within this container.
        /// </summary>
        [DataMember(Name="components", EmitDefaultValue=false)]
        public HashSet<Component> Components { get; set; }
  
        public override string CanonicalName
        {
            get
            {
                return Parent.CanonicalName + CanonicalNameSeparator + FormatForCanonicalName(Name);
            }
        }

        internal Container()
        {
            this.Components = new HashSet<Component>();
        }

        public Component AddComponent(string name, string description)
        {
            return this.AddComponent(name, description, null);
        }

        public Component AddComponent(string name, string description, string technology)
        {
            return this.AddComponent(name, null, null, description, technology);
        }

        public Component AddComponent(string name, string interfaceType, string implementationType, string description, string technology)
        {
            Component component = Model.AddComponent(this, name, interfaceType, implementationType, description, technology);

            return component;
        }

        internal void Add(Component component)
        {
            if (GetComponentWithName(component.Name) == null)
            {
                Components.Add(component);
            }
        }

        public Component GetComponentWithName(string name)
        {
            if (name == null)
            {
                return null;
            }

            foreach (Component component in Components)
            {
                if (component.Name == name)
                {
                    return component;
                }
            }

            return null;
        }

        public Component getComponentOfType(string type)
        {
            if (type == null)
            {
                return null;
            }

            foreach (Component component in Components)
            {
                if (component.InterfaceType == type || component.ImplementationType == type)
                {
                    return component;
                }
            }

            return null;
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
