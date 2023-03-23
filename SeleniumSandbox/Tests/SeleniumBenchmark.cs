using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class SeleniumBenchmark
    {
        IWebDriver driver;

        [SetUp]
        [GlobalSetup]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // string url = "https://xiaomifirmwareupdater.com/miui/";
            string url = @"C:\Users\jbcro\Desktop\sample.html";
            driver.Url = url;
        }

        [Benchmark]
        public void ById()
        {
            driver.FindElement(By.Id("test"));
        }

        [Benchmark]
        public void ByCssSelector()
        {
            driver.FindElement(By.CssSelector("#test"));
        }

        [Benchmark]
        public void ByXPath()
        {
            driver.FindElement(By.XPath("//*[@id='test']"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}