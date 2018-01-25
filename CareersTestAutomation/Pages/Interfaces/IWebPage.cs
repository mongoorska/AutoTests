using System;

namespace CareersTestAutomation.Pages.Interfaces
{
    public interface IWebPage
    {
        Uri PageUrl { get; }
        bool WaitForPageToLoad { set; }
        void NavigateToCurrentPage();
        void NavigateToPage(IWebPage page);
    }
}