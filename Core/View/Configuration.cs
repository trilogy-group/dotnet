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
    /// The configuration associated with a set of views.
    /// </summary>
    [DataContract]
    public partial class Configuration :  IEquatable<Configuration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" />class.
        /// </summary>
        /// <param name="Styles">Styles.</param>

        public Configuration(ConfigurationStyles Styles = null)
        {
            this.Styles = Styles;
            
        }

        
        /// <summary>
        /// Gets or Sets Styles
        /// </summary>
        [DataMember(Name="styles", EmitDefaultValue=false)]
        public ConfigurationStyles Styles { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Configuration {\n");
            sb.Append("  Styles: ").Append(Styles).Append("\n");
            
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
            return this.Equals(obj as Configuration);
        }

        /// <summary>
        /// Returns true if Configuration instances are equal
        /// </summary>
        /// <param name="other">Instance of Configuration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Configuration other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Styles == other.Styles ||
                    this.Styles != null &&
                    this.Styles.Equals(other.Styles)
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
                
                if (this.Styles != null)
                    hash = hash * 59 + this.Styles.GetHashCode();
                
                return hash;
            }
        }

    }
}
