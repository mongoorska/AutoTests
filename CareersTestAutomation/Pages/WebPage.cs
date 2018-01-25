using System;
using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Common;
using CareersTestAutomation.Pages.Interfaces;
using OpenQA.Selenium;

namespace CareersTestAutomation.Pages
{
    public abstract class WebPage : AutomationBase, IWebPage
    {
        private bool _waitForPageToLoad;
        public abstract Uri PageUrl { get; }

        public virtual bool WaitForPageToLoad
        {
            set { _waitForPageToLoad = value; }
            protected get { return _waitForPageToLoad; }
        }

        protected WebPage(IWebDriver driver) : base(driver)
        {
            _waitForPageToLoad = true;
        }

        public void NavigateToCurrentPage()
        {
            if (Driver.Url != PageUrl.ToString())
            {
                if (WaitForPageToLoad)
                {
                    Driver.NavigateToUrlAndWaitForPageToLoad(PageUrl);
                }
                else
                {
                    Driver.NavigateToUrl(PageUrl);
                }
            }
        }

        public void NavigateToPage(IWebPage page)
        {
            page.NavigateToCurrentPage();
        }
    }
}
