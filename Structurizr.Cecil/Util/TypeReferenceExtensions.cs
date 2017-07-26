using System;
using System.Linq;

using Mono.Cecil;

namespace Structurizr.Cecil
{
    public static class TypeReferenceExtensions
    {
        public static string GetAssemblyQualifiedName(this TypeReference type)
        {
            string typeName;

            if (type.IsGenericInstance)
            {
                var genericInstance = (GenericInstanceType)type;
                typeName = String.Format("{0}.{1}[{2}]",
                    genericInstance.Namespace,
                    type.Name,
                    String.Join(",",
                        genericInstance.GenericArguments.Select(p => p.GetAssemblyQualifiedName()).ToArray()
                ));
            }
            else
            {
                typeName = type.FullName;
            }

            var scope = type.Scope as AssemblyNameReference;
            if (scope != null)
            {
                return typeName + ", " + scope.FullName;
            }
            else if (type.Scope != null)
            {
                return typeName + ", " + type.Module.Assembly.FullName;
            }

            return typeName;
        }
    }
}
