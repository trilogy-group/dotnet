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
    /// A definition of a relationship style.
    /// </summary>
    [DataContract]
    public partial class RelationshipStyle :  IEquatable<RelationshipStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipStyle" />class.
        /// </summary>
        /// <param name="Tag">The tag to which this relationship style applies..</param>
        /// <param name="Thickness">The thickness of the line, in pixels..</param>
        /// <param name="Color">The colour of the line, as a HTML RGB hex string (e.g..</param>
        /// <param name="FontSize">The standard font size used to render the relationship annotation, in pixels..</param>
        /// <param name="Width">The width of the relationship annotation, in pixels..</param>
        /// <param name="Dashed">A flag to indicate whether the line is rendered as dashed or not..</param>
        /// <param name="Smooth">A flag to indicate whether the line is rendered as smooth (curved) or not..</param>
        /// <param name="Position">The position of the annotation along the line; 0 (start) to 100 (end)..</param>

        public RelationshipStyle(string Tag = null, double? Thickness = null, string Color = null, double? FontSize = null, double? Width = null, bool? Dashed = null, bool? Smooth = null, double? Position = null)
        {
            this.Tag = Tag;
            this.Thickness = Thickness;
            this.Color = Color;
            this.FontSize = FontSize;
            this.Width = Width;
            this.Dashed = Dashed;
            this.Smooth = Smooth;
            this.Position = Position;
            
        }

        
        /// <summary>
        /// The tag to which this relationship style applies.
        /// </summary>
        /// <value>The tag to which this relationship style applies.</value>
        [DataMember(Name="tag", EmitDefaultValue=false)]
        public string Tag { get; set; }
  
        
        /// <summary>
        /// The thickness of the line, in pixels.
        /// </summary>
        /// <value>The thickness of the line, in pixels.</value>
        [DataMember(Name="thickness", EmitDefaultValue=false)]
        public double? Thickness { get; set; }
  
        
        /// <summary>
        /// The colour of the line, as a HTML RGB hex string (e.g.
        /// </summary>
        /// <value>The colour of the line, as a HTML RGB hex string (e.g.</value>
        [DataMember(Name="color", EmitDefaultValue=false)]
        public string Color { get; set; }
  
        
        /// <summary>
        /// The standard font size used to render the relationship annotation, in pixels.
        /// </summary>
        /// <value>The standard font size used to render the relationship annotation, in pixels.</value>
        [DataMember(Name="fontSize", EmitDefaultValue=false)]
        public double? FontSize { get; set; }
  
        
        /// <summary>
        /// The width of the relationship annotation, in pixels.
        /// </summary>
        /// <value>The width of the relationship annotation, in pixels.</value>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public double? Width { get; set; }
  
        
        /// <summary>
        /// A flag to indicate whether the line is rendered as dashed or not.
        /// </summary>
        /// <value>A flag to indicate whether the line is rendered as dashed or not.</value>
        [DataMember(Name="dashed", EmitDefaultValue=false)]
        public bool? Dashed { get; set; }
  
        
        /// <summary>
        /// A flag to indicate whether the line is rendered as smooth (curved) or not.
        /// </summary>
        /// <value>A flag to indicate whether the line is rendered as smooth (curved) or not.</value>
        [DataMember(Name="smooth", EmitDefaultValue=false)]
        public bool? Smooth { get; set; }
  
        
        /// <summary>
        /// The position of the annotation along the line; 0 (start) to 100 (end).
        /// </summary>
        /// <value>The position of the annotation along the line; 0 (start) to 100 (end).</value>
        [DataMember(Name="position", EmitDefaultValue=false)]
        public double? Position { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RelationshipStyle {\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  Thickness: ").Append(Thickness).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  FontSize: ").Append(FontSize).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Dashed: ").Append(Dashed).Append("\n");
            sb.Append("  Smooth: ").Append(Smooth).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            
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
            return this.Equals(obj as RelationshipStyle);
        }

        /// <summary>
        /// Returns true if RelationshipStyle instances are equal
        /// </summary>
        /// <param name="other">Instance of RelationshipStyle to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RelationshipStyle other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Tag == other.Tag ||
                    this.Tag != null &&
                    this.Tag.Equals(other.Tag)
                ) && 
                (
                    this.Thickness == other.Thickness ||
                    this.Thickness != null &&
                    this.Thickness.Equals(other.Thickness)
                ) && 
                (
                    this.Color == other.Color ||
                    this.Color != null &&
                    this.Color.Equals(other.Color)
                ) && 
                (
                    this.FontSize == other.FontSize ||
                    this.FontSize != null &&
                    this.FontSize.Equals(other.FontSize)
                ) && 
                (
                    this.Width == other.Width ||
                    this.Width != null &&
                    this.Width.Equals(other.Width)
                ) && 
                (
                    this.Dashed == other.Dashed ||
                    this.Dashed != null &&
                    this.Dashed.Equals(other.Dashed)
                ) && 
                (
                    this.Smooth == other.Smooth ||
                    this.Smooth != null &&
                    this.Smooth.Equals(other.Smooth)
                ) && 
                (
                    this.Position == other.Position ||
                    this.Position != null &&
                    this.Position.Equals(other.Position)
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
                
                if (this.Tag != null)
                    hash = hash * 59 + this.Tag.GetHashCode();
                
                if (this.Thickness != null)
                    hash = hash * 59 + this.Thickness.GetHashCode();
                
                if (this.Color != null)
                    hash = hash * 59 + this.Color.GetHashCode();
                
                if (this.FontSize != null)
                    hash = hash * 59 + this.FontSize.GetHashCode();
                
                if (this.Width != null)
                    hash = hash * 59 + this.Width.GetHashCode();
                
                if (this.Dashed != null)
                    hash = hash * 59 + this.Dashed.GetHashCode();
                
                if (this.Smooth != null)
                    hash = hash * 59 + this.Smooth.GetHashCode();
                
                if (this.Position != null)
                    hash = hash * 59 + this.Position.GetHashCode();
                
                return hash;
            }
        }

    }
}
