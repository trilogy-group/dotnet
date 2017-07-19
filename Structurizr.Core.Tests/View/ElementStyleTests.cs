using Xunit;

namespace Structurizr.Core.Tests
{
    
    public class ElementStyleTests
    {

        [Fact]
        public void Test_Opacity()
        {
            ElementStyle style = new ElementStyle();
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
