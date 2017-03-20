using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structurizr.Util;

namespace Structurizr.CoreTests
{

    [TestClass]
    public class UrlTests
    {

        [TestMethod]
        public void test_IsUrl_ReturnsFalse_WhenPassedNull()
        {
            Assert.IsFalse(Url.IsUrl(null));
        }

        [TestMethod]
        public void test_IsUrl_ReturnsFalse_WhenPassedAnEmptyString()
        {
            Assert.IsFalse(Url.IsUrl(""));
            Assert.IsFalse(Url.IsUrl(" "));
        }

        [TestMethod]
        public void test_IsUrl_ReturnsFalse_WhenPassedAnInvalidUrl()
        {
            Assert.IsFalse(Url.IsUrl("www.google.com"));
        }

        [TestMethod]
        public void test_IsUrl_ReturnsTrue_WhenPassedAValidUrl()
        {
            Assert.IsTrue(Url.IsUrl("https://www.google.com"));
        }

    }
}
