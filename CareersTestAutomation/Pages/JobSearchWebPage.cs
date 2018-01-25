using System;
using CareersTestAutomation.Factories;
using CareersTestAutomation.HtmlObjects;
using CareersTestAutomation.Selectors;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace CareersTestAutomation.Pages
{
    public class JobSearchWebPage : CapGeminiWebPage
    {
        public HtmlControl JobSearchComponent;
        public HtmlTextbox JobSearchField;
        public HtmlControl JobLocationDiv;
        public HtmlHyperLink JobLocationLink;
        public HtmlSubmit JobSearchSubmit;
        public HtmlControl SearchResultsContainer;
        public HtmlControl ButtonsComp;
        public HtmlSubmit NextBtn;
        public IWebElement SortingFilter;
        public IWebElement ContractTypeFilter;

        public IList<HtmlControl> SearchResults;

        public JobSearchWebPage(IWebDriver driver) : base(driver)
        {
            ContractTypeFilter = driver.FindElement(By.Name("filter_location"));
          //  SortingFilter = driver.FindElement(By.Name("filter_sorting"));
       
            WaitForElements();
        }

        private new void WaitForElements()
        {
            JobSearchComponent = WaitForElementToBeInDom<HtmlControl>(JobSearchSelectors.JobSearchComponent);
            WaitForGivenElementToBeVisible(JobSearchComponent);

            JobSearchField = WaitForElementToBeInDom<HtmlTextbox>(JobSearchSelectors.JobSearchField, JobSearchComponent);
            JobSearchSubmit = WaitForElementToBeInDom<HtmlSubmit>(JobSearchSelectors.JobSearchSubmit, JobSearchComponent);


            WaitForGivenElementToBeVisible(JobSearchField);         

            base.WaitForElements();

            SearchResultsContainer = WaitForElementToBeInDom<HtmlControl>(JobSearchSelectors.SearchResultsContainer);
           
            base.WaitForElements();

            NextBtn = WaitForElementToBeInDom<HtmlSubmit>(JobSearchSelectors.NextBtn);

            //    WaitForGivenElementToBeVisible(SortingFilter);
            // WaitForGivenElementToBeVisible(ContractTypeFilter);
            //   SortingFilter = WaitForElementToBeInDom<HtmlControl>(JobSearchSelectors.SortingFilter);
            //  ContractTypeFilter = WaitForElementToBeInDom<HtmlControl>(JobSearchSelectors.ContractTypeFilter);
            

        }
    
        public override Uri PageUrl
        {
            get
            {
                return new Uri(base.PageUrl + "jobs/search/");
            }
        }

        public JobSearchWebPage SearchForJob(string jobToSearchFor)
        {
            JobSearchField.SetText(jobToSearchFor);
            WaitForGivenElementToBeVisible(JobSearchSubmit);

            JobSearchSubmit.Click();
            WaitForElements(); // Clicking search button reloads the page

            WaitForGivenElementToBeVisible(SearchResultsContainer);
            SearchResults = SearchResultsContainer.FindChildElements<HtmlControl>(JobSearchSelectors.SearchResult);

            return this;
        }

        public JobSearchWebPage FilterAndSearch(string jobToSearchFor)
        {
            SelectElement ContractSelect = new SelectElement(ContractTypeFilter);
            ContractSelect.SelectByIndex(1);
            WaitForElements();

         

            WaitForGivenElementToBeVisible(SearchResultsContainer);
            SearchResults = SearchResultsContainer.FindChildElements<HtmlControl>(JobSearchSelectors.SearchResult);

            return this;

        }

        public JobOfferWebPage OpenJobOffer(string jobOfferTitle)
        {
            var matchingOffer = GetJobOfferByTitle(jobOfferTitle);
            var offerLink = matchingOffer.FindChildElement<HtmlHyperLink>(TagNames.Anchor);
            offerLink.Click();
            
            return PageFactory.InitWebPage<JobOfferWebPage>(Driver);
        }

        private HtmlControl GetJobOfferByTitle(string jobOfferTitle)
        {
            foreach (var offer in SearchResults)
            {
                var offerLink = offer.FindChildElement<HtmlHyperLink>(TagNames.Anchor);
                WaitForGivenElementToBeVisible(offerLink);

                if (offerLink.DisplayedText == jobOfferTitle)
                {
                    return offer;
                }
            }
            throw new WebDriverException(string.Format("Unable to find job offer {0}.", jobOfferTitle));
        }

        public int HowManyOffers(string jobOfferTitle)

        {
            int counter = 0;
            while (true) { 
                try {
                    counter += SearchResults.Count - 2;
                    Thread.Sleep(2000);
                    NextBtn.Click();
                }
                catch (Exception e) { break; }
        }
            return counter;

        }
    }
}
