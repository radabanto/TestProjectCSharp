using NUnit.Framework;

namespace AutomationCore.UI.Test
{
    public class FirefoxBrowserActionTest
    {
        private BrowserAction FirefoxWebDriver;

        [SetUp]
        public void Setup()
        {
            FirefoxWebDriver = new BrowserAction(new OpenQA.Selenium.Firefox.FirefoxOptions());
        }

        [Test]
        public void BrowserActionFirefoxSessionTest()
        {
            FirefoxWebDriver.GoToUrl("https://www.google.com");
            FirefoxWebDriver.WaitForPageToLoad();
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            FirefoxWebDriver.CloseDriver();
        }
    }
}