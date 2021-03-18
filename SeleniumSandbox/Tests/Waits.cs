using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class Waits
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            string url = "file:///C:/Users/jbcro/Desktop/sample.html";
            _driver.Url = url;
        }

        [Test]
        public void SampleTest()
        {
            string url = @"C:/Users/jbcro/Desktop/sample.html";
            _driver.FindElement(By.CssSelector("input")).SendKeys(url);
        }

        [Test]
        public void WaitTest()
        {
            By[] locators = { By.Id("element1"), By.Id("element2") };
            IWebElement foundElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(AnyElementExists(locators));
        }

        public Func<IWebDriver, IWebElement> AnyElementExists(By[] locators)
        {
            return (driver) =>
            {
                foreach (By locator in locators)
                {
                    IReadOnlyCollection<IWebElement> e = _driver.FindElements(locator);
                    if (e.Any())
                    {
                        return e.ElementAt(0);
                    }
                }

                return null;
            };
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}