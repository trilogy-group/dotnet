using Xunit;
using System;

namespace Structurizr.Core.Tests
{

    
    public class WorkspaceTests
    {

        private Workspace workspace = new Workspace("Name", "Description");

        [Fact]
        public void Test_SetApi_DoesNotThrowAnException_WhenANullUrlIsSpecified()
        {
            workspace.Api = null;
        }

        [Fact]
        public void Test_SetApi_DoesNotThrowAnException_WhenAnEmptyUrlIsSpecified()
        {
            workspace.Api = "";
        }

        [Fact]
        public void Test_SetApi_ThrowsAnException_WhenAnInvalidUrlIsSpecified()
        {
            try
            {
                workspace.Api = "www.somedomain.com";
                throw new TestFailedException();
            }
            catch (Exception e)
            {
                Assert.Equal("www.somedomain.com is not a valid URL.", e.Message);
            }
        }

        [Fact]
        public void Test_SetApi_DoesNotThrowAnException_WhenAValidUrlIsSpecified()
        {
            workspace.Api = "http://www.somedomain.com";
            Assert.Equal("http://www.somedomain.com", workspace.Api);
        }

    }

}
