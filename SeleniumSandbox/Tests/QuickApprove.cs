using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumSandbox
{
    [TestFixture]
    public class QuickApprove
    {
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.loanspq.com/";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ctl00_bc_LoginMain_txtLogin"))).SendKeys("autotest123\n");
        }
    }
}