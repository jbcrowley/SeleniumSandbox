using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class Test
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "https://github.com/SeleniumHQ/selenium/blob/trunk/dotnet/test/common/TakesScreenshotTest.cs";
            // string url = @"C:\Users\jbcro\Desktop\sample.html";
            driver.Url = url;
        }

        [Test]
        public void SampleTest()
        {
            string hidden = "hidden text: " + driver.FindElement(By.Id("hidden")).Text;
            string visible = "visible text: " + driver.FindElement(By.Id("visible")).Text;
            Console.WriteLine(hidden);
            Console.WriteLine(visible);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}