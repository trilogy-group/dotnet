using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Structurizr.View
{

    /// <summary>
    /// The set of views onto a software architecture model.
    /// </summary>
    [DataContract]
    public class ViewSet
    {

        public ViewSet(Model.Model model)
        {
            this.Model = model;
        }

        public Model.Model Model { get; set; }

        /// <summary>
        /// The set of system context views.
        /// </summary>
        /// <value>The set of system context views.</value>
        [DataMember(Name="systemContextViews", EmitDefaultValue=false)]
        public List<SystemContextView> SystemContextViews { get; set; }
  
        
        /// <summary>
        /// The set of container views.
        /// </summary>
        /// <value>The set of container views.</value>
        [DataMember(Name="containerViews", EmitDefaultValue=false)]
        public List<ContainerView> ContainerViews { get; set; }
  
        
        /// <summary>
        /// The set of component views.
        /// </summary>
        /// <value>The set of component views.</value>
        [DataMember(Name="componentViews", EmitDefaultValue=false)]
        public List<ComponentView> ComponentViews { get; set; }
  
        
        /// <summary>
        /// The configuration object associated with this set of views.
        /// </summary>
        /// <value>The configuration object associated with this set of views.</value>
        [DataMember(Name="configuration", EmitDefaultValue=false)]
        public Configuration Configuration { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Views {\n");
            sb.Append("  SystemContextViews: ").Append(SystemContextViews).Append("\n");
            sb.Append("  ContainerViews: ").Append(ContainerViews).Append("\n");
            sb.Append("  ComponentViews: ").Append(ComponentViews).Append("\n");
            sb.Append("  Configuration: ").Append(Configuration).Append("\n");
            
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

    }
}
