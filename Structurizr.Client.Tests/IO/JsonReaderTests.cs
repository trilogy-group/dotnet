using System.IO;
using Structurizr.Client.Tests.IO;
using Structurizr.IO.Json;
using Xunit;

namespace Structurizr.Api.Tests.IO
{
    public class JsonReaderTests
    {
        
        [Fact]
        public void Test_DeserializationOfProperties() {
            Workspace workspace = new Workspace("Name", "Description");
            SoftwareSystem softwareSystem = workspace.Model.AddSoftwareSystem("Name", "Description");
            softwareSystem.AddProperty("Name", "Value");
            
            StringWriter stringWriter = new StringWriter();
            new JsonWriter(false).WriteAsync(workspace, stringWriter).Wait();
                        
            StringReader stringReader = new StringReader(stringWriter.ToString());
            workspace = new JsonReader().ReadAsync(stringReader).Result;
            Assert.Equal("Value", workspace.Model.GetSoftwareSystemWithName("Name").Properties["Name"]);
        }

        [Fact]
        public void Test_Deserialization()
        {
            StringReader stringReader = new StringReader(TestData.Model1);
            var workspace = new JsonReader().ReadAsync(stringReader).Result;
            Assert.Equal("292", workspace.Model.GetSoftwareSystemWithName("Magento Plugin").Id);
        }
    }
}