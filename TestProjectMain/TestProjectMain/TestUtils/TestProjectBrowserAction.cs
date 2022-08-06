using AutomationCore.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestProjectMain.TestUtils
{
    public class TestProjectBrowserAction : BrowserAction
    {
        private readonly IWebDriver _driver;

        public TestProjectBrowserAction()
        {
            _driver = GetDriver();
        }

        public TestProjectBrowserAction(ChromeOptions options) : base(options)
        {
            _driver = GetDriver();
        }

        public void step()
        {
            Console.WriteLine("This");
        }
    }
}
