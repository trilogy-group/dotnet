using System.Runtime.Serialization;

namespace Structurizr.Documentation
{

    [DataContract]
    public sealed class Section
    {

        public Element Element { get; internal set; }

        private string elementId;

        /// <summary>
        /// The ID of the element.
        /// </summary>
        [DataMember(Name = "elementId", EmitDefaultValue = false)]
        public string ElementId
        {
            get
            {
                if (this.Element != null)
                {
                    return this.Element.Id;
                }
                else
                {
                    return this.elementId;
                }
            }

            set
            {
                this.elementId = value;
            }
        }

        [DataMember(Name = "type", EmitDefaultValue = true)]
        public string SectionType { get; internal set; }

        [DataMember(Name = "order", EmitDefaultValue = true)]
        public int Order { get; internal set; }
        
        [DataMember(Name = "format", EmitDefaultValue = true)]
        public Format Format { get; internal set; }

        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content { get; internal set; }

        internal Section() { }

        internal Section(Element element, string type, int order, Format format, string content) {
            Element = element;
            SectionType = type;
            Order = order;
            Format = format;
            Content = content;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Section);
        }

        public bool Equals(Section section)
        {
            if (section == this)
            {
                return true;
            }

            if (section == null)
            {
                return false;
            }
            
            if (ElementId != null)
            {
                return ElementId.Equals(section.ElementId) && SectionType == section.SectionType;
            }
            else
            {
                return SectionType == section.SectionType;
            }
        }

        public override int GetHashCode()
        {
            int result = ElementId != null ? ElementId.GetHashCode() : 0;
            result = 31 * result + SectionType.GetHashCode();
            return result;
        }

    }
}