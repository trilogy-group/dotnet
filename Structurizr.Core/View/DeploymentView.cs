using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Structurizr
{

    /// <summary>
    /// A deployment view, used to show the mapping of container instances to deployment nodes.
    /// </summary>
    public sealed class DeploymentView : View
    {

        public override Model Model { get; set; }

        private IList<Animation> _animations = new List<Animation>();

        [DataMember(Name = "animations", EmitDefaultValue = false)]
        public IList<Animation> Animations
        {
            get { return new List<Animation>(_animations); }

            internal set { _animations = new List<Animation>(value); }
        }

        /// <summary>
        /// The name of the environment that this deployment view is for (e.g. "Development", "Live", etc).
        /// </summary>
        [DataMember(Name = "environment", EmitDefaultValue = false)]
        public string Environment { get; set; }

        DeploymentView()
        {
        }

        internal DeploymentView(Model model, string key, string description) : base(null, key, description)
        {
            Model = model;
        }

        internal DeploymentView(SoftwareSystem softwareSystem, string key, string description) : base(softwareSystem,
            key, description)
        {
            Model = softwareSystem.Model;
        }

        /// <summary>
        /// Adds all of the top-level deployment nodes to this view. 
        /// </summary>
        public void AddAllDeploymentNodes()
        {
            Model.DeploymentNodes.ToList().ForEach(Add);
        }

        /// <summary>
        /// Adds a deployment node to this view.
        /// </summary>
        /// <param name="deploymentNode">the DeploymentNode to add</param>
        public void Add(DeploymentNode deploymentNode)
        {
            Add(deploymentNode, true);
        }

        /// <summary>
        /// Adds a deployment node to this view.
        /// </summary>
        /// <param name="deploymentNode">the DeploymentNode to add</param>
        public void Add(DeploymentNode deploymentNode, bool addRelationships)
        {
            if (deploymentNode != null)
            {
                if (AddContainerInstancesAndDeploymentNodesAndInfrastructureNodes(deploymentNode, addRelationships))
                {
                    Element parent = deploymentNode.Parent;
                    while (parent != null)
                    {
                        AddElement(parent, false);
                        parent = parent.Parent;
                    }
                }
            }
        }

        private bool AddContainerInstancesAndDeploymentNodesAndInfrastructureNodes(DeploymentNode deploymentNode, bool addRelationships)
        {
            bool hasContainersOrInfrastructureNodes = false;
            foreach (ContainerInstance containerInstance in deploymentNode.ContainerInstances) {
                Container container = containerInstance.Container;
                if (SoftwareSystem == null || container.Parent.Equals(SoftwareSystem))
                {
                    AddElement(containerInstance, addRelationships);
                    hasContainersOrInfrastructureNodes = true;
                }
            }

            foreach (InfrastructureNode infrastructureNode in deploymentNode.InfrastructureNodes) {
                AddElement(infrastructureNode, addRelationships);
                hasContainersOrInfrastructureNodes = true;
            }

            foreach (DeploymentNode child in deploymentNode.Children)
            {
                hasContainersOrInfrastructureNodes = hasContainersOrInfrastructureNodes | AddContainerInstancesAndDeploymentNodesAndInfrastructureNodes(child, addRelationships);
            }

            if (hasContainersOrInfrastructureNodes)
            {
                AddElement(deploymentNode, addRelationships);
            }

            return hasContainersOrInfrastructureNodes;
        }

        /// <summary>
        /// Removes a deployment node from this view.
        /// </summary>
        /// <param name="deploymentNode">the DpeloymentNode to remove</param>
        public void Remove(DeploymentNode deploymentNode)
        {
            RemoveElement(deploymentNode);
        }
        
        /// <summary>
        /// Adds an animation step, with the specified infrastructure nodes.
        /// </summary>
        /// <param name="infrastructureNodes">the infrastructure nodes that should be shown in the animation step</param>
        public void AddAnimation(params InfrastructureNode[] infrastructureNodes)
        {
            if (infrastructureNodes == null || infrastructureNodes.Length == 0)
            {
                throw new ArgumentException("One or more infrastructure nodes must be specified.");
            }

            addAnimationStep(infrastructureNodes);
        }

        /// <summary>
        /// Adds an animation step, with the specified container instances.
        /// </summary>
        /// <param name="containerInstances">the container instances that should be shown in the animation step</param>
        public void AddAnimation(params ContainerInstance[] containerInstances)
        {
            if (containerInstances == null || containerInstances.Length == 0)
            {
                throw new ArgumentException("One or more container instances must be specified.");
            }

            addAnimationStep(containerInstances);
        }

        private void addAnimationStep(params Element[] elements)
        {
            ISet<string> elementIdsInPreviousAnimationSteps = new HashSet<string>();
            foreach (Animation animationStep in Animations) {
                foreach (string element in animationStep.Elements)
                {
                    elementIdsInPreviousAnimationSteps.Add(element);
                }
            }

            ISet<Element> elementsInThisAnimationStep = new HashSet<Element>();
            ISet<Relationship> relationshipsInThisAnimationStep = new HashSet<Relationship>();

            foreach (Element element in elements)
            {
                if (IsElementInView(element) && !elementIdsInPreviousAnimationSteps.Contains(element.Id))
                {
                    elementIdsInPreviousAnimationSteps.Add(element.Id);
                    elementsInThisAnimationStep.Add(element);

                    Element deploymentNode = findDeploymentNode(element);
                    while (deploymentNode != null)
                    {
                        if (!elementIdsInPreviousAnimationSteps.Contains(deploymentNode.Id))
                        {
                            elementIdsInPreviousAnimationSteps.Add(deploymentNode.Id);
                            elementsInThisAnimationStep.Add(deploymentNode);
                        }

                        deploymentNode = deploymentNode.Parent;
                    }
                }
            }

            if (elementsInThisAnimationStep.Count == 0)
            {
                throw new ArgumentException("None of the specified container instances exist in this view.");
            }

            foreach (RelationshipView relationshipView in Relationships)
            {
                if (
                        (elementsInThisAnimationStep.Contains(relationshipView.Relationship.Source) && elementIdsInPreviousAnimationSteps.Contains(relationshipView.Relationship.Destination.Id)) ||
                        (elementIdsInPreviousAnimationSteps.Contains(relationshipView.Relationship.Source.Id) && elementsInThisAnimationStep.Contains(relationshipView.Relationship.Destination))
                )
                {
                    relationshipsInThisAnimationStep.Add(relationshipView.Relationship);
                }
            }

            _animations.Add(new Animation(Animations.Count + 1, elementsInThisAnimationStep, relationshipsInThisAnimationStep));
        }

        
        private DeploymentNode findDeploymentNode(Element e)
        {
            foreach (Element element in Model.GetElements())
            {
                if (element is DeploymentNode)
                {
                    DeploymentNode deploymentNode = (DeploymentNode) element;

                    if (e is ContainerInstance)
                    {
                        if (deploymentNode.ContainerInstances.Contains(e))
                        {
                            return deploymentNode;
                        }
                    }

                    if (e is InfrastructureNode)
                    {
                        if (deploymentNode.InfrastructureNodes.Contains(e))
                        {
                            return deploymentNode;
                        }
                    }
                }
            }

            return null;
        }

        public override string Name
        {
            get
            {
                if (SoftwareSystem != null)
                {
                    return SoftwareSystem.Name + " - Deployment";
                }
                else
                {
                    return "Deployment";
                }
            }
        }
        
    }
}