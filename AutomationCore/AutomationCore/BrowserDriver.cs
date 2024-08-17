using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Drawing;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationCore
{
    public class BrowserDriver
    {
        private IWebDriver _webDriver;
        private DriverManager _webDriverManager;

        //TODO: Parametrize browser selection from here
        // at the minimum, be able to switch among
        // Chrome, Firefox and Safari
        public BrowserDriver()
        {
            _webDriverManager = new DriverManager();
            SetDefaultChromeDriver();
        }

        public BrowserDriver(ChromeOptions options)
        {
            _webDriverManager = new DriverManager();
            SetChromeDriver(options);
        }

        public BrowserDriver(EdgeOptions options)
        {
            _webDriverManager = new DriverManager();
            SetEdgeDriver(options);
        }

        public BrowserDriver(FirefoxOptions options)
        {
            _webDriverManager = new DriverManager();
            SetFirefoxDriver(options);
        }


        //TODO: Add switching of browsers here
        // + Capability to switch between Chrome, Firefox and Safari
        // + Add Capability to interact with selenium grid
        public void SetDefaultChromeDriver()
        {
            //TODO: Add switching of drivers here, for now use chrome
            _webDriver = GetChromeDriver();
        }

        public void SetChromeDriver(ChromeOptions options)
        {
            _webDriver = GetChromeDriver(options);
        }

        public void SetEdgeDriver(EdgeOptions options)
        {
            _webDriver = GetEdgeDriver(options);
        }

        public void SetFirefoxDriver(FirefoxOptions options)
        {
            _webDriver = GetFirefoxDriver(options);
        }

        public IWebDriver GetChromeDriver()
        {
            _webDriverManager.SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        public IWebDriver GetChromeDriver(ChromeOptions options)
        {
            _webDriverManager.SetUpDriver(new ChromeConfig());
            return new ChromeDriver(options);
        }

        public IWebDriver GetEdgeDriver()
        {
            _webDriverManager.SetUpDriver(new EdgeConfig());
            return new EdgeDriver();
        }

        public IWebDriver GetEdgeDriver(EdgeOptions options)
        {
            _webDriverManager.SetUpDriver(new EdgeConfig());
            return new EdgeDriver(options);
        }

        public IWebDriver GetFirefoxDriver()
        {
            _webDriverManager.SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        public IWebDriver GetFirefoxDriver(FirefoxOptions options)
        {
            _webDriverManager.SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
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
