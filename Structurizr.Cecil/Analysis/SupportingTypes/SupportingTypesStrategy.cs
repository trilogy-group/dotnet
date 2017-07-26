using System.Collections.Generic;

namespace Structurizr.Analysis
{
    public abstract class SupportingTypesStrategy
    {

        protected internal ITypeRepository TypeRepository { get; internal set; }

        public abstract HashSet<string> FindSupportingTypes(Component component);

    }
}
