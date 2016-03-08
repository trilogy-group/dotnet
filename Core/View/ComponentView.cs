using System;
using System.Runtime.Serialization;
using Structurizr.Model;

namespace Structurizr.View
{

    /// <summary>
    /// A system context view.
    /// </summary>
    [DataContract]
    public class ComponentView : StaticView
    {

        public override string Name
        {
            get
            {
                return SoftwareSystem.Name + " - " + Container.Name + " - Components";
            }
        }

        public Container Container { get; set; }

        private string containerId;

        /// <summary>
        /// The ID of the container this view is associated with.
        /// </summary>
        [DataMember(Name="containerId", EmitDefaultValue=false)]
        public string ContainerId {
            get
            {
                if (Container != null)
                {
                    return Container.Id;
                } else
                {
                    return containerId;
                }
            }
            set
            {
                this.containerId = value;
            }
        }

        public override void AddAllElements()
        {
            throw new NotImplementedException();
        }

        public override void Add(SoftwareSystem softwareSystem)
        {
            if (softwareSystem != null && !softwareSystem.Equals(SoftwareSystem))
            {
                AddElement(softwareSystem, true);
            }
        }

        public void AddAllContainers()
        {
            foreach (Container container in SoftwareSystem.Containers)
            {
                Add(container);
            }
        }

        public void Add(Container container)
        {
            if (container != null && !container.Equals(Container))
            {
                AddElement(container, true);
            }
        }

    }
}
