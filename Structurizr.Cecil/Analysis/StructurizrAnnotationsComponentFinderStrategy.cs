using System.Collections.Generic;
using System.Linq;

using Mono.Cecil;

using Structurizr.Annotations;
using Structurizr.Cecil;
using Structurizr.Cecil.Util;

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
            List<TypeDefinition> types = _typeRepository.GetAllTypes().ToList();

            foreach (TypeDefinition type in types)
            {
                if (!type.HasCustomAttributes) continue;

                ComponentAttribute componentAttribute =
                    type.ResolvableAttributes<ComponentAttribute>().SingleOrDefault();
                if (componentAttribute != null)
                {
                    Component component = ComponentFinder.Container.AddComponent(
                        type.Name,
                        type.GetAssemblyQualifiedName(),
                        componentAttribute.Description,
                        componentAttribute.Technology
                    );
                    _componentsFound.Add(component);
                }
            }

            // Look for code elements after finding all the components
            foreach (TypeDefinition type in types)
            {
                CodeElementAttribute codeElementAttribute = type.ResolvableAttributes<CodeElementAttribute>().SingleOrDefault();
                if (codeElementAttribute != null)
                {
                    Component component =
                        ComponentFinder.Container.GetComponentOfType(codeElementAttribute.ComponentName)
                        ?? ComponentFinder.Container.GetComponentWithName(codeElementAttribute.ComponentName);
                    if (component != null)
                    {
                        CodeElement codeElement = component.AddSupportingType(type.GetAssemblyQualifiedName());
                        codeElement.Description = codeElementAttribute.Description;
                    }
                    else
                    {
                        // todo: logging
                    }
                }
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
                    FindUsesSoftwareSystemAnnotations(component, codeElement.Type);

                    FindUsedByPersonAnnotations(component, codeElement.Type);
                    FindUsedByContainerAnnotations(component, codeElement.Type);
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
                var annotation = field.ResolvableAttributes<UsesComponentAttribute>().SingleOrDefault();
                if (annotation == null) continue;

                AddUsesComponentRelationship(component, field.FieldType, annotation);
            }

            foreach (PropertyDefinition property in type.Properties)
            {
                if (!property.HasCustomAttributes) continue;
                var annotation = property.ResolvableAttributes<UsesComponentAttribute>().SingleOrDefault();
                if (annotation == null) continue;

                AddUsesComponentRelationship(component, property.PropertyType, annotation);
            }

            foreach (MethodDefinition method in type.Methods)
            {
                foreach (ParameterDefinition parameter in method.Parameters)
                {
                    if (!parameter.HasCustomAttributes) continue;
                    var annotation = parameter.ResolvableAttributes<UsesComponentAttribute>().SingleOrDefault();
                    if (annotation == null) continue;

                    AddUsesComponentRelationship(component, parameter.ParameterType, annotation);
                }
            }
        }

        private void AddUsesComponentRelationship(
            Component component,
            TypeReference destinationType,
            UsesComponentAttribute annotation)
        {
            if (annotation == null)
            {
                // todo: logging
                return;
            }

            string destinationTypeName = destinationType.GetAssemblyQualifiedName();
            Component destination = ComponentFinder.Container.GetComponentOfType(destinationTypeName);
            if (destination != null)
            {
                IList<Relationship> relationships = component.Relationships
                    .Where(r => r.Destination.Equals(destination))
                    .ToList();
                if (relationships.Count > 0)
                {
                    foreach (Relationship relationship in relationships)
                    {
                        relationship.Description = annotation.Description;
                        relationship.Technology = annotation.Technology;
                    }
                }
                else
                {
                    // Relationship doesn't already exist, so add it
                    component.Uses(destination, annotation.Description, annotation.Technology);
                }
            }
            else
            {
                // todo: logging
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

            var annotations = type.ResolvableAttributes<UsesContainerAttribute>().ToList();
            foreach(UsesContainerAttribute annotation in annotations)
            {
                Container container = FindContainerByNameOrId(component, annotation.ContainerName);
                if (container != null)
                {
                    string description = annotation.Description;
                    string technology = annotation.Technology;

                    component.Uses(container, description, technology);
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

            var annotations = type.ResolvableAttributes<UsesSoftwareSystemAttribute>().ToList();
            foreach(UsesSoftwareSystemAttribute annotation in annotations)
            {
                SoftwareSystem system = component.Model.GetSoftwareSystemWithName(annotation.SoftwareSystemName);
                if (system != null)
                {
                    string description = annotation.Description;
                    string technology = annotation.Technology;

                    component.Uses(system, description, technology);
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

            var annotations = type.ResolvableAttributes<UsedByContainerAttribute>().ToList();
            foreach(UsedByContainerAttribute annotation in annotations)
            {
                Container container = FindContainerByNameOrId(component, annotation.ContainerName);
                if (container != null)
                {
                    string description = annotation.Description;
                    string technology = annotation.Technology;

                    container.Uses(component, description, technology);
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

            var annotations = type.ResolvableAttributes<UsedByPersonAttribute>().ToList();
            foreach(UsedByPersonAttribute annotation in annotations)
            {
                Person person = component.Model.GetPersonWithName(annotation.PersonName);
                if (person != null)
                {
                    string description = annotation.Description;
                    string technology = annotation.Technology;

                    person.Uses(component, description, technology);
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

            var annotations = type.ResolvableAttributes<UsedBySoftwareSystemAttribute>().ToList();
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