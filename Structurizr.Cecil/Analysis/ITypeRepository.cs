using System.Collections.Generic;

using Mono.Cecil;

namespace Structurizr.Analysis
{
    public interface ITypeRepository
    {
        string Namespace { get; }
        IEnumerable<TypeDefinition> GetAllTypes();
        TypeDefinition GetType(string typeName);
        IEnumerable<string> GetReferencedTypes(string type);

        string FindCategory(string typeName);
        string FindVisibility(string typeName);
    }
}
