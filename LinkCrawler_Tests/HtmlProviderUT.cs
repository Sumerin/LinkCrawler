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
    }
}