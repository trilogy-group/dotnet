using Xunit;

namespace Structurizr.Core.Tests.View
{
    
    public class RelationshipStyleTests
    {

        [Fact]
        public void Test_Position()
        {
            RelationshipStyle style = new RelationshipStyle();
            Assert.Null(style.Position);

            style.Position = -1;
            Assert.Equal(0, style.Position);

            style.Position = 0;
            Assert.Equal(0, style.Position);

            style.Position = 50;
            Assert.Equal(50, style.Position);

            style.Position = 100;
            Assert.Equal(100, style.Position);

            style.Position = 101;
            Assert.Equal(100, style.Position);
        }

        [Fact]
        public void Test_Opacity()
        {
            RelationshipStyle style = new RelationshipStyle();
            Assert.Null(style.Opacity);

            style.Opacity = -1;
            Assert.Equal(0, style.Opacity);

            style.Opacity = 0;
            Assert.Equal(0, style.Opacity);

            style.Opacity = 50;
            Assert.Equal(50, style.Opacity);

            style.Opacity = 100;
            Assert.Equal(100, style.Opacity);

            style.Opacity = 101;
            Assert.Equal(100, style.Opacity);
        }
    }
}
