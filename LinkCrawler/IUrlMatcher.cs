using System.Collections.Generic;

namespace LinkCrawler
{
    public interface IUrlMatcher
    {
        IList<string> MatchUrls(string siteSource);
        IList<string> MatchDomains(string siteSource);
    }
}