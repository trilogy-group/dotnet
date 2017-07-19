using System;
using System.IO;
using System.Linq;
using Xunit;
using Structurizr.IO.PlantUML;

namespace Structurizr.Core.Tests.IO.PlantUML
{
    
    public class PlantUMLWriterTests
    {

        private PlantUMLWriter _plantUMLWriter;
        private Workspace _workspace;
        private StringWriter _stringWriter;

        public PlantUMLWriterTests()
        {
            _plantUMLWriter = new PlantUMLWriter();
            _workspace = new Workspace("Name", "Description");
            _stringWriter = new StringWriter();
        }

        [Fact]
        public void Test_WriteWorkspace_DoesNotThrowAnExceptionWhenPassedNullParameters()
        {
            _plantUMLWriter.Write((Workspace)null, null);
            _plantUMLWriter.Write(_workspace, null);
            _plantUMLWriter.Write((Workspace)null, _stringWriter);
        }

        [Fact]
        public void Test_WriteView_DoesNotThrowAnExceptionWhenPassedNullParameters()
        {
            PopulateWorkspace();

            _plantUMLWriter.Write((Structurizr.View)null, null);
            _plantUMLWriter.Write(_workspace.Views.EnterpriseContextViews.First(), null);
            _plantUMLWriter.Write((Structurizr.View)null, _stringWriter);
        }

        [Fact]
        public void Test_WriteWorkspace()
        {
            PopulateWorkspace();

            _plantUMLWriter.Write(_workspace, _stringWriter);
            Assert.Equal("@startuml" + Environment.NewLine +
                "title Enterprise Context for Some Enterprise" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "package SomeEnterprise {" + Environment.NewLine +
                "  actor User" + Environment.NewLine +
                "  [Software System] <<Software System>> as SoftwareSystem" + Environment.NewLine +
                "}" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "SoftwareSystem ..> EmailSystem : Sends e-mail using" + Environment.NewLine +
                "User ..> SoftwareSystem : Uses" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                "" + Environment.NewLine +
                "@startuml" + Environment.NewLine +
                "title Software System - System Context" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "[Software System] <<Software System>> as SoftwareSystem" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "SoftwareSystem ..> EmailSystem : Sends e-mail using" + Environment.NewLine +
                "User ..> SoftwareSystem : Uses" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                "" + Environment.NewLine +
                "@startuml" + Environment.NewLine +
                "title Software System - Containers" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "package SoftwareSystem {" + Environment.NewLine +
                "  [Database] <<Container>> as Database" + Environment.NewLine +
                "  [Web Application] <<Container>> as WebApplication" + Environment.NewLine +
                "}" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "User ..> WebApplication : Uses <<HTTP>>" + Environment.NewLine +
                "WebApplication ..> Database : Reads from and writes to <<JDBC>>" + Environment.NewLine +
                "WebApplication ..> EmailSystem : Sends e-mail using" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                "" + Environment.NewLine +
                "@startuml" + Environment.NewLine +
                "title Software System - Web Application - Components" + Environment.NewLine +
                "[Database] <<Container>> as Database" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "package WebApplication {" + Environment.NewLine +
                "  [EmailComponent] <<Component>> as EmailComponent" + Environment.NewLine +
                "  [SomeController] <<Spring MVC Controller>> as SomeController" + Environment.NewLine +
                "  [SomeRepository] <<Spring Data>> as SomeRepository" + Environment.NewLine +
                "}" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "EmailComponent ..> EmailSystem : Sends e-mails using <<SMTP>>" + Environment.NewLine +
                "SomeController ..> EmailComponent : Sends e-mail using" + Environment.NewLine +
                "SomeController ..> SomeRepository : Uses" + Environment.NewLine +
                "SomeRepository ..> Database : Reads from and writes to <<JDBC>>" + Environment.NewLine +
                "User ..> SomeController : Uses <<HTTP>>" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                "" + Environment.NewLine +
                "@startuml" + Environment.NewLine +
                "title Web Application - Dynamic" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "User -> SomeController : Requests /something" + Environment.NewLine +
                "SomeController -> SomeRepository : Uses" + Environment.NewLine +
                "SomeRepository -> Database : select * from something" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                Environment.NewLine, _stringWriter.ToString());
        }

        [Fact]
        public void Test_WriteEnterpriseContextView()
        {
            PopulateWorkspace();

            EnterpriseContextView enterpriseContextView = _workspace.Views.EnterpriseContextViews.First();
            _plantUMLWriter.Write(enterpriseContextView, _stringWriter);

            Assert.Equal("@startuml" + Environment.NewLine +
                "title Enterprise Context for Some Enterprise" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "package SomeEnterprise {" + Environment.NewLine +
                "  actor User" + Environment.NewLine +
                "  [Software System] <<Software System>> as SoftwareSystem" + Environment.NewLine +
                "}" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "SoftwareSystem ..> EmailSystem : Sends e-mail using" + Environment.NewLine +
                "User ..> SoftwareSystem : Uses" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                Environment.NewLine, _stringWriter.ToString());
         }

        [Fact]
        public void Test_WriteSystemContextView()
        {
            PopulateWorkspace();

            SystemContextView systemContextView = _workspace.Views.SystemContextViews.First();
            _plantUMLWriter.Write(systemContextView, _stringWriter);

            Assert.Equal("@startuml" + Environment.NewLine +
                "title Software System - System Context" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "[Software System] <<Software System>> as SoftwareSystem" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "SoftwareSystem ..> EmailSystem : Sends e-mail using" + Environment.NewLine +
                "User ..> SoftwareSystem : Uses" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                "" + Environment.NewLine, _stringWriter.ToString());
            }

