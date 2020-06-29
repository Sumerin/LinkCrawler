using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using LinkCrawler;

namespace LinkCrawler_Tests
{
    [TestClass]
    public class PageComparerUT
    {
        [TestMethod]
        public void GivenBothPagesAreNull_WhenCompare_ThenTrue()
        {
            //Arrange
            var comparer = new PageComparer();
            Page a = null;
            Page b = null;

            //Act/Assert
            Assert.IsTrue(comparer.Equals(a, b));
        }
        [TestMethod]
        public void GivenAPagesIsNull_WhenCompare_ThenFalse()
        {
            //Arrange
            var mock = new Mock<IHtmlProvider>();
            mock.Setup(m => m.Url).Returns("Object B Url");
            var comparer = new PageComparer();
            Page a = null;
            Page b = new Page(mock.Object);

            //Act/Assert
            Assert.IsFalse(comparer.Equals(a, b));
        }

        [TestMethod]
        public void GivenBPagesIsNull_WhenCompare_ThenFalse()
        {
            //Arrange
            var mock = new Mock<IHtmlProvider>();
            mock.Setup(m => m.Url).Returns("Object A Url");
            var comparer = new PageComparer();
            Page a = new Page(mock.Object);
            Page b = null;

            //Act/Assert
            Assert.IsFalse(comparer.Equals(a, b));
        }

        [TestMethod]
        public void GivenSamePageObject_WhenCompare_ThenTrue()
        {
            //Arrange
            var mock = new Mock<IHtmlProvider>();
            mock.Setup(m => m.Url).Returns("Object A Url");
            var comparer = new PageComparer();
            Page a = new Page(mock.Object);

            //Act/Assert
            Assert.IsTrue(comparer.Equals(a, a));
        }

        [TestMethod]
        public void GivenSamePage_WhenCompare_ThenTrue()
        {
            //Arrange
            var mockA = new Mock<IHtmlProvider>();
            mockA.Setup(m => m.Url).Returns("google.com");

            var mockB = new Mock<IHtmlProvider>();
            mockB.Setup(m => m.Url).Returns("google.com");

            var comparer = new PageComparer();
            Page a = new Page(mockA.Object);
            Page b = new Page(mockB.Object);

            //Act/Assert
            Assert.IsTrue(comparer.Equals(a, b));
        }
    }
}