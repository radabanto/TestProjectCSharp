using NUnit.Framework;

namespace AutomationCore.UI.Test
{
    public class EdgeBrowserActionTest
    {
        private BrowserAction EdgeWebDriver;

        [SetUp]
        public void Setup()
        {
            EdgeWebDriver = new BrowserAction(new OpenQA.Selenium.Edge.EdgeOptions());
        }

        [Test]
        public void BrowserActionEdgeSessionTest()
        {
            EdgeWebDriver.GoToUrl("https://www.google.com");
            EdgeWebDriver.WaitForPageToLoad();
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            EdgeWebDriver.CloseDriver();
        }
    }
}