using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using NUnit.Framework;

namespace CareersTestAutomation.Tests
{
    class ExpEduDepartLocTest : TestBase
    {
        private string JobToSearchFor = "Senior Quality Assurance Specialist";

        private string ExpectedDescriptionFragment =
    "The scope of work is software testing, creating automated tests for software products "
    + "(various projects mainly in Microsoft .NET technology, Remedy ITSM), creating test plans,"
    + " tests strategies, coordination/management or leading testing processes.";

        private string ExpectedLocation = "Krakow";
        private string ExpectedExperience = "Professionals";
        private string ExpectedEducation = "Bachelor's degree or equivalent";
        private string ExpectedDepartment = "Infrastructure Services";

        [Test]
        public void FindJobWithFiveAspectsAtCapGemini([Values(BrowserType.IE, BrowserType.Chrome)] BrowserType browserType)
        {
            using (var careersPage = GoToPage<CareersWebPage>(browserType))
            {
                var job = careersPage.GoToJobSearch()
                    .SearchForJob(JobToSearchFor)
                    .OpenJobOffer(JobToSearchFor);

                var jobLocation = job.GetJobLocation();

                var jobDescription = job.GetJobDescription();

                int i = 0;

                if (jobLocation.Contains(ExpectedLocation)) i++;
                if (jobDescription.Contains(ExpectedDescriptionFragment)) i++;
                if (jobLocation.Contains(ExpectedExperience)) i++;
                if (jobLocation.Contains(ExpectedEducation)) i++;
                if (jobLocation.Contains(ExpectedDepartment)) i++;

                Assert.IsTrue(i>2);
            }
        }

    }
}
