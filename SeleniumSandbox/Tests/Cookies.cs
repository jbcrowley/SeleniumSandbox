using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class Cookies
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "https://www.google.com";
            driver.Url = url;
        }

        [Test]
        public void CookieTest()
        {
            // https://www.selenium.dev/documentation/webdriver/interactions/cookies/#get-all-cookies
            WriteAllCookies(ProcessCookies());
            // do click
            WriteAllCookies(ProcessCookies());
            // driver.Manage().Cookies.AddCookie(new Cookie("test1", "cookie1"));
        }

        public StringBuilder ProcessCookies()
        {
            StringBuilder sb = new StringBuilder();
            ReadOnlyCollection<Cookie> cookies = driver.Manage().Cookies.AllCookies;
            foreach (Cookie cookie in cookies)
            {
                string[] cookieParts = cookie.ToString().Split(new string[] { "; " }, StringSplitOptions.None);
                sb.AppendLine(cookieParts[0]);
                foreach (string s in cookieParts.Skip(1))
                {
                    sb.AppendLine($"  {s}");
                }
                sb.AppendLine();
            }

            return sb;
        }

        public void WriteAllCookies(StringBuilder sb)
        {
            string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(myDocsPath, "cookies.txt")))
            {
                outputFile.WriteLine(sb.ToString());
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}