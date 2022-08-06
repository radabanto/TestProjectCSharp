using OpenQA.Selenium;
using TestProjectMain.TestUtils;

namespace TestProjectMain.TestPages
{
    public class GoogleSearchPage : BasePage
    {
        #region elements
        public IWebElement GoogleSearchForm => _driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form"));

        public IWebElement GoogleSearchField => _driver.FindElement(By.XPath("//input[contains(@title, 'Search')]"));

        public IWebElement GoogleEnterSearchButton => _driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[5]/center/input[1]"));

        public IWebElement GooglePrimaryEnterSearchButton => _driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"));

        #endregion

        public GoogleSearchPage(TestProjectBrowserAction webDriver) : base(webDriver)
        {
        }

        public bool IsGoogleSearchFormDisplayed()
        {
            return _webDriver.IsElementDisplayed(GoogleSearchForm);
        }

        public bool IsGoogleSearchFieldPresent()
        {
            return _webDriver.IsElementDisplayed(GoogleSearchField);
        }

        public void InputSearchOnGoogleSearchField(string searchString)
        {
            _webDriver.WaitForElement(GoogleSearchField, 5000);
            _webDriver.InputFieldText(GoogleSearchField, searchString);
        }

        public void HitSearchOnGoogle()
        {
            _webDriver.WaitForElement(GoogleEnterSearchButton, 5000);
            GoogleEnterSearchButton.Click();
        }

        public void HitPrimarySearchOnGoogle()
        {
            _webDriver.WaitForElement(GooglePrimaryEnterSearchButton, 5000);
            GooglePrimaryEnterSearchButton.Click();
        }
    }
}