        [Fact]
        public void Test_WriteContainerView()
        {
            PopulateWorkspace();

            ContainerView containerView = _workspace.Views.ContainerViews.First();
            _plantUMLWriter.Write(containerView, _stringWriter);

            Assert.Equal("@startuml" + Environment.NewLine +
                "title Software System - Containers" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "package SoftwareSystem {" + Environment.NewLine +
                "  [Database] <<Container>> as Database" + Environment.NewLine +
                "  [Web Application] <<Container>> as WebApplication" + Environment.NewLine +
                "}" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "User ..> WebApplication : Uses <<HTTP>>" + Environment.NewLine +
                "WebApplication ..> Database : Reads from and writes to <<JDBC>>" + Environment.NewLine +
                "WebApplication ..> EmailSystem : Sends e-mail using" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                "" + Environment.NewLine, _stringWriter.ToString());
        }

        [Fact]
        public void Test_WriteComponentsView()
        {
            PopulateWorkspace();

            ComponentView componentView = _workspace.Views.ComponentViews.First();
            _plantUMLWriter.Write(componentView, _stringWriter);

            Assert.Equal("@startuml" + Environment.NewLine +
                "title Software System - Web Application - Components" + Environment.NewLine +
                "[Database] <<Container>> as Database" + Environment.NewLine +
                "[E-mail System] <<Software System>> as EmailSystem" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "package WebApplication {" + Environment.NewLine +
                "  [EmailComponent] <<Component>> as EmailComponent" + Environment.NewLine +
                "  [SomeController] <<Spring MVC Controller>> as SomeController" + Environment.NewLine +
                "  [SomeRepository] <<Spring Data>> as SomeRepository" + Environment.NewLine +
                "}" + Environment.NewLine +
                "EmailSystem ..> User : Delivers e-mails to" + Environment.NewLine +
                "EmailComponent ..> EmailSystem : Sends e-mails using <<SMTP>>" + Environment.NewLine +
                "SomeController ..> EmailComponent : Sends e-mail using" + Environment.NewLine +
                "SomeController ..> SomeRepository : Uses" + Environment.NewLine +
                "SomeRepository ..> Database : Reads from and writes to <<JDBC>>" + Environment.NewLine +
                "User ..> SomeController : Uses <<HTTP>>" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                "" + Environment.NewLine, _stringWriter.ToString());
        }

        [Fact]
        public void Test_WriteDynamicView()
        {
            PopulateWorkspace();

            DynamicView dynamicView = _workspace.Views.DynamicViews.First();
            _plantUMLWriter.Write(dynamicView, _stringWriter);

            Assert.Equal("@startuml" + Environment.NewLine +
                "title Web Application - Dynamic" + Environment.NewLine +
                "actor User" + Environment.NewLine +
                "User -> SomeController : Requests /something" + Environment.NewLine +
                "SomeController -> SomeRepository : Uses" + Environment.NewLine +
                "SomeRepository -> Database : select * from something" + Environment.NewLine +
                "@enduml" + Environment.NewLine +
                Environment.NewLine, _stringWriter.ToString());
        }

        private void PopulateWorkspace()
        {
            Model model = _workspace.Model;
            model.Enterprise = new Enterprise("Some Enterprise");

            Person user = model.AddPerson(Location.Internal, "User", "");
            SoftwareSystem softwareSystem = model.AddSoftwareSystem(Location.Internal, "Software System", "");
            user.Uses(softwareSystem, "Uses");

            SoftwareSystem emailSystem = model.AddSoftwareSystem(Location.External, "E-mail System", "");
            softwareSystem.Uses(emailSystem, "Sends e-mail using");
            emailSystem.Delivers(user, "Delivers e-mails to");

            Container webApplication = softwareSystem.AddContainer("Web Application", "", "");
            Container database = softwareSystem.AddContainer("Database", "", "");
            user.Uses(webApplication, "Uses", "HTTP");
            webApplication.Uses(database, "Reads from and writes to", "JDBC");
            webApplication.Uses(emailSystem, "Sends e-mail using");

            Component controller = webApplication.AddComponent("SomeController", "", "Spring MVC Controller");
            Component emailComponent = webApplication.AddComponent("EmailComponent", "");
            Component repository = webApplication.AddComponent("SomeRepository", "", "Spring Data");
            user.Uses(controller, "Uses", "HTTP");
            controller.Uses(repository, "Uses");
            controller.Uses(emailComponent, "Sends e-mail using");
            repository.Uses(database, "Reads from and writes to", "JDBC");
            emailComponent.Uses(emailSystem, "Sends e-mails using", "SMTP");

            EnterpriseContextView enterpriseContextView = _workspace.Views.CreateEnterpriseContextView("enterpriseContext", "");
            enterpriseContextView.AddAllElements();

            SystemContextView systemContextView = _workspace.Views.CreateSystemContextView(softwareSystem, "systemContext", "");
            systemContextView.AddAllElements();

            ContainerView containerView = _workspace.Views.CreateContainerView(softwareSystem, "containers", "");
            containerView.AddAllElements();

            ComponentView componentView = _workspace.Views.CreateComponentView(webApplication, "components", "");
            componentView.AddAllElements();

            DynamicView dynamicView = _workspace.Views.CreateDynamicView(webApplication, "dynamic", "");
            dynamicView.Add(user, "Requests /something", controller);
            dynamicView.Add(controller, repository);
            dynamicView.Add(repository, "select * from something", database);
        }

    }
}