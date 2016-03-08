using Structurizr.Model;
using System.Runtime.Serialization;

namespace Structurizr.View
{

    [DataContract]
    public abstract class StaticView : View
    {

        internal StaticView() : base()
        {
        }

        internal StaticView(SoftwareSystem softwareSystem, string description) : base(softwareSystem, description)
        {
        }

        /// <summary>
        /// Adds all software systems in the model to this view.
        /// </summary>
        public void AddAllSoftwareSystems()
        {
            foreach (SoftwareSystem softwareSystem in this.Model.SoftwareSystems)
            {
                Add(softwareSystem);
            }
        }

        /// <summary>
        /// Adds the given SoftwareSystem to this view.
        /// </summary>
        public void Add(SoftwareSystem softwareSystem)
        {
            AddElement(softwareSystem, true);
        }

        /// <summary>
        /// Adds all people in the model to this view.
        /// </summary>
        public void AddAllPeople()
        {
            foreach (Person person in this.Model.People)
            {
                Add(person);
            }
        }

        /// <summary>
        /// Adds the given Person to this view.
        /// </summary>
        public void Add(Person person)
        {
            AddElement(person, true);
        }

    }
}
