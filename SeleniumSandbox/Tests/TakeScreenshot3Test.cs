using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SeleniumSandbox.Tests
{
    internal class TakeScreenshot3Test
    {
        private static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "https://ssfcu.org/";
            // string url = @"C:\Users\jbcro\Desktop\sample.html";
            driver.Url = url;
        }

        [Test]
        public void Test()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            // string sshot = (string)jse.ExecuteScript("const debuggerClient = await session.openDebuggingProtocol(tab.webSocketDebuggerUrl);await new Page(debuggerClient).captureScreenshot({ clip: passageRect });");
            string sshot = "R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==";
            string filePath = @"C:\Users\jbcro\Desktop\test.gif";
            File.WriteAllBytes(filePath, Convert.FromBase64String(sshot));

            // var screenshot = new TakeScreenshot3().GetScreenshotOfPage(driver);
            // screenshot.Save(@"C:\Users\jbcro\Desktop\test.jpg", ImageFormat.Jpeg);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}