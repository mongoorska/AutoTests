using System;
using System.Linq;
using System.Reflection;
using CareersTestAutomation.HtmlObjects.Interfaces;
using OpenQA.Selenium;

namespace CareersTestAutomation.Factories
{
    public class HtmlControlFactory
    {
        public static TElement GetHtmlElementInstance<TElement>(IWebElement element, By selector) where TElement : class, IHtmlControl
        {
            return (TElement)GetHtmlElementInstance(typeof(TElement), element, selector);
        }

        public static IHtmlControl GetHtmlElementInstance(Type elementType, IWebElement element, By selector)
        {
            IHtmlControl ctrl = CreateInstance(elementType, element) as IHtmlControl;
            if (ctrl == null)
            {
                return null;
            }

            ctrl.Selector = selector;
            return ctrl;
        }

        private static object CreateInstance(Type objectType, params object[] parameters)
        {
            Type[] contructorTypes = parameters.Select(x => x.GetType()).ToArray();
            Type typeToInitialize = objectType;
            ConstructorInfo constructor = typeToInitialize.GetConstructor(contructorTypes);
            if (constructor == null)
            {
                throw new ArgumentException("No constructor for the specified class containing a single argument of type IWebElement can be found");
            }
            return constructor.Invoke(parameters);
        }
    }
}
