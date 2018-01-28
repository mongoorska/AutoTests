using System;
using CareersTestAutomation.HtmlObjects;
using CareersTestAutomation.Providers;
using CareersTestAutomation.Selectors;
using OpenQA.Selenium;
namespace CareersTestAutomation.Pages
{
    class GoogleMainWebPage : WebPage
    {
        public HtmlTextbox SearchField;
        public HtmlSubmit SearchButton;
        public HtmlControl Description;


        public GoogleMainWebPage(IWebDriver driver) : base(driver)
        {
            NavigateToCurrentPage();
            WaitForElements();
        }

        public void WaitForElements()
        {
            SearchField = WaitForElementToBeInDom<HtmlTextbox>(GoogleMainSelectors.SearchField);
            SearchButton = WaitForElementToBeInDom<HtmlSubmit>(GoogleMainSelectors.SearchButton);
        }

        public void WaitForTable()
        {
            Description = WaitForElementToBeInDom<HtmlControl>(GoogleMainSelectors.Description);
        }

        public GoogleMainWebPage SearchForKeyword(string Keyword)
        {
            SearchField.SetText(Keyword);
            WaitForElements();
            WaitForGivenElementToBeVisible(SearchButton);
            SearchButton.Click();
            return this;
        }

        public override Uri PageUrl
        {
            get { return new Uri("https://google.com"); }
        }


        public String GetDescription()
        {
            WaitForTable();
            return Description.DisplayedText;
        }


    }
}
