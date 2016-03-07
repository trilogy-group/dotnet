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
    /// The X, Y coordinate of a bend in a line.
    /// </summary>
    [DataContract]
    public partial class Vertex :  IEquatable<Vertex>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex" />class.
        /// </summary>
        /// <param name="X">The horizontal position of the vertex when rendered..</param>
        /// <param name="Y">The vertical position of the vertex when rendered..</param>

        public Vertex(double? X = null, double? Y = null)
        {
            this.X = X;
            this.Y = Y;
            
        }

        
        /// <summary>
        /// The horizontal position of the vertex when rendered.
        /// </summary>
        /// <value>The horizontal position of the vertex when rendered.</value>
        [DataMember(Name="x", EmitDefaultValue=false)]
        public double? X { get; set; }
  
        
        /// <summary>
        /// The vertical position of the vertex when rendered.
        /// </summary>
        /// <value>The vertical position of the vertex when rendered.</value>
        [DataMember(Name="y", EmitDefaultValue=false)]
        public double? Y { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Vertex {\n");
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
            return this.Equals(obj as Vertex);
        }

        /// <summary>
        /// Returns true if Vertex instances are equal
        /// </summary>
        /// <param name="other">Instance of Vertex to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Vertex other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
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
                
                if (this.X != null)
                    hash = hash * 59 + this.X.GetHashCode();
                
                if (this.Y != null)
                    hash = hash * 59 + this.Y.GetHashCode();
                
                return hash;
            }
        }

    }
}
