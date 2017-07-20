using System.IO;
using Structurizr.Api;
using Structurizr.Documentation;

namespace Structurizr.Examples
{
    
    /// <summary>
    /// An empty software architecture document using the arc42 template.
    /// 
    /// See https://structurizr.com/share/27791/documentation for the live version.
    /// </summary>
    public class Arc42DocumentationExample
    {
        
        private const long WorkspaceId = 27791;
        private const string ApiKey = "key";
        private const string ApiSecret = "secret";

        static void Main()
        {
            Workspace workspace = new Workspace("Documentation - arc42", "An empty software architecture document using the arc42 template.");
            Model model = workspace.Model;
            ViewSet views = workspace.Views;

            Person user = model.AddPerson("User", "A user of my software system.");
            SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");
            user.Uses(softwareSystem, "Uses");

            SystemContextView contextView = views.CreateSystemContextView(softwareSystem, "SystemContext", "An example of a System Context diagram.");
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            Styles styles = views.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.Person) { Shape = Shape.Person });

            Arc42Documentation documentation = new Arc42Documentation(workspace);

            // this is the Markdown version
            DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "arc42" + Path.DirectorySeparatorChar + "markdown");
            documentation.AddIntroductionAndGoalsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "01-introduction-and-goals.md")));
            documentation.AddConstraintsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "02-architecture-constraints.md")));
            documentation.AddContextAndScopeSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "03-system-scope-and-context.md")));
            documentation.AddSolutionStrategySection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "04-solution-strategy.md")));
            documentation.AddBuildingBlockViewSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "05-building-block-view.md")));
            documentation.AddRuntimeViewSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "06-runtime-view.md")));
            documentation.AddDeploymentViewSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "07-deployment-view.md")));
            documentation.AddCrosscuttingConceptsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "08-crosscutting-concepts.md")));
            documentation.AddArchitecturalDecisionsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "09-architecture-decisions.md")));
            documentation.AddRisksAndTechnicalDebtSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "10-quality-requirements.md")));
            documentation.AddQualityRequirementsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "11-risks-and-technical-debt.md")));
            documentation.AddGlossarySection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "12-glossary.md")));

            // this is the AsciiDoc version
//            DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "arc42" + Path.DirectorySeparatorChar + "asciidoc");
//            documentation.AddIntroductionAndGoalsSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "01-introduction-and-goals.adoc")));
//            documentation.AddConstraintsSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "02-architecture-constraints.adoc")));
//            documentation.AddContextAndScopeSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "03-system-scope-and-context.adoc")));
//            documentation.AddSolutionStrategySection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "04-solution-strategy.adoc")));
//            documentation.AddBuildingBlockViewSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "05-building-block-view.adoc")));
//            documentation.AddRuntimeViewSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "06-runtime-view.adoc")));
//            documentation.AddDeploymentViewSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "07-deployment-view.adoc")));
//            documentation.AddCrosscuttingConceptsSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "08-crosscutting-concepts.adoc")));
//            documentation.AddArchitecturalDecisionsSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "09-architecture-decisions.adoc")));
//            documentation.AddRisksAndTechnicalDebtSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "10-quality-requirements.adoc")));
//            documentation.AddQualityRequirementsSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "11-risks-and-technical-debt.adoc")));
//            documentation.AddGlossarySection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "12-glossary.adoc")));

            StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
            structurizrClient.PutWorkspace(WorkspaceId, workspace);
        }
        
    }
    
}