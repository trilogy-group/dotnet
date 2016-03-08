using System.Runtime.Serialization;
using Structurizr.View;

namespace Structurizr
{

    /// <summary>
    /// Represents a Structurizr workspace, which is a wrapper for a software architecture model and the associated views.
    /// </summary>
    [DataContract]
    public class Workspace : AbstractWorkspace
    {

        /// <summary>
        /// The software architecture model.
        /// </summary>
        /// <value>The software architecture model.</value>
        [DataMember(Name = "model", EmitDefaultValue = false)]
        public Model.Model Model { get; set; }

        /// <summary>
        /// The set of views onto a software architecture model.
        /// </summary>
        /// <value>The set of views onto a software architecture model.</value>
        [DataMember(Name = "views", EmitDefaultValue = false)]
        public ViewSet Views { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Workspace" />class.
        /// </summary>
        /// <param name="Name">The name of the workspace..</param>
        /// <param name="Description">A short description of the workspace..</param>
        public Workspace(string name, string description) : base(name, description)
        {
            this.Model = new Model.Model();
            this.Views = new ViewSet(Model);        
        }

    }
}
