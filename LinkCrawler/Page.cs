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
        private IHtmlProvider source;

        public Page(IHtmlProvider source)
        {
            this.source = source;
        }

        public Dictionary<string, int> Crawl()
        {
            return null;
        }
    }
}
