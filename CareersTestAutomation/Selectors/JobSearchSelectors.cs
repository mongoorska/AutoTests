using OpenQA.Selenium;

namespace CareersTestAutomation.Selectors
{
    public static class JobSearchSelectors
    {
        public static By JobSearchComponent = By.ClassName("component__hero-inset--search");
        public static By JobSearchField = By.Name("search_term");
        public static By JobSearchSubmit = By.ClassName("single-input__submit");
        public static By SearchResultsContainer = By.XPath("//section[@class='section container']");
        public static By SearchResult = By.ClassName("col-12"); 
        public static By NextBtn = By.ClassName("pagination__next");
  //      public static By SortingFilter = By.Name("filter_sorting");
     //   public static By ContractTypeFilter = By.Name("filter_contract_type");


    }
}
