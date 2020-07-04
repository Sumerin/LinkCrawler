using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using LinkCrawler;

namespace LinkCrawler_Tests
{
    [TestClass]
    public class UrlMatcherUT
    {
        [TestMethod]
        public void GivenSourceHttpsLink_WhenMatchUrl_returnsUrl()
        {
            //Arrange
            string jqueryCDNUrl = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js";
            string siteSource = $"<html><head><script src=\"{jqueryCDNUrl}\"></script></head><body></body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jqueryCDNUrl, result[0]);
        }

        [TestMethod]
        public void GivenSourceHttpLink_WhenMatchUrl_returnsUrl()
        {
            //Arrange
            string jqueryCDNUrl = "http://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js";
            string siteSource = $"<html><head><script src=\"{jqueryCDNUrl}\"></script></head><body></body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jqueryCDNUrl, result[0]);
        }

        [TestMethod]
        public void GivenSourceHttpWWWLink_WhenMatchUrl_returnsUrl()
        {
            //Arrange
            string jqueryCDNUrl = "http://www.ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js";
            string siteSource = $"<html><head><script src=\"{jqueryCDNUrl}\"></script></head><body></body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jqueryCDNUrl, result[0]);
        }

        [TestMethod]
        public void GivenSourceHttpsWWWLink_WhenMatchUrl_returnsUrl()
        {
            //Arrange
            string jqueryCDNUrl = "https://www.ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js";
            string siteSource = $"<html><head><script src=\"{jqueryCDNUrl}\"></script></head><body></body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jqueryCDNUrl, result[0]);
        }

        [TestMethod]
        public void GivenSourceAllowedCharacterLink_WhenMatchUrl_returnsUrl()
        {
            //Arrange
            string jqueryCDNUrl = "https://guess-whoo.netlify24.app/ajax/libs/jquery/3.5.1/jquery.min.js";
            string siteSource = $"<html><head><script src=\"{jqueryCDNUrl}\"></script></head><body></body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jqueryCDNUrl, result[0]);
        }

        [TestMethod]
        public void GivenSourceManySites_WhenMatchUrl_returnsUrls()
        {
            //Arrange
            string jqueryCDNUrl = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js";
            string picURL = "https://cdn.pg.edu.pl/ekontakt-updated-theme/images/favicon/apple-touch-icon.png?v=jw6lLb8YQ4";

            string siteSource = $"<html><head><script src=\"{jqueryCDNUrl}\"></script></head><body> <a class=\"logInButton\" href=\"{picURL}\" title=\"Login\">Login</a></body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(jqueryCDNUrl, result[0]);
            Assert.AreEqual(picURL, result[1]);
        }

        [TestMethod]
        public void GivenSourceExternalDependenciesAsText_WhenMatchUrl_returnsUrl()
        {
            //Arrange
            string picURL = "https://cdn.pg.edu.pl/ekontakt-updated-theme/images/favicon/apple-touch-icon.png?v=jw6lLb8YQ4";

            string siteSource = $"<html><head><script></script></head><body> Sources avaliable at {picURL} </body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(picURL, result[0]);
        }

        [TestMethod]
        public void GivenSourceNoExternalDependencies_WhenMatchUrl_returnsEmptyList()
        {
            //Arrange
            string siteSource = $"<html><head><script></script></head><body> </body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GivenSourceManySites_WhenMatchDomains_returnsDomains()
        {
            //Arrange
            string jqueryCDNUrl = "ajax.googleapis.com";
            string picURL = "cdn.pg.edu.pl";

            string siteSource = $"<html><head><script src=\"https://{jqueryCDNUrl}/ajax/libs/jquery/3.5.1/jquery.min.js\"></script></head><body> <a class=\"logInButton\" href=\"https://{picURL}/ekontakt-updated-theme/images/favicon/apple-touch-icon.png?v=jw6lLb8YQ4\" title=\"Login\">Login</a></body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchDomains(siteSource);

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(jqueryCDNUrl, result[0]);
            Assert.AreEqual(picURL, result[1]);
        }
    }
}