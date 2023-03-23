using OpenQA.Selenium;

namespace SeleniumSandbox.PageObject
{
    public class LoginPage
    {
        IWebDriver Driver;

        private readonly By _loginButtonLocator = By.CssSelector("button");
        private readonly By _passwordLocator = By.Id("password");
        private readonly By _usernameLocator = By.Id("username");

        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void Login(string username, string password)
        {
            Driver.FindElement(_usernameLocator).SendKeys(username);
            Driver.FindElement(_passwordLocator).SendKeys(password);
            Driver.FindElement(_loginButtonLocator).Click();
        }
    }
}