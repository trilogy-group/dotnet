![Structurizr](docs/images/structurizr-banner.png)

# Structurizr for .NET

This GitHub repository is a .NET library to create software architecture models that are compatible with [Structurizr](https://structurizr.com), a SaaS to create web-based software architecture diagrams. It's an implementation of the "C4 software architecture model", as described in Simon Brown's FREE [The Art of Visualising Software Architecture](https://leanpub.com/visualising-software-architecture) book. In a nutshell:

1. Create a software architecture model using .NET code, either manually or by extracting information from an existing codebase.
1. Upload the model (as a JSON document) to [Structurizr](https://structurizr.com) using the web API.
1. Visualise and share the resulting software architecture diagrams ([example](https://structurizr.com/public/1)).

![An overview of Structurizr](docs/images/structurizr-overview.png)

__Please note:__ This is a work in progess.

## Table of contents

1. [Getting started](#getting-started)
1. [Styling elements](docs/styling-elements.md)
1. [Styling relationships](docs/styling-relationships.md)
 
## Getting started

Here is a quick overview of how to get started with "Structurizr for .NET" so that you can create a software architecture model as code. You can find the code [here](https://github.com/structurizr/dotnet/blob/master/Examples/GettingStarted.cs). For more examples, please see the [Examples project](https://github.com/structurizr/dotnet/blob/master/Examples).

### 1. Dependencies

The "Structurizr for .NET" binaries will be published on NuGet in the near future.

Name                                          | Description
-------------------------------------------   | ---------------------------------------------------------------------------------------------------------------------------
StructurizrCore | The core library that can used to create models.
StructurizrClient | The structurizr.com API client for .NET for uploading models.

### 2. Create a model

The first step is to create a workspace in which the software architecture model will reside.

```c#
Workspace workspace = new Workspace("My model", "This is a model of my software system.");
Model.Model model = workspace.Model;
```

Now let's add some elements to the model.

```c#
Person user = model.AddPerson("User", "A user of my software system.");
SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");
user.Uses(softwareSystem, "Uses");
```

### 3. Create some views

With the model created, we need to create some views with which to visualise it.

```c#
ViewSet viewSet = workspace.Views;
SystemContextView contextView = viewSet.CreateContextView(softwareSystem);
contextView.AddAllSoftwareSystems();
contextView.AddAllPeople();
```

### 4. Add some colour

Elements and relationships can be styled by specifying colours, sizes and shapes.

```c#
Styles styles = viewSet.Configuration.Styles;
styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#A4B7C9", Color = "#000000" });
styles.Add(new ElementStyle(Tags.Person) { Background = "#728da5", Color = "#ffffff" });
```

### 5. Upload to Structurizr

structurizr.com provides an API to get and put workspaces directly from/to your Structurizr account as follows.

```c#
StructurizrClient structurizrClient = new StructurizrClient("key", "secret");
structurizrClient.PutWorkspace(1234, workspace);
```

> In order to upload your model to Structurizr using the web API, you'll need to [sign up](https://structurizr.com/signup) to get your own API key and secret.

The result is a diagram like this (once you've dragged the boxes around).

![Getting Started with Structurizr for .NET](docs/images/getting-started.png)

#### Retaining diagram layout information

Once you have uploaded your model to Structurizr and organised the boxes on the diagrams, you'll probably want to retain the diagram layout next time you upload the model. To do this, you can use the `MergeWorkspace` helper method on the `StructurizrClient`.

```c#
structurizrClient.MergeWorkspace(1234, workspace);
```

This will get the current version of the workspace via the API, merge the diagram layout information, and then upload the new version via the API. See [API Client](docs/api-client.md) for more details.