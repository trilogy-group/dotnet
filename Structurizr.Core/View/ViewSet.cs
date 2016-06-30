using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Structurizr
{

    /// <summary>
    /// The set of views onto a software architecture model.
    /// </summary>
    [DataContract]
    public class ViewSet
    {

        public Model Model { get; set; }

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
            this.SystemContextViews = new List<SystemContextView>();
            this.ContainerViews = new List<ContainerView>();
            this.ComponentViews = new List<ComponentView>();

            this.Configuration = new Configuration();
        }

        internal ViewSet(Model model) : this()
        {
            this.Model = model;
        }

        public SystemContextView CreateSystemContextView(SoftwareSystem softwareSystem, String key, String description)
        {
            SystemContextView view = new SystemContextView(softwareSystem, key, description);
            this.SystemContextViews.Add(view);

            return view;
        }

        public ContainerView CreateContainerView(SoftwareSystem softwareSystem, string key, string description)
        {
            ContainerView view = new ContainerView(softwareSystem, key, description);
            ContainerViews.Add(view);

            return view;
        }

        public ComponentView CreateComponentView(Container container, string key, string description)
        {
            ComponentView view = new ComponentView(container, key, description);
            ComponentViews.Add(view);

            return view;
        }

        public void Hydrate()
        {
            foreach (SystemContextView systemContextView in SystemContextViews)
            {
                HydrateView(systemContextView);
            }

            foreach (ContainerView containerView in ContainerViews)
            {
                HydrateView(containerView);
            }

            foreach (ComponentView componentView in ComponentViews)
            {
                HydrateView(componentView);
                componentView.Container = componentView.SoftwareSystem.GetContainerWithId(componentView.ContainerId);
            }

            /*
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

            foreach (ContainerView sourceView in source.ContainerViews)
            {
                ContainerView destinationView = FindContainerView(sourceView);
                if (destinationView != null)
                {
                    destinationView.CopyLayoutInformationFrom(sourceView);
                }
            }

            foreach (ComponentView sourceView in source.ComponentViews)
            {
                ComponentView destinationView = FindComponentView(sourceView);
                if (destinationView != null)
                {
                    destinationView.CopyLayoutInformationFrom(sourceView);
                }
            }

            /*
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
                if (view.Key == systemContextView.Key)
                {
                    return view;
                }
            }

            foreach (SystemContextView view in SystemContextViews)
            {
                if (view.Title == systemContextView.Title)
                {
                    return view;
                }
            }

            return null;
        }

        private ContainerView FindContainerView(ContainerView containerView)
        {
            foreach (ContainerView view in ContainerViews)
            {
                if (view.Key == containerView.Key)
                {
                    return view;
                }
            }

            foreach (ContainerView view in ContainerViews)
            {
                if (view.Title == containerView.Title)
                {
                    return view;
                }
            }

            return null;
        }

        private ComponentView FindComponentView(ComponentView componentView)
        {
            foreach (ComponentView view in ComponentViews)
            {
                if (view.Key == componentView.Key)
                {
                    return view;
                }
            }

            foreach (ComponentView view in ComponentViews)
            {
                if (view.Title == componentView.Title)
                {
                    return view;
                }
            }

            return null;
        }

    }
}
