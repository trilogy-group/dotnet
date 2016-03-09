using Structurizr.Model;
using System.Collections.Generic;

namespace Structurizr.ComponentFinder
{
    public abstract class ComponentFinderStrategy
    {

        public ComponentFinder ComponentFinder { get; internal set; }

        public abstract ICollection<Component> FindComponents();

        public abstract void FindDependencies();

    }
}
