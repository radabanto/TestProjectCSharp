using AutomationCore.UI;
using BoDi;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
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
            InitializeDriver();
            _featureContext["driver"] = _webDriver;
        }

        public void SetupScenarioWebDriver()
        {
            InitializeDriver();
            _scenarioContext["driver"] = _webDriver;
            _objectContainer.RegisterInstanceAs<BrowserAction>(_webDriver);
        }

        public static void InitializeDriver()
        {
            var chromeOptions = new ChromeOptions();
            AddChromeOptions(chromeOptions);

            _webDriver = new TestProjectBrowserAction(chromeOptions);
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
            chromeOptions.AddArgument("--start-maximized");
        }
    }
}
