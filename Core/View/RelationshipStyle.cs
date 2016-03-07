using System.Runtime.Serialization;

namespace Structurizr.View
{

    /// <summary>
    /// A definition of a relationship style.
    /// </summary>
    [DataContract]
    public class RelationshipStyle
    {
        
        /// <summary>
        /// The tag to which this relationship style applies.
        /// </summary>
        [DataMember(Name="tag", EmitDefaultValue=false)]
        public string Tag { get; set; }
  
        
        /// <summary>
        /// The thickness of the line, in pixels.
        /// </summary>
        [DataMember(Name="thickness", EmitDefaultValue=false)]
        public int? Thickness { get; set; }
  
        
        /// <summary>
        /// The colour of the line, as a HTML RGB hex string (e.g. #123456)
        /// </summary>
        [DataMember(Name="color", EmitDefaultValue=false)]
        public string Color { get; set; }
  
        
        /// <summary>
        /// The standard font size used to render the relationship annotation, in pixels.
        /// </summary>
        [DataMember(Name="fontSize", EmitDefaultValue=false)]
        public int? FontSize { get; set; }
  
        
        /// <summary>
        /// The width of the relationship annotation, in pixels.
        /// </summary>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public int? Width { get; set; }
  
        
        /// <summary>
        /// A flag to indicate whether the line is rendered as dashed or not.
        /// </summary>
        /// <value>A flag to indicate whether the line is rendered as dashed or not.</value>
        [DataMember(Name="dashed", EmitDefaultValue=false)]
        public bool? Dashed { get; set; }
  
        
        /// <summary>
        /// A flag to indicate whether the line is rendered as smooth (curved) or not.
        /// </summary>
        [DataMember(Name="smooth", EmitDefaultValue=false)]
        public bool? Smooth { get; set; }
  
        
        /// <summary>
        /// The position of the annotation along the line; 0 (start) to 100 (end).
        /// </summary>
        [DataMember(Name="position", EmitDefaultValue=false)]
        public int? Position { get; set; }

        public RelationshipStyle(string tag)
        {
            this.Tag = tag;
        }  
        
    }
}
