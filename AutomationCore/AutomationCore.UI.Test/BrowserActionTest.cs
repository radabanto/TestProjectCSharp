using NUnit.Framework;

namespace AutomationCore.UI.Test
{
    public class BrowserActionTest
    {
        private BrowserAction WebDriver;

        [SetUp]
        public void Setup()
        {
            WebDriver = new BrowserAction();
        }

        [Test]
        public void BrowserActionChromeDefaultSessionTest()
        {
            WebDriver.GoToUrl("https://www.google.com");
            WebDriver.WaitForPageToLoad();
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }
    }
}