using System.Runtime.Serialization;

namespace Structurizr
{

    [DataContract]
    public abstract class AbstractWorkspace
    {

        /// <summary>
        /// The ID of the workspace. 
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// The name of the workspace.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// A short description of the workspace.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The thumbnail associated with the workspace; a Base64 encoded PNG file as a Data URI (data:image/png;base64).
        /// </summary>
        /// <value>The thumbnail associated with the workspace; a Base64 encoded PNG file as a Data URI (data:image/png;base64).</value>
        [DataMember(Name = "thumbnail", EmitDefaultValue = false)]
        public string Thumbnail { get; set; }

        public AbstractWorkspace() { }

        public AbstractWorkspace(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

    }
}
