using Structurizr.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Structurizr.Analysis
{

    /// <summary>
    /// This is the base class for component finder strategies that use the standard .NET assembly
    /// scanning facility to find components.
    /// </summary>
    public class AssemblyScanningComponentFinderStrategy : ComponentFinderStrategy
    {

        private List<ITypeMatcher> typeMatchers = new List<ITypeMatcher>();

        public AssemblyScanningComponentFinderStrategy(params ITypeMatcher[] typeMatchers)
        {
            this.typeMatchers.AddRange(typeMatchers);
        }

        public override ICollection<Component> FindComponents()
        {
            List<Component> components = new List<Component>();

            IEnumerable<Type> types =   from a in AppDomain.CurrentDomain.GetAssemblies()
                                        from t in a.GetTypes()
                                        where InNamespace(t)
                                        select t;

            foreach (Type type in types)
            {
                foreach (ITypeMatcher typeMatcher in this.typeMatchers)
                {
                    if (typeMatcher.Matches(type))
                    {
                        if (type.IsInterface)
                        {
                            components.Add(this.ComponentFinder.FoundComponent(type.Name, type.FullName, null, typeMatcher.GetDescription(), typeMatcher.GetTechnology(), null));
                        }
                        else
                        {
                            components.Add(this.ComponentFinder.FoundComponent(type.Name, null, type.FullName, typeMatcher.GetDescription(), typeMatcher.GetTechnology(), null));
                        }
                    }
                }
            }

            return components;
        }

        public override void FindDependencies()
        {
        }

        private bool InNamespace(Type type)
        {
            return type.Namespace != null && type.Namespace.StartsWith(ComponentFinder.Namespace);
        }

    }
}
