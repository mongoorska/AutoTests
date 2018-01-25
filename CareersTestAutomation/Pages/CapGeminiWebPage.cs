using System;
using CareersTestAutomation.HtmlObjects;
using CareersTestAutomation.Providers;
using CareersTestAutomation.Selectors;
using OpenQA.Selenium;

namespace CareersTestAutomation.Pages
{
    public abstract class CapGeminiWebPage : WebPage
    {
        public HtmlHyperLink CapGeminiLogo;
        public HtmlControl Menu;

        protected CapGeminiWebPage(IWebDriver driver) : base(driver)
        {
        }

        protected void WaitForElements()
        {
            CapGeminiLogo = WaitForElementToBeInDom<HtmlHyperLink>(CapGeminiSelectors.CapGeminiLogo);
            Menu = WaitForElementToBeInDom<HtmlControl>(CapGeminiSelectors.Menu);

            WaitForGivenElementToBeVisible(CapGeminiLogo);
            WaitForGivenElementToBeVisible(Menu);
        }

        public override Uri PageUrl
        {
            get { return new Uri(SettingsProvider.HostName); }
        }
    }
}
