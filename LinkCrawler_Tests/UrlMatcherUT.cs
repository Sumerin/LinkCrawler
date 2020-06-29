using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinkCrawler;
using System.Collections.Generic;

namespace LinkCrawler_Tests
{
    [TestClass]
    public class UrlMatcherUT
    {
        [TestMethod]
        public void GivenSourceHttpsLink_WhenMatch_returnsUrl()
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
        public void GivenSourceHttpLink_WhenMatch_returnsUrl()
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
        public void GivenSourceHttpWWWLink_WhenMatch_returnsUrl()
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
        public void GivenSourceHttpsWWWLink_WhenMatch_returnsUrl()
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
        public void GivenSourceAllowedCharacterLink_WhenMatch_returnsUrl()
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
        public void GivenSourceManySites_WhenMatch_returnsUrls()
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
        public void GivenSourceExternalDependenciesAsText_WhenMatch_returnsUrl()
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
        public void GivenSourceNoExternalDependencies_WhenMatch_returnsEmptyList()
        {
            //Arrange
            string siteSource = $"<html><head><script></script></head><body> </body></html>";
            var matcher = new UrlMatcher();

            //Act
            IList<string> result = matcher.MatchUrls(siteSource);

            //Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}