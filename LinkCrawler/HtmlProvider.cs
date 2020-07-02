using System.IO;
using System.Net;

namespace LinkCrawler
{
    public class HtmlProvider : IHtmlProvider
    {

        public string Url { get; private set; }
        public HtmlProvider(string url)
        {
            this.Url = url;
        }

        public string GetSiteSource()
        {
            WebRequest request = WebRequest.Create(this.Url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            return html;
        }
    }
}