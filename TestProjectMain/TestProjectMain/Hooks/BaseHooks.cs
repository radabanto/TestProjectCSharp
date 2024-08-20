using AutomationCore.UI;
using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using TestProjectMain.TestUtils;

namespace TestProjectMain.Hooks
{
    [Binding]
    public class BaseHooks
    {
        protected static TestProjectBrowserAction _webDriver;
        protected static FeatureContext _featureContext;
        protected ScenarioContext _scenarioContext;
        protected readonly IObjectContainer _objectContainer;

        public BaseHooks(FeatureContext featureContext, ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }


        [BeforeFeature(Order = 10)]
        public static void BeforeFeature()
        {
            if (_featureContext != null)
            {
                SetupFeatureWebDriver();
            }
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            SetupScenarioWebDriver();
        }

        [AfterStep]
        public static void AfterStep()
        {
            //TODO: Implement Test Failure Handling

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            _webDriver.CloseDriver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            //TODO: Add browser session checker
        }

        public static void SetupFeatureWebDriver()
        {
            _featureContext["driver"] = _webDriver;
        }

        public void SetupScenarioWebDriver()
        {
            //Readbrowser
            if (_featureContext.FeatureInfo.Tags.Contains("run_on"))
            {
                if (_featureContext.FeatureInfo.Tags.Contains("edgeBrowser"))
                {
                    InitializeEdgeDriver();
                }
                else if (_featureContext.FeatureInfo.Tags.Contains("firefoxBrowser"))
                {
                    InitializeFirefoxDriver();
                }
            }
            else
            {
                InitializeDriver();
            }
            _scenarioContext["driver"] = _webDriver;
            _objectContainer.RegisterInstanceAs<BrowserAction>(_webDriver);
        }

        public static void InitializeDriver()
        {
            var chromeOptions = new ChromeOptions();
            AddChromeOptions(chromeOptions);

            _webDriver = new TestProjectBrowserAction(chromeOptions);
        }

        public static void InitializeEdgeDriver()
        {
            var edgeOptions = new EdgeOptions();
            AddEdgeOptions(edgeOptions);

            _webDriver = new TestProjectBrowserAction(edgeOptions);
        }

        public static void InitializeFirefoxDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            AddFirefoxOptions(firefoxOptions);

            _webDriver = new TestProjectBrowserAction(firefoxOptions);
#if DEBUG
            _webDriver.GetDriver().Manage().Window.Maximize();
#endif
        }

        /// <summary>
        /// Add chrome options here
        /// </summary>
        /// <param name="chromeOptions"></param>
        public static void AddChromeOptions(ChromeOptions chromeOptions)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string directoryPath = Environment.CurrentDirectory;
            var downloadLocation = directoryPath + "\\TestDownloads\\";
#if DEBUG
            chromeOptions.AddArgument("--start-maximized");
#else
            chromeOptions.AddArgument("--headless");
#endif
        }


        /// <summary>
        /// Add edge options here
        /// </summary>
        /// <param name="edgeOptions"></param>
        public static void AddEdgeOptions(EdgeOptions edgeOptions)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string directoryPath = Environment.CurrentDirectory;
            var downloadLocation = directoryPath + "\\TestDownloads\\";
#if DEBUG
            edgeOptions.AddArgument("--start-maximized");
#else
            edgeOptions.AddArgument("--headless");
#endif
        }

        /// <summary>
        /// Add firefox options here
        /// </summary>
        /// <param name="firefoxOptions"></param>
        public static void AddFirefoxOptions(FirefoxOptions firefoxOptions)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string directoryPath = Environment.CurrentDirectory;
            var downloadLocation = directoryPath + "\\TestDownloads\\";
#if DEBUG
            //firefoxOptions.AddArguments("--start-maximized");
#else
            firefoxOptions.AddArgument("--headless");
#endif
            firefoxOptions.SetPreference("browser.download.dir", downloadLocation);
        }
    }
}