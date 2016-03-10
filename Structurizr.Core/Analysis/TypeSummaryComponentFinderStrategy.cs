using System.Collections.Generic;
using Structurizr.Model;
using System;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace Structurizr.Analysis
{
    public class TypeSummaryComponentFinderStrategy : ComponentFinderStrategy
    {

        public string PathToSolution { get; set; }
        public string ProjectName { get; set; }

        public TypeSummaryComponentFinderStrategy(string pathToSolution, string projectName)
        {
            this.PathToSolution = pathToSolution;
            this.ProjectName = projectName;
        }

        public override ICollection<Component> FindComponents()
        {
            MSBuildWorkspace msWorkspace = MSBuildWorkspace.Create();

            Solution solution = msWorkspace.OpenSolutionAsync(PathToSolution).Result;
            Project project = solution.Projects.Where(p => p.Name == ProjectName).First();
            Compilation compilation = project.GetCompilationAsync().Result;
            foreach (Component component in ComponentFinder.Container.Components)
            {
                try {
                    string type = component.Type.Substring(0, component.Type.IndexOf(',')); // remove the assembly name from the type
                    INamedTypeSymbol symbol = compilation.GetTypeByMetadataName(type);
                    foreach (Microsoft.CodeAnalysis.Location location in symbol.Locations)
                    {
                        if (location.IsInSource)
                        {
                            component.SourcePath = location.SourceTree.FilePath;
                        }
                    }
                    string xml = symbol.GetDocumentationCommentXml();
                    if (xml != null && xml.Trim().Length > 0)
                    {
                        XDocument xdoc = XDocument.Parse(xml);
                        String comment = xdoc.Descendants("summary").First().Value.Trim();
                        component.Description = comment;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine("Could not get summary comment for " + component.Name + ": " + e.Message);
                }
            }

            return new List<Component>();
        }

        public override void FindDependencies()
        {
        }

    }
}
