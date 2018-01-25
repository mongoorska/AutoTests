using System;
using System.Collections.Generic;
using System.Linq;
using CareersTestAutomation.Common;
using CareersTestAutomation.Factories;
using CareersTestAutomation.HtmlObjects.Interfaces;
using OpenQA.Selenium;

namespace CareersTestAutomation.HtmlObjects
{
    public class HtmlControl : IHtmlControl
    {
        private IWebDriver _driver;
        private IWebElement _element;

        public virtual By Selector { get; set; }

        public virtual IWebElement Element
        {
            get { return _element; }
            set { _element = value; }
        }

        protected internal IWebDriver Driver => _driver ?? (_driver = _element.GetWrappedDriver());

        public virtual string TagName => Element.TagName;

        public virtual bool Enabled => Element.Enabled;

        public virtual bool Visible => Element.Displayed;

        public HtmlControl(IWebElement element)
        {
            Element = element;
        }

        public virtual string DisplayedText
        {
            get { return Element.Text; }
        }


        public virtual string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        public virtual string GetCssValue(string propertyName)
        {
            return Element.GetCssValue(propertyName);
        }

        public virtual TElement FindChildElement<TElement>(By selector) where TElement : class, IHtmlControl
        {
            IWebElement childElement = Element.FindElement(selector);
            return HtmlControlFactory.GetHtmlElementInstance<TElement>(childElement, selector);
        }

        public IList<TElement> FindChildElements<TElement>(By selector) where TElement : class, IHtmlControl
        {
            IList<IWebElement> childElements = Element.FindElements(selector);
            return childElements.Any() ? childElements.Select(x => HtmlControlFactory.GetHtmlElementInstance<TElement>(x, selector)).ToList() : new List<TElement>();
        }

        public virtual TElement TryFindChildElement<TElement>(By selector) where TElement : class, IHtmlControl
        {
            try
            {
                return FindChildElement<TElement>(selector);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual IList<TElement> TryFindChildElements<TElement>(By selector) where TElement : class, IHtmlControl
        {
            try
            {
                return FindChildElements<TElement>(selector);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual TParentElement GetParentElement<TParentElement>() where TParentElement : class, IHtmlControl
        {
            return (TParentElement)GetParentElement();
        }

        public virtual IHtmlControl GetParentElement()
        {
            By parentSelector = By.XPath("..");
            IWebElement parent = Element.FindElement(parentSelector);
            return HtmlControlFactory.GetHtmlElementInstance<HtmlControl>(parent, parentSelector);
        }

        public virtual void Click()
        {
            ClickElement();
        }

        protected virtual void ClickElement()
        {
            Driver.ExecuteJS("arguments[0].click();", this);
        }
    }
}
