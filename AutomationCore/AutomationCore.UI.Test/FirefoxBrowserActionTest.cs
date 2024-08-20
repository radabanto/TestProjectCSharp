using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AutomationCore.UI.Test
{
    public class FirefoxBrowserActionTest
    {
        private BrowserAction FirefoxWebDriver;

        [SetUp]
        public void Setup()
        {
            FirefoxWebDriver = new BrowserAction(new OpenQA.Selenium.Firefox.FirefoxOptions());
        }

        [Test]
        public void BrowserActionFirefoxSessionTest()
        {
            FirefoxWebDriver.GoToUrl("https://www.google.com");
            FirefoxWebDriver.WaitForPageToLoad();
            Assert.Pass();
        }

        [Test]
        public void BrowserActionSeleniumWait()
        {
            FirefoxWebDriver.GoToUrl("https://www.google.com");
            FirefoxWebDriver.WaitForPageToLoad();
            try
            {
                FirefoxWebDriver.Wait();
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
            FirefoxWebDriver.GoToUrl("https://www.google.com");
            FirefoxWebDriver.WaitForPageToLoad();
            try
            {
                FirefoxWebDriver.Wait(5000);
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
            FirefoxWebDriver.GoToUrl("https://www.google.com");
            FirefoxWebDriver.WaitForPageToLoad();
            try
            {
                FirefoxWebDriver.IsElementDisplayed(FirefoxWebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")), 10000);
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
            FirefoxWebDriver.GoToUrl("https://www.google.com");
            FirefoxWebDriver.WaitForPageToLoad();
            try
            {
                string eltName = FirefoxWebDriver.GetElementName(FirefoxWebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")));
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
            FirefoxWebDriver.GoToUrl("https://www.google.com");
            FirefoxWebDriver.WaitForPageToLoad();
            try
            {
                string eltType = FirefoxWebDriver.GetElementType(FirefoxWebDriver.GetElementBy(By.XPath("//textarea[contains(@title, 'Search')]")));
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
            FirefoxWebDriver.CloseDriver();
        }
    }
}