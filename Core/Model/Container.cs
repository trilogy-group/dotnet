using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Structurizr.Model
{

    /// <summary>
    /// A container (something that can execute code or host data).
    /// </summary>
    [DataContract]
    public partial class Container :  IEquatable<Container>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Container" />class.
        /// </summary>
        /// <param name="Id">The ID of this container in the model..</param>
        /// <param name="Name">The name of this container..</param>
        /// <param name="Description">A short description of this container..</param>
        /// <param name="Technology">The technology associated with this container (e.g. Apache Tomcat)..</param>
        /// <param name="Tags">A comma separated list of tags associated with this container..</param>
        /// <param name="Components">The set of components within this container..</param>
        /// <param name="Relationships">The set of relationships between this container and other elements..</param>

        public Container(string Id = null, string Name = null, string Description = null, string Technology = null, string Tags = null, List<Component> Components = null, List<Relationship> Relationships = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Technology = Technology;
            this.Tags = Tags;
            this.Components = Components;
            this.Relationships = Relationships;
            
        }

        
        /// <summary>
        /// The ID of this container in the model.
        /// </summary>
        /// <value>The ID of this container in the model.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
  
        
        /// <summary>
        /// The name of this container.
        /// </summary>
        /// <value>The name of this container.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
  
        
        /// <summary>
        /// A short description of this container.
        /// </summary>
        /// <value>A short description of this container.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
  
        
        /// <summary>
        /// The technology associated with this container (e.g. Apache Tomcat).
        /// </summary>
        /// <value>The technology associated with this container (e.g. Apache Tomcat).</value>
        [DataMember(Name="technology", EmitDefaultValue=false)]
        public string Technology { get; set; }
  
        
        /// <summary>
        /// A comma separated list of tags associated with this container.
        /// </summary>
        /// <value>A comma separated list of tags associated with this container.</value>
        [DataMember(Name="tags", EmitDefaultValue=false)]
        public string Tags { get; set; }
  
        
        /// <summary>
        /// The set of components within this container.
        /// </summary>
        /// <value>The set of components within this container.</value>
        [DataMember(Name="components", EmitDefaultValue=false)]
        public List<Component> Components { get; set; }
  
        
        /// <summary>
        /// The set of relationships between this container and other elements.
        /// </summary>
        /// <value>The set of relationships between this container and other elements.</value>
        [DataMember(Name="relationships", EmitDefaultValue=false)]
        public List<Relationship> Relationships { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Container {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Technology: ").Append(Technology).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Components: ").Append(Components).Append("\n");
            sb.Append("  Relationships: ").Append(Relationships).Append("\n");
            
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as Container);
        }

        /// <summary>
        /// Returns true if Container instances are equal
        /// </summary>
        /// <param name="other">Instance of Container to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Container other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Technology == other.Technology ||
                    this.Technology != null &&
                    this.Technology.Equals(other.Technology)
                ) && 
                (
                    this.Tags == other.Tags ||
                    this.Tags != null &&
                    this.Tags.Equals(other.Tags)
                ) && 
                (
                    this.Components == other.Components ||
                    this.Components != null &&
                    this.Components.SequenceEqual(other.Components)
                ) && 
                (
                    this.Relationships == other.Relationships ||
                    this.Relationships != null &&
                    this.Relationships.SequenceEqual(other.Relationships)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.Technology != null)
                    hash = hash * 59 + this.Technology.GetHashCode();
                
                if (this.Tags != null)
                    hash = hash * 59 + this.Tags.GetHashCode();
                
                if (this.Components != null)
                    hash = hash * 59 + this.Components.GetHashCode();
                
                if (this.Relationships != null)
                    hash = hash * 59 + this.Relationships.GetHashCode();
                
                return hash;
            }
        }

    }
}
