using System;
using HtmlRenderEngine.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlRenderEngine.Test.TestClass
{
    [TestClass]
    public class ElementsTest
    {
        [TestMethod]
        public void AnchorTest()
        {
            var anchor = new Anchor("https://www.google.com", "Hello").ID("link1");
            Assert.IsTrue("<a id='link1' href='https://www.google.com'>Hello</a>".Replace(" ", "").Equals(anchor.Render().Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
            anchor.ID("link").Classes("btn btn-black");
            Assert.IsTrue("<a id='link'  href='https://www.google.com' class='btn btn-black'>Hello</a>".Replace(" ", "").Equals(anchor.Render().Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
            anchor.RemoveClasses("btn");
            Assert.IsTrue("<a href='https://www.google.com' class=' btn-black'>Hello</a>".Replace(" ", "").Equals(anchor.Render().Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
            anchor.TargetAttr(Anchor.TargetOption.Top);
            Assert.IsTrue("<a href='https://www.google.com' target='_top' class=' btn-black'>Hello</a>".Replace(" ", "").Equals(anchor.Render().Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
        }
    }
}
