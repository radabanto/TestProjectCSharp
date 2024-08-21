using OpenQA.Selenium;
using TestProjectMain.TestUtils;

namespace TestProjectMain.TestPages
{
    public class GoogleSearchPage : BasePage
    {
        #region elements
        public IWebElement GoogleSearchForm => _driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form"));

        public IWebElement GoogleSearchField => _driver.FindElement(By.XPath("//textarea[contains(@title, 'Search')]"));

        public IWebElement GoogleEnterSearchButton => _driver.FindElement(By.XPath("//input[contains(@aria-label, 'Google Search')]"));

        public IWebElement GooglePrimaryEnterSearchButton => _driver.FindElement(By.XPath("//input[contains(@aria-label, 'Google Search')]"));

        #endregion

        public GoogleSearchPage(TestProjectBrowserAction webDriver) : base(webDriver)
        {
        }

        public bool IsGoogleSearchFormDisplayed()
        {
            return _webDriver.IsElementDisplayed(GoogleSearchForm, 3);
        }

        public bool IsGoogleSearchFieldPresent()
        {
            return _webDriver.IsElementDisplayed(GoogleSearchField, 3);
        }

        public void InputSearchOnGoogleSearchField(string searchString)
        {
            _webDriver.IsElementDisplayed(GoogleSearchField, 3);
            _webDriver.InputFieldText(GoogleSearchField, searchString);
        }

        public void HitSearchOnGoogle()
        {
            GoogleEnterSearchButton.Click();
        }

        public void HitPrimarySearchOnGoogle()
        {
            _webDriver.IsElementDisplayed(GooglePrimaryEnterSearchButton, 3);
            GooglePrimaryEnterSearchButton.Click();
        }
    }
}
