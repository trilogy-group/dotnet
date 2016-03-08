using Structurizr.Client;
using Structurizr.Model;
using Structurizr.View;

namespace Structurizr.Examples
{
    class FinancialRiskSystem
    {

        private const string AlertTag = "Alert";

        static void Main(string[] args)
        {
            Workspace workspace = new Workspace("Financial Risk System", "This is a simple (incomplete) example C4 model based upon the financial risk system architecture kata, which can be found at http://bit.ly/sa4d-risksystem");
            Model.Model model = workspace.Model;

            // create the basic model
            SoftwareSystem financialRiskSystem = model.AddSoftwareSystem(Location.Internal, "Financial Risk System", "Calculates the bank's exposure to risk for product X");

            Person businessUser = model.AddPerson(Location.Internal, "Business User", "A regular business user");
            businessUser.Uses(financialRiskSystem, "Views reports using");

            Person configurationUser = model.AddPerson(Location.Internal, "Configuration User", "A regular business user who can also configure the parameters used in the risk calculations");
            configurationUser.Uses(financialRiskSystem, "Configures parameters using");

            SoftwareSystem tradeDataSystem = model.AddSoftwareSystem(Location.Internal, "Trade Data System", "The system of record for trades of type X");
            financialRiskSystem.Uses(tradeDataSystem, "Gets trade data from");

            SoftwareSystem referenceDataSystem = model.AddSoftwareSystem(Location.Internal, "Reference Data System", "Manages reference data for all counterparties the bank interacts with");
            financialRiskSystem.Uses(referenceDataSystem, "Gets counterparty data from");

            SoftwareSystem emailSystem = model.AddSoftwareSystem(Location.Internal, "E-mail system", "Microsoft Exchange");
            financialRiskSystem.Uses(emailSystem, "Sends a notification that a report is ready to");
            emailSystem.Delivers(businessUser, "Sends a notification that a report is ready to", "E-mail message", InteractionStyle.Asynchronous);

            SoftwareSystem centralMonitoringService = model.AddSoftwareSystem(Location.Internal, "Central Monitoring Service", "The bank-wide monitoring and alerting dashboard");
            financialRiskSystem.Uses(centralMonitoringService, "Sends critical failure alerts to", "SNMP", InteractionStyle.Asynchronous).AddTags(AlertTag);

            SoftwareSystem activeDirectory = model.AddSoftwareSystem(Location.Internal, "Active Directory", "Manages users and security roles across the bank");
            financialRiskSystem.Uses(activeDirectory, "Uses for authentication and authorisation");

            // create some views
            ViewSet viewSet = workspace.Views;
            SystemContextView contextView = viewSet.CreateContextView(financialRiskSystem);
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            // tag and style some elements
            Styles styles = viewSet.Configuration.Styles;
            financialRiskSystem.AddTags("Risk System");

            styles.Add(new ElementStyle(Tags.Element) { Color = "#ffffff", FontSize = 34 });
            styles.Add(new ElementStyle("Risk System") { Background = "#550000", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Width = 650, Height = 400, Background = "#801515", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle(Tags.Person) { Width = 550, Background = "#d46a6a", Shape = Shape.Person });

            styles.Add(new RelationshipStyle(Tags.Relationship) { Thickness = 4, Dashed = false, FontSize = 32, Width = 400 });
            styles.Add(new RelationshipStyle(Tags.Synchronous) { Dashed = false });
            styles.Add(new RelationshipStyle(Tags.Asynchronous) { Dashed = true });
            styles.Add(new RelationshipStyle(AlertTag) { Color = "#ff0000" });

            // and upload the model to structurizr.com
            StructurizrClient structurizrClient = new StructurizrClient("key", "secret");
            structurizrClient.PutWorkspace(9481, workspace);

            System.Console.ReadKey();
        }
    }
}
