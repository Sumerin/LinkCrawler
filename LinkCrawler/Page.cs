using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace LinkCrawler
{
    public class Page
    {

        public Dictionary<string, int> DomainsCounter { get; private set; }
        public HashSet<Page> SubPages { get; private set; }
        public string Domain { get; private set; }
        public string Url => source.Url;

        private readonly IHtmlProvider source;
        private readonly IUrlMatcher urlMatcher;

        public Page(IHtmlProvider source, IUrlMatcher urlMatcher)
        {
            this.source = source;
            this.urlMatcher = urlMatcher;
        }

        public Dictionary<string, int> Crawl()
        {
            var domainsCounter = new Dictionary<string, int>();
            string siteSource = source.GetSiteSource();
            IList<string> domains = this.urlMatcher.MatchDomains(siteSource);
            foreach (string domain in domains)
            {
                if (!domainsCounter.ContainsKey(domain))
                {
                    domainsCounter[domain] = 0;
                }
                domainsCounter[domain] += 1;
            }
            DomainsCounter = domainsCounter;
            return domainsCounter;
        }
    }
}
