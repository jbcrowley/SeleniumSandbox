using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace SeleniumSandbox.Tests
{
    public class WaitForStrings
    {
        [Test]
        public void WaitForStringsTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "http://the-internet.herokuapp.com/dynamic_loading/2";
            driver.Url = url;

            string[] expectedStrings = new string[] { "A", "B", "Hello World!" };
            driver.FindElement(By.CssSelector("#start > button")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(StringsToBePresentInElementLocated(By.XPath("(//h4)[2]"), expectedStrings));

            driver.Quit();
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the element that matches the given locator.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="strings">Text to be present in the element</param>
        /// <returns><see langword="true"/> once the element contains the given text; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebDriver, bool> StringsToBePresentInElementLocated(By locator, string[] strings)
        {
            return (driver) =>
            {
                try
                {
                    string s = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(locator)).Text;
                    return strings.Contains(s);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }
    }
}