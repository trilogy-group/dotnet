using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structurizr.Analysis;

namespace Structurizr.CoreTests.Analysis
{

    [TestClass]
    public class ComponentFinderTests : AbstractTestBase
    {

        [TestMethod]
        public void Test_Construction_ThrowsAnException_WhenANullContainerIsSpecified()
        {
            try
            {
                new ComponentFinder(null, null);
                Assert.Fail();
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("A container must be specified.", ae.Message);
            }
        }

        [TestMethod]
        public void Test_Construction_ThrowsAnException_WhenANullPackageNameIsSpecified()
        {
            try
            {
                Container container = model.AddSoftwareSystem("Software System", "").AddContainer("Container", "", "");
                new ComponentFinder(container, null);
                Assert.Fail();
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("A package name must be specified.", ae.Message);
            }
        }

        [TestMethod]
        public void Test_Construction_ThrowsAnException_WhenNoComponentFinderStrategiesAreSpecified()
        {
            try
            {
                Container container = model.AddSoftwareSystem("Software System", "").AddContainer("Container", "", "");
                new ComponentFinder(container, "com.mycompany.myapp");
                Assert.Fail();
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("One or more ComponentFinderStrategy objects must be specified.", ae.Message);
            }
        }

    }

}
