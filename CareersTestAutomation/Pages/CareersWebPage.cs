using System;
using CareersTestAutomation.Factories;
using CareersTestAutomation.HtmlObjects;
using CareersTestAutomation.Selectors;
using OpenQA.Selenium;

namespace CareersTestAutomation.Pages
{
    public class CareersWebPage : CapGeminiWebPage
    {
        public HtmlControl JobSearchSection;
        public HtmlHyperLink JobOffersLink;

        public CareersWebPage(IWebDriver driver) : base(driver)
        {
            NavigateToCurrentPage();
            WaitForElements();
        }

        private new void WaitForElements()
        {
            JobSearchSection = WaitForElementToBeInDom<HtmlControl>(CareersSelector.JobSearchSection);
            WaitForGivenElementToBeVisible(JobSearchSection);
            JobOffersLink = JobSearchSection.FindChildElement<HtmlHyperLink>(TagNames.Anchor);

            base.WaitForElements();
        }

        public override Uri PageUrl
        {
            get
            {
                return new Uri(base.PageUrl + "careers");
            }
        }

        public JobSearchWebPage GoToJobSearch()
        {
            JobOffersLink.Click();
            WaitForGivenElementToBeNotVisible(JobOffersLink);
            return PageFactory.InitWebPage<JobSearchWebPage>(Driver);
        }
    }
}
