# arc42 documentation template

Structurizr for .NET includes an implementation of the [arc42 documentation template](http://arc42.org), which can be used to document your software architecture.

## Example

To use this template, create an instance of the [Arc42Documentation](https://github.com/structurizr/dotnet/blob/master/Structurizr.Core/Documentation/Arc42Documentation.cs) class.
You can then add documentation sections as needed, each associated with a software system in your software architecture model, using Markdown or AsciiDoc. For example:

```c#
Arc42Documentation documentation = new Arc42Documentation(workspace);

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
```

Structurizr will create navigation controls based upon the the sections in the documentation, and the software systems they have been associated with. This particular example is rendered as follows: 

![Documentation based upon the arc42 template](images/documentation-arc42-1.png)

See [Arc42DocumentationExample.cs](https://github.com/structurizr/dotnet/blob/master/Structurizr.Examples/Arc42DocumentationExample.cs) for the full code, and [https://structurizr.com/share/27791/documentation](https://structurizr.com/share/27791/documentation) to see the rendered documentation.

## More information

See [Help - Documentation](https://structurizr.com/help/documentation) for more information about how headings are rendered, and how to embed diagrams from you workspace into the documentation.