namespace CareersTestAutomation.HtmlObjects.Interfaces
{
    public interface IHtmlTextbox : IHtmlControl
    {
        string Text { get; }
        string Placeholder { get; }
        void SetText(string text, bool clear = true);
        void Clear();
    }
}
