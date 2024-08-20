using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AutomationCore.UI.Test
{
    public class BrowserActionTest
    {
        private BrowserAction WebDriver;

        [SetUp]
        public void Setup()
        {
            WebDriver = new BrowserAction();
            WebDriver.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void BrowserActionChromeDefaultSessionTest()
        {
            WebDriver.GoToUrl("https://www.google.com");
            try
            {
                WebDriver.WaitForPageToLoad();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.Pass();
        }

        [Test]
        public void BrowserActionSeleniumWait()
        {
            WebDriver.GoToUrl("https://www.google.com");
            WebDriver.WaitForPageToLoad();
            try
            {
                WebDriver.Wait();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.Pass();
        }

        [Test]
        public void BrowserActionSeleniumWaitTimeout()
        {
            WebDriver.GoToUrl("https://www.google.com");
            WebDriver.WaitForPageToLoad();
            try
            {
                WebDriver.Wait(5000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.Pass();
        }

        [Test]
        public void BrowserActionWaitForElementToBeVisible()
        {
            WebDriver.GoToUrl("https://www.google.com");
            WebDriver.WaitForPageToLoad();
            try
            {
                WebDriver.IsElementDisplayed(WebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")), 10000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.Pass();
        }

        [Test]
        public void BrowserActionGetElementName()
        {
            WebDriver.GoToUrl("https://www.google.com");
            WebDriver.WaitForPageToLoad();
            try
            {
                string eltName = WebDriver.GetElementName(WebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")));
                Assert.That(eltName.Contains("textarea"), $"Expected not found but was {eltName}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void BrowserActionGetType()
        {
            WebDriver.GoToUrl("https://www.google.com");
            WebDriver.WaitForPageToLoad();
            try
            {
                string eltType = WebDriver.GetElementType(WebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")));
                Assert.That(eltType.Contains("textarea"), $"Expected not found but was {eltType}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }
    }
}