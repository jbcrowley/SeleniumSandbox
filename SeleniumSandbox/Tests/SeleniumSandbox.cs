using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class SeleniumSandbox
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // string url = "https://www.google.com/search?q=budynki&rlz=1C1GCEU_plPL919PL919&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiRyJvoo_L9AhWJxIsKHTIKDqwQ_AUoAXoECAEQAw&biw=1553&bih=724";
            string url = @"C:\Users\jbcro\Desktop\sample.html";
            driver.Url = url;
        }

        [Test]
        public void SampleTest()
        {
            driver.FindElement(By.Id("test")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}