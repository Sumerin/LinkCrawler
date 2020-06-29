using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using LinkCrawler;
using System.Collections.Generic;

namespace LinkCrawler_Tests
{
    [TestClass]
    public class PageUT
    {

        [TestMethod]
        [Ignore]
        public void GivenHtmlWithScriptSource_WhenCrawl_ReturnsOneDomain()
        {
            //Arrange
            string siteSource = "<html><head><script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>";
            var mock = new Mock<IHtmlProvider>();
            mock.Setup(m => m.GetSiteSource()).Returns(siteSource);
            var page = new Page(mock.Object, null);


            //Act
            Dictionary<string, int> domains = page.Crawl();

            //Assert
            Assert.Equals(1, domains.Count);
            Assert.Equals("ajax.googleapis.com", domains.Keys);

        }
    }
}