using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Structurizr
{

    /// <summary>
    /// An instance of a model relationship in a View.
    /// </summary>
    [DataContract]
    public sealed class RelationshipView : IEquatable<RelationshipView>
    {

        public Relationship Relationship { get; set; }

        private string id;

        /// <summary>
        /// The ID of the relationship.
        /// </summary>
        /// <value>The ID of the relationship.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
        {
            get
            {
                if (this.Relationship != null)
                {
                    return this.Relationship.Id;
                }
                else
                {
                    return this.id;
                }
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// The order of this relationship (used in dynamic views only; e.g. 1.0, 1.1, 2.0, etc).
        /// </summary>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public string Order { get; set; }

        /// <summary>
        /// The description of this relationship (used in dynamic views only).
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The set of vertices used to render the relationship.
        /// </summary>
        [DataMember(Name = "vertices", EmitDefaultValue = false)]
        public List<Vertex> Vertices { get; set; }

        /// <summary>
        /// The routing of the line.
        /// </summary>
        [DataMember(Name = "routing", EmitDefaultValue = false)]
        public Routing? Routing { get; set; }

        private int? _position;

        /// <summary>
        /// The position of the annotation along the line; 0 (start) to 100 (end).
        /// </summary>
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public int? Position
        {
            get { return _position; }
            set
            {
                if (value != null)
                {
                    if (value < 0)
                    {
                        _position = 0;
                    }
                    else if (value > 100)
                    {
                        _position = 100;
                    }
                    else
                    {
                        _position = value;
                    }
                }
            }
        }

        /// <summary>
        /// Relationship tags extended with additional view related tags (which are not part of the model). 
        /// (e.g. PlantUMLWriter uses layout specific relation tags, and via this extended tags a relation can have
        /// view specific layout directions like REL_UP, REL_DOWN..)
        /// </summary>
        public IEnumerable<string> GetAllTags()
        {
            List<string> listOfTags = new List<string>(this._viewTags);
            if (this.Relationship != null)
                listOfTags.AddRange(this.Relationship.GetAllTags());
            return listOfTags;
        }

        private List<string> _viewTags = new List<string>();

        [DataMember(Name = "viewTags", EmitDefaultValue = false)]
        public string ViewTags
        {
            get
            {
                if (_viewTags.Count == 0)
                {
                    return "";
                }

                StringBuilder buf = new StringBuilder();
                foreach (string tag in this._viewTags)
                {
                    buf.Append(tag);
                    buf.Append(",");
                }

                string tagsAsString = buf.ToString();
                return tagsAsString.Substring(0, tagsAsString.Length - 1);
            }

            set
            {
                this._viewTags.Clear();

                if (value == null)
                {
                    return;
                }

                this._viewTags.AddRange(value.Split(','));
            }
        }

        public void AddViewTags(params string[] tags)
        {
            if (tags == null)
            {
                return;
            }

            foreach (string tag in tags)
            {
                if (tag != null)
                {
                    this._viewTags.Add(tag);
                }
            }
        }

        public void RemoveViewTag(string tag)
        {
            if (tag != null)
            {
                this._viewTags.Remove(tag);
            }
        }

        internal RelationshipView()
        {
        }

        internal RelationshipView(Relationship relationship)
        {
            this.Relationship = relationship;
        }

        public override string ToString()
        {
            return this.Relationship.ToString();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RelationshipView);
        }

        public bool Equals(RelationshipView relationshipView)
        {
            if (relationshipView == null)
            {
                return false;
            }
            if (relationshipView == this)
            {
                return true;
            }

            if (Description != null ? Description != relationshipView.Description : relationshipView.Description != null) return false;
            if (Id != relationshipView.Id) return false;
            return !(Order != null ? Order != relationshipView.Order : relationshipView.Order != null);

        }

        public override int GetHashCode()
        {
            int result = Id.GetHashCode();
            result = 31 * result + (Description != null ? Description.GetHashCode() : 0);
            result = 31 * result + (Order != null ? Order.GetHashCode() : 0);
            return result;
        }

        internal void CopyLayoutInformationFrom(RelationshipView source)
        {
            if (source != null)
            {
                this.Vertices = source.Vertices;
                this.Routing = source.Routing;
                this.Position = source.Position;
            }
        }
    }
}
