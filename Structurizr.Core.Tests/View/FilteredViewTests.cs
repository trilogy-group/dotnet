using Xunit;

namespace Structurizr.Core.Tests.View
{

    public class FilteredViewTests : AbstractTestBase
    {
    
        [Fact]
        public void Test_Construction()
        {
            SoftwareSystem softwareSystem = model.AddSoftwareSystem("Name", "Description");
            SystemContextView systemContextView = views.CreateSystemContextView(softwareSystem, "SystemContext", "Description");
            FilteredView filteredView = views.CreateFilteredView(
                systemContextView,
                "CurrentStateSystemContext",
                "The system context as-is.",
                FilterMode.Exclude,
                "v2", "v3"
            );

            Assert.Equal("CurrentStateSystemContext", filteredView.Key);
            Assert.Equal("SystemContext", filteredView.BaseViewKey);
            Assert.Same(systemContextView, filteredView.View);
            Assert.Equal("The system context as-is.", filteredView.Description);
            Assert.Equal(FilterMode.Exclude, filteredView.Mode);
            Assert.Equal(2, filteredView.Tags.Count);
            Assert.True(filteredView.Tags.Contains("v2"));
            Assert.True(filteredView.Tags.Contains("v3"));
        }
       
    }
    
}