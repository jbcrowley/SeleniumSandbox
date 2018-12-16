using NUnit.Framework;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class IgnoreTests
    {
        [Test]
        [Category("Ignore")]
        public void IgnoreTest1()
        {
            Assert.Pass();
        }
        [Test]
        [Category("Ignore")]
        [Ignore("Bug 1234", Until = "2018-08-03")]
        public void IgnoreTest2()
        {
            Assert.Pass();
        }
        [Test]
        [Category("Ignore")]
        [Ignore("Waiting for bug 1234", Until = "2018-08-02 10:29:00Z")]
        public void SomeTestCase()
        {
            Assert.Pass();
        }
    }
}
