using CareersTestAutomation.HtmlObjects;
using CareersTestAutomation.Selectors;
using OpenQA.Selenium;

namespace CareersTestAutomation.Pages
{
    public class JobOfferWebPage : CapGeminiWebPage
    {
        public HtmlControl OfferTitle;
        public HtmlHyperLink OfferApplyButton;
        public HtmlControl OfferBody;
        public HtmlControl OfferDescriptionDiv;
        public HtmlControl OfferDescription;
        public HtmlControl OfferLocation;

        public JobOfferWebPage(IWebDriver driver) : base(driver)
        {
            WaitForElements();
        }

        private new void WaitForElements()
        {
            OfferTitle = WaitForElementToBeInDom<HtmlControl>(JobOfferSelectors.OfferTitle);
            OfferApplyButton = WaitForElementToBeInDom<HtmlHyperLink>(JobOfferSelectors.OfferApplyLink);
            OfferBody = WaitForElementToBeInDom<HtmlControl>(JobOfferSelectors.OfferBody);
            OfferDescription = WaitForElementToBeInDom<HtmlControl>(JobOfferSelectors.OfferDescription);
            OfferLocation = WaitForElementToBeInDom<HtmlControl>(JobOfferSelectors.OfferLocation);

            WaitForGivenElementToBeVisible(OfferTitle);
            WaitForGivenElementToBeVisible(OfferApplyButton);
            WaitForGivenElementToBeVisible(OfferBody);

            base.WaitForElements();
        }

        public string GetJobDescription()
        {
            return OfferDescription.DisplayedText;
        }

        public string GetJobLocation()
        {
            return OfferLocation.DisplayedText;
        }
    }
}
