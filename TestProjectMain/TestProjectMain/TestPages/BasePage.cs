using AutomationCore.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProjectMain.TestUtils;

namespace TestProjectMain.TestPages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly TestProjectBrowserAction _webDriver;
        protected readonly WebDriverWait _wait;

        protected BasePage(BrowserAction webDriver)
        {
            _webDriver = webDriver as TestProjectBrowserAction;
            _driver = _webDriver.GetDriver();
            _wait = _webDriver.Wait();
        }
    }
}
