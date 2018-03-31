using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Structurizr
{
    
    /// <summary>
    /// Represents a deployment instance of a Container, which can be added to a DeploymentNode.
    /// </summary>
    [DataContract]
    public sealed class ContainerInstance : Element
    {

        public Container Container { get; internal set; }

        private string _containerId;

        [DataMember(Name = "containerId", EmitDefaultValue = false)]
        public string ContainerId
        {
            get
            {
                if (Container != null)
                {
                    return Container.Id;
                }
                else
                {
                    return _containerId;
                }
            }
            set { _containerId = value; }
        }

        [DataMember(Name = "instanceId", EmitDefaultValue = false)]
        public int InstanceId { get; internal set; }

        public override string Name
        {
            get { return null; }
            set
            {
                // no-op
            }
        }

        internal ContainerInstance() {
        }

        internal ContainerInstance(Container container, int instanceId)
        {
            Container = container;
            Tags = container.Tags;
            AddTags(Structurizr.Tags.ContainerInstance);
            InstanceId = instanceId;
        }

        public override List<string> getRequiredTags()
        {
            return new List<string>();
        }

        public override void RemoveTag(string tag)
        {
            // do nothing ... tags cannot be removed from container instances (they should reflect the container they are based upon)
        }

        public override string CanonicalName
        {
            get { return Container.CanonicalName + "[" + InstanceId + "]"; }
        }

        public override Element Parent
        {
            get { return Container.Parent; }
            set
            {
            }
        }
        
        /// <summary>
        /// Adds a relationship between this container instance and another.
        /// </summary>
        /// <param name="destination">the destination of the relationship (a ContainerInstance)</param>
        /// <param name="description">a description of the relationship</param>
        /// <param name="technology">the technology of the relationship</param>
        /// <returns>a Relationship object</returns>
        /// <exception cref="ArgumentException"></exception>
        public Relationship Uses(ContainerInstance destination, string description, string technology) {
            if (destination != null) {
                return Model.AddRelationship(this, destination, description, technology);
            } else {
                throw new ArgumentException("The destination of a relationship must be specified.");
            }
        }

    }
    
}