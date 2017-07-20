# Structurizr documentation template

Structurizr for .NET includes an implementation of the "software guidebook" from Simon Brown's [Software Architecture for Developers](https://leanpub.com/visualising-software-architecture) book, which can be used to document your software architecture.

## Example

To use this template, create an instance of the [StructurizrDocumentation](https://github.com/structurizr/dotnet/blob/master/Structurizr.Core/Documentation/StructurizrDocumentation.cs) class.
You can then add documentation sections as needed, each associated with a software system in your software architecture model, using Markdown or AsciiDoc. For example:

```c#
StructurizrDocumentation documentation = new StructurizrDocumentation(workspace);

DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "structurizr" + Path.DirectorySeparatorChar + "markdown");
documentation.AddContextSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "01-context.md")));
documentation.AddFunctionalOverviewSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "02-functional-overview.md")));
documentation.AddQualityAttributesSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "03-quality-attributes.md")));
documentation.AddConstraintsSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "04-constraints.md")));
documentation.AddPrinciplesSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "05-principles.md")));
documentation.AddSoftwareArchitectureSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "06-software-architecture.md")));
documentation.AddDataSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "07-data.md")));
documentation.AddInfrastructureArchitectureSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "08-infrastructure-architecture.md")));
documentation.AddDeploymentSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "09-deployment.md")));
documentation.AddDevelopmentEnvironmentSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "10-development-environment.md")));
documentation.AddOperationAndSupportSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "11-operation-and-support.md")));
documentation.AddDecisionLogSection(softwareSystem, Format.Markdown,new FileInfo(Path.Combine(documentationRoot.FullName, "12-decision-log.md")));
```

Structurizr will create navigation controls based upon the the sections in the documentation, and the software systems they have been associated with. This particular example is rendered as follows: 

![Documentation based upon the Structurizr template](images/documentation-structurizr-1.png)

See [StructurizrDocumentationExample.cs](https://github.com/structurizr/dotnet/blob/master/Structurizr.Examples/StructurizrDocumentationExample.cs) for the full code, and [https://structurizr.com/share/14181/documentation](https://structurizr.com/share/14181/documentation) to see the rendered documentation.

## More information

See [Help - Documentation](https://structurizr.com/help/documentation) for more information about how headings are rendered, and how to embed diagrams from you workspace into the documentation.