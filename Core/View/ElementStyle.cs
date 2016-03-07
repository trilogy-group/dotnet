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
    /// A definition of an element style.
    /// </summary>
    [DataContract]
    public partial class ElementStyle :  IEquatable<ElementStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementStyle" />class.
        /// </summary>
        /// <param name="Tag">The tag to which this element style applies..</param>
        /// <param name="Width">The width of the element, in pixels..</param>
        /// <param name="Height">The height of the element, in pixels..</param>
        /// <param name="Background">The background colour of the element, as a HTML RGB hex string (e.g..</param>
        /// <param name="Color">The foreground (text) colour of the element, as a HTML RGB hex string (e.g..</param>
        /// <param name="FontSize">The standard font size used to render text, in pixels..</param>
        /// <param name="Shape">The shape used to render the element..</param>

        public ElementStyle(string Tag = null, double? Width = null, double? Height = null, string Background = null, string Color = null, double? FontSize = null, string Shape = null)
        {
            this.Tag = Tag;
            this.Width = Width;
            this.Height = Height;
            this.Background = Background;
            this.Color = Color;
            this.FontSize = FontSize;
            this.Shape = Shape;
            
        }

        
        /// <summary>
        /// The tag to which this element style applies.
        /// </summary>
        /// <value>The tag to which this element style applies.</value>
        [DataMember(Name="tag", EmitDefaultValue=false)]
        public string Tag { get; set; }
  
        
        /// <summary>
        /// The width of the element, in pixels.
        /// </summary>
        /// <value>The width of the element, in pixels.</value>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public double? Width { get; set; }
  
        
        /// <summary>
        /// The height of the element, in pixels.
        /// </summary>
        /// <value>The height of the element, in pixels.</value>
        [DataMember(Name="height", EmitDefaultValue=false)]
        public double? Height { get; set; }
  
        
        /// <summary>
        /// The background colour of the element, as a HTML RGB hex string (e.g.
        /// </summary>
        /// <value>The background colour of the element, as a HTML RGB hex string (e.g.</value>
        [DataMember(Name="background", EmitDefaultValue=false)]
        public string Background { get; set; }
  
        
        /// <summary>
        /// The foreground (text) colour of the element, as a HTML RGB hex string (e.g.
        /// </summary>
        /// <value>The foreground (text) colour of the element, as a HTML RGB hex string (e.g.</value>
        [DataMember(Name="color", EmitDefaultValue=false)]
        public string Color { get; set; }
  
        
        /// <summary>
        /// The standard font size used to render text, in pixels.
        /// </summary>
        /// <value>The standard font size used to render text, in pixels.</value>
        [DataMember(Name="fontSize", EmitDefaultValue=false)]
        public double? FontSize { get; set; }
  
        
        /// <summary>
        /// The shape used to render the element.
        /// </summary>
        /// <value>The shape used to render the element.</value>
        [DataMember(Name="shape", EmitDefaultValue=false)]
        public string Shape { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ElementStyle {\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Background: ").Append(Background).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  FontSize: ").Append(FontSize).Append("\n");
            sb.Append("  Shape: ").Append(Shape).Append("\n");
            
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
            return this.Equals(obj as ElementStyle);
        }

        /// <summary>
        /// Returns true if ElementStyle instances are equal
        /// </summary>
        /// <param name="other">Instance of ElementStyle to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ElementStyle other)
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
                    this.Width == other.Width ||
                    this.Width != null &&
                    this.Width.Equals(other.Width)
                ) && 
                (
                    this.Height == other.Height ||
                    this.Height != null &&
                    this.Height.Equals(other.Height)
                ) && 
                (
                    this.Background == other.Background ||
                    this.Background != null &&
                    this.Background.Equals(other.Background)
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
                    this.Shape == other.Shape ||
                    this.Shape != null &&
                    this.Shape.Equals(other.Shape)
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
                
                if (this.Width != null)
                    hash = hash * 59 + this.Width.GetHashCode();
                
                if (this.Height != null)
                    hash = hash * 59 + this.Height.GetHashCode();
                
                if (this.Background != null)
                    hash = hash * 59 + this.Background.GetHashCode();
                
                if (this.Color != null)
                    hash = hash * 59 + this.Color.GetHashCode();
                
                if (this.FontSize != null)
                    hash = hash * 59 + this.FontSize.GetHashCode();
                
                if (this.Shape != null)
                    hash = hash * 59 + this.Shape.GetHashCode();
                
                return hash;
            }
        }

    }
}
