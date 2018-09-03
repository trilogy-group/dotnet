using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Structurizr
{
    
    [DataContract]
    public sealed class Animation
    {
        
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public int Order { get; internal set; }
        
        [DataMember(Name = "elements", EmitDefaultValue = false)]
        public ISet<string> Elements { get; internal set; }

        [DataMember(Name = "relationships", EmitDefaultValue = false)]
        public ISet<string> Relationships { get; internal set; }

        internal Animation()
        {
            Elements = new HashSet<string>();
            Relationships = new HashSet<string>();
        }
        
        internal Animation(int order, ISet<Element> elements, ISet<Relationship> relationships) : this()
        {
            Order = order;

            foreach (Element element in elements)
            {
                Elements.Add(element.Id);
            }

            foreach (Relationship relationship in relationships)
            {
                Relationships.Add(relationship.Id);
            }
        }


    }
}