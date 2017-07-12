using System;
using System.Collections.Generic;

namespace Structurizr.Analysis
{

    public interface TypeRepository
    {

        string Namespace { get; }
        IEnumerable<Type> GetAllTypes();
        IEnumerable<string> GetReferencedTypes(string type);

        string FindCategory(string typeName);
        string FindVisibility(string typeName);

    }

}