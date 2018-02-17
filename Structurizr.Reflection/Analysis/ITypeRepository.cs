using System;
using System.Collections.Generic;

namespace Structurizr.Analysis
{

    public interface ITypeRepository
    {

        string Namespace { get; }
        IEnumerable<Type> GetAllTypes();
        Type GetType(string type);
        IEnumerable<string> GetReferencedTypes(string type);

        string FindCategory(string typeName);
        string FindVisibility(string typeName);

    }

}