using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Structurizr.CoreTests
{

    [TestClass]
    public class CodeElementTests
    {

        [TestMethod]
        public void Test_Construction_WhenAFullyQualifiedTypeIsSpecified()
        {
            CodeElement codeElement = new CodeElement("Wibble.Wobble, Foo.Bar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=xyz");
            Assert.AreEqual("Wobble", codeElement.Name);
        }

    }

}
