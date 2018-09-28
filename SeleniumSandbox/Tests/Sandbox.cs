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

        [Test]
        public void SampleTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            string url = "https://www.humanbenchmark.com/tests/reactiontime/";
            Driver.Url = url;
        }
    }
}