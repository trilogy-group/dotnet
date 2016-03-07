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
    /// A system context view.
    /// </summary>
    [DataContract]
    public partial class SystemContextView :  IEquatable<SystemContextView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemContextView" />class.
        /// </summary>
        /// <param name="Key">An identifier for this view..</param>
        /// <param name="SoftwareSystemId">The ID of the software system this view is associated with..</param>
        /// <param name="PaperSize">The paper size that should be used to render this view..</param>
        /// <param name="Elements">The set of elements in this views..</param>
        /// <param name="Relationships">The set of relationships in this views..</param>

        public SystemContextView(string Key = null, string SoftwareSystemId = null, string PaperSize = null, List<ElementInView> Elements = null, List<RelationshipInView> Relationships = null)
        {
            this.Key = Key;
            this.SoftwareSystemId = SoftwareSystemId;
            this.PaperSize = PaperSize;
            this.Elements = Elements;
            this.Relationships = Relationships;
            
        }

        
        /// <summary>
        /// An identifier for this view.
        /// </summary>
        /// <value>An identifier for this view.</value>
        [DataMember(Name="key", EmitDefaultValue=false)]
        public string Key { get; set; }
  
        
        /// <summary>
        /// The ID of the software system this view is associated with.
        /// </summary>
        /// <value>The ID of the software system this view is associated with.</value>
        [DataMember(Name="softwareSystemId", EmitDefaultValue=false)]
        public string SoftwareSystemId { get; set; }
  
        
        /// <summary>
        /// The paper size that should be used to render this view.
        /// </summary>
        /// <value>The paper size that should be used to render this view.</value>
        [DataMember(Name="paperSize", EmitDefaultValue=false)]
        public string PaperSize { get; set; }
  
        
        /// <summary>
        /// The set of elements in this views.
        /// </summary>
        /// <value>The set of elements in this views.</value>
        [DataMember(Name="elements", EmitDefaultValue=false)]
        public List<ElementInView> Elements { get; set; }
  
        
        /// <summary>
        /// The set of relationships in this views.
        /// </summary>
        /// <value>The set of relationships in this views.</value>
        [DataMember(Name="relationships", EmitDefaultValue=false)]
        public List<RelationshipInView> Relationships { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SystemContextView {\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  SoftwareSystemId: ").Append(SoftwareSystemId).Append("\n");
            sb.Append("  PaperSize: ").Append(PaperSize).Append("\n");
            sb.Append("  Elements: ").Append(Elements).Append("\n");
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
            return this.Equals(obj as SystemContextView);
        }

        /// <summary>
        /// Returns true if SystemContextView instances are equal
        /// </summary>
        /// <param name="other">Instance of SystemContextView to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SystemContextView other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Key == other.Key ||
                    this.Key != null &&
                    this.Key.Equals(other.Key)
                ) && 
                (
                    this.SoftwareSystemId == other.SoftwareSystemId ||
                    this.SoftwareSystemId != null &&
                    this.SoftwareSystemId.Equals(other.SoftwareSystemId)
                ) && 
                (
                    this.PaperSize == other.PaperSize ||
                    this.PaperSize != null &&
                    this.PaperSize.Equals(other.PaperSize)
                ) && 
                (
                    this.Elements == other.Elements ||
                    this.Elements != null &&
                    this.Elements.SequenceEqual(other.Elements)
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
                
                if (this.Key != null)
                    hash = hash * 59 + this.Key.GetHashCode();
                
                if (this.SoftwareSystemId != null)
                    hash = hash * 59 + this.SoftwareSystemId.GetHashCode();
                
                if (this.PaperSize != null)
                    hash = hash * 59 + this.PaperSize.GetHashCode();
                
                if (this.Elements != null)
                    hash = hash * 59 + this.Elements.GetHashCode();
                
                if (this.Relationships != null)
                    hash = hash * 59 + this.Relationships.GetHashCode();
                
                return hash;
            }
        }

    }
}
