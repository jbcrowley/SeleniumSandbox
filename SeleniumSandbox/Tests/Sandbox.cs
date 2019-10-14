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
    public class Sandbox
    {
        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            string url = "file:///C:/Users/jbcro/Desktop/sample.html";
            Driver.Url = url;
        }

        [Test]
        public void SampleTest()
        {
            By dropdownLocator = By.Id("pet-select");
            By hiddenLocator = By.Id("hidden");
            WaitForElement(ExpectedConditions.ElementIsVisible(dropdownLocator)).Click();
            WaitForElement(ExpectedConditions.InvisibilityOfElementLocated(hiddenLocator));

            Wait(ExpectedConditions.ElementIsVisible(dropdownLocator));
            Wait(ExpectedConditions.ElementToBeClickable(dropdownLocator)).Click();
            Wait(ExpectedConditions.InvisibilityOfElementLocated(hiddenLocator));
        }

        public IAlert WaitForAlert(Func<IWebDriver, IAlert> expectedCondition)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(expectedCondition);
        }

        public IWebElement WaitForElement(Func<IWebDriver, IWebElement> expectedCondition)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(expectedCondition);
        }

        public bool WaitForElement(Func<IWebDriver, bool> expectedCondition)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(expectedCondition);
        }

        public IReadOnlyCollection<IWebElement> WaitForElements(Func<IWebDriver, IReadOnlyCollection<IWebElement>> expectedCondition)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(expectedCondition);
        }

        public T Wait<T>(Func<IWebDriver, T> expectedCondition)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(expectedCondition);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}