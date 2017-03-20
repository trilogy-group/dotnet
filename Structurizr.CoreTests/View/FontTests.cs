using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Structurizr.CoreTests.View
{

    [TestClass]
    public class FontTests
    {

        private Font _font;

        [TestMethod]
        public void construction_WithANameOnly()
        {
            this._font = new Font("Times New Roman");
            Assert.AreEqual("Times New Roman", _font.Name);
        }

        [TestMethod]
        public void construction_WithANameAndUrl()
        {
            this._font = new Font("Open Sans", "https://fonts.googleapis.com/css?family=Open+Sans:400,700");
            Assert.AreEqual("Open Sans", _font.Name);
            Assert.AreEqual("https://fonts.googleapis.com/css?family=Open+Sans:400,700", _font.Url);
        }

        [TestMethod]
        public void test_setUrl_WithAUrl()
        {
            _font = new Font();
            _font.Url = "https://fonts.googleapis.com/css?family=Open+Sans:400,700";
            Assert.AreEqual("https://fonts.googleapis.com/css?family=Open+Sans:400,700", _font.Url);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void test_setUrl_ThrowsAnArgumentException_WhenAnInvalidUrlIsSpecified()
        {
            _font = new Font();
            _font.Url = "www.google.com";
        }

        [TestMethod]
        public void test_setUrl_DoesNothing_WhenANullUrlIsSpecified()
        {
            _font = new Font();
            _font.Url = null;
            Assert.IsNull(_font.Url);
        }

        [TestMethod]
        public void test_setUrl_DoesNothing_WhenAnEmptyUrlIsSpecified()
        {
            _font = new Font();
            _font.Url = " ";
            Assert.IsNull(_font.Url);
        }

    }

}