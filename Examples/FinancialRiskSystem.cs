using Structurizr.Client;
using Structurizr.IO.Json;
using Structurizr.Model;
using Structurizr.View;
using System.IO;

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

            Container webApplication = financialRiskSystem.AddContainer("Web Application", "Allows users to view reports and modify risk calculation parameters", "ASP.NET MVC");
            businessUser.Uses(webApplication, "Views reports using");
            configurationUser.Uses(webApplication, "Modifies risk calculation parameters using");
            webApplication.Uses(activeDirectory, "Uses for authentication and authorisation");

            Container batchProcess = financialRiskSystem.AddContainer("Batch Process", "Calculates the risk", "Windows Service");
            batchProcess.Uses(emailSystem, "Sends a notification that a report is ready to");
            batchProcess.Uses(tradeDataSystem, "Gets trade data from");
            batchProcess.Uses(referenceDataSystem, "Gets counterparty data from");
            batchProcess.Uses(centralMonitoringService, "Sends critical failure alerts to", "SNMP", InteractionStyle.Asynchronous).AddTags(AlertTag);

            // create some views
            ViewSet viewSet = workspace.Views;
            SystemContextView contextView = viewSet.CreateContextView(financialRiskSystem);
            contextView.PaperSize = PaperSize.A4_Landscape;
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            ContainerView containerView = viewSet.CreateContainerView(financialRiskSystem);
            containerView.AddAllElements();

            // tag and style some elements
            Styles styles = viewSet.Configuration.Styles;
            financialRiskSystem.AddTags("Risk System");

            styles.Add(new ElementStyle(Tags.Element) { Color = "#ffffff", FontSize = 34 });
            styles.Add(new ElementStyle("Risk System") { Background = "#FACC2E", Color = "#000000" });
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Width = 650, Height = 400, Background = "#801515", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle(Tags.Person) { Width = 550, Background = "#d46a6a", Shape = Shape.Person });

            styles.Add(new RelationshipStyle(Tags.Relationship) { Thickness = 4, Dashed = false, FontSize = 32, Width = 400 });
            styles.Add(new RelationshipStyle(Tags.Synchronous) { Dashed = false });
            styles.Add(new RelationshipStyle(Tags.Asynchronous) { Dashed = true });
            styles.Add(new RelationshipStyle(AlertTag) { Color = "#ff0000" });

            StringWriter stringWriter = new StringWriter();
            JsonWriter jsonWriter = new JsonWriter(true);
            jsonWriter.Write(workspace, stringWriter);
            string json = stringWriter.ToString();
            //System.Console.WriteLine(json);

            // and upload the model to structurizr.com
            StructurizrClient structurizrClient = new StructurizrClient("key", "secret");
            structurizrClient.MergeWorkspace(9481, workspace);

            //System.Console.ReadKey();
        }
    }
}
