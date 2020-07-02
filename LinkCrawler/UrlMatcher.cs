using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace LinkCrawler
{
    public class UrlMatcher
    {
        const string pattern = "((http|https)://){0,1}(www\\.){0,1}([a-zA-Z0-9-\\.]*\\.[a-zA-Z]{2,3})(/[a-zA-z0-9-=\\.\\$\\?]*)*";

        public IList<string> MatchUrls(string siteSource)
        {
            return (from Match match in Regex.Matches(siteSource, pattern)
                    select match.Value).ToList();
        }

        public IList<string> MatchDomains(string siteSource)
        {
            return (from Match match in Regex.Matches(siteSource, pattern)
                    select match.Groups[4]?.Value).ToList();
        }
    }
}