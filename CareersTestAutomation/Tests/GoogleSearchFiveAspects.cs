using CareersTestAutomation.BaseClasses;
using CareersTestAutomation.Enums;
using CareersTestAutomation.Pages;
using NUnit.Framework;


namespace CareersTestAutomation.Tests
{
    class GoogleSearchFiveAspects : TestBase
    {

        private string Keyword = "burak";
        private string ExpectedFat = "Tłuszcz 0,2 g";
        private string ExpectedCholesterol = "Cholesterol 0 mg";
        private string ExpectedPotassium = "Potas 325 mg";
        private string ExpectedCalories = "(kcal) 37";
        private string ExpectedType = "Roślina";

        [Test]
        public void GoogleTest([Values(BrowserType.IE, BrowserType.Chrome)] BrowserType browserType)
        {
            using (var GoogleMain = GoToPage<GoogleMainWebPage>(browserType))
            {
                var Description = GoogleMain.SearchForKeyword(Keyword).GetDescription();
                int counter = 0;
                if (Description.Contains(ExpectedCalories)) counter++;
                if (Description.Contains(ExpectedFat)) counter++;
                if (Description.Contains(ExpectedCholesterol)) counter++;
                if (Description.Contains(ExpectedPotassium)) counter++;
                if (Description.Contains(ExpectedType)) counter++;

                Assert.IsTrue(counter>2);
            }
        }


    }
}
