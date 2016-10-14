using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Structurizr
{

    [DataContract]
    public abstract class Element : Taggable
    {

        public const string CanonicalNameSeparator = "/";

        /// <summary>
        /// The ID of this element in the model.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }


        /// <summary>
        /// The name of this element.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }


        /// <summary>
        /// A short description of this element.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        public Model Model { get; set; }

        [DataMember(Name = "relationships", EmitDefaultValue = false)]
        public HashSet<Relationship> Relationships { get; set; }

        public abstract string CanonicalName { get; }

        public abstract Element Parent { get; set; }

        internal Element()
        {
            this.Relationships = new HashSet<Relationship>();
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and another.
        /// </summary>
        /// <param name="destination"> the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        public Relationship Uses(SoftwareSystem destination, string description)
        {
            Relationship relationship = new Relationship(this, destination, description);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and another.
        /// </summary>
        /// <param name="destination"> the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        public Relationship Uses(SoftwareSystem destination, string description, string technology)
        {
            Relationship relationship = new Relationship(this, destination, description, technology);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and another.
        /// </summary>
        /// <param name="destination"> the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        /// <param name="interactionStyle">the interaction style (sync vs async)</param>
        public Relationship Uses(SoftwareSystem destination, string description, string technology, InteractionStyle interactionStyle)
        {
            Relationship relationship = new Relationship(this, destination, description, technology, interactionStyle);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and a container.
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        public Relationship Uses(Container destination, string description)
        {
            Relationship relationship = new Relationship(this, destination, description);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and a container.
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        public Relationship Uses(Container destination, string description, string technology)
        {
            Relationship relationship = new Relationship(this, destination, description, technology);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and a container.
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        public Relationship Uses(Container destination, string description, string technology, InteractionStyle interactionStyle)
        {
            Relationship relationship = new Relationship(this, destination, description, technology, interactionStyle);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and a component (within a container).
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        public Relationship Uses(Component destination, string description)
        {
            Relationship relationship = new Relationship(this, destination, description);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and a component (within a container).
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        public Relationship Uses(Component destination, string description, string technology)
        {
            Relationship relationship = new Relationship(this, destination, description, technology);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional "uses" style relationship between this element and a component (within a container).
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "uses", "gets data from", "sends data to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        /// <param name="interactionStyle">the interaction style (sync vs async)</param>
        public Relationship Uses(Component destination, string description, string technology, InteractionStyle interactionStyle)
        {
            Relationship relationship = new Relationship(this, destination, description, technology, interactionStyle);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional relationship between this element and a person.
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "sends e-mail to")</param>
        public Relationship Delivers(Person destination, string description)
        {
            Relationship relationship = new Relationship(this, destination, description);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional relationship between this element and a person.
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "sends e-mail to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        public Relationship Delivers(Person destination, string description, string technology)
        {
            Relationship relationship = new Relationship(this, destination, description, technology);
            Model.AddRelationship(relationship);

            return relationship;
        }

        /// <summary>
        /// Adds a unidirectional relationship between this element and a person.
        /// </summary>
        /// <param name="destination">the target of the relationship</param>
        /// <param name="description">a description of the relationship (e.g. "sends e-mail to")</param>
        /// <param name="technology">the technology details (e.g. JSON/HTTPS)</param>
        /// <param name="interactionStyle">the interaction style (sync vs async)</param>
        public Relationship Delivers(Person destination, string description, string technology, InteractionStyle interactionStyle)
        {
            Relationship relationship = new Relationship(this, destination, description, technology, interactionStyle);
            Model.AddRelationship(relationship);

            return relationship;
        }


        internal void AddRelationship(Relationship relationship)
        {
            this.Relationships.Add(relationship);
        }

        public bool Has(Relationship relationship)
        {
            return Relationships.Contains(relationship);
        }

        public bool HasAfferentRelationships()
        {
            return Model.Relationships.Where(r => r.Destination == this).Count() > 0;
        }

        public bool hasEfferentRelationshipWith(Element element)
        {
            return GetEfferentRelationshipWith(element) != null;
        }

        public Relationship GetEfferentRelationshipWith(Element element)
        {
            if (element == null)
            {
                return null;
            }

            foreach (Relationship relationship in Relationships)
            {
                if (relationship.Destination.Equals(element))
                {
                    return relationship;
                }
            }

            return null;
        }



        protected string FormatForCanonicalName(String name)
        {
            return name.Replace(CanonicalNameSeparator, "");
        }

        public override string ToString()
        {
            return "{" + Id + " | " + Name + " | " + Description + "}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Element);
        }

        public bool Equals(Element element)
        {
            if (element == null)
            {
                return false;
            }
            if (element == this)
            {
                return true;
            }

            return CanonicalName.Equals(element.CanonicalName);
        }

    }
}
