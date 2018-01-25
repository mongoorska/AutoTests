namespace CareersTestAutomation.HtmlObjects.Interfaces
{
    public interface IHtmlHyperLink : IHtmlControl
    {
        string Href { get; }
        string Target { get; }
        bool OpenInNewWindow { get; }
    }
}