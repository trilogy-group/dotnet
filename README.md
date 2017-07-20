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
SystemContextView contextView = viewSet.CreateSystemContextView(softwareSystem, "SystemContext", "An example of a System Context diagram.");
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

* Introduction
    * [Getting started](docs/getting-started.md)
    * [About Structurizr and how it compares to other tooling](https://structurizr.com/help/about)
    * [Basic concepts](https://structurizr.com/help/concepts) (workspaces, models, views and documentation)
    * [C4 model](https://structurizr.com/help/c4)
    * [Binaries](docs/binaries.md)
    * [API Client](docs/api-client.md)
* Diagrams
    * [System Context diagram](docs/system-context-diagram.md)
    * [Container diagram](docs/container-diagram.md)
    * [Component diagram](docs/component-diagram.md)
    * [Dynamic diagram](docs/dynamic-diagram.md)
    * [Enterprise Context diagram](docs/enterprise-context-diagram.md)
    * [Styling elements](docs/styling-elements.md)
    * [Styling relationships](docs/styling-relationships.md)
* Documentation
    * [Documentation overview](docs/documentation.md)
    * [Structurizr](docs/documentation-structurizr.md)
    * [arc42](docs/documentation-arc42.md)
    * [Viewpoints and Perspectives](docs/documentation-viewpoints-and-perspectives.md)
* Other
    * [Client-side encryption](docs/client-side-encryption.md)
* Related projects
    * [structurizr-java](https://github.com/structurizr/java): Structurizr for Java
    * [cat-boot-structurizr](https://github.com/Catalysts/cat-boot/tree/master/cat-boot-structurizr): A way to apply dependency management to help modularise Structurizr code.
    * [java-starter](https://github.com/structurizr/java-starter): A simple starting point for using Structurizr for Java
    * [structurizr-groovy](https://github.com/tidyjava/structurizr-groovy): An initial version of a Groovy wrapper around Structurizr for Java.
    