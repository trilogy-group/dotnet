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
    /// An instance of a model element (Person, Software System, Container or Component) in a View.
    /// </summary>
    [DataContract]
    public partial class ElementInView :  IEquatable<ElementInView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementInView" />class.
        /// </summary>
        /// <param name="Id">The ID of the element..</param>
        /// <param name="X">The horizontal position of the element when rendered..</param>
        /// <param name="Y">The vertical position of the element when rendered..</param>

        public ElementInView(string Id = null, double? X = null, double? Y = null)
        {
            this.Id = Id;
            this.X = X;
            this.Y = Y;
            
        }

        
        /// <summary>
        /// The ID of the element.
        /// </summary>
        /// <value>The ID of the element.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
  
        
        /// <summary>
        /// The horizontal position of the element when rendered.
        /// </summary>
        /// <value>The horizontal position of the element when rendered.</value>
        [DataMember(Name="x", EmitDefaultValue=false)]
        public double? X { get; set; }
  
        
        /// <summary>
        /// The vertical position of the element when rendered.
        /// </summary>
        /// <value>The vertical position of the element when rendered.</value>
        [DataMember(Name="y", EmitDefaultValue=false)]
        public double? Y { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ElementInView {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  X: ").Append(X).Append("\n");
            sb.Append("  Y: ").Append(Y).Append("\n");
            
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
            return this.Equals(obj as ElementInView);
        }

        /// <summary>
        /// Returns true if ElementInView instances are equal
        /// </summary>
        /// <param name="other">Instance of ElementInView to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ElementInView other)
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
                    this.X == other.X ||
                    this.X != null &&
                    this.X.Equals(other.X)
                ) && 
                (
                    this.Y == other.Y ||
                    this.Y != null &&
                    this.Y.Equals(other.Y)
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
                
                if (this.X != null)
                    hash = hash * 59 + this.X.GetHashCode();
                
                if (this.Y != null)
                    hash = hash * 59 + this.Y.GetHashCode();
                
                return hash;
            }
        }

    }
}
