using CareersTestAutomation.Common;
using CareersTestAutomation.HtmlObjects.Interfaces;
using OpenQA.Selenium;

namespace CareersTestAutomation.HtmlObjects
{
    public class HtmlTextbox : HtmlControl, IHtmlTextbox
    {
        public virtual string Text => Element.Text;
        public virtual string Value => Element.GetAttribute("Value");
        public virtual string Placeholder => Element.GetAttribute("placeholder");
        public HtmlTextbox(IWebElement element) : base(element) { }

        public virtual void SetText(string text, bool clear = true)
        {
            if (clear)
            {
                Clear();
            }
            Element.SendKeys(text);
            Driver.WaitForElementWithGivenAttributeValue(this, "value", text);
        }

        public virtual void Clear()
        {
            Element.Clear();
        }
    }
}
