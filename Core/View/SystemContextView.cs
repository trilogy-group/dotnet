using System.Runtime.Serialization;
using Newtonsoft.Json;
using Structurizr.Model;

namespace Structurizr.View
{

    /// <summary>
    /// A system context view.
    /// </summary>
    [DataContract]
    public class SystemContextView : StaticView
    {

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

        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
