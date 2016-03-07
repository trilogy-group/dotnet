using Structurizr.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Structurizr.View
{

    [DataContract]
    public abstract class View
    {

        /// <summary>
        /// An identifier for this view.
        /// </summary>
        /// <value>An identifier for this view.</value>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        public SoftwareSystem SoftwareSystem { get; set; }

        private string softwareSystemId;

        /// <summary>
        /// The ID of the software system this view is associated with.
        /// </summary>
        /// <value>The ID of the software system this view is associated with.</value>
        [DataMember(Name = "softwareSystemId", EmitDefaultValue = false)]
        public string SoftwareSystemId {
            get
            {
                if (this.SoftwareSystem != null)
                {
                    return this.SoftwareSystem.Id;
                } else
                {
                    return this.softwareSystemId;
                }
            }
            set
            {
                this.softwareSystemId = value;
            }
        }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        public Model.Model Model
        {
            get
            {
                return this.SoftwareSystem.Model;
            }
        }

        /// <summary>
        /// The paper size that should be used to render this view.
        /// </summary>
        /// <value>The paper size that should be used to render this view.</value>
        [DataMember(Name = "paperSize", EmitDefaultValue = false)]
        public string PaperSize { get; set; }


        /// <summary>
        /// The set of elements in this views.
        /// </summary>
        /// <value>The set of elements in this views.</value>
        [DataMember(Name = "elements", EmitDefaultValue = false)]
        public HashSet<ElementView> Elements { get; set; }


        /// <summary>
        /// The set of relationships in this views.
        /// </summary>
        /// <value>The set of relationships in this views.</value>
        [DataMember(Name = "relationships", EmitDefaultValue = false)]
        public HashSet<RelationshipView> Relationships { get; set; }

        internal View(SoftwareSystem softwareSystem, string description)
        {
            this.SoftwareSystem = softwareSystem;
            this.Description = description;

            this.Elements = new HashSet<ElementView>();
            this.Relationships = new HashSet<RelationshipView>();
        }

        internal void AddElement(Element element, bool addRelationships)
        {
            if (element != null)
            {
                if (SoftwareSystem.Model.Contains(element))
                {
                    Elements.Add(new ElementView(element));

                    if (addRelationships)
                    {
                        AddRelationships(element);
                    }
                }
            }
        }

        private void AddRelationships(Element element)
        {
            List<Element> elements = new List<Element>();
            foreach (ElementView elementView in this.Elements)
            {
                elements.Add(elementView.Element);
            }

            // add relationships where the destination exists in the view already
            foreach (Relationship relationship in element.Relationships)
            {
                if (elements.Contains(relationship.Destination))
                {
                    this.Relationships.Add(new RelationshipView(relationship));
                }
            }

            // add relationships where the source exists in the view already
            foreach (Element e in elements)
            {
                foreach (Relationship relationship in e.Relationships)
                {
                    if (relationship.Destination.Equals(element))
                    {
                        this.Relationships.Add(new RelationshipView(relationship));
                    }
                }
            }
        }


    }
}
