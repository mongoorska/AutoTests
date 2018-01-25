using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using NUnit.Framework;

namespace CareersTestAutomation.Tests
{  
    public class CareersTests : TestBase
    {
        private string JobToSearchFor = "Senior Quality Assurance Specialist";

        private string ExpectedDescriptionFragment =
            "The scope of work is software testing, creating automated tests for software products "
            + "(various projects mainly in Microsoft .NET technology, Remedy ITSM), creating test plans," 
            + " tests strategies, coordination/management or leading testing processes.";

        [Test]
        public void FindJobAtCapGemini([Values(BrowserType.IE, BrowserType.Chrome)] BrowserType browserType)
        {
            using (var careersPage = GoToPage<CareersWebPage>(browserType))
            {
                var jobDescription = careersPage.GoToJobSearch()
                    .SearchForJob(JobToSearchFor)
                    .OpenJobOffer(JobToSearchFor)
                    .GetJobDescription();

                Assert.IsTrue(jobDescription.Contains(ExpectedDescriptionFragment));
            }
        }
    }
}
