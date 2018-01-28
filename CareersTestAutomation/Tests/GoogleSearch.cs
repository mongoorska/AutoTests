using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using NUnit.Framework;
namespace CareersTestAutomation.Tests
{
    class GoogleSearch : TestBase
    {
        private string Keyword = "burak";
        private string ExpectedCholesterol = "Cholesterol 0 mg";


        [Test]
        public void IsThisCholesterolFree([Values(BrowserType.IE, BrowserType.Chrome)] BrowserType browserType)
        {
            using (var GoogleMain = GoToPage<GoogleMainWebPage>(browserType))
            {
                var Description = GoogleMain.SearchForKeyword(Keyword).GetDescription();
            
                Assert.IsTrue(Description.Contains(ExpectedCholesterol));
            }
        }

    }
}
