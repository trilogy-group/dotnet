using System.IO;
using Structurizr.Api;
using Structurizr.Documentation;

namespace Structurizr.Examples
{
    
    /// <summary>
    /// An empty software architecture document using the "Viewpoints and Perspectives" template.
    /// 
    /// See https://structurizr.com/share/36371/documentation for the live version.
    /// </summary>
    public class ViewpointsAndPerspectivesDocumentationExample
    {
        
        private const long WorkspaceId = 36371;
        private const string ApiKey = "key";
        private const string ApiSecret = "secret";

        static void Main()
        {
            Workspace workspace = new Workspace("Documentation - Viewpoints and Perspectives", "An empty software architecture document using the Viewpoints and Perspectives template.");
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

            ViewpointsAndPerspectivesDocumentation documentation = new ViewpointsAndPerspectivesDocumentation(workspace);

            // this is the Markdown version
            DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "viewpointsandperspectives" + Path.DirectorySeparatorChar + "markdown");
            documentation.AddIntroductionSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "01-introduction.md")));
            documentation.AddGlossarySection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "02-glossary.md")));
            documentation.AddSystemStakeholdersAndRequirementsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "03-system-stakeholders-and-requirements.md")));
            documentation.AddArchitecturalForcesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "04-architectural-forces.md")));
            documentation.AddArchitecturalViewsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "05-architectural-views")));
            documentation.AddSystemQualitiesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "06-system-qualities.md")));
            documentation.AddAppendicesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "07-appendices.md")));

            // this is the AsciiDoc version
//            DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "viewpointsandperspectives" + Path.DirectorySeparatorChar + "asciidoc");
//            documentation.AddIntroductionSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "01-introduction.adoc")));
//            documentation.AddGlossarySection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "02-glossary.adoc")));
//            documentation.AddSystemStakeholdersAndRequirementsSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "03-system-stakeholders-and-requirements.adoc")));
//            documentation.AddArchitecturalForcesSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "04-architectural-forces.adoc")));
//            documentation.AddArchitecturalViewsSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "05-architectural-views")));
//            documentation.AddSystemQualitiesSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "06-system-qualities.adoc")));
//            documentation.AddAppendicesSection(softwareSystem, Format.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "07-appendices.adoc")));

            StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
            structurizrClient.PutWorkspace(WorkspaceId, workspace);
        }
        
    }
    
}