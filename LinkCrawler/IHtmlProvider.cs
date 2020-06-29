namespace LinkCrawler
{
    public interface IHtmlProvider
    {
        string Url { get; }
        string GetSiteSource();
    }
}