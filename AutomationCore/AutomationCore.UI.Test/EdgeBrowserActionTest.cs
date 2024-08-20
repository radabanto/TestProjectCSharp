using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AutomationCore.UI.Test
{
    public class EdgeBrowserActionTest
    {
        private BrowserAction EdgeWebDriver;

        [SetUp]
        public void Setup()
        {
            EdgeWebDriver = new BrowserAction(new OpenQA.Selenium.Edge.EdgeOptions());
        }

        [Test]
        public void BrowserActionEdgeSessionTest()
        {
            EdgeWebDriver.GoToUrl("https://www.google.com");
            EdgeWebDriver.WaitForPageToLoad();
            Assert.Pass();
        }

        [Test]
        public void BrowserActionSeleniumWait()
        {
            EdgeWebDriver.GoToUrl("https://www.google.com");
            EdgeWebDriver.WaitForPageToLoad();
            try
            {
                EdgeWebDriver.Wait();
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
            EdgeWebDriver.GoToUrl("https://www.google.com");
            EdgeWebDriver.WaitForPageToLoad();
            try
            {
                EdgeWebDriver.Wait(5000);
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
            EdgeWebDriver.GoToUrl("https://www.google.com");
            EdgeWebDriver.WaitForPageToLoad();
            try
            {
                EdgeWebDriver.IsElementDisplayed(EdgeWebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")), 10000);
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
            EdgeWebDriver.GoToUrl("https://www.google.com");
            EdgeWebDriver.WaitForPageToLoad();
            try
            {
                string eltName = EdgeWebDriver.GetElementName(EdgeWebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")));
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
            EdgeWebDriver.GoToUrl("https://www.google.com");
            EdgeWebDriver.WaitForPageToLoad();
            try
            {
                string eltType = EdgeWebDriver.GetElementType(EdgeWebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")));
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
            EdgeWebDriver.CloseDriver();
        }
    }
}