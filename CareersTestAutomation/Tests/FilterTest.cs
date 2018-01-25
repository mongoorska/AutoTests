using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using NUnit.Framework;

namespace CareersTestAutomation.Tests
{
    class FilterTest : TestBase
    {
        
        private string JobToSearchFor = "Junior Client Advisor with Hungarian";
        private string ExpectedLocation =    "Krakow";


        [Test]
        public void FindFilteredJobAtCapGemini([Values(BrowserType.IE, BrowserType.Chrome)] BrowserType browserType)
        {
            using (var careersPage = GoToPage<CareersWebPage>(browserType))
            {
                var jobLocation = careersPage.GoToJobSearch()
                    .FilterAndSearch(JobToSearchFor)
                    .OpenJobOffer(JobToSearchFor)
                    .GetJobLocation();

                Assert.IsTrue(jobLocation.Contains(ExpectedLocation));
            }
        }
    }
}

