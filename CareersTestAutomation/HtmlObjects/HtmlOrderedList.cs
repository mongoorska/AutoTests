using System.Collections.Generic;
using CareersTestAutomation.Common;
using CareersTestAutomation.HtmlObjects.Interfaces;
using CareersTestAutomation.Selectors;
using OpenQA.Selenium;

namespace CareersTestAutomation.HtmlObjects
{
    public class HtmlOrderedList : HtmlControl, IHtmlOrderedList
    {
        public IList<HtmlControl> ListItems { get; set; }

        public HtmlOrderedList(IWebElement element) : base(element)
        {
            Driver.WaitForGivenElementToBeVisible(this);
            ListItems = FindChildElements<HtmlControl>(TagNames.ListItem);
        }
    }
}
