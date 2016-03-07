using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Structurizr.View
{

    /// <summary>
    /// An instance of a model relationship in a View.
    /// </summary>
    [DataContract]
    public partial class RelationshipInView :  IEquatable<RelationshipInView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipInView" />class.
        /// </summary>
        /// <param name="Id">The ID of the relationship..</param>
        /// <param name="Order">The order of this relationship (used in dynamic views only; e.g. 1.0, 1.1, 2.0, etc)..</param>
        /// <param name="Description">The description of this relationship (used in dynamic views only)..</param>
        /// <param name="Vertices">The set of vertices used to render the relationship..</param>

        public RelationshipInView(string Id = null, string Order = null, string Description = null, List<Vertex> Vertices = null)
        {
            this.Id = Id;
            this.Order = Order;
            this.Description = Description;
            this.Vertices = Vertices;
            
        }

        
        /// <summary>
        /// The ID of the relationship.
        /// </summary>
        /// <value>The ID of the relationship.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
  
        
        /// <summary>
        /// The order of this relationship (used in dynamic views only; e.g. 1.0, 1.1, 2.0, etc).
        /// </summary>
        /// <value>The order of this relationship (used in dynamic views only; e.g. 1.0, 1.1, 2.0, etc).</value>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public string Order { get; set; }
  
        
        /// <summary>
        /// The description of this relationship (used in dynamic views only).
        /// </summary>
        /// <value>The description of this relationship (used in dynamic views only).</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
  
        
        /// <summary>
        /// The set of vertices used to render the relationship.
        /// </summary>
        /// <value>The set of vertices used to render the relationship.</value>
        [DataMember(Name="vertices", EmitDefaultValue=false)]
        public List<Vertex> Vertices { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RelationshipInView {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Vertices: ").Append(Vertices).Append("\n");
            
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
            return this.Equals(obj as RelationshipInView);
        }

        /// <summary>
        /// Returns true if RelationshipInView instances are equal
        /// </summary>
        /// <param name="other">Instance of RelationshipInView to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RelationshipInView other)
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
                    this.Order == other.Order ||
                    this.Order != null &&
                    this.Order.Equals(other.Order)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Vertices == other.Vertices ||
                    this.Vertices != null &&
                    this.Vertices.SequenceEqual(other.Vertices)
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
                
                if (this.Order != null)
                    hash = hash * 59 + this.Order.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.Vertices != null)
                    hash = hash * 59 + this.Vertices.GetHashCode();
                
                return hash;
            }
        }

    }
}
