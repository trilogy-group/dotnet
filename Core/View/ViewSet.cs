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

        internal ViewSet()
        {
        }

        internal ViewSet(Model.Model model)
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

        public void Hydrate()
        {
            foreach (SystemContextView systemContextView in SystemContextViews)
            {
                HydrateView(systemContextView);
            }

            /*
            foreach (ContainerView containerView in ContainerViews)
            {
                HydrateView(containerView);
            }

            foreach (ComponentView componentView in ComponentViews)
            {
                HydrateView(componentView);
                componentView.Container = componentView.SoftwareSystem.GetContainerWithId(componentView.ContainerId);
            }

            dynamicViews.forEach(this::hydrateView);
            */
        }

        private void HydrateView(View view)
        {
            view.SoftwareSystem = Model.GetSoftwareSystemWithId(view.SoftwareSystemId);

            foreach (ElementView elementView in view.Elements)
            {
                elementView.Element = Model.GetElement(elementView.Id);
            }
            foreach (RelationshipView relationshipView in view.Relationships)
            {
                relationshipView.Relationship = Model.GetRelationship(relationshipView.Id);
            }
        }

        public void CopyLayoutInformationFrom(ViewSet source)
        {
            foreach (SystemContextView sourceView in source.SystemContextViews)
            {
                SystemContextView destinationView = FindSystemContextView(sourceView);
                if (destinationView != null)
                {
                    destinationView.CopyLayoutInformationFrom(sourceView);
                }
            }

            /*
            for (ContainerView sourceView : source.getContainerViews())
            {
                ContainerView destinationView = findContainerView(sourceView);
                if (destinationView != null)
                {
                    destinationView.copyLayoutInformationFrom(sourceView);
                }
            }

            for (ComponentView sourceView : source.getComponentViews())
            {
                ComponentView destinationView = findComponentView(sourceView);
                if (destinationView != null)
                {
                    destinationView.copyLayoutInformationFrom(sourceView);
                }
            }

            for (DynamicView sourceView : source.getDynamicViews())
            {
                DynamicView destinationView = findDynamicView(sourceView);
                if (destinationView != null)
                {
                    destinationView.copyLayoutInformationFrom(sourceView);
                }
            }
            */
        }

        private SystemContextView FindSystemContextView(SystemContextView systemContextView)
        {
            foreach (SystemContextView view in SystemContextViews)
            {
                if (view.Title == systemContextView.Title)
                {
                    return view;
                }
            }

            return null;
        }

    }
}
