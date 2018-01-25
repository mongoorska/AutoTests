using CareersTestAutomation.HtmlObjects.Interfaces;
using OpenQA.Selenium;

namespace CareersTestAutomation.HtmlObjects
{
    public class HtmlSubmit : HtmlControl, IHtmlSubmit
    {
        public virtual string Value
        {
            get { return Element.GetAttribute("value"); }
        }

        public HtmlSubmit(IWebElement element) : base(element) { }
    }
}