# Documentation

In addition to diagrams, Structurizr lets you create supplementary documentation using the Markdown format. See [Documentation](https://structurizr.com/help/documentation) on the Structurizr website for more information about this feature.

![Example documentation](images/documentation-1.png)

## Adding documentation to your workspace

The following [example code](https://github.com/structurizr/dotnet/blob/master/Structurizr.Examples/FinancialRiskSystem.cs) shows how to add documentation to your workspace.

```c#
SoftwareSystem financialRiskSystem = model.AddSoftwareSystem(Location.Internal, "Financial Risk System", "Calculates the bank's exposure to risk for product X");

Documentation documentation = workspace.Documentation;
FileInfo documentationRoot = new FileInfo(@"..\..\FinancialRiskSystem");
documentation.Add(financialRiskSystem, SectionType.Context, DocumentationFormat.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "context.md")));
documentation.Add(financialRiskSystem, SectionType.FunctionalOverview, DocumentationFormat.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "functional-overview.md")));
documentation.Add(financialRiskSystem, SectionType.QualityAttributes, DocumentationFormat.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "quality-attributes.md")));
```

In this example, three sections (Context, Functional Overview and Quality Attributes) are added to the workspace, each of which is associated with the "Financial Risk System" software system that exists in the model. The content for the sections is pulled from the specified file and included into the workspace.

The documentation is broken up into a number of sections as follows, which are represented by the [SectionType enum](https://github.com/structurizr/dotnet/blob/master/Structurizr.Core/Documentation/SectionType.cs).

- Context
- Functional Overview
- Quality Attributes
- Constraints
- Principles
- Software Architecture
- Containers
- Components
- Code
- Data
- Infrastructure Architecture
- Deployment
- Development Environment
- Operation and Support
- Decision Log

All sections must be associated with a software system in the model, except for "Components", which needs to be associated with a container.

### Images

As shown in [this example Markdown file](https://github.com/structurizr/dotnet/blob/master/Structurizr.Examples/FinancialRiskSystem/functional-overview.md), images can be included using the regular Markdown syntax. For this to work, the image files must be hosted externally (e.g. on your own web server) or uploaded with your workspace using the ```AddImages()``` or ```AddImage()``` methods on the [Documentation class](https://github.com/structurizr/dotnet/blob/master/Structurizr.Core/Documentation/Documentation.cs).

```c#
documentation.AddImages(documentationRoot);
```

### Software architecture diagrams

Software architecture diagrams from the workspace can be embedded within the documentation sections using an additional special syntax. See [Documentation](https://structurizr.com/help/documentation) on the Structurizr website for more information.
