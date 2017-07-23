using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Structurizr.Util;
using Newtonsoft.Json;

namespace Structurizr.Documentation
{

    /// <summary>
    /// Represents the documentation within a workspace - a collection of
    /// content in Markdown or AsciiDoc format, optionally with attached images.
    ///
    /// See https://structurizr.com/help/documentation on the Structurizr website for more details.
    /// </summary>
    [DataContract]
    public sealed class Documentation
    {

        public Model Model { get; set; }

        [DataMember(Name = "sections", EmitDefaultValue = false)]
        public HashSet<Section> Sections { get; private set; }

        [DataMember(Name = "images", EmitDefaultValue = false)]
        public HashSet<Image> Images { get; private set; }

        [JsonConstructor]
        internal Documentation()
        {
            Sections = new HashSet<Section>();
            Images = new HashSet<Image>();
        }

        public Documentation(Model model) : this()
        {
            if (model == null)
            {
                throw new ArgumentException("A model must be specified.");
            }
            
            Model = model;
        }

        public void Hydrate()
        {
            foreach (Section section in Sections)
            {
                if (!String.IsNullOrEmpty(section.ElementId))
                {
                    section.Element = Model.GetElement(section.ElementId);
                }
            }

        }
            
        internal Section AddSection(Element element, string type, int group, Format format, string content)
        {
            if (group < 1)
            {
                group = 1;
            }
            else if (group > 5)
            {
                group = 5;
            }
    
            Section section = new Section(element, type, CalculateOrder(), group, format, content);
            if (!Sections.Contains(section))
            {
                Sections.Add(section);
                return section;
            }
            else
            {
                throw new ArgumentException("A section of type " + type +
                        (element != null ? " for " + element.Name : "")
                        + " already exists.");
            }
        }
    
        private int CalculateOrder()
        {
            return Sections.Count+1;
        }

        internal void Add(Image image)
        {
            Images.Add(image);
        }
        
        public bool IsEmpty() {
            return Sections.Count == 0 && Images.Count == 0;
        }

    }


}

