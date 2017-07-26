using System;
using System.Collections.Generic;

namespace Structurizr.Analysis
{

    /// <summary>
    /// This is a component finder strategy that uses one or more TypeMatcher instances to find components.
    /// </summary>
    public class TypeMatcherComponentFinderStrategy : ComponentFinderStrategy
    {

        private ComponentFinder _componentFinder;
        public ComponentFinder ComponentFinder
        {
            get { return _componentFinder; }
            set
            {
                _componentFinder = value;
            }
        }

        private HashSet<Component> _componentsFound = new HashSet<Component>();

        private ITypeRepository _typeRepository;
        private List<ITypeMatcher> _typeMatchers = new List<ITypeMatcher>();
        private List<SupportingTypesStrategy> _supportingTypesStrategies = new List<SupportingTypesStrategy>();

        public TypeMatcherComponentFinderStrategy(params ITypeMatcher[] typeMatchers)
        {
            this._typeMatchers.AddRange(typeMatchers);
        }

        public void BeforeFindComponents()
        {
            _typeRepository = new ReflectionTypeRepository(_componentFinder.Namespace, _componentFinder.Exclusions);
            foreach (SupportingTypesStrategy strategy in _supportingTypesStrategies)
            {
                strategy.TypeRepository = _typeRepository;
            }
        }

        public IEnumerable<Component> FindComponents()
        {
            foreach (Type type in _typeRepository.GetAllTypes())
            {
                foreach (ITypeMatcher typeMatcher in this._typeMatchers)
                {
                    if (typeMatcher.Matches(type))
                    {
                        Component component = ComponentFinder.Container.AddComponent(
                            type.Name,
                            type,
                            typeMatcher.GetDescription(),
                            typeMatcher.GetTechnology());
                        _componentsFound.Add(component);
                    }
                }
            }

            return _componentsFound;
        }

        public void AfterFindComponents()
        {
            // before finding dependencies, let's find the types that are used to implement each component
            foreach (Component component in _componentsFound)
            {
                foreach (CodeElement codeElement in component.CodeElements)
                {
                    codeElement.Visibility = _typeRepository.FindVisibility(codeElement.Type);
                    codeElement.Category = _typeRepository.FindCategory(codeElement.Type);
                }

                foreach (SupportingTypesStrategy strategy in _supportingTypesStrategies)
                {
                    foreach (string type in strategy.FindSupportingTypes(component))
                    {
                        if (ComponentFinder.Container.GetComponentOfType(type) == null)
                        {
                            CodeElement codeElement = component.AddSupportingType(type);
                            codeElement.Visibility = _typeRepository.FindVisibility(type);
                            codeElement.Category = _typeRepository.FindCategory(type);
                        }
                    }
                }
            }

            foreach (Component component in ComponentFinder.Container.Components)
            {
                if (component.Type != null)
                {
                    AddEfferentDependencies(component, component.Type, new HashSet<string>());

                    // and repeat for the supporting types
                    foreach (CodeElement codeElement in component.CodeElements)
                    {
                        AddEfferentDependencies(component, codeElement.Type, new HashSet<string>());
                    }
                }
            }
        }

        private void AddEfferentDependencies(Component component, string type, HashSet<string> typesVisited)
        {
            typesVisited.Add(type);

            foreach (string referencedTypeName in _typeRepository.GetReferencedTypes(type))
            {
                Component destinationComponent = ComponentFinder.Container.GetComponentOfType(referencedTypeName);
                if (destinationComponent != null)
                {
                    if (component != destinationComponent)
                    {
                        component.Uses(destinationComponent, "");
                    }
                }
                else if (!typesVisited.Contains(referencedTypeName))
                {
                    AddEfferentDependencies(component, referencedTypeName, typesVisited);
                }
            }
        }

        /// <summary>
        /// Adds a SupportingTypeStrategy.
        /// </summary>
        /// <param name="strategy">A SupportingTypesStrategy object</param>
        public void AddSupportingTypesStrategy(SupportingTypesStrategy strategy)
        {
            if (strategy != null)
            {
                _supportingTypesStrategies.Add(strategy);
                strategy.TypeRepository = _typeRepository;
            }
        }

    }
}