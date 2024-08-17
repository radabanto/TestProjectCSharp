using NUnit.Framework;

namespace AutomationCore.UI.Test
{
    public class ChromeBrowserActionTest
    {
        private BrowserAction ChromeWebDriver;

        [SetUp]
        public void Setup()
        {
            ChromeWebDriver = new BrowserAction(new OpenQA.Selenium.Chrome.ChromeOptions());
        }

        [Test]
        public void BrowserActionChromeSessionTest()
        {
            ChromeWebDriver.GoToUrl("https://www.google.com");
            ChromeWebDriver.WaitForPageToLoad();
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            ChromeWebDriver.CloseDriver();
        }
    }
}