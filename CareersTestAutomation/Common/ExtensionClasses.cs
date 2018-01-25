using System;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Factories;
using CareersTestAutomation.HtmlObjects.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using CareersTestAutomation.HtmlObjects;

namespace CareersTestAutomation.Common
{
    public static class WebDriverExtensions
    {


        public static WebDriverWait GetWaitDriver(this IWebDriver driver, int timeout = 45)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        }

        public static void WaitUntil(this IWebDriver driver, Func<IWebDriver, bool> condition, int timeout = 45)
        {
            driver.GetWaitDriver(timeout).Until(condition);
        }

        public static TElement WaitUntil<TElement>(this IWebDriver driver, Func<IWebDriver, TElement> condition, int timeout = 45)
        {
            return driver.GetWaitDriver(timeout).Until(condition);
        }

        public static IWebDriver NavigateToUrlAndWaitForPageToLoad(this IWebDriver driver, string url, int timeout = 90)
        {
            driver.NavigateToUrl(url).WaitForPageToLoad(timeout);
            return driver;
        }

        public static IWebDriver NavigateToUrlAndWaitForPageToLoad(this IWebDriver driver, Uri url, int timeout = 90)
        {
            driver.NavigateToUrl(url).WaitForPageToLoad(timeout);
            return driver;
        }

        public static IWebDriver NavigateToUrl(this IWebDriver driver, string url)
        {
            return driver.NavigateToUrl(new Uri(url));
        }

        public static IWebDriver NavigateToUrl(this IWebDriver driver, Uri url)
        {
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        public static IWebDriver WaitForPageToLoad(this IWebDriver driver, int timeout = 90)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
            return driver;
        }

        public static IWebDriver MaximizeBrowserWindow(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void ExecuteJS(this IWebDriver driver, string script, HtmlControl target)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script, target.Element);
        }

        public static void WaitForPageUrlToChange(this IWebDriver driver, string currentUrl, int timeout = 45)
        {
            try
            {
                driver.WaitUntil(d => d.Url != currentUrl, timeout);
            }
            catch (WebDriverTimeoutException)
            {
                string msg = "Waiting for url change failed. Url remains " + currentUrl + ". Exception is the following:";
                throw new WebDriverException(msg);
            }
        }

        public static void WaitForElementWithGivenAttributeValue(this IWebDriver driver, IHtmlControl element, string attributeName, string attributeValue)
        {
            try
            {
                driver.WaitUntil(d => element.GetAttribute(attributeName) == attributeValue);
            }
            catch (WebDriverTimeoutException)
            {
                string msg = $"Waiting for element attribute value failed. Waited for value: '{attributeValue}' in attribute: '{attributeName}'. ";
                throw new WebDriverTimeoutException(msg);
            }
        }

        public static void WaitForGivenElementToBeVisible(this IWebDriver driver, IHtmlControl element, int timeout = 45)
        {
            try
            {
                driver.WaitForElement(element, el => el.Visible, timeout);
            }
            catch (WebDriverTimeoutException)
            {
                string msg = "Waiting for element to be visible failed.";
                throw new WebDriverTimeoutException(msg);
            }
        }

        public static bool TryWaitForGivenElementToBeVisible(this IWebDriver driver, IHtmlControl element, int timeout = 45)
        {
            try
            {
                driver.WaitForElement(element, el => el.Visible, timeout);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static void WaitForGivenElementToBeNotVisible(this IWebDriver driver, IHtmlControl element, int timeout = 45)
        {
            try
            {
                driver.WaitForElement(element, el => !element.Element.Displayed, timeout, false);
            }
            catch (WebDriverTimeoutException)
            {
                string msg = "Waiting for element to be not visible failed.";
                throw new WebDriverTimeoutException(msg);
            }
        }

        public static bool TryWaitForGivenElementToBeNotVisible(this IWebDriver driver, IHtmlControl element, int timeout = 45)
        {
            try
            {
                driver.WaitForElement(element, el => !element.Element.Displayed, timeout, false);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static void WaitForElement(this IWebDriver driver, IHtmlControl element, Func<IHtmlControl, bool> condition, int timeout, bool returnFalseIfNotExists = true)
        {
            driver.WaitUntil(dr =>
            {
                try
                {
                    return condition(element);
                }
                catch (WebDriverException)
                {
                    return !returnFalseIfNotExists;
                }
                catch (InvalidOperationException)
                {
                    return !returnFalseIfNotExists;
                }
            }, timeout);
        }

        public static TElement WaitForElementToBeInDom<TElement>(this IWebDriver driver, By selector, IHtmlControl parent = null, int timeout = 45) where TElement : class, IHtmlControl
        {
            if (selector == null) throw new Exception("'By' selector cannot be null.");
            try
            {
                return driver.WaitUntil(dr =>
                {
                    try
                    {
                        if (parent != null)
                        {
                            return parent.FindChildElement<TElement>(selector);
                        }
                        IWebElement element = driver.FindElement(selector);
                        return HtmlControlFactory.GetHtmlElementInstance<TElement>(element, selector);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }, timeout);
            }
            catch (WebDriverTimeoutException)
            {
                string msg = "Waiting for element to be not clickable failed.";
                throw new WebDriverTimeoutException(msg);
            }
        }

        public static TElement TryWaitForElementToBeInDom<TElement>(this IWebDriver driver, By selector, IHtmlControl parent = null, int timeout = 45) where TElement : class, IHtmlControl
        {
            if (selector == null) throw new Exception("'By' selector cannot be null.");
            try
            {
                return driver.WaitUntil(dr =>
                {
                    try
                    {
                        if (parent != null)
                        {
                            return parent.FindChildElement<TElement>(selector);
                        }
                        IWebElement element = driver.FindElement(selector);
                        return HtmlControlFactory.GetHtmlElementInstance<TElement>(element, selector);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }, timeout);
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        public static BrowserType GetBrowserType(this IWebDriver driver)
        {
            string browserName = ((RemoteWebDriver)driver).Capabilities.BrowserName.ToLowerInvariant();
            switch (browserName)
            {
                case "internet explorer":
                    return BrowserType.IE;
                case "chrome":
                    return BrowserType.Chrome;
            }
            throw new ArgumentException("Browser type is not defined in BrowserType enum and not handled in GetBrowserType extension method");
        }
    }

    public static class WebElementExtensions
    {
        public static IWrapsDriver GetWrapsDriver(this IWebElement element)
        {
            IWrapsDriver wrappedDriver = element as IWrapsDriver;
            if (wrappedDriver == null)
            {
                throw new Exception("Could not retrive IWebDriver from current IWebElement instance");
            }
            return wrappedDriver;
        }

        public static IWebDriver GetWrappedDriver(this IWebElement element)
        {
            return element.GetWrapsDriver().WrappedDriver;
        }
    }
}
