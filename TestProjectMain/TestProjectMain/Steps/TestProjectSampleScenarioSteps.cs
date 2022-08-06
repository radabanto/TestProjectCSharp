using NUnit.Framework;
using TechTalk.SpecFlow;
using TestProjectMain.Steps;
using TestProjectMain.TestPages;

namespace TestProjectMain
{
    [Binding]
    public class TestProjectSampleScenarioSteps : BaseSteps
    {
        readonly GoogleSearchPage googlePage;
        public TestProjectSampleScenarioSteps(FeatureContext featureContext, ScenarioContext scenarioContext, GoogleSearchPage testPageGoogle) : base(featureContext, scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            googlePage = testPageGoogle;
        }

        [Given(@"I am a user")]
        public void GivenIAmAUser()
        {

        }

        [When(@"I access Google site")]
        public void WhenIAccessGoogleSite()
        {
            _webDriver.GoToUrl("https://www.google.com");
            _webDriver.WaitForPageToLoad();
        }

        [When(@"I perform search on '(.*)'")]
        public void WhenIPerformSearchOnString(string searchString)
        {
            googlePage.InputSearchOnGoogleSearchField(searchString);
            googlePage.HitPrimarySearchOnGoogle();
        }

        [Then(@"I am directed to the site search page")]
        public void ThenIAmDirectedToTheSiteSearchPage()
        {
            Assert.IsTrue(googlePage.IsGoogleSearchFormDisplayed(), "Failure: Google page not found.");
        }

        [Then(@"I am directed to the site search results page")]
        public void ThenIAmDirectedToTheSiteSearchResultsPage()
        {
            Assert.IsTrue(_webDriver.GetCurrentUrl().Contains("https://www.google.com/search?"), "Failure: search failed");
        }
    }
}
