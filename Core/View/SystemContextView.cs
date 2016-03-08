using System;
using System.Runtime.Serialization;
using Structurizr.Model;

namespace Structurizr.View
{

    /// <summary>
    /// A system context view.
    /// </summary>
    [DataContract]
    public class SystemContextView : StaticView
    {

        public override string Name
        {
            get
            {
                return SoftwareSystem.Name + " - System Context";
            }
        }

        internal SystemContextView() : base()
        {
        }

        internal SystemContextView(SoftwareSystem softwareSystem, string description) : base(softwareSystem, description)
        {
            AddElement(softwareSystem, true);
        }

        /// <summary>
        /// Adds all software systems and all people to this view.
        /// </summary>
        public void AddAllElements()
        {
            AddAllSoftwareSystems();
            AddAllPeople();
        }

    }
}
