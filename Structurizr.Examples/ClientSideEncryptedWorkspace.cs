using Structurizr.Client;
using Structurizr.Encryption;
using Structurizr.Model;
using Structurizr.View;

namespace Structurizr.Examples
{
    class ClientSideEncryptedWorkspace
    {

        static void Main(string[] args)
        {
            Workspace workspace = new Workspace("Client-side encrypted workspace", "This is a client-side encrypted workspace. The passphrase is 'password'.");
            Model.Model model = workspace.Model;

            Person user = model.AddPerson("User", "A user of my software system.");
            SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");
            user.Uses(softwareSystem, "Uses");

            ViewSet viewSet = workspace.Views;
            SystemContextView contextView = viewSet.CreateContextView(softwareSystem);
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            Styles styles = viewSet.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#d34407", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#f86628", Color = "#ffffff" });

            StructurizrClient structurizrClient = new StructurizrClient("key", "secret");
            structurizrClient.EncryptionStrategy = new AesEncryptionStrategy("password");
            structurizrClient.MergeWorkspace(41, workspace);
        }

    }
}
