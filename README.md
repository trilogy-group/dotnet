![Structurizr](docs/images/structurizr-banner.png)

# Structurizr for .NET

This GitHub repository is a collection of tooling to help you visualise, document and explore the software architecture of a software system. In summary, it allows you to create a software architecture model based upon Simon Brown's [C4 model](https://structurizr.com/help/c4) using C# code, and then export that model to be visualised using tools such as:

1. [Structurizr](https://structurizr.com): a web-based software as a service and on-premises product to render software architecture diagrams and supplementary Markdown/AsciiDoc documentation.
1. [PlantUML](docs/plantuml.md): a tool to create UML diagrams using a simple textual domain specific language.

As an example, the following C# code can be used to create a software architecture model that describes a user using a software system.

```c#
Workspace workspace = new Workspace("Getting Started", "This is a model of my software system.");
Model model = workspace.Model;

Person user = model.AddPerson("User", "A user of my software system.");
SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");
user.Uses(softwareSystem, "Uses");

ViewSet viewSet = workspace.Views;
SystemContextView contextView = viewSet.CreateSystemContextView(softwareSystem, "context", "An example of a System Context diagram.");
contextView.AddAllSoftwareSystems();
contextView.AddAllPeople();

Styles styles = viewSet.Configuration.Styles;
styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd", Color = "#ffffff" });
styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });
```

If using [Structurizr](https://structurizr.com), the end-result, after adding some styling and positioning the diagram elements, is a system context diagram like this:

![Getting Started with Structurizr for .NET](docs/images/getting-started.png)

You can see the live workspace at [https://structurizr.com/share/25441](https://structurizr.com/share/25441).

## Table of contents

1. [Getting started](docs/getting-started)
1. [Basic concepts](docs/basic-concepts.md)
1. [Styling elements](docs/styling-elements.md)
1. [Styling relationships](docs/styling-relationships.md)
1. [Client-side encryption](docs/client-side-encryption.md)
1. [Documentation](docs/documentation.md)