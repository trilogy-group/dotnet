using Xunit;
using System;

namespace Structurizr.Core.Tests
{

    
    public class EnterpriseContextViewTests : AbstractTestBase
    {

        private EnterpriseContextView view;

        public EnterpriseContextViewTests()
        {
            view = workspace.Views.CreateEnterpriseContextView("context", "Description");
        }

        [Fact]
        public void Test_Construction()
        {
            Assert.Equal("Enterprise Context", view.Name);
            Assert.Equal(0, view.Elements.Count);
            Assert.Same(model, view.Model);
        }

        [Fact]
        public void Test_GetName_WhenNoEnterpriseIsSpecified()
        {
            Assert.Equal("Enterprise Context", view.Name);
        }

        [Fact]
        public void Test_GetName_WhenAnEnterpriseIsSpecified()
        {
            model.Enterprise = new Enterprise("Widgets Limited");
            Assert.Equal("Enterprise Context for Widgets Limited", view.Name);
        }

        [Fact]
        public void Test_GetName_WhenAnEmptyEnterpriseNameIsSpecified()
        {
            Assert.Throws<ArgumentException>(() =>
                model.Enterprise = new Enterprise("")
            );
        }

        [Fact]
        public void Test_GetName_WhenANullEnterpriseNameIsSpecified()
        {
            Assert.Throws<ArgumentException>(() =>
                model.Enterprise = new Enterprise(null)
            );
        }

        [Fact]
        public void Test_AddAllSoftwareSystems_DoesNothing_WhenThereAreNoOtherSoftwareSystems()
        {
            view.AddAllSoftwareSystems();
            Assert.Equal(0, view.Elements.Count);
        }

        [Fact]
        public void Test_AddAllSoftwareSystems_AddsAllSoftwareSystems_WhenThereAreSomeSoftwareSystemsInTheModel()
        {
            SoftwareSystem softwareSystemA = model.AddSoftwareSystem(Location.External, "System A", "Description");
            SoftwareSystem softwareSystemB = model.AddSoftwareSystem(Location.External, "System B", "Description");

            view.AddAllSoftwareSystems();

            Assert.Equal(2, view.Elements.Count);
            Assert.True(view.Elements.Contains(new ElementView(softwareSystemA)));
            Assert.True(view.Elements.Contains(new ElementView(softwareSystemB)));
        }

        [Fact]
        public void Test_AddAllPeople_DoesNothing_WhenThereAreNoPeople()
        {
            view.AddAllPeople();
            Assert.Equal(0, view.Elements.Count);
        }

        [Fact]
        public void Test_AddAllPeople_AddsAllPeople_WhenThereAreSomePeopleInTheModel()
        {
            Person userA = model.AddPerson("User A", "Description");
            Person userB = model.AddPerson("User B", "Description");

            view.AddAllPeople();

            Assert.Equal(2, view.Elements.Count);
            Assert.True(view.Elements.Contains(new ElementView(userA)));
            Assert.True(view.Elements.Contains(new ElementView(userB)));
        }

        [Fact]
        public void Test_AddAllElements_DoesNothing_WhenThereAreNoSoftwareSystemsOrPeople()
        {
            view.AddAllElements();
            Assert.Equal(0, view.Elements.Count);
        }

        [Fact]
        public void Test_AddAllElements_AddsAllSoftwareSystemsAndPeople_WhenThereAreSomeSoftwareSystemsAndPeopleInTheModel()
        {
            SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "Description");
            Person person = model.AddPerson("Person", "Description");

            view.AddAllElements();

            Assert.Equal(2, view.Elements.Count);
            Assert.True(view.Elements.Contains(new ElementView(softwareSystem)));
            Assert.True(view.Elements.Contains(new ElementView(person)));
        }

    }

}