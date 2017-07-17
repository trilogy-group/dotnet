using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Mono.Cecil;

namespace Structurizr.Cecil
{
    public static class AssemblyDefinitionExtensions
    {
        public static IEnumerable<AssemblyDefinition> EnumerateReferencedAssemblies(this AssemblyDefinition assembly,
            bool includeSelf = true)
        {
            var references = new HashSet<MetadataToken>();

            var queue = new Queue<AssemblyDefinition>();
            queue.Enqueue(assembly);

            if (includeSelf)
            {
                yield return assembly;
            }

            while (queue.Count > 0)
            {
                var assm = queue.Dequeue();

                if (references.Contains(assm.MetadataToken)) continue;
                references.Add(assm.MetadataToken);

                var refs = from m in assm.Modules from r in m.AssemblyReferences select r;
                foreach (var r in refs)
                {
                    AssemblyDefinition refAssm;
                    try
                    {
                        refAssm = assembly.MainModule.AssemblyResolver.Resolve(r);
                        queue.Enqueue(refAssm);
                    }
                    catch (AssemblyResolutionException e)
                    {
                        Debug.WriteLine(e);
                        refAssm = null;
                    }

                    if (refAssm != null)
                        yield return refAssm;
                }
            }
        }
    }
}
