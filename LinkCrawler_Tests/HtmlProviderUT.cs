using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinkCrawler;

namespace LinkCrawler_Tests
{
    [TestClass]
    public class HtmlProviderUT
    {
        
        [TestMethod]
        public void GivenHtmlProvider_whenCreateProvider_ReturnsObjectWithSameType()
        {
            //Arrange
            var htmlProvider = new HtmlProvider("google.com");
            string subUrl= "monk.com";

            //Act
            var child = htmlProvider.CreateProvier(subUrl);

            //Assert
            Assert.IsInstanceOfType(child, typeof(HtmlProvider));
            Assert.AreEqual(subUrl, child.Url);
        }

        [TestMethod]
        public void GivenHtmlProvider_whenGetSources_ReturnsGoogleSource()
        {
            //Arrange
            var htmlProvider = new HtmlProvider("http://www.google.com");

            //Act
            string result = htmlProvider.GetSiteSource();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}