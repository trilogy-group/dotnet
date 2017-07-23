using System.IO;
using System.Linq;
using Structurizr.Api;
using Structurizr.Core.Util;
using Structurizr.Documentation;
using Structurizr.Util;

namespace Structurizr.Examples
{
    
    /// <summary>
    /// This is an example workspace to illustrate the key features of Structurizr,
    /// based around a fictional Internet Banking System for Big Bank plc.
    ///
    /// The live workspace is available to view at https://structurizr.com/share/36141
    /// </summary>
    public class BigBankPlc
    {
        
        private const long WorkspaceId = 36141;
        private const string ApiKey = "key";
        private const string ApiSecret = "secret";

        private const string DatabaseTag = "Database";

        private static Workspace Create(bool usePaidFeatures)
        {
            Workspace workspace = new Workspace("Big Bank plc", "This is an example workspace to illustrate the key features of Structurizr, based around a fictional online banking system.");
            Model model = workspace.Model;
            ViewSet views = workspace.Views;
    
            model.Enterprise = new Enterprise("Big Bank plc");
    
            // people and software systems
            Person customer = model.AddPerson(Location.External, "Customer", "A customer of the bank.");
    
            SoftwareSystem internetBankingSystem = model.AddSoftwareSystem(Location.Internal, "Internet Banking System", "Allows customers to view information about their bank accounts and make payments.");
            customer.Uses(internetBankingSystem, "Uses");
    
            SoftwareSystem mainframeBankingSystem = model.AddSoftwareSystem(Location.Internal, "Mainframe Banking System", "Stores all of the core banking information about customers, accounts, transactions, etc.");
            internetBankingSystem.Uses(mainframeBankingSystem, "Uses");
    
            SoftwareSystem atm = model.AddSoftwareSystem(Location.Internal, "ATM", "Allows customers to withdraw cash.");
            atm.Uses(mainframeBankingSystem, "Uses");
            customer.Uses(atm, "Withdraws cash using");
    
            Person bankStaff = model.AddPerson(Location.Internal, "Bank Staff", "Staff within the bank.");
            bankStaff.Uses(mainframeBankingSystem, "Uses");
    
            // containers
            Container webApplication = internetBankingSystem.AddContainer("Web Application", "Provides all of the Internet banking functionality to customers.", "Java and Spring MVC");
            Container database = internetBankingSystem.AddContainer("Database", "Stores interesting data.", "Relational Database Schema");
            database.AddTags(DatabaseTag);
    
            customer.Uses(webApplication, "HTTPS");
            webApplication.Uses(database, "Reads from and writes to", "JDBC");
            webApplication.Uses(mainframeBankingSystem, "Uses", "XML/HTTPS");
    
            // components
            // - for a real-world software system, you would probably want to extract the components using
            // - static analysis/reflection rather than manually specifying them all
            Component homePageController = webApplication.AddComponent("Home Page Controller", "Serves up the home page.", "Spring MVC Controller");
            Component signinController = webApplication.AddComponent("Sign In Controller", "Allows users to sign in to the Internet Banking System.", "Spring MVC Controller");
            Component accountsSummaryController = webApplication.AddComponent("Accounts Summary Controller", "Provides customers with an summary of their bank accounts.", "Spring MVC Controller");
            Component securityComponent = webApplication.AddComponent("Security Component", "Provides functionality related to signing in, changing passwords, etc.", "Spring Bean");
            Component mainframeBankingSystemFacade = webApplication.AddComponent("Mainframe Banking System Facade", "A facade onto the mainframe banking system.", "Spring Bean");
    
            webApplication.Components.Where(c => "Spring MVC Controller".Equals(c.Technology)).ToList().ForEach(c => customer.Uses(c, "Uses", "HTTPS"));
            signinController.Uses(securityComponent, "Uses");
            accountsSummaryController.Uses(mainframeBankingSystemFacade, "Uses");
            securityComponent.Uses(database, "Reads from and writes to", "JDBC");
            mainframeBankingSystemFacade.Uses(mainframeBankingSystem, "Uses", "XML/HTTPS");
    
            // deployment nodes and container instances
            DeploymentNode developerLaptop = model.AddDeploymentNode("Developer Laptop", "A developer laptop.", "Windows 7 or 10");
            developerLaptop.AddDeploymentNode("Docker Container - Web Server", "A Docker container.", "Docker")
                .AddDeploymentNode("Apache Tomcat", "An open source Java EE web server.", "Apache Tomcat 8.x", 1, DictionaryUtils.Create("Xmx=512M", "Xms=1024M", "Java Version=8"))
                .Add(webApplication);
    
            developerLaptop.AddDeploymentNode("Docker Container - Database Server", "A Docker container.", "Docker")
                .AddDeploymentNode("Database Server", "A development database.", "Oracle 12c")
                .Add(database);
    
            DeploymentNode liveWebServer = model.AddDeploymentNode("bigbank-web***", "A web server residing in the web server farm, accessed via F5 BIG-IP LTMs.", "Ubuntu 16.04 LTS", 8, DictionaryUtils.Create("Location=London"));
            liveWebServer.AddDeploymentNode("Apache Tomcat", "An open source Java EE web server.", "Apache Tomcat 8.x", 1, DictionaryUtils.Create("Xmx=512M", "Xms=1024M", "Java Version=8"))
                    .Add(webApplication);
    
            DeploymentNode primaryDatabaseServer = model.AddDeploymentNode("bigbank-db01", "The primary database server.", "Ubuntu 16.04 LTS", 1, DictionaryUtils.Create("Location=London"))
                    .AddDeploymentNode("Oracle - Primary", "The primary, live database server.", "Oracle 12c");
            primaryDatabaseServer.Add(database);
    
            DeploymentNode secondaryDatabaseServer = model.AddDeploymentNode("bigbank-db02", "The secondary database server.", "Ubuntu 16.04 LTS", 1, DictionaryUtils.Create("Location=Reading"))
                    .AddDeploymentNode("Oracle - Secondary", "A secondary, standby database server, used for failover purposes only.", "Oracle 12c");
            ContainerInstance secondaryDatabase = secondaryDatabaseServer.Add(database);
    
            model.Relationships.Where(r => r.Destination.Equals(secondaryDatabase)).ToList().ForEach(r => r.AddTags("Failover"));
            Relationship dataReplicationRelationship = primaryDatabaseServer.Uses(secondaryDatabaseServer, "Replicates data to", "");
            secondaryDatabase.AddTags("Failover");
    
            // views/diagrams
            EnterpriseContextView enterpriseContextView = views.CreateEnterpriseContextView("EnterpriseContext", "The system context diagram for the Internet Banking System.");
            enterpriseContextView.AddAllElements();
            enterpriseContextView.PaperSize = PaperSize.A5_Landscape;
    
            SystemContextView systemContextView = views.CreateSystemContextView(internetBankingSystem, "SystemContext", "The system context diagram for the Internet Banking System.");
            systemContextView.AddNearestNeighbours(internetBankingSystem);
            systemContextView.PaperSize = PaperSize.A5_Landscape;
    
            ContainerView containerView = views.CreateContainerView(internetBankingSystem, "Containers", "The container diagram for the Internet Banking System.");
            containerView.Add(customer);
            containerView.AddAllContainers();
            containerView.Add(mainframeBankingSystem);
            containerView.PaperSize = PaperSize.A5_Landscape;
    
            ComponentView componentView = views.CreateComponentView(webApplication, "Components", "The components diagram for the Web Application");
            componentView.AddAllContainers();
            componentView.AddAllComponents();
            componentView.Add(customer);
            componentView.Add(mainframeBankingSystem);
            componentView.PaperSize = PaperSize.A5_Landscape;
    
            if (usePaidFeatures) {
                // dynamic diagrams, deployment diagrams and corporate branding are not available with the Free Plan
                DynamicView dynamicView = views.CreateDynamicView(webApplication, "SignIn", "Summarises how the sign in feature works.");
                dynamicView.Add(customer, "Requests /signin from", signinController);
                dynamicView.Add(customer, "Submits credentials to", signinController);
                dynamicView.Add(signinController, "Calls isAuthenticated() on", securityComponent);
                dynamicView.Add(securityComponent, "select * from users u where username = ?", database);
                dynamicView.PaperSize = PaperSize.A5_Landscape;
    
                DeploymentView developmentDeploymentView = views.CreateDeploymentView(internetBankingSystem, "DevelopmentDeployment", "An example development deployment scenario for the Internet Banking System.");
                developmentDeploymentView.Add(developerLaptop);
                developmentDeploymentView.PaperSize = PaperSize.A5_Landscape;
    
                DeploymentView liveDeploymentView = views.CreateDeploymentView(internetBankingSystem, "LiveDeployment", "An example live deployment scenario for the Internet Banking System.");
                liveDeploymentView.Add(liveWebServer);
                liveDeploymentView.Add(primaryDatabaseServer);
                liveDeploymentView.Add(secondaryDatabaseServer);
                liveDeploymentView.Add(dataReplicationRelationship);
                liveDeploymentView.PaperSize = PaperSize.A5_Landscape;
    
                Branding branding = views.Configuration.Branding;
                branding.Logo = ImageUtils.GetImageAsDataUri(new FileInfo("structurizr-logo.png"));
            }
    
            // colours, shapes and other diagram styling
            Styles styles = views.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.Element) { Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd" });
            styles.Add(new ElementStyle(Tags.Container) { Background = "#438dd5" });
            styles.Add(new ElementStyle(Tags.Component) { Background = "#85bbf0", Color = "#000000" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Shape = Shape.Person });
            styles.Add(new ElementStyle(DatabaseTag) { Shape = Shape.Cylinder });
            styles.Add(new ElementStyle("Failover") { Opacity = 25 });
            styles.Add(new RelationshipStyle("Failover") {Opacity = 25, Position = 70});
    
            // documentation
            // - usually the documentation would be included from separate Markdown/AsciiDoc files, but this is just an example
            StructurizrDocumentationTemplate template = new StructurizrDocumentationTemplate(workspace);
            template.AddContextSection(internetBankingSystem, Format.Markdown,
                    "Here is some context about the Internet Banking System...\n" +
                    "![](embed:EnterpriseContext)\n" +
                    "![](embed:SystemContext)\n" +
                    "### Internet Banking System\n...\n" +
                    "### Mainframe Banking System\n...\n");
            template.AddContainersSection(internetBankingSystem, Format.Markdown,
                    "Here is some information about the containers within the Internet Banking System...\n" +
                    "![](embed:Containers)\n" +
                    "### Web Application\n...\n" +
                    "### Database\n...\n");
            template.AddComponentsSection(webApplication, Format.Markdown,
                    "Here is some information about the Web Application...\n" +
                    "![](embed:Components)\n" +
                    "### Sign in process\n" +
                    "Here is some information about the Sign In Controller, including how the sign in process works...\n" +
                    "![](embed:SignIn)");
            template.AddDevelopmentEnvironmentSection(internetBankingSystem, Format.AsciiDoc,
                    "Here is some information about how to set up a development environment for the Internet Banking System...\n" +
                    "image::embed:DevelopmentDeployment[]");
            template.AddDeploymentSection(internetBankingSystem, Format.AsciiDoc,
                    "Here is some information about the live deployment environment for the Internet Banking System...\n" +
                    "image::embed:LiveDeployment[]");
    
            return workspace;
        }
        
        static void Main()
        {
            StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
            structurizrClient.PutWorkspace(WorkspaceId, Create(true));
        }
        
    }
    
}