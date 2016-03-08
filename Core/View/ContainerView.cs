using System.Runtime.Serialization;
using Structurizr.Model;

namespace Structurizr.View
{

    /// <summary>
    /// A container view.
    /// </summary>
    [DataContract]
    public class ContainerView : StaticView
    {

        public override string Name
        {
            get
            {
                return SoftwareSystem.Name + " - Containers";
            }
        }

        internal ContainerView() : base()
        {
        }

        internal ContainerView(SoftwareSystem softwareSystem, string description) : base(softwareSystem, description)
        {
        }


        /// <summary>
        /// Adds all software systems, people and containers to this view.
        /// </summary>
        public override void AddAllElements()
        {
            AddAllSoftwareSystems();
            AddAllPeople();
            AddAllContainers();
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
            AddElement(container, true);
        }

    }
}
