using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structurizr.ComponentFinder;
using Structurizr.Model;
using System.Collections.Generic;

namespace Structurizr.CoreTests
{
    [TestClass]
    public class NameSuffixComponentFinderStrategyTests
    {
        [TestMethod]
        public void Test_FindComponents()
        {
            Workspace workspace = new Workspace("Name", "Description");
            Container container = workspace.Model.AddSoftwareSystem("Name", "Description").AddContainer("Name", "Description", "Technology");

            ComponentFinder.ComponentFinder componentFinder = new ComponentFinder.ComponentFinder(
                container,
                "Structurizr.CoreTests.ComponentFinderTests.MyApp",
                new NameSuffixComponentFinderStrategy("Component"));

            ICollection<Component> components = componentFinder.FindComponents();

            Assert.IsTrue(components.Count == 1);
        }

    }
}

namespace Structurizr.CoreTests.ComponentFinderTests.MyApp
{
    internal class AThing { }

    internal class AComponent { }
}