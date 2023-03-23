using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

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
            string url = "https://www.cboe.com/delayed_quotes/vix/quote_table";
            // string url = @"C:\Users\jbcro\Desktop\sample.html";
            driver.Url = url;
        }

        [Test]
        public void SampleTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Read less']"))).Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}