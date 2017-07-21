using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Structurizr
{
    
    /// <summary>
    /// Represents a deployment node, which is something like:
    ///  - Physical infrastructure (e.g. a physical server or device)
    ///  - Virtualised infrastructure (e.g. IaaS, PaaS, a virtual machine)
    ///  - Containerised infrastructure (e.g. a Docker container)
    ///  - Database server
    ///  - Java EE web/application server
    ///  - Microsoft IIS
    ///  - etc
    /// </summary>
    [DataContract]
    public sealed class DeploymentNode : Element
    {

        private DeploymentNode _parent;

        public override Element Parent
        {
            get { return _parent; }
            set { _parent = value as DeploymentNode; }
        }
            
        [DataMember(Name = "technology", EmitDefaultValue = false)]
        public string Technology { get; set; }

        [DataMember(Name = "instances", EmitDefaultValue = false)]
        public int Instances { get; set; }
        
        [DataMember(Name = "children", EmitDefaultValue = false)]
        public HashSet<DeploymentNode> Children { get; internal set; }

        [DataMember(Name = "containerInstances", EmitDefaultValue = false)]
        public HashSet<ContainerInstance> ContainerInstances { get; internal set; }

        internal DeploymentNode()
        {
            Instances = 1;
            Children = new HashSet<DeploymentNode>();
            ContainerInstances = new HashSet<ContainerInstance>();
        }

        public override string Tags {
            get
            {
                return "";
            }
            set
            {
                // no-op
            }
        }
        
        public override List<string> getRequiredTags()
        {
            return new List<string>();
        }

        public override string CanonicalName
        {
            get
            {
                if (_parent != null)
                {
                    return _parent.CanonicalName + CanonicalNameSeparator + FormatForCanonicalName(Name);
                }
                else
                {
                    return CanonicalNameSeparator + FormatForCanonicalName(Name);
                }
            }
        }

        /// <summary>
        /// Adds a container instance to this deployment node.
        /// </summary>
        /// <param name="container">the Container to add an instance of</param>
        /// <returns>a ContainerInstance object</returns>
        public ContainerInstance Add(Container container) {
            if (container == null) {
                throw new ArgumentException("A container must be specified.");
            }

            ContainerInstance containerInstance = Model.AddContainerInstance(container);
            ContainerInstances.Add(containerInstance);
    
            return containerInstance;
        }

        public DeploymentNode AddDeploymentNode(string name, string description, string technology) {
            return AddDeploymentNode(name, description, technology, 1);
        }
    
        public DeploymentNode AddDeploymentNode(string name, string description, string technology, int instances) {
            return AddDeploymentNode(name, description, technology, instances, null);
        }
    
        public DeploymentNode AddDeploymentNode(string name, string description, string technology, int instances, Dictionary<string,string> properties) {
            DeploymentNode deploymentNode = Model.AddDeploymentNode(this, name, description, technology, instances, properties);
            if (deploymentNode != null) {
                Children.Add(deploymentNode);
            }
            
            return deploymentNode;
        }

        /// <summary>
        /// Gets the DeploymentNode with the specified name.
        /// </summary>
        /// <param name="name">the name of the deployment node</param>
        /// <returns>the DeploymentNode instance with the specified name (or null if it doesn't exist)</returns>
        public DeploymentNode GetDeploymentNodeWithName(string name)
        {
            return Children.FirstOrDefault(dn => dn.Name.Equals(name));
        }

        public Relationship Uses(DeploymentNode destination, string description, string technology)
        {
            if (destination != null)
            {
                return Model.AddRelationship(this, destination, description, technology);
            }
            else
            {
                throw new ArgumentException("The destination of a relationship must be specified.");
            }
        }

    }
    
}