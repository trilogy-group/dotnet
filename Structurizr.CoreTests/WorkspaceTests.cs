using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Structurizr.CoreTests
{

    [TestClass]
    public class WorkspaceTests
    {

        private Workspace workspace = new Workspace("Name", "Description");

        [TestMethod]
        public void Test_SetSource_DoesNotThrowAnException_WhenANullUrlIsSpecified()
        {
            workspace.Source = null;
        }

        [TestMethod]
        public void Test_SetSource_DoesNotThrowAnException_WhenAnEmptyUrlIsSpecified()
        {
            workspace.Source = "";
        }

        [TestMethod]
        public void Test_SetSource_ThrowsAnException_WhenAnInvalidUrlIsSpecified()
        {
            try
            {
                workspace.Source = "www.somedomain.com";
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("www.somedomain.com is not a valid URL.", e.Message);
            }
        }

        [TestMethod]
        public void Test_SetSource_DoesNotThrowAnException_WhenAnValidHttpUrlIsSpecified()
        {
            workspace.Source = "http://www.somedomain.com";
            Assert.AreEqual("http://www.somedomain.com", workspace.Source);
        }

        [TestMethod]
        public void Test_SetSource_DoesNotThrowAnException_WhenAnValidHttpsUrlIsSpecified()
        {
            workspace.Source = "https://www.somedomain.com";
            Assert.AreEqual("https://www.somedomain.com", workspace.Source);
        }

    }

}
