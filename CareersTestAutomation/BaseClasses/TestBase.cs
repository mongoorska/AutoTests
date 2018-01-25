using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using CareersTestAutomation.Providers;
using OpenQA.Selenium;
using PageFactory = CareersTestAutomation.Factories.PageFactory;

namespace CareersTestAutomation.BaseClasses
{
    public abstract class TestBase
    {
        protected T GoToPage<T>(BrowserType browserType) where T : WebPage
        {
            IWebDriver driver = DriverProvider.CreateWebDriverInstance(browserType);
            T page = PageFactory.InitWebPage<T>(driver);
            return page;
        }
    }
}