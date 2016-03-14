using System.Runtime.Serialization;
namespace Structurizr.View
{

    /// <summary>
    /// The configuration associated with a set of views.
    /// </summary>
    [DataContract]
    public class Configuration
    {

        internal Configuration()
        {
            this.Styles = new Styles();
        }
        
        [DataMember(Name="styles", EmitDefaultValue=false)]
        public Styles Styles { get; set; }

        /// <summary>
        /// The placement of the diagram metadata.
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = false)]
        public Metadata? Metadata { get; set; }

    }
}
