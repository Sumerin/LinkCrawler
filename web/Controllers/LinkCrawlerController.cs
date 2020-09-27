using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkCrawler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web.Controllers
{
    [ApiController]
    [Route("/linkCrawlerApi")]
    public class LinkCrawlerController : ControllerBase
    {


        [HttpGet]
        public Page Get()
        {
            var provider = new HtmlProvider("http://www.google.com");
            var page = new Page(provider, new UrlMatcher());
            page.Crawl();
            return page;
        }
    }
}