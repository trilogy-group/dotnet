using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Structurizr.Model
{

    /// <summary>
    /// A person who uses a software system.
    /// </summary>
    [DataContract]
    public class Person : Element, IEquatable<Person>
    {

        /// <summary>
        /// The location of this person.
        /// </summary>
        [DataMember(Name = "location", EmitDefaultValue = false)]
        public Location Location { get; set; }

        public override string CanonicalName
        {
            get
            {
                return CanonicalNameSeparator + FormatForCanonicalName(Name);
            }
        }

        public override Element Parent
        {
            get
            {
                return null;
            }

            set
            {
            }
        }

        internal Person()
        {
        }

        public override List<string> getRequiredTags()
        {
            string[] tags = {
                Structurizr.Model.Tags.Element,
                Structurizr.Model.Tags.Person
            };
            return tags.ToList();
        }

        public bool Equals(Person person)
        {
            return this.Equals(person as Element);
        }

    }
}
