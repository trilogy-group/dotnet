using Structurizr.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Structurizr.Examples
{

    /// <summary>
    /// An empty software architecture document using the Structurizr template.
    /// 
    /// See https://structurizr.com/share/14181/documentation for the live version.
    /// </summary>
    class StructurizrDocumentationExample
        {

        private const long WorkspaceId = 14181;
        private const string ApiKey = "key";
        private const string ApiSecret = "secret";

        static void Main()
        {
            Workspace workspace = new Workspace("Documentation - Structurizr", "An empty software architecture document using the Structurizr template.");
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

            StructurizrDocumentation documentation = new StructurizrDocumentation(workspace);

            // this is the Markdown version
            DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "structurizr" + Path.DirectorySeparatorChar + "markdown");
            documentation.AddContextSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "01-context.md")));
            documentation.AddFunctionalOverviewSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "02-functional-overview.md")));
            documentation.AddQualityAttributesSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "03-quality-attributes.md")));
            documentation.AddConstraintsSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "04-constraints.md")));
            documentation.AddPrinciplesSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "05-principles.md")));
            documentation.AddSoftwareArchitectureSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "06-software-architecture.md")));
            documentation.AddDataSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "07-data.md")));
            documentation.AddInfrastructureArchitectureSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "08-infrastructure-architecture.md")));
            documentation.AddDeploymentSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "09-deployment.md")));
            documentation.AddDevelopmentEnvironmentSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "10-development-environment.md")));
            documentation.AddOperationAndSupportSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "11-operation-and-support.md")));
            documentation.AddDecisionLogSection(softwareSystem, DocumentationFormat.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "12-decision-log.md")));

            // this is the AsciiDoc version
//            DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "structurizr" + Path.DirectorySeparatorChar + "asciidoc");
//            documentation.AddContextSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "01-context.adoc")));
//            documentation.AddFunctionalOverviewSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "02-functional-overview.adoc")));
//            documentation.AddQualityAttributesSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "03-quality-attributes.adoc")));
//            documentation.AddConstraintsSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "04-constraints.adoc")));
//            documentation.AddPrinciplesSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "05-principles.adoc")));
//            documentation.AddSoftwareArchitectureSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "06-software-architecture.adoc")));
//            documentation.AddDataSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "07-data.adoc")));
//            documentation.AddInfrastructureArchitectureSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "08-infrastructure-architecture.adoc")));
//            documentation.AddDeploymentSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "09-deployment.adoc")));
//            documentation.AddDevelopmentEnvironmentSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "10-development-environment.adoc")));
//            documentation.AddOperationAndSupportSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "11-operation-and-support.adoc")));
//            documentation.AddDecisionLogSection(softwareSystem, DocumentationFormat.AsciiDoc, new FileInfo(Path.Combine(documentationRoot.FullName, "12-decision-log.adoc")));

            StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
            structurizrClient.PutWorkspace(WorkspaceId, workspace);
        }

    }
}
