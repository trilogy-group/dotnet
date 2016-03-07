using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Structurizr.Model
{

    /// <summary>
    /// A component (a grouping of related functionality behind an interface that runs inside a container).
    /// </summary>
    [DataContract]
    public partial class Component :  IEquatable<Component>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Component" />class.
        /// </summary>
        /// <param name="Id">The ID of this component in the model..</param>
        /// <param name="Name">The name of this component..</param>
        /// <param name="Description">A short description of this component..</param>
        /// <param name="Technology">The technology associated with this component (e.g. Spring Bean)..</param>
        /// <param name="InterfaceType">The interface type (e.g. a fully qualified Java interface name)..</param>
        /// <param name="ImplementationType">The implementation type (e.g. a fully qualified Java class name)..</param>
        /// <param name="SourcePath">The source code path that reflects this component (e.g. a GitHub URL)..</param>
        /// <param name="Tags">A comma separated list of tags associated with this container..</param>
        /// <param name="Relationships">The set of relationships between this container and other elements..</param>

        public Component(string Id = null, string Name = null, string Description = null, string Technology = null, string InterfaceType = null, string ImplementationType = null, string SourcePath = null, string Tags = null, List<Relationship> Relationships = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Technology = Technology;
            this.InterfaceType = InterfaceType;
            this.ImplementationType = ImplementationType;
            this.SourcePath = SourcePath;
            this.Tags = Tags;
            this.Relationships = Relationships;
            
        }

        
        /// <summary>
        /// The ID of this component in the model.
        /// </summary>
        /// <value>The ID of this component in the model.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
  
        
        /// <summary>
        /// The name of this component.
        /// </summary>
        /// <value>The name of this component.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
  
        
        /// <summary>
        /// A short description of this component.
        /// </summary>
        /// <value>A short description of this component.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
  
        
        /// <summary>
        /// The technology associated with this component (e.g. Spring Bean).
        /// </summary>
        /// <value>The technology associated with this component (e.g. Spring Bean).</value>
        [DataMember(Name="technology", EmitDefaultValue=false)]
        public string Technology { get; set; }
  
        
        /// <summary>
        /// The interface type (e.g. a fully qualified Java interface name).
        /// </summary>
        /// <value>The interface type (e.g. a fully qualified Java interface name).</value>
        [DataMember(Name="interfaceType", EmitDefaultValue=false)]
        public string InterfaceType { get; set; }
  
        
        /// <summary>
        /// The implementation type (e.g. a fully qualified Java class name).
        /// </summary>
        /// <value>The implementation type (e.g. a fully qualified Java class name).</value>
        [DataMember(Name="implementationType", EmitDefaultValue=false)]
        public string ImplementationType { get; set; }
  
        
        /// <summary>
        /// The source code path that reflects this component (e.g. a GitHub URL).
        /// </summary>
        /// <value>The source code path that reflects this component (e.g. a GitHub URL).</value>
        [DataMember(Name="sourcePath", EmitDefaultValue=false)]
        public string SourcePath { get; set; }
  
        
        /// <summary>
        /// A comma separated list of tags associated with this container.
        /// </summary>
        /// <value>A comma separated list of tags associated with this container.</value>
        [DataMember(Name="tags", EmitDefaultValue=false)]
        public string Tags { get; set; }
  
        
        /// <summary>
        /// The set of relationships between this container and other elements.
        /// </summary>
        /// <value>The set of relationships between this container and other elements.</value>
        [DataMember(Name="relationships", EmitDefaultValue=false)]
        public List<Relationship> Relationships { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Component {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Technology: ").Append(Technology).Append("\n");
            sb.Append("  InterfaceType: ").Append(InterfaceType).Append("\n");
            sb.Append("  ImplementationType: ").Append(ImplementationType).Append("\n");
            sb.Append("  SourcePath: ").Append(SourcePath).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Relationships: ").Append(Relationships).Append("\n");
            
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
            return this.Equals(obj as Component);
        }

        /// <summary>
        /// Returns true if Component instances are equal
        /// </summary>
        /// <param name="other">Instance of Component to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Component other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Technology == other.Technology ||
                    this.Technology != null &&
                    this.Technology.Equals(other.Technology)
                ) && 
                (
                    this.InterfaceType == other.InterfaceType ||
                    this.InterfaceType != null &&
                    this.InterfaceType.Equals(other.InterfaceType)
                ) && 
                (
                    this.ImplementationType == other.ImplementationType ||
                    this.ImplementationType != null &&
                    this.ImplementationType.Equals(other.ImplementationType)
                ) && 
                (
                    this.SourcePath == other.SourcePath ||
                    this.SourcePath != null &&
                    this.SourcePath.Equals(other.SourcePath)
                ) && 
                (
                    this.Tags == other.Tags ||
                    this.Tags != null &&
                    this.Tags.Equals(other.Tags)
                ) && 
                (
                    this.Relationships == other.Relationships ||
                    this.Relationships != null &&
                    this.Relationships.SequenceEqual(other.Relationships)
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
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.Technology != null)
                    hash = hash * 59 + this.Technology.GetHashCode();
                
                if (this.InterfaceType != null)
                    hash = hash * 59 + this.InterfaceType.GetHashCode();
                
                if (this.ImplementationType != null)
                    hash = hash * 59 + this.ImplementationType.GetHashCode();
                
                if (this.SourcePath != null)
                    hash = hash * 59 + this.SourcePath.GetHashCode();
                
                if (this.Tags != null)
                    hash = hash * 59 + this.Tags.GetHashCode();
                
                if (this.Relationships != null)
                    hash = hash * 59 + this.Relationships.GetHashCode();
                
                return hash;
            }
        }

    }
}
