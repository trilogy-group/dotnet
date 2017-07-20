# Viewpoints and Perspectives documentation template

Structurizr for .NET includes an implementation of the [Viewpoints and Perspectives documentation template](http://www.viewpoints-and-perspectives.info), which can be used to document your software architecture.

## Example

To use this template, create an instance of the [ViewpointsAndPerspectivesDocumentation](https://github.com/structurizr/dotnet/blob/master/Structurizr.Core/Documentation/ViewpointsAndPerspectivesDocumentation.cs) class.
You can then add documentation sections as needed, each associated with a software system in your software architecture model, using Markdown or AsciiDoc. For example:

```c#
ViewpointsAndPerspectivesDocumentation documentation = new ViewpointsAndPerspectivesDocumentation(workspace);

DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "viewpointsandperspectives" + Path.DirectorySeparatorChar + "markdown");
documentation.AddIntroductionSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "01-introduction.md")));
documentation.AddGlossarySection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "02-glossary.md")));
documentation.AddSystemStakeholdersAndRequirementsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "03-system-stakeholders-and-requirements.md")));
documentation.AddArchitecturalForcesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "04-architectural-forces.md")));
documentation.AddArchitecturalViewsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "05-architectural-views")));
documentation.AddSystemQualitiesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "06-system-qualities.md")));
documentation.AddAppendicesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(documentationRoot.FullName, "07-appendices.md")));
```

Structurizr will create navigation controls based upon the the sections in the documentation, and the software systems they have been associated with. This particular example is rendered as follows: 

![Documentation based upon the Viewpoints and Perspectives template](images/documentation-viewpoints-and-perspectives-1.png)

See [ViewpointsAndPerspectivesDocumentationExample.cs](https://github.com/structurizr/dotnet/blob/master/Structurizr.Examples/ViewpointsAndPerspectivesDocumentationExample.cs) for the full code, and [https://structurizr.com/share/36371/documentation](https://structurizr.com/share/36371/documentation) to see the rendered documentation.

## More information

See [Help - Documentation](https://structurizr.com/help/documentation) for more information about how headings are rendered, and how to embed diagrams from you workspace into the documentation.