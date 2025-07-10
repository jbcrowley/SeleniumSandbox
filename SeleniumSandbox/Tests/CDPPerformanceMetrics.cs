using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class CDPPerformanceMetrics
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "https://www.selenium.dev/selenium/web/frameset.html";
            // string url = @"C:\Users\jbcro\Desktop\sample.html";
            driver.Url = url;
        }

        [Test]
        public void TracingTest()
        {
            string url = "https://www.google.com";
            Dictionary<string, object> emptyDictionary = new Dictionary<string, object>();
            ((ChromeDriver)driver).ExecuteCdpCommand("Tracing.start", emptyDictionary);
            driver.Url = url;
            ((ChromeDriver)driver).ExecuteCdpCommand("Tracing.end", emptyDictionary);

            Dictionary<string, object> response = (Dictionary<string, object>)((ChromeDriver)driver).ExecuteCdpCommand("Tracing.dataCollected", emptyDictionary);

            object[] metricList = (object[])response["metrics"];
            var metrics = metricList.OfType<Dictionary<string, object>>()
                .ToDictionary(
                    dict => (string)dict["name"],
                    dict => dict["value"]
                );

            Assert.IsTrue((double)metrics["DevToolsCommandDuration"] > 0);
            Assert.AreEqual((long)12, metrics["Frames"]);
        }

        [Test]
        public void PerformanceMetricsTest()
        {
            Dictionary<string, object> emptyDictionary = new Dictionary<string, object>();
            ((ChromeDriver)driver).ExecuteCdpCommand("Performance.enable", emptyDictionary);

            Dictionary<string, object> response = (Dictionary<string, object>)((ChromeDriver)driver).ExecuteCdpCommand("Performance.getMetrics", emptyDictionary);

            object[] metricList = (object[])response["metrics"];
            var metrics = metricList.OfType<Dictionary<string, object>>()
                .ToDictionary(
                    dict => (string)dict["name"],
                    dict => dict["value"]
                );

            Assert.IsTrue((double)metrics["DevToolsCommandDuration"] > 0);
            Assert.AreEqual((long)12, metrics["Frames"]);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}