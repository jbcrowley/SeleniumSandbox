using NUnit.Framework;

namespace SeleniumSandbox
{
    [TestFixture]
    class SimpleTest : Base
    {
        [Test]
        public void Test1()
        {
            Assert.Fail("This is a failure");
        }
        [Test]
        public void Test2()
        {
            Assert.True(2 == 2);
        }
        [Test]
        public void Test3()
        {
            Assert.True(2 == 2);
        }
        [Test]
        public void Test4()
        {
            Assert.True(2 == 2);
        }
    }
}