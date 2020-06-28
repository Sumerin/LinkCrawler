using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkCrawler_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Pass()
        {
        }

            [TestMethod]
        public void Fail()
        {
            Assert.Fail();
        }
    }
}
