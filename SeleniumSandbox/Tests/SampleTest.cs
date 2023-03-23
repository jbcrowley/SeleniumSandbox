using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumSandbox.PageObject;

namespace SeleniumSandbox.Tests
{
    public class SampleTest
    {
        [Test]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "http://the-internet.herokuapp.com/";
            driver.Url = url;

            string username = "tomsmith";
            string password = "SuperSecretPassword!";

            new LandingPage(driver).ClickLogin();

            new LoginPage(driver).Login(username, password);
        }
    }
}
