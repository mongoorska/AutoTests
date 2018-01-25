using OpenQA.Selenium;

namespace CareersTestAutomation.Selectors
{
    public static class JobOfferSelectors
    {
        public static By OfferTitle = By.ClassName("component__hero-subpage__title");
        public static By OfferApplyLink = By.LinkText("Aplikuj teraz");
        public static By OfferBody = By.ClassName("blog-article-text");
        public static By OfferDescription = By.Id("JD-Field2");
        public static By OfferLocation = By.ClassName("careers__jobinfo");
    }
}
