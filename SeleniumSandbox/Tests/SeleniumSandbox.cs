using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

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
            string url = "https://www.nvidia.com/en-us/shop/geforce/?page=1&limit=9&locale=en-us";
            // string url = @"C:\Users\jbcro\Desktop\sample.html";
            driver.Url = url;
        }

        [Test]
        public void SampleTest()
        {
            By locator = By.CssSelector(".MyClass");
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
            IWebElement lastElement = elements.ElementAt(elements.Count - 1);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(locator).Text != lastElement.Text);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}