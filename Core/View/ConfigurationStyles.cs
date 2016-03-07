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
    /// The styles associated with this set of views.
    /// </summary>
    [DataContract]
    public partial class ConfigurationStyles :  IEquatable<ConfigurationStyles>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStyles" />class.
        /// </summary>
        /// <param name="Relationships">The set of relationship styles..</param>
        /// <param name="Metadata">The placement of the diagram metadata..</param>
        /// <param name="Elements">The set of element styles..</param>

        public ConfigurationStyles(List<RelationshipStyle> Relationships = null, string Metadata = null, List<ElementStyle> Elements = null)
        {
            this.Relationships = Relationships;
            this.Metadata = Metadata;
            this.Elements = Elements;
            
        }

        
        /// <summary>
        /// The set of relationship styles.
        /// </summary>
        /// <value>The set of relationship styles.</value>
        [DataMember(Name="relationships", EmitDefaultValue=false)]
        public List<RelationshipStyle> Relationships { get; set; }
  
        
        /// <summary>
        /// The placement of the diagram metadata.
        /// </summary>
        /// <value>The placement of the diagram metadata.</value>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public string Metadata { get; set; }
  
        
        /// <summary>
        /// The set of element styles.
        /// </summary>
        /// <value>The set of element styles.</value>
        [DataMember(Name="elements", EmitDefaultValue=false)]
        public List<ElementStyle> Elements { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConfigurationStyles {\n");
            sb.Append("  Relationships: ").Append(Relationships).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Elements: ").Append(Elements).Append("\n");
            
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
            return this.Equals(obj as ConfigurationStyles);
        }

        /// <summary>
        /// Returns true if ConfigurationStyles instances are equal
        /// </summary>
        /// <param name="other">Instance of ConfigurationStyles to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConfigurationStyles other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Relationships == other.Relationships ||
                    this.Relationships != null &&
                    this.Relationships.SequenceEqual(other.Relationships)
                ) && 
                (
                    this.Metadata == other.Metadata ||
                    this.Metadata != null &&
                    this.Metadata.Equals(other.Metadata)
                ) && 
                (
                    this.Elements == other.Elements ||
                    this.Elements != null &&
                    this.Elements.SequenceEqual(other.Elements)
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
                
                if (this.Relationships != null)
                    hash = hash * 59 + this.Relationships.GetHashCode();
                
                if (this.Metadata != null)
                    hash = hash * 59 + this.Metadata.GetHashCode();
                
                if (this.Elements != null)
                    hash = hash * 59 + this.Elements.GetHashCode();
                
                return hash;
            }
        }

    }
}
