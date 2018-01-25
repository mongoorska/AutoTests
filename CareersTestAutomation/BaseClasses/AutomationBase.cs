using System;
using CareersTestAutomation.Common;
using CareersTestAutomation.HtmlObjects.Interfaces;
using OpenQA.Selenium;
namespace CareersTestAutomation.BaseClasses
{
    public abstract class AutomationBase : IDisposable
    {
        public IWebDriver Driver { get; protected set; }

        protected AutomationBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                Driver?.Dispose();
            }
        }

        protected void WaitForGivenElementToBeVisible(IHtmlControl element, int timeout = 45)
        {
            Driver.WaitForGivenElementToBeVisible(element, timeout);
        }

        protected bool TryWaitForGivenElementToBeVisible(IHtmlControl element, int timeout = 45)
        {
            return Driver.TryWaitForGivenElementToBeVisible(element, timeout);
        }

        protected void WaitForGivenElementToBeNotVisible(IHtmlControl element, int timeout = 45)
        {
            Driver.WaitForGivenElementToBeNotVisible(element, timeout);
        }

        protected bool TryWaitForGivenElementToBeNotVisible(IHtmlControl element, int timeout = 45)
        {
            return Driver.TryWaitForGivenElementToBeNotVisible(element, timeout);
        }

        protected TElement WaitForElementToBeInDom<TElement>(By selector, IHtmlControl parent = null, int timeout = 45) where TElement : class, IHtmlControl
        {
            return Driver.WaitForElementToBeInDom<TElement>(selector, parent, timeout);
        }

        protected TElement TryWaitForElementToBeInDom<TElement>(By selector, IHtmlControl parent = null, int timeout = 45) where TElement : class, IHtmlControl
        {
            return Driver.TryWaitForElementToBeInDom<TElement>(selector, parent, timeout);
        }
    }
}
