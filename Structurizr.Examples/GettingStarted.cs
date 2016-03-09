using Structurizr.Client;
using Structurizr.Model;
using Structurizr.View;

namespace Structurizr.Examples
{
    class GettingStarted
    {

        static void Main(string[] args)
        {
            Workspace workspace = new Workspace("My model", "This is a model of my software system.");
            Model.Model model = workspace.Model;

            Person user = model.AddPerson("User", "A user of my software system.");
            SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");
            user.Uses(softwareSystem, "Uses");

            ViewSet viewSet = workspace.Views;
            SystemContextView contextView = viewSet.CreateContextView(softwareSystem);
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            Styles styles = viewSet.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#a4b7c9", Color = "#000000" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#728da5", Color = "#ffffff" });

            StructurizrClient structurizrClient = new StructurizrClient("key", "secret");
            structurizrClient.PutWorkspace(1234, workspace);
        }

    }
}
