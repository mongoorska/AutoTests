using System;
using System.Linq;
using System.Reflection;
using CareersTestAutomation.Pages;
using OpenQA.Selenium;

namespace CareersTestAutomation.Factories
{
    public class PageFactory
    {
        public static TPage InitWebPage<TPage>(ISearchContext driver) where TPage : WebPage
        {
            return (TPage) InitWebPage(typeof (TPage), driver);
        }

        public static WebPage InitWebPage(Type pageType, ISearchContext driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "IWebDriver cannot be null");
            }

            WebPage webPage = CreateInstance(pageType, driver) as WebPage;
            if (webPage == null)
            {
                return null;
            }
            return webPage;
        }

        private static object CreateInstance(Type objectType, params object[] parameters)
        {
            Type[] contructorTypes = parameters.Select(x => x.GetType()).ToArray();
            ConstructorInfo constructor = objectType.GetConstructor(contructorTypes);
            if (constructor == null)
            {
                throw new ArgumentException(
                    "No constructor for the specified class containing a single argument of type IWebDriver can be found");
            }
            return constructor.Invoke(parameters);
        }
    }
}
