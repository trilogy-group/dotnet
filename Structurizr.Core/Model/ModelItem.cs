using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Structurizr
{

    [DataContract]
    public abstract class ModelItem
    {

        /// <summary>
        /// The ID of this item in the model.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        private List<string> _tags = new List<string>();

        public IEnumerable<string> GetAllTags()
        {
            if (String.IsNullOrWhiteSpace(Tags))
                return Enumerable.Empty<string>();
            return Tags.Split(new [] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }

        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public virtual string Tags
        {
            get
            {
                List<string> listOfTags = new List<string>(GetRequiredTags());
                listOfTags.AddRange(_tags);

                if (listOfTags.Count == 0)
                {
                    return "";
                }

                StringBuilder buf = new StringBuilder();
                foreach (string tag in listOfTags)
                {
                    buf.Append(tag);
                    buf.Append(",");
                }

                string tagsAsString = buf.ToString();
                return tagsAsString.Substring(0, tagsAsString.Length - 1);
            }

            set
            {
                this._tags.Clear();

                if (value == null)
                {
                    return;
                }

                this._tags.AddRange(value.Split(','));
            }
        }

        internal ModelItem()
        {
        }

        public void AddTags(params string[] tags)
        {
            if (tags == null)
            {
                return;
            }

            foreach (string tag in tags)
            {
                if (tag != null)
                {
                    this._tags.Add(tag);
                }
            }
        }

        public virtual void RemoveTag(string tag)
        {
            if (tag != null)
            {
                this._tags.Remove(tag);
            }
        }

        public abstract List<string> GetRequiredTags();

        /// <summary>
        /// The collection of name-value property pairs associated with this element, as a Dictionary.
        /// </summary>
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public Dictionary<string, string> Properties = new Dictionary<string, string>();

        /// <summary>
        /// Adds a name-value pair property to this element. 
        /// </summary>
        /// <param name="name">the name of the property</param>
        /// <param name="value">the value of the property</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddProperty(string name, string value) {
            if (String.IsNullOrEmpty(name)) {
                throw new ArgumentException("A property name must be specified.");
            }

            if (String.IsNullOrEmpty(value)) {
                throw new ArgumentException("A property value must be specified.");
            }

            Properties[name] = value;
        }

    }
}