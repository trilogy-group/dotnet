using System.Collections.Generic;
using Xunit;

namespace Structurizr.Core.Tests
{
    public class ModelItemTests : AbstractTestBase
    {
        [Fact]
        public void Test_GetAllTags_NoTagAdded_RequiredTagsAreReturned()
        {
            Person user = Model.AddPerson("Person", "Description");
            SoftwareSystem softwareSystem = Model.AddSoftwareSystem("Software System", "Description");
            var relation = user.Uses(softwareSystem, "Uses", "");
            // Relationship.GetRequiredTags() == new List<string> { Structurizr.Tags.Relationship, Structurizr.Tags.Synchronous }
            Assert.Equal(new List<string> { Structurizr.Tags.Relationship, Structurizr.Tags.Synchronous }, relation.GetAllTags());
        }

        [Fact]
        public void Test_GetAllTags_TagsAdded_AddedTagsAndRequiredTagsAreReturned()
        {
            Person user = Model.AddPerson("Person", "Description");
            SoftwareSystem softwareSystem = Model.AddSoftwareSystem("Software System", "Description");
            var relation = user.Uses(softwareSystem, "Uses", "");
            relation.AddTags("TagA","TagB");
            // Relationship.GetRequiredTags() == new List<string> { Structurizr.Tags.Relationship, Structurizr.Tags.Synchronous }
            Assert.Equal(new List<string> { Structurizr.Tags.Relationship, Structurizr.Tags.Synchronous, "TagA","TagB" }, relation.GetAllTags());
        }
    }
}