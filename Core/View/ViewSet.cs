using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Structurizr.Model;

namespace Structurizr.View
{

    /// <summary>
    /// The set of views onto a software architecture model.
    /// </summary>
    [DataContract]
    public class ViewSet
    {

        public Model.Model Model { get; set; }

        /// <summary>
        /// The set of system context views.
        /// </summary>
        [DataMember(Name = "systemContextViews", EmitDefaultValue = false)]
        public List<SystemContextView> SystemContextViews { get; set; }


        /// <summary>
        /// The set of container views.
        /// </summary>
        [DataMember(Name = "containerViews", EmitDefaultValue = false)]
        public List<ContainerView> ContainerViews { get; set; }


        /// <summary>
        /// The set of component views.
        /// </summary>
        [DataMember(Name = "componentViews", EmitDefaultValue = false)]
        public List<ComponentView> ComponentViews { get; set; }


        /// <summary>
        /// The configuration object associated with this set of views.
        /// </summary>
        [DataMember(Name = "configuration", EmitDefaultValue = false)]
        public Configuration Configuration { get; set; }

        public ViewSet(Model.Model model)
        {
            this.Model = model;
            this.SystemContextViews = new List<SystemContextView>();

            this.Configuration = new Configuration();
        }


        public SystemContextView CreateContextView(SoftwareSystem softwareSystem)
        {
            return CreateContextView(softwareSystem, null);
        }

        public SystemContextView CreateContextView(SoftwareSystem softwareSystem, String description)
        {
            SystemContextView view = new SystemContextView(softwareSystem, description);
            this.SystemContextViews.Add(view);

            return view;
        }

    }
}
