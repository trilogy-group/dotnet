using System;
using System.Collections.Generic;
using System.Linq;

namespace Structurizr.Analysis
{

    public class ReferencedTypesSupportingTypesStrategy : SupportingTypesStrategy
    {

        private bool _includeIndirectlyReferencedTypes;

        public ReferencedTypesSupportingTypesStrategy() : this(true)
        {
        }

        public ReferencedTypesSupportingTypesStrategy(bool includeIndirectlyReferencedTypes)
        {
            _includeIndirectlyReferencedTypes = includeIndirectlyReferencedTypes;
        }

        public override HashSet<string> FindSupportingTypes(Component component)
        {
            HashSet<string> referencedTypes = new HashSet<string>();
            referencedTypes.UnionWith(GetReferencedTypesInNamespace(component.Type));

            foreach (CodeElement codeElement in component.CodeElements)
            {
                referencedTypes.UnionWith(GetReferencedTypesInNamespace(codeElement.Type));
            }

            if (_includeIndirectlyReferencedTypes) {
                int numberOfTypes = referencedTypes.Count;
                bool foundMore = true;
                while (foundMore) {
                    HashSet<string> indirectlyReferencedTypes = new HashSet<string>();
                    foreach (string type in referencedTypes)
                    {
                        indirectlyReferencedTypes.UnionWith(GetReferencedTypesInNamespace(type));
                    }
                    referencedTypes.UnionWith(indirectlyReferencedTypes);

                    if (referencedTypes.Count > numberOfTypes)
                    {
                        foundMore = true;
                        numberOfTypes = referencedTypes.Count;
                    }
                    else
                    {
                        foundMore = false;
                    }
                }
            }

            return referencedTypes;
        }

        private IEnumerable<string> GetReferencedTypesInNamespace(string typeName)
        {
            IEnumerable<string> referencedTypes = TypeRepository.GetReferencedTypes(typeName);
            return referencedTypes.Where(t => t.StartsWith(TypeRepository.Namespace));
        }
    }

}
