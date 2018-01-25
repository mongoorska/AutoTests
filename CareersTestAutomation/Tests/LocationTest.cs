
using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using NUnit.Framework;

namespace CareersTestAutomation.Tests
{
    class LocationTest : TestBase
    {
        private string JobToSearchFor = "Senior Quality Assurance Specialist";

        private string ExpectedLocation =
            "Krakow";

        [Test]
        public void FindJobWithLocationAtCapGemini([Values(BrowserType.IE, BrowserType.Chrome)] BrowserType browserType)
        {
            using (var careersPage = GoToPage<CareersWebPage>(browserType))
            {
                var jobLocation = careersPage.GoToJobSearch()
                    .SearchForJob(JobToSearchFor)
                    .OpenJobOffer(JobToSearchFor)
                    .GetJobLocation();

                Assert.IsTrue(jobLocation.Contains(ExpectedLocation));
            }
        }
    }
}
