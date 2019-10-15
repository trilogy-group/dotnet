using System.Collections.Generic;
using Xunit;

namespace Structurizr.Core.Tests.View
{
    public class RelationshipViewTests : AbstractTestBase
    {
        [Fact]
        public void Test_GetAllTags_RelationshipViewTagsAdded_AddedViewTagsAndAllRelationTagsAreReturned()
        {
            Person user = Model.AddPerson("Person", "Description");
            SoftwareSystem softwareSystem = Model.AddSoftwareSystem("Software System", "Description");
            var relation = user.Uses(softwareSystem, "Uses", "");
            relation.AddTags("TagA","TagB");

            var relationView = new RelationshipView(relation);
            relationView.AddViewTags("Rel_Left", "AnotherLayoutTag");

            // var expected = new List<string>(relation.GetAllTags()) {"Rel_Left", "AnotherLayoutTag"};
            var expected = new List<string>{"Rel_Left", "AnotherLayoutTag"};
            expected.AddRange(relation.GetAllTags());

            Assert.Equal(expected, relationView.GetAllTags());
        }
    }
}