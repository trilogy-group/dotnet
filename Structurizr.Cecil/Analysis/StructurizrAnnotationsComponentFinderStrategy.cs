using System.Collections.Generic;
using System.Linq;

using Mono.Cecil;

using Structurizr.Annotations;
using Structurizr.Cecil;

namespace Structurizr.Analysis
{
    public class StructurizrAnnotationsComponentFinderStrategy : ComponentFinderStrategy
    {
        public ComponentFinder ComponentFinder { get; set; }

        private HashSet<Component> _componentsFound = new HashSet<Component>();

        private AssemblyDefinition _primaryAssembly;

        private ITypeRepository _typeRepository;

        public StructurizrAnnotationsComponentFinderStrategy(AssemblyDefinition assembly)
        {
            this._primaryAssembly = assembly;
        }

        public void BeforeFindComponents()
        {
            _typeRepository = new CecilTypeRepository(
                _primaryAssembly,
                ComponentFinder.Namespace,
                ComponentFinder.Exclusions);
        }

        public IEnumerable<Component> FindComponents()
        {
            foreach(TypeDefinition type in _typeRepository.GetAllTypes())
            {
                if (!type.HasCustomAttributes) continue;
                var componentAttribute = type.CustomAttributes.OfType<ComponentAttribute>().FirstOrDefault();
                if (componentAttribute == null) continue;

                Component component = ComponentFinder.Container.AddComponent(
                    type.Name,
                    type.GetAssemblyQualifiedName(),
                    componentAttribute.Description,
                    componentAttribute.Technology
                );
                _componentsFound.Add(component);
            }

            return _componentsFound;
        }

        public void AfterFindComponents()
        {
            foreach (Component component in _componentsFound)
            {
                foreach (CodeElement codeElement in component.CodeElements)
                {
                    codeElement.Visibility = _typeRepository.FindVisibility(codeElement.Type);
                    codeElement.Category = _typeRepository.FindCategory(codeElement.Type);

                    FindUsesComponentAnnotations(component, codeElement.Type);
                    FindUsesContainerAnnotations(component, codeElement.Type);
                    FindUsedBySoftwareSystemAnnotations(component, codeElement.Type);

                    FindUsedByPersonAnnotations(component, codeElement.Type);
                    FindUsedBySoftwareSystemAnnotations(component, codeElement.Type);
                    FindUsedBySoftwareSystemAnnotations(component, codeElement.Type);
                }
            }
        }

        private void FindUsesComponentAnnotations(Component component, string typeName)
        {
            TypeDefinition type = _typeRepository.GetType(typeName);
            if (type == null)
            {
                // todo: logging
                return;
            }

            foreach (FieldDefinition field in type.Fields)
            {
                if (!field.HasCustomAttributes) continue;
                var annotation = field.CustomAttributes.OfType<UsesComponentAttribute>().SingleOrDefault();
                if (annotation == null) continue;

                string destinationTypeName = field.FieldType.FullName;
                Component destination = ComponentFinder.Container.GetComponentOfType(destinationTypeName);
                if (destination != null)
                {
                    foreach (Relationship relationship in component.Relationships.Where(r => r.Destination == destination))
                    {
                        relationship.Description = annotation.Description;
                        relationship.Technology = annotation.Technology;
                    }
                }
                else
                {
                    // todo: logging
                }
            }
        }

        private void FindUsesContainerAnnotations(Component component, string typeName)
        {
            TypeDefinition type = _typeRepository.GetType(typeName);
            if (type == null)
            {
                // todo: logging
                return;
            }
            if (!type.HasCustomAttributes) return;

            var annotations = type.CustomAttributes.OfType<UsesContainerAttribute>().ToList();
            foreach(UsesContainerAttribute annotation in annotations)
            {
                Container container = FindContainerByNameOrId(component, annotation.ContainerName);
                if (container != null)
                {
                    component.Uses(container, annotation.Description, annotation.Technology);
                }
                else
                {
                    // todo: logging
                }
            }
        }

        private void FindUsesSoftwareSystemAnnotations(Component component, string typeName)
        {
            TypeDefinition type = _typeRepository.GetType(typeName);
            if (type == null)
            {
                // todo: logging
                return;
            }
            if (!type.HasCustomAttributes) return;

            var annotations = type.CustomAttributes.OfType<UsesSoftwareSystemAttribute>().ToList();
            foreach(UsesSoftwareSystemAttribute annotation in annotations)
            {
                SoftwareSystem system = component.Model.GetSoftwareSystemWithName(annotation.SoftwareSystemName);
                if (system != null)
                {
                    component.Uses(system, annotation.Description, annotation.Technology);
                }
                else
                {
                    // todo: logging
                }
            }
        }

        private void FindUsedByContainerAnnotations(Component component, string typeName)
        {
            TypeDefinition type = _typeRepository.GetType(typeName);
            if (type == null)
            {
                // todo: logging
                return;
            }
            if (!type.HasCustomAttributes) return;

            var annotations = type.CustomAttributes.OfType<UsedByContainerAttribute>().ToList();
            foreach(UsedByContainerAttribute annotation in annotations)
            {
                Container container = FindContainerByNameOrId(component, annotation.ContainerName);
                if (container != null)
                {
                    container.Uses(component, annotation.Description, annotation.Technology);
                }
                else
                {
                    // todo: logging
                }
            }
        }

        private void FindUsedByPersonAnnotations(Component component, string typeName)
        {
            TypeDefinition type = _typeRepository.GetType(typeName);
            if (type == null)
            {
                // todo: logging
                return;
            }
            if (!type.HasCustomAttributes) return;

            var annotations = type.CustomAttributes.OfType<UsedByPersonAttribute>().ToList();
            foreach(UsedByPersonAttribute annotation in annotations)
            {
                Person person = component.Model.GetPersonWithName(annotation.PersonName);
                if (person != null)
                {
                    person.Uses(component, annotation.Description, annotation.Technology);
                }
                else
                {
                    // todo: logging
                }
            }
        }

        private void FindUsedBySoftwareSystemAnnotations(Component component, string typeName)
        {
            TypeDefinition type = _typeRepository.GetType(typeName);
            if (type == null)
            {
                // todo: logging
                return;
            }
            if (!type.HasCustomAttributes) return;

            var annotations = type.CustomAttributes.OfType<UsedBySoftwareSystemAttribute>().ToList();
            foreach(UsedBySoftwareSystemAttribute annotation in annotations)
            {
                SoftwareSystem system = component.Model.GetSoftwareSystemWithName(annotation.SoftwareSystemName);
                if (system != null)
                {
                    system.Uses(component, annotation.Description, annotation.Technology);
                }
                else
                {
                    // todo: logging
                }
            }
        }

        private Container FindContainerByNameOrId(Component component, string name)
        {
            // assume that the container resides in the same software system
            Container container = component.Container.SoftwareSystem.GetContainerWithName(name);
            if (container == null)
            {
                // perhaps it's an element ID?
                container = component.Model.GetElement(name) as Container;
            }

            return container;
        }
    }
}