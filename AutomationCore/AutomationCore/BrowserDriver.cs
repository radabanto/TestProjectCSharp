using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace AutomationCore
{
    public class BrowserDriver
    {
        private IWebDriver _webDriver;

        //TODO: Parametrize browser selection from here
        // at the minimum, be able to switch among
        // Chrome, Firefox and Safari
        public BrowserDriver()
        {
            SetDriver();
        }

        public BrowserDriver(ChromeOptions options)
        {
            SetDriver(options);
        }


        //TODO: Add switching of browsers here
        // + Capability to switch between Chrome, Firefox and Safari
        // + Add Capability to interact with selenium grid
        public void SetDriver()
        {
            //TODO: Add switching of drivers here, for now use chrome
            _webDriver = GetChromeDriver();
        }

        public void SetDriver(ChromeOptions options)
        {
            _webDriver = GetChromeDriver(options);
        }

        public IWebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }

        public IWebDriver GetChromeDriver(ChromeOptions options)
        {
            return new ChromeDriver(options);
        }

        public IWebDriver GetDriver()
        {
            return _webDriver;
        }

        public void CloseDriver()
        {
            _webDriver.Quit();
            _webDriver = null;
        }

        public bool AreWindowHandlesClosed()
        {
            if (_webDriver.WindowHandles.Count > 0)
            {
                return false;
            }
            return true;
        }

        public Size GetBrowserSize()
        {
            var size = GetDriver().Manage().Window.Size;
            return size;
        }

        public void SetBrowserSize(Size size)
        {
            GetDriver().Manage().Window.Size = size;
        }
    }
}
