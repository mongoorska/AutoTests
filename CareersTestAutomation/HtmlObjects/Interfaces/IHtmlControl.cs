using System.Collections.Generic;
using OpenQA.Selenium;

namespace CareersTestAutomation.HtmlObjects.Interfaces
{
    public interface IHtmlControl
    {
        By Selector { get; set; }
        IWebElement Element { get; set; }
        string TagName { get; }
        bool Enabled { get; }
        bool Visible { get; }
        string DisplayedText { get; }
        string GetAttribute(string attributeName);
        string GetCssValue(string propertyName);
        TElement FindChildElement<TElement>(By selector) where TElement : class, IHtmlControl;
        IList<TElement> FindChildElements<TElement>(By selector) where TElement : class, IHtmlControl;
        TElement TryFindChildElement<TElement>(By selector) where TElement : class, IHtmlControl;
        IList<TElement> TryFindChildElements<TElement>(By selector) where TElement : class, IHtmlControl;
        void Click();
    }
}
