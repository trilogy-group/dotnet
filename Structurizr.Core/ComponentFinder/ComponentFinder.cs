using Structurizr.Model;
using System.Collections.Generic;

namespace Structurizr.ComponentFinder
{
    public class ComponentFinder
    {

        public Container Container { get; }
        public string Namespace { get; }

        private List<ComponentFinderStrategy> ComponentFinderStrategies = new List<ComponentFinderStrategy>();

        public ComponentFinder(Container container, string namespaceToScan, params ComponentFinderStrategy[] componentFinderStrategies)
        {
            this.Container = container;
            this.Namespace = namespaceToScan;

            foreach (ComponentFinderStrategy componentFinderStrategy in componentFinderStrategies)
            {
                this.ComponentFinderStrategies.Add(componentFinderStrategy);
                componentFinderStrategy.ComponentFinder = this;
            }
        }

        public Component FoundComponent(string interfaceType, string implementationType, string description, string technology, string sourcePath)
        {
            string type = interfaceType;
            if (type == null || type.Equals(""))
            {
                // there is no interface type, so we'll just have to use the implementation type
                type = implementationType;
            }

            Component component = null; // = Container.GetComponentOfType(type);
            if (component != null)
            {
                //mergeInformation(component, interfaceType, implementationType, description, technology, sourcePath);
            }
            else {
                string name = type.Substring(type.LastIndexOf(".") + 1);
                component = Container.GetComponentWithName(name);
                if (component == null)
                {
                    component = Container.AddComponentOfType(interfaceType, implementationType, description, technology);
                }
                else {
                    //mergeInformation(component, interfaceType, implementationType, description, technology, sourcePath);
                }
            }

            return component;
        }

        public ICollection<Component> FindComponents()
        {
            List<Component> componentsFound = new List<Component>();

            foreach (ComponentFinderStrategy componentFinderStrategy in ComponentFinderStrategies) {
                componentsFound.AddRange(componentFinderStrategy.FindComponents());
            }

            foreach (ComponentFinderStrategy componentFinderStrategy in ComponentFinderStrategies)
            {
                componentFinderStrategy.FindDependencies();
            }

            return componentsFound;
        }

    }
}
