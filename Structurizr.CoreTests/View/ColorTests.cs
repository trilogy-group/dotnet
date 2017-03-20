
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Structurizr.CoreTests
{

    [TestClass]
    public class ColorTests
    {

        [TestMethod]
        public void Test_IsHexColorCode_ReturnsFalse_WhenPassedNull()
        {
            Assert.IsFalse(Color.IsHexColorCode(null));
        }

        [TestMethod]
        public void Test_IsHexColorCode_ReturnsFalse_WhenPassedAnEmptyString()
        {
            Assert.IsFalse(Color.IsHexColorCode(""));
        }

        [TestMethod]
        public void Test_IsHexColorCode_ReturnsFalse_WhenPassedAnInvalidString()
        {
            Assert.IsFalse(Color.IsHexColorCode("ffffff"));
            Assert.IsFalse(Color.IsHexColorCode("#fffff"));
            Assert.IsFalse(Color.IsHexColorCode("#gggggg"));
        }

        [TestMethod]
        public void Test_IsHexColorCode_ReturnsTrue_WhenPassedAnValidString()
        {
            Assert.IsTrue(Color.IsHexColorCode("#abcdef"));
            Assert.IsTrue(Color.IsHexColorCode("#ABCDEF"));
            Assert.IsTrue(Color.IsHexColorCode("#123456"));
        }

    }

}
