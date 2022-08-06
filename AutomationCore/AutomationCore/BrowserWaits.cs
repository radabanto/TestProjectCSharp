using OpenQA.Selenium;
using System;

namespace AutomationCore.UI
{
    internal class BrowserWaits
    {
        private readonly IJavaScriptExecutor _jsExecutor;
        private readonly BrowserAction _driver;
        private string _angularRootElement = "ng-app";

        public BrowserWaits(BrowserAction driver)
        {
            _driver = driver;
            _jsExecutor = (IJavaScriptExecutor)_driver.GetDriver();
        }

        public void WaitForPageToLoad()
        {
            //TODO: Parametrize customization of waits

            //Check Dom
            WaitForReadyState();

            //Check Ajax
            WaitForAjaxToComplete();

            //Check JQuery
            WaitForJQuery();

            //Check Angular
            WaitForAngular();

            //Check AngularJS
            WaitForAngularJs();
        }

        public bool WaitForReadyState()
        {
            var result = false;

            try
            {
                result = _driver.Wait().Until(x => HasDomLoaded());
                result = true;
            }
            catch (WebDriverTimeoutException e)
            {
                //TODO: Add logger class
            }
            return result;
        }

        private bool HasDomLoaded()
        {
            try
            {
                var hasThePageLoaded = _jsExecutor.ExecuteScript("return document.readyState");
                if (hasThePageLoaded == null || (string)hasThePageLoaded != "complete")
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;

        }

        public bool WaitForJQuery()
        {
            var result = false;

            try
            {
                result = !IsJqueryBeingUsed() || _driver.Wait().Until(x => HasJQueryLoaded());
            }
            catch
            {
                return false;
            }
            return result;
        }

        private bool IsJqueryBeingUsed()
        {
            bool isTheSiteUsingJQuery = false;

            try
            {
                isTheSiteUsingJQuery = (bool)_jsExecutor.ExecuteScript("return window.jQuery != undefined");
            }
            catch
            {
                //TODO: Add logging here
            }

            return isTheSiteUsingJQuery;
        }

        private bool HasJQueryLoaded()
        {
            try
            {
                var hasTheJQueryLoaded = _jsExecutor.ExecuteScript("return jQuery.active === 0");
                if (hasTheJQueryLoaded == null || !(bool)hasTheJQueryLoaded)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WaitForAngular()
        {
            var result = false;

            try
            {
                result = !IsAngularBeingUsed() || _driver.Wait().Until(x => HasAngularLoaded());
            }
            catch (Exception e)
            {
                //TODO: Add logger here
            }

            return result;
        }

        private bool IsAngularBeingUsed()
        {
            bool isTheSiteUsingAngular = false;
            try
            {
                var UsingAngular = "return window.getAllAngularRootElements()[0].attributes['ng-version']";
                isTheSiteUsingAngular = (bool)_jsExecutor.ExecuteScript(UsingAngular);
            }
            catch
            {
                //TODO: Add logger here
            }
            return isTheSiteUsingAngular;
        }

        private bool HasAngularLoaded()
        {
            var HasAngularLoaded = "return window.getAllAngularTestabilities().findIndex(x=>!x.isStable()) === -1";

            try
            {
                var hasTheAngularLoaded = _jsExecutor.ExecuteScript(HasAngularLoaded);
                if (hasTheAngularLoaded == null || !(bool)hasTheAngularLoaded)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void WaitForAjaxToComplete()
        {
            _jsExecutor.ExecuteScript("var callback = arguments[arguments.length - 1]; " +
                "var xhr = new XMLHttpRequest();" +
                "xhr.open('GET', '/Ajax_call', true);" +
                "xhr.onreadystatechange = function() {" +
                "   if (xhr.readyState == 4) {" +
                "       callback(xhr.responseText);" +
                "   }" +
                "};" +
                "xhr.send();");
        }

        public bool WaitForAngularJs()
        {
            var result = false;

            try
            {
                result = !IsAngularBeingUsedJs() || _driver.Wait().Until(x => HasAngularJsLoaded());
            }
            catch (Exception e)
            {
                //TODO: Add logger here
            }
            return result;
        }

        private bool IsAngularBeingUsedJs()
        {
            bool isTheSiteUsingAngularJs;
            try
            {
                var UsingAngularJs = @"if (window.angular){ return true; }";
                isTheSiteUsingAngularJs = (bool)_jsExecutor.ExecuteScript(UsingAngularJs);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool HasAngularJsLoaded()
        {
            var hasAngularJsLoadedString =
                $"return (window.angular !== undefined) && " +
                $"(window.angular.element(document.querySelectorAll('[{_angularRootElement}]')) !== undefined) && " +
                $"(angular.element(document.querySelectorAll('[{_angularRootElement}]')).injector() !== undefined) && " +
                $"(angular.element(document.querySelectorAll('[{_angularRootElement}]')).injector().get('$http').pendingRequests.length === 0)";

            try
            {
                var hasTheAngularJsLoaded = _jsExecutor.ExecuteScript(hasAngularJsLoadedString);
                if (hasTheAngularJsLoaded == null || !(bool)hasTheAngularJsLoaded)
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
