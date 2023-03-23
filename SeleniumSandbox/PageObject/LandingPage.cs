using OpenQA.Selenium;

namespace SeleniumSandbox.PageObject
{
    public class LandingPage
    {
        IWebDriver Driver;

        // this actually isn't a Login button, it's a "Form Authentication" link but for demo purposes...
        private readonly By _loginButtonLocator = By.CssSelector("a[href='/login']");

        public LandingPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void ClickLogin()
        {
            Driver.FindElement(_loginButtonLocator).Click();
        }
    }
}