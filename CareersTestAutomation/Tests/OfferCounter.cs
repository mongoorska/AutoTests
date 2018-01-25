using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using NUnit.Framework;
using System;

namespace CareersTestAutomation.Tests
{
    class OfferCounter : TestBase
    {
        private string JobToSearchFor = "Quality Assurance";

        private int ExpectedJobsCount = 3;

        [Test]
        public void HowManyJobsAtCapGemini([Values(BrowserType.IE, BrowserType.Chrome)] BrowserType browserType)
        {
            using (var careersPage = GoToPage<CareersWebPage>(browserType))
            {
                var jobOfferCount = careersPage.GoToJobSearch()
                    .SearchForJob(JobToSearchFor).HowManyOffers(JobToSearchFor);


                Assert.IsTrue(jobOfferCount>ExpectedJobsCount);
            }
        }
    }
}
