using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class SeleniumBasic
    {
        [Test]
        public void SampleTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.google.com";
            driver.Quit();
        }
    }
}