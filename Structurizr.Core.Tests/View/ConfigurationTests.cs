using Xunit;

namespace Structurizr.Core.Tests
{

    
    public class ConfigurationTests : AbstractTestBase
    {

        [Fact]
        public void test_defaultView_DoesNothing_WhenPassedNull()
        {
            Configuration configuration = new Configuration();
            configuration.SetDefaultView(null);
            Assert.Null(configuration.DefaultView);
        }

        [Fact]
        public void test_defaultView()
        {
            SystemLandscapeView view = Views.CreateSystemLandscapeView("key", "Description");
            Configuration configuration = new Configuration();
            configuration.SetDefaultView(view);
            Assert.Equal("key", configuration.DefaultView);
        }

        [Fact]
        public void test_copyConfigurationFrom()
        {
            Configuration source = new Configuration();
            source.LastSavedView = "someKey";

            Configuration destination = new Configuration();
            destination.CopyConfigurationFrom(source);
            Assert.Equal("someKey", destination.LastSavedView);
        }

    }

}
