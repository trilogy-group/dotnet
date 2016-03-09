using Structurizr.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Structurizr.ComponentFinder
{

    /// <summary>
    /// This is the base class for component finder strategies that use the standard .NET assembly
    /// scanning facility to find components.
    /// </summary>
    public abstract class AbstractAssemblyScanningComponentFinderStrategy : ComponentFinderStrategy
    {

        public AbstractAssemblyScanningComponentFinderStrategy()
        {
        }

        public override ICollection<Component> FindComponents()
        {
            IEnumerable<Type> types =   from a in AppDomain.CurrentDomain.GetAssemblies()
                                        from t in a.GetTypes()
                                        select t;

            List<Component> components = new List<Component>();

            foreach (Type type in types)
            {
                System.Console.WriteLine("Testing " + type.FullName);

                if (InNamespace(type) && Matches(type))
                {
                    if (type.IsInterface) {
                        components.Add(this.ComponentFinder.FoundComponent(type.FullName, null, null, null, null));
                    }
                    else
                    {
                        components.Add(this.ComponentFinder.FoundComponent(null, type.FullName, null, null, null));
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

        public abstract bool Matches(Type type);

    }
}
