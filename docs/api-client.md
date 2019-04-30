# API client

The Structurizr for .NET library includes a client for the [Structurizr web API](https://api.structurizr.com), which allows you to get and put workspaces using JSON over HTTPS. This page provides a quick overview of how to use the API client.

## Configuration

To configure the API client, simply provide values for the API key and API secret programmatically when creating a ```StructurizrClient``` instance. Each workspace has its own API key and secret, the values for which can be found on [your dashboard](https://structurizr.com/dashboard).

```c#
StructurizrClient structurizrClient = new StructurizrClient("key", "secret");
```

If you're using the [on-premises installation](https://structurizr.com/help/on-premises-ui), there is a three argument version of the constructor where you can also specify the API URL.

```c#
StructurizrClient structurizrClient = new StructurizrClient("url", "key", "secret");
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

### 3. LockWorkspace

If your workspace supports sharing (not available with the Free Plan), you can optionally attempt to lock your workspace before writing to it, to prevent concurrent updates.

```c#
structurizrClient.LockWorkspace(1234);
```

This method returns a boolean; ```true``` if the workspace could be locked, ```false``` otherwise.

### 4. UnlockWorkspace

Similarly, you can unlock a workspace.

```c#
structurizrClient.UnlockWorkspace(1234);
```

This method also returns a boolean; ```true``` if the workspace could be unlocked, ```false``` otherwise.

