using System;
using CareersTestAutomation.HtmlObjects.Interfaces;
using OpenQA.Selenium;

namespace CareersTestAutomation.HtmlObjects
{
    public class HtmlHyperLink : HtmlControl, IHtmlHyperLink
    {
        public virtual string Href => GetAttribute("href");

        public virtual string Target => GetAttribute("target");

        public virtual bool OpenInNewWindow => string.Equals(Target, "_blank", StringComparison.InvariantCultureIgnoreCase);

        public HtmlHyperLink(IWebElement element) : base(element) { }
    }
}