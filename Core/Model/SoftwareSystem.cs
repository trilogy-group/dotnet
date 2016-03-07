using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Structurizr.Model
{

    /// <summary>
    /// A software system.
    /// </summary>
    [DataContract]
    public class SoftwareSystem : Element, IEquatable<SoftwareSystem>
    {

        /// <summary>
        /// The location of this software system.
        /// </summary>
        /// <value>The location of this software system.</value>
        [DataMember(Name="location", EmitDefaultValue=false)]
        public Location Location { get; set; }
  
        
        /// <summary>
        /// The set of containers within this software system.
        /// </summary>
        /// <value>The set of containers within this software system.</value>
        [DataMember(Name="containers", EmitDefaultValue=false)]
        public List<Container> Containers { get; set; }
  
        public override string CanonicalName
        {
            get
            {
                return CanonicalNameSeparator + FormatForCanonicalName(Name);
            }
        }

        /// <summary>
        /// Adds a unidirectional relationship between this software system and a person.
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
        /// Adds a unidirectional relationship between this software system and a person.
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
        /// Adds a unidirectional relationship between this software system and a person.
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

        public override List<string> getRequiredTags()
        {
            string[] tags = {
                Structurizr.Model.Tags.Element,
                Structurizr.Model.Tags.SoftwareSystem
            };
            return tags.ToList();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public bool Equals(SoftwareSystem softwareSystem)
        {
            return this.Equals(softwareSystem as Element);
        }

    }
}
