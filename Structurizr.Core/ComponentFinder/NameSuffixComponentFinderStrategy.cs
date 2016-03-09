using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structurizr.ComponentFinder
{
    public class NameSuffixComponentFinderStrategy : AbstractAssemblyScanningComponentFinderStrategy
    {

        public string Suffix { get; private set; }

        public NameSuffixComponentFinderStrategy(string suffix)
        {
            this.Suffix = suffix;
        }

        public override bool Matches(Type type)
        {
            return type.Name.EndsWith(Suffix);
        }

    }
}
