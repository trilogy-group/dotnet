using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

namespace Structurizr.Cecil.Util
{
    static class CustomAttributeExtensions
    {
        public static IEnumerable<TAttribute> ResolvableAttributes<TAttribute>(this TypeDefinition klassType)
            where TAttribute : Attribute
        {
            var attributeType = typeof(TAttribute).GetTypeInfo();

            foreach (var customAttribute in klassType.CustomAttributes)
            {
                if (!customAttribute.Is<TAttribute>()) continue;

                var arguments = customAttribute.ConstructorArguments.Select(a => a.Value).ToArray();

                var createdAttribute = (TAttribute)Activator.CreateInstance(typeof(TAttribute), arguments);
                foreach (var attributeProperty in customAttribute.Properties)
                {
                    var propertyInfo = attributeType.GetDeclaredProperty(attributeProperty.Name);
                    propertyInfo.SetValue(createdAttribute, attributeProperty.Argument.Value);
                }

                yield return createdAttribute;
            }
        }

        public static IEnumerable<TAttribute> ResolvableAttributes<TAttribute>(this FieldDefinition field)
            where TAttribute : Attribute
        {
            var attributeType = typeof(TAttribute).GetTypeInfo();

            foreach (var customAttribute in field.CustomAttributes)
            {
                if (!customAttribute.Is<TAttribute>()) continue;

                var arguments = customAttribute.ConstructorArguments.Select(a => a.Value).ToArray();

                var createdAttribute = (TAttribute)Activator.CreateInstance(typeof(TAttribute), arguments);
                foreach (var attributeProperty in customAttribute.Properties)
                {
                    var propertyInfo = attributeType.GetDeclaredProperty(attributeProperty.Name);
                    propertyInfo.SetValue(createdAttribute, attributeProperty.Argument.Value);
                }

                yield return createdAttribute;
            }
        }

        public static IEnumerable<TAttribute> ResolvableAttributes<TAttribute>(this PropertyDefinition property)
            where TAttribute : Attribute
        {
            var attributeType = typeof(TAttribute).GetTypeInfo();

            foreach (var customAttribute in property.CustomAttributes)
            {
                if (!customAttribute.Is<TAttribute>()) continue;

                var arguments = customAttribute.ConstructorArguments.Select(a => a.Value).ToArray();

                var createdAttribute = (TAttribute)Activator.CreateInstance(typeof(TAttribute), arguments);
                foreach (var attributeProperty in customAttribute.Properties)
                {
                    var propertyInfo = attributeType.GetDeclaredProperty(attributeProperty.Name);
                    propertyInfo.SetValue(createdAttribute, attributeProperty.Argument.Value);
                }

                yield return createdAttribute;
            }
        }

        public static IEnumerable<TAttribute> ResolvableAttributes<TAttribute>(this ParameterDefinition parameter)
            where TAttribute : Attribute
        {
            var attributeType = typeof(TAttribute).GetTypeInfo();

            foreach (var customAttribute in parameter.CustomAttributes)
            {
                if (!customAttribute.Is<TAttribute>()) continue;

                var arguments = customAttribute.ConstructorArguments.Select(a => a.Value).ToArray();

                var createdAttribute = (TAttribute)Activator.CreateInstance(typeof(TAttribute), arguments);
                foreach (var attributeProperty in customAttribute.Properties)
                {
                    var propertyInfo = attributeType.GetDeclaredProperty(attributeProperty.Name);
                    propertyInfo.SetValue(createdAttribute, attributeProperty.Argument.Value);
                }

                yield return createdAttribute;
            }
        }

        private static bool Is<TAttribute>(this CustomAttribute attribute)
        {
            return attribute.AttributeType.FullName == typeof(TAttribute).FullName;
        }
    }
}
