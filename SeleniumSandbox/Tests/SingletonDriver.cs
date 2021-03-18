using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class SingletonDriver
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = Driver.Instance;
            // _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            string url = "https://www.google.com";
            // string url = @"C:\Users\jbcro\Desktop\sample.html";
            _driver.Url = url;
        }

        [Test]
        public void SampleTest()
        {
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}