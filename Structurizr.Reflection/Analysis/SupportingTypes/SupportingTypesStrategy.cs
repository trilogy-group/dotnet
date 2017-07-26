using System.Collections.Generic;

namespace Structurizr.Analysis
{
    public abstract class SupportingTypesStrategy
    {

        public ITypeRepository TypeRepository { get; set; }

        public abstract HashSet<string> FindSupportingTypes(Component component);

    }

}