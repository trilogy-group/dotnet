using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Structurizr.CoreTests.View
{

    [TestClass]
    public class ColorPairTests
    {

        [TestMethod]
        public void test_construction()
        {
            ColorPair colorPair = new ColorPair("#ffffff", "#000000");
            Assert.AreEqual("#ffffff", colorPair.Background);
            Assert.AreEqual("#000000", colorPair.Foreground);
        }

        [TestMethod]
        public void test_setBackground_WithAValidHtmlColorCode()
        {
            ColorPair colorPair = new ColorPair();
            colorPair.Background = "#ffffff";
            Assert.AreEqual("#ffffff", colorPair.Background);
        }

        [TestMethod]
        public void test_setBackground_ThrowsAnException_WhenANullHtmlColorCodeIsSpecified()
        {
            try
            {
                ColorPair colorPair = new ColorPair();
                colorPair.Background = null;
                Assert.Fail();
            }
            catch (ArgumentException iae)
            {
                Assert.AreEqual("'' is not a valid hex color code.", iae.Message);
            }
        }

        [TestMethod]
        public void test_setBackground_ThrowsAnException_WhenAnEmptyHtmlColorCodeIsSpecified()
        {
            try
            {
                ColorPair colorPair = new ColorPair();
                colorPair.Background = "";
                Assert.Fail();
            }
            catch (ArgumentException iae)
            {
                Assert.AreEqual("'' is not a valid hex color code.", iae.Message);
            }
        }

        [TestMethod]
        public void test_setBackground_ThrowsAnException_WhenAnInvalidHtmlColorCodeIsSpecified()
        {
            try
            {
                ColorPair colorPair = new ColorPair();
                colorPair.Background = "ffffff";
                Assert.Fail();
            }
            catch (ArgumentException iae)
            {
                Assert.AreEqual("'ffffff' is not a valid hex color code.", iae.Message);
            }
        }

        [TestMethod]
        public void test_setForeground_WithAValidHtmlColorCode()
        {
            ColorPair colorPair = new ColorPair();
            colorPair.Foreground = "#000000";
            Assert.AreEqual("#000000", colorPair.Foreground);
        }

        [TestMethod]
        public void test_setForeground_ThrowsAnException_WhenANullHtmlColorCodeIsSpecified()
        {
            try
            {
                ColorPair colorPair = new ColorPair();
                colorPair.Foreground = null;
                Assert.Fail();
            }
            catch (ArgumentException iae)
            {
                Assert.AreEqual("'' is not a valid hex color code.", iae.Message);
            }
        }

        [TestMethod]
        public void test_setForeground_ThrowsAnException_WhenAnEmptyHtmlColorCodeIsSpecified()
        {
            try
            {
                ColorPair colorPair = new ColorPair();
                colorPair.Foreground = "";
                Assert.Fail();
            }
            catch (ArgumentException iae)
            {
                Assert.AreEqual("'' is not a valid hex color code.", iae.Message);
            }
        }

        [TestMethod]
        public void test_setForeground_ThrowsAnException_WhenAnInvalidHtmlColorCodeIsSpecified()
        {
            try
            {
                ColorPair colorPair = new ColorPair();
                colorPair.Foreground = "000000";
                Assert.Fail();
            }
            catch (ArgumentException iae)
            {
                Assert.AreEqual("'000000' is not a valid hex color code.", iae.Message);
            }
        }

    }

}
