namespace LinkCrawler
{
    public interface IHtmlProvider
    {
        IHtmlProvider CreateProvier(string url);
        string Url { get; }
        string GetSiteSource();
    }
}