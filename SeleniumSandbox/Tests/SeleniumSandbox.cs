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
    public class SeleniumSandbox
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
            string url = @"C:/Users/jbcro/Desktop/sample.html";
            Driver.FindElement(By.CssSelector("input")).SendKeys(url);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}