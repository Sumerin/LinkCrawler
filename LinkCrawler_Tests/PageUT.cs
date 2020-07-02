using System.Linq;
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
        public void GivenOneDomain_WhenCrawl_ReturnsOneDomain()
        {
            //Arrange
            string siteSource = "mock string";
            var sites = new List<string>() { "ajax.googleapis.com" };
            var mockProvider = new Mock<IHtmlProvider>();
            mockProvider.Setup(m => m.GetSiteSource())
                        .Returns(siteSource);

            var mockMatcher = new Mock<IUrlMatcher>();
            mockMatcher.Setup(m => m.MatchDomains(It.Is<string>(x => x == siteSource)))
                       .Returns(sites);

            var page = new Page(mockProvider.Object, mockMatcher.Object);


            //Act
            Dictionary<string, int> domains = page.Crawl();

            //Assert
            Assert.AreEqual(1, domains.Count);
            Assert.AreEqual("ajax.googleapis.com", domains.Keys.FirstOrDefault());
            Assert.AreEqual(1, domains["ajax.googleapis.com"]);

        }


        [TestMethod]
        public void GivenOneDomain_WhenCrawl_ResultsIsSavedAsProperties()
        {
            //Arrange
            string siteSource = "mock string";
            var sites = new List<string>() { "ajax.googleapis.com" };
            var mockProvider = new Mock<IHtmlProvider>();
            mockProvider.Setup(m => m.GetSiteSource())
                        .Returns(siteSource);

            var mockMatcher = new Mock<IUrlMatcher>();
            mockMatcher.Setup(m => m.MatchDomains(It.Is<string>(x => x == siteSource)))
                       .Returns(sites);

            var page = new Page(mockProvider.Object, mockMatcher.Object);


            //Act
            Dictionary<string, int> domains = page.Crawl();

            //Assert
            Assert.AreSame(domains, page.DomainsCounter);

        }

        [TestMethod]
        public void GivenOneDomainTwice_WhenCrawl_ReturnsOneDomainTwice()
        {
            //Arrange
            string siteSource = "mock string";
            var sites = new List<string>() { "ajax.googleapis.com", "ajax.googleapis.com" };
            var mockProvider = new Mock<IHtmlProvider>();
            mockProvider.Setup(m => m.GetSiteSource())
                        .Returns(siteSource);

            var mockMatcher = new Mock<IUrlMatcher>();
            mockMatcher.Setup(m => m.MatchDomains(It.Is<string>(x => x == siteSource)))
                       .Returns(sites);

            var page = new Page(mockProvider.Object, mockMatcher.Object);


            //Act
            Dictionary<string, int> domains = page.Crawl();

            //Assert
            Assert.AreEqual(1, domains.Count);
            Assert.AreEqual("ajax.googleapis.com", domains.Keys.FirstOrDefault());
            Assert.AreEqual(2, domains["ajax.googleapis.com"]);
        }

        [TestMethod]
        public void GivenTwoDomain_WhenCrawl_ReturnsTwoDomains()
        {
            //Arrange
            string siteSource = "mock string";
            var sites = new List<string>() { "ajax.googleapis.com", "cdn.googleapis.com" };
            var mockProvider = new Mock<IHtmlProvider>();
            mockProvider.Setup(m => m.GetSiteSource())
                        .Returns(siteSource);

            var mockMatcher = new Mock<IUrlMatcher>();
            mockMatcher.Setup(m => m.MatchDomains(It.Is<string>(x => x == siteSource)))
                       .Returns(sites);

            var page = new Page(mockProvider.Object, mockMatcher.Object);


            //Act
            Dictionary<string, int> domains = page.Crawl();

            //Assert
            Assert.AreEqual(2, domains.Count);
            Assert.AreEqual(1, domains["ajax.googleapis.com"]);
            Assert.AreEqual(1, domains["cdn.googleapis.com"]);
        }
    }
}