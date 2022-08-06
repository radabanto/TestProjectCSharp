using TechTalk.SpecFlow;
using TestProjectMain.TestUtils;

namespace TestProjectMain.Steps
{
    public class BaseSteps
    {
        protected readonly TestProjectBrowserAction _webDriver;
        protected FeatureContext _featureContext;
        protected ScenarioContext _scenarioContext;

        public BaseSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

            _webDriver = (TestProjectBrowserAction)_scenarioContext["driver"];
        }
    }
}
