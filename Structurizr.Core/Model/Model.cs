using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Structurizr
{

    /// <summary>
    /// A software architecture model.
    /// </summary>
    [DataContract]
    public sealed class Model
    {

        [DataMember(Name = "enterprise", EmitDefaultValue = false)]
        public Enterprise Enterprise { get; set; }

        [DataMember(Name = "people", EmitDefaultValue = false)]
        public HashSet<Person> People { get; set; }

        [DataMember(Name = "softwareSystems", EmitDefaultValue = false)]
        public HashSet<SoftwareSystem> SoftwareSystems { get; }

        [DataMember(Name = "deploymentNodes", EmitDefaultValue = false)]
        public HashSet<DeploymentNode> DeploymentNodes { get; }

        private readonly Dictionary<string, Element> _elementsById = new Dictionary<string, Element>();
        private readonly Dictionary<string, Relationship> _relationshipsById = new Dictionary<string, Relationship>();

        public ICollection<Relationship> Relationships
        {
            get
            {
                return _relationshipsById.Values;
            }
        }

        private readonly SequentialIntegerIdGeneratorStrategy _idGenerator = new SequentialIntegerIdGeneratorStrategy();

        internal Model()
        {
            People = new HashSet<Person>();
            SoftwareSystems = new HashSet<SoftwareSystem>();
            DeploymentNodes = new HashSet<DeploymentNode>();
        }

        /// <summary>
        /// Creates a software system (location is unspecified) and adds it to the model
        /// (unless one exists with the same name already).
        /// </summary>
        /// <param name="Name">The name of the software system</param>
        /// <param name="Description">A short description of the software syste.</param>
        /// <returns>the SoftwareSystem instance created and added to the model (or null)</returns>
        public SoftwareSystem AddSoftwareSystem(string name, string description)
        {
            return AddSoftwareSystem(Location.Unspecified, name, description);
        }

        /// <summary>
        /// Creates a software system (location is unspecified) and adds it to the model
        /// (unless one exists with the same name already).
        /// </summary>
        /// <param name="location">The location of the software system (e.g. internal, external, etc)</param>
        /// <param name="name">The name of the software system</param>
        /// <param name="description">A short description of the software syste.</param>
        /// <returns>the SoftwareSystem instance created and added to the model (or null)</returns>
        public SoftwareSystem AddSoftwareSystem(Location location, string name, string description)
        {
            if (GetSoftwareSystemWithName(name) == null)
            {
                SoftwareSystem softwareSystem = new SoftwareSystem();
                softwareSystem.Location = location;
                softwareSystem.Name = name;
                softwareSystem.Description = description;

                SoftwareSystems.Add(softwareSystem);

                softwareSystem.Id = _idGenerator.GenerateId(softwareSystem);
                AddElementToInternalStructures(softwareSystem);

                return softwareSystem;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a person (location is unspecified) and adds it to the model
        /// (unless one exists with the same name already.
        /// </summary>
        /// <param name="name">the name of the person (e.g. "Admin User" or "Bob the Business User")</param>
        /// <param name="description">a short description of the person</param>
        /// <returns>the Person instance created and added to the model (or null)</returns>
        public Person AddPerson(string name, string description)
        {
            return AddPerson(Location.Unspecified, name, description);
        }

        /// <summary>
        /// Creates a person (location is unspecified) and adds it to the model
        /// (unless one exisrs with the same name already.
        /// </summary>
        /// <param name="location">the location of the person (e.g. internal, external, etc)</param>
        /// <param name="name">the name of the person (e.g. "Admin User" or "Bob the Business User")</param>
        /// <param name="description">a short description of the person</param>
        /// <returns>the Person instance created and added to the model (or null)</returns>
        public Person AddPerson(Location location, string name, string description)
        {
            if (GetPersonWithName(name) == null)
            {
                Person person = new Person();
                person.Location = location;
                person.Name = name;
                person.Description = description;

                People.Add(person);

                person.Id = _idGenerator.GenerateId(person);
                AddElementToInternalStructures(person);

                return person;
            }
            else {
                return null;
            }
        }

        internal Container AddContainer(SoftwareSystem parent, string name, string description, string technology)
        {
            if (parent.GetContainerWithName(name) == null)
            {
                Container container = new Container();
                container.Name = name;
                container.Description = description;
                container.Technology = technology;

                container.Parent = parent;
                parent.Add(container);

                container.Id = _idGenerator.GenerateId(container);
                AddElementToInternalStructures(container);

                return container;
            }
            else {
                return null;
            }
        }
        
        internal ContainerInstance AddContainerInstance(Container container) {
            if (container == null) {
                throw new ArgumentException("A container must be specified.");
            }

            long instanceNumber = GetElements().Count(e => e is ContainerInstance && ((ContainerInstance)e).Container.Equals(container));
            instanceNumber++;
            ContainerInstance containerInstance = new ContainerInstance(container, (int)instanceNumber);
            containerInstance.Id = _idGenerator.GenerateId(containerInstance);

            // find all ContainerInstance objects
            IEnumerable<ContainerInstance> containerInstances = GetElements().OfType<ContainerInstance>();

            // and replicate the container-container relationships
            foreach (ContainerInstance ci in containerInstances)
            {
                Container c = ci.Container;

                foreach (Relationship relationship in container.Relationships) {
                    if (relationship.Destination.Equals(c)) {
                        AddRelationship(containerInstance, ci, relationship.Description, relationship.Technology, relationship.InteractionStyle);
                    }
                }

                foreach (Relationship relationship in c.Relationships) {
                    if (relationship.Destination.Equals(container)) {
                        AddRelationship(ci, containerInstance, relationship.Description, relationship.Technology, relationship.InteractionStyle);
                    }
                }
            }

            AddElementToInternalStructures(containerInstance);

            return containerInstance;
        }

        internal Component AddComponent(Container parent, string name, string type, string description, string technology)
        {
            if (parent.GetComponentWithName(name) == null)
            {
                Component component = new Component();
                component.Name = name;
                component.Description = description;
                component.Technology = technology;

                if (type != null)
                {
                    component.Type = type;

                }

                component.Parent = parent;
                parent.Add(component);

                component.Id = _idGenerator.GenerateId(component);
                AddElementToInternalStructures(component);

                return component;
            }
             
            throw new ArgumentException("A container named '" + name + "' already exists for this software system.");
        }

        public DeploymentNode AddDeploymentNode(string name, string description, string technology) {
            return AddDeploymentNode(name, description, technology, 1);
        }

        public DeploymentNode AddDeploymentNode(string name, string description, string technology, int instances) {
            return AddDeploymentNode(name, description, technology, instances, null);
        }

        public DeploymentNode AddDeploymentNode(string name, string description, string technology, int instances, Dictionary<string,string> properties) {
            return AddDeploymentNode(null, name, description, technology, instances, properties);
        }

        internal DeploymentNode AddDeploymentNode(DeploymentNode parent, string name, string description, string technology, int instances, Dictionary<string,string> properties) {
            if ((parent == null && GetDeploymentNodeWithName(name) == null) || (parent != null && parent.GetDeploymentNodeWithName(name) == null)) {
                DeploymentNode deploymentNode = new DeploymentNode
                {
                    Name = name,
                    Description = description,
                    Technology = technology,
                    Parent = parent,
                    Instances = instances
                };
                
                if (properties != null) {
                    deploymentNode.Properties = properties;
                }

                if (parent == null) {
                    DeploymentNodes.Add(deploymentNode);
                }

                deploymentNode.Id = _idGenerator.GenerateId(deploymentNode);
                AddElementToInternalStructures(deploymentNode);

                return deploymentNode;
            } else {
                throw new ArgumentException("A deployment node named '" + name + "' already exists.");
            }
        }
        
        /// <summary>
        /// Gets the DeploymentNode with the specified name.
        /// </summary>
        /// <param name="name">the name of the deployment node</param>
        /// <returns>the DeploymentNode instance with the specified name (or null if it doesn't exist)</returns>
        public DeploymentNode GetDeploymentNodeWithName(string name)
        {
            return DeploymentNodes.FirstOrDefault(dn => dn.Name.Equals(name));
        }

        internal Relationship AddRelationship(Element source, Element destination, string description) {
            return AddRelationship(source, destination, description, null);
        }

        internal Relationship AddRelationship(Element source, Element destination, string description, string technology) {
            return AddRelationship(source, destination, description, technology, InteractionStyle.Synchronous);
        }

        internal Relationship AddRelationship(Element source, Element destination, string description, string technology, InteractionStyle interactionStyle) {
            if (destination == null)
            {
                throw new ArgumentException("The destination must be specified.");
            }
            
            Relationship relationship = new Relationship(source, destination, description, technology, interactionStyle);
            if (AddRelationship(relationship)) {
                return relationship;
            }
            
            return null;
        }

        private bool AddRelationship(Relationship relationship)
        {
            if (!relationship.Source.Has(relationship))
            {
                relationship.Id = _idGenerator.GenerateId(relationship);
                relationship.Source.AddRelationship(relationship);

                AddRelationshipToInternalStructures(relationship);
                return true;
            }

            return false;
        }

        private void AddRelationshipToInternalStructures(Relationship relationship)
        {
            _relationshipsById.Add(relationship.Id, relationship);
            _idGenerator.Found(relationship.Id);
        }

        /// <summary>
        /// Gets the SoftwareSystem instance with the specified name.
        /// </summary>
        /// <returns>A SoftwareSystem instance, or null if one doesn't exist.</returns>
        public SoftwareSystem GetSoftwareSystemWithName(string name)
        {
            foreach (SoftwareSystem softwareSystem in SoftwareSystems)
            {
                if (softwareSystem.Name == name)
                {
                    return softwareSystem;
                }
            }

            return null;
        }

        public SoftwareSystem GetSoftwareSystemWithId(string id)
        {
            foreach (SoftwareSystem softwareSystem in SoftwareSystems)
            {
                if (softwareSystem.Id == id)
                {
                    return softwareSystem;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the Person instance with the specified name.
        /// </summary>
        /// <returns>A Person instance, or null if one doesn't exist.</returns>
        public Person GetPersonWithName(string name)
        {
            foreach (Person person in People)
            {
                if (person.Name == name)
                {
                    return person;
                }
            }

            return null;
        }

        private void AddElementToInternalStructures(Element element)
        {
            _elementsById.Add(element.Id, element);
            element.Model = this;
            _idGenerator.Found(element.Id);
        }

        public bool Contains(Element element)
        {
            return _elementsById.Values.Contains(element);
        }

        internal void Hydrate()
        {
            
            // add all of the elements to the model
            foreach (Person person in People)
            {
                AddElementToInternalStructures(person);
            }

            foreach (SoftwareSystem softwareSystem in SoftwareSystems)
            {
                AddElementToInternalStructures(softwareSystem);
                foreach (Container container in softwareSystem.Containers)
                {
                    softwareSystem.Add(container);
                    AddElementToInternalStructures(container);
                    container.Parent = softwareSystem;
                    foreach (Component component in container.Components)
                    {
                        container.Add(component);
                        AddElementToInternalStructures(component);
                        component.Parent = container;
                    }
                }
            }

            DeploymentNodes.ToList().ForEach(dn => HydrateDeploymentNode(dn, null));

            // now hydrate the relationships
            foreach (Person person in People)
            {
                HydrateRelationships(person);
            }

            foreach (SoftwareSystem softwareSystem in SoftwareSystems)
            {
                HydrateRelationships(softwareSystem);
                foreach (Container container in softwareSystem.Containers)
                {
                    HydrateRelationships(container);
                    foreach (Component component in container.Components)
                    {
                        HydrateRelationships(component);
                    }
                }
            }
            
            DeploymentNodes.ToList().ForEach(HydrateDeploymentNodeRelationships);
        }

        private void HydrateDeploymentNode(DeploymentNode deploymentNode, DeploymentNode parent)
        {
            deploymentNode.Parent = parent;
            AddElementToInternalStructures(deploymentNode);

            deploymentNode.Children.ToList().ForEach(child => HydrateDeploymentNode(child, deploymentNode));

            foreach (ContainerInstance containerInstance in deploymentNode.ContainerInstances)
            {
                containerInstance.Container = (Container)GetElement(containerInstance.ContainerId);
                AddElementToInternalStructures(containerInstance);
            }
        }
        
        private void HydrateDeploymentNodeRelationships(DeploymentNode deploymentNode)
        {
            HydrateRelationships(deploymentNode);
            deploymentNode.Children.ToList().ForEach(HydrateDeploymentNodeRelationships);
            deploymentNode.ContainerInstances.ToList().ForEach(HydrateRelationships);
        }

        private void HydrateRelationships(Element element)
        {
            foreach (Relationship relationship in element.Relationships)
            {
                relationship.Source = GetElement(relationship.SourceId);
                relationship.Destination = GetElement(relationship.DestinationId);
                AddRelationshipToInternalStructures(relationship);
            }
        }

        public Element GetElement(string id)
        {
            return _elementsById[id];
        }

        public IEnumerable<Element> GetElements()
        {
            return _elementsById.Values;
        }

        public Relationship GetRelationship(string id)
        {
            return _relationshipsById[id];
        }
        
        /// <summary>
        /// Propagates all relationships from children to their parents. For example, if you have two components (AAA and BBB)
        /// in different software systems that have a relationship, calling this method will add the following
        /// additional implied relationships to the model: AAA-&gt;BB AAA--&gt;B AA-&gt;BBB AA-&gt;BB AA-&gt;B A-&gt;BBB A-&gt;BB A-&gt;B.
        /// </summary>
        /// <returns>a set of all implicit relationships</returns>
        public ISet<Relationship> AddImplicitRelationships()
        {
            ISet<Relationship> implicitRelationships = new HashSet<Relationship>();

            string descriptionKey = "D";
            string technologyKey = "T";
            
            // source element -> destination element -> D/T -> possible values
            Dictionary<Element, Dictionary<Element, Dictionary<string, HashSet<string>>>> candidateRelationships = new Dictionary<Element, Dictionary<Element, Dictionary<string, HashSet<string>>>>();
    
            foreach (Relationship relationship in Relationships)
            {
                Element source = relationship.Source;
                Element destination = relationship.Destination;
    
                while (source != null)
                {
                    while (destination != null)
                    {
                        if (!source.HasEfferentRelationshipWith(destination))
                        {
                            if (propagatedRelationshipIsAllowed(source, destination))
                            {
    
                                if (!candidateRelationships.ContainsKey(source)) 
                                {
                                    candidateRelationships.Add(source, new Dictionary<Element, Dictionary<string, HashSet<string>>>());
                                }
    
                                if (!candidateRelationships[source].ContainsKey(destination))
                                {
                                    candidateRelationships[source].Add(destination, new Dictionary<string, HashSet<string>>());
                                    candidateRelationships[source][destination].Add(descriptionKey, new HashSet<string>());
                                    candidateRelationships[source][destination].Add(technologyKey, new HashSet<string>());
                                }
    
                                if (relationship.Description != null)
                                {
                                    candidateRelationships[source][destination][descriptionKey].Add(relationship.Description);
                                }
    
                                if (relationship.Technology != null)
                                {
                                    candidateRelationships[source][destination][technologyKey].Add(relationship.Technology);
                                }
                            }
                        }
    
                        destination = destination.Parent;
                    }
    
                    destination = relationship.Destination;
                    source = source.Parent;
                }
            }
    
            foreach (Element source in candidateRelationships.Keys)
            {
                foreach (Element destination in candidateRelationships[source].Keys)
                {
                    ISet<string> possibleDescriptions = candidateRelationships[source][destination][descriptionKey];
                    ISet<string> possibleTechnologies = candidateRelationships[source][destination][technologyKey];
    
                    string description = "";
                    if (possibleDescriptions.Count == 1)
                    {
                        description = possibleDescriptions.First();
                    }
    
                    string technology = "";
                    if (possibleTechnologies.Count == 1)
                    {
                        technology = possibleTechnologies.First();
                    }
    
                    Relationship implicitRelationship = AddRelationship(source, destination, description, technology);
                    if (implicitRelationship != null)
                    {
                        implicitRelationships.Add(implicitRelationship);
                    }
                }
            }
    
            return implicitRelationships;
        }

        private bool propagatedRelationshipIsAllowed(Element source, Element destination)
        {
            if (source.Equals(destination))
            {
                return false;
            }
    
            if (source.Parent != null) {
                if (destination.Equals(source.Parent))
                {
                    return false;
                }
    
                if (source.Parent.Parent != null)
                {
                    if (destination.Equals(source.Parent.Parent))
                    {
                        return false;
                    }
                }
            }
    
            if (destination.Parent != null)
            {
                if (source.Equals(destination.Parent))
                {
                    return false;
                }
    
                if (destination.Parent.Parent != null)
                {
                    if (source.Equals(destination.Parent.Parent))
                    {
                        return false;
                    }
                }
            }
    
            return true;
        }

    }

}
