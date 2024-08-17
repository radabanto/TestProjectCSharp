using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace AutomationCore.UI
{
    public class BrowserAction : BrowserDriver
    {
        private IWebDriver _webDriver;
        private int _explicitWaitValue = 5000;

        public BrowserAction()
        {
            _webDriver = GetDriver();
        }

        public BrowserAction(ChromeOptions options) : base(options)
        {
            _webDriver = GetDriver();
        }

        public BrowserAction(EdgeOptions options) : base(options)
        {
            _webDriver = GetDriver();
        }

        public BrowserAction(FirefoxOptions options) : base(options)
        {
            _webDriver = GetDriver();
        }

        public WebDriverWait Wait()
        {
            return Wait(_explicitWaitValue);
        }

        public WebDriverWait Wait(int timeout)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromMilliseconds(timeout));
        }

        public void WaitForPageToLoad()
        {
            new BrowserWaits(this).WaitForPageToLoad();
        }

        public bool WaitForElement(IWebElement element, double timeout)
        {
            var name = GetElementName(element);
            Exception lastException = null;
            var stopwatch = new Stopwatch();
            while (stopwatch.Elapsed.TotalSeconds <= timeout)
            {
                try
                {
                    if (element.Displayed)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
                Thread.Sleep(1000);
            }

            stopwatch.Stop();

            return false;
        }

        public string GetElementName(IWebElement element)
        {
            var name = string.Empty;

            try
            {
                if (element != null)
                {
                    if (element.TagName == "input" && element.GetAttribute("type") == "password")
                    {
                        name = "Password";
                    }
                    else if (!string.IsNullOrEmpty(element.GetAttribute("name")))
                    {
                        name = element.GetAttribute("name");
                    }
                    else if (!string.IsNullOrEmpty(element.GetAttribute("id")))
                    {
                        name = element.GetAttribute("id");
                    }
                    else if (!string.IsNullOrEmpty(element.GetAttribute("value")))
                    {
                        name = element.GetAttribute("value");
                    }
                    else
                    {
                        name = element.Text;
                    }
                }

                if (!string.IsNullOrEmpty(name))
                {
                    name = $"{name} {GetElementType(element)}";
                }
            }
            catch (Exception exception)
            {
                if (exception is StaleElementReferenceException || exception is NoSuchElementException)
                {
                    name = string.Empty;
                }

            }
            return name;
        }

        public string GetElementType(IWebElement element)
        {
            var type = string.Empty;
            if (string.IsNullOrEmpty(element.GetAttribute("type")))
            {
                type = $"{element.GetAttribute("type")} input";
            }
            else if (element.TagName.Contains("select"))
            {
                type = "dropdown";
            }
            else if (new List<string> { "button", "textarea", "table", "header", "footer" }.Contains(element.TagName))
            {
                type = element.TagName;
            }
            else if (element.TagName == "a")
            {
                type = "link";
            }
            else if (element.TagName == "tr")
            {
                type = "table row";
            }
            else if (element.TagName == "td")
            {
                type = "table column";
            }
            else if (element.TagName == "tbody")
            {
                type = "table";
            }
            else if (element.TagName == "option")
            {
                type = "dropdown option";
            }
            else if (new List<string> { "ol", "ul" }.Contains(element.TagName))
            {
                type = "list";
            }
            else if (new List<string> { "h1", "h2", "h3", "h4", "h5", "h6" }.Contains(element.TagName))
            {
                type = "section header";
            }
            else
            {
                type = "element";
            }
            return type;
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void GoToUrl(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }

        public string GetCurrentUrl()
        {
            return GetDriver().Url;
        }

        public void InputFieldText(IWebElement element, string textToType)
        {
            element.SendKeys(textToType);
        }
    }
}
