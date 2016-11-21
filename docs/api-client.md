# API client

This page provides a quick overview of how to use the API client.

## Configuration

To configure the API client, simply provide values for the API key and API secret programmatically when creating a ```StructurizrClient``` instance. Each workspace has its own API key and secret, the values for which can be found on [your dashboard](https://structurizr.com/dashboard).

```c#
StructurizrClient structurizrClient = new StructurizrClient("key", "secret");
```

## Usage

The following operations are available on the API client.

### 1. GetWorkspace

This allows you to get the content of a workspace.

```c#
Workspace workspace = structurizrClient.GetWorkspace(1234);
```

By default, a copy of the workspace (as JSON) is archived to the current working directory. You can modify this behaviour by setting the ```WorkspaceArchiveLocation``` property. A ```null``` value will disable archiving.

### 2. PutWorkspace

This allows you to overwrite an existing workspace.   If the ```MergeFromRemote``` property (on the ```StructurizrClient``` instance) is set to ```true``` (this is the default), any layout information (i.e. the location of boxes on diagrams) is preserved where possible (i.e. where diagram elements haven't been renamed).

```c#
structurizrClient.PutWorkspace(1234, workspace);
```

