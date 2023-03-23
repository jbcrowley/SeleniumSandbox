using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScreenShotDemo;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class TakeScreenshot
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "https://stackoverflow.com/questions/44085722/how-to-get-screenshot-of-full-webpage-using-selenium-and-java";
            driver.Url = url;
        }

        [Test]
        public void GetFullPageScreenshot()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // 1
            // int bodyHeight = driver.FindElement(By.TagName("body")).Size.Height;
            // int windowChromeHeight = (int)(long)js.ExecuteScript("return window.outerHeight - window.innerHeight");
            // Size size = new Size(driver.Manage().Window.Size.Width, bodyHeight + windowChromeHeight);

            // 2
            int height = (int)(long)js.ExecuteScript("return window.innerHeight");
            int width = (int)(long)js.ExecuteScript("return document.documentElement.clientWidth");

            Size size = new Size(width, height);
            js.ExecuteScript("window.scrollTo(0, 0);");
            driver.Manage().Window.Size = size;

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\temp\Screenshot.png", ScreenshotImageFormat.Png);
        }

        [Test]
        public void GetFullPageScreenshot2()
        {
            string saveLocation = @"C:\temp\Screenshot2.png";
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save(saveLocation, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        [Test]
        public void ScreenCapture()
        {
            string saveLocation = @"C:\temp\ScreenCapture.png";
            ScreenCapture sc = new ScreenCapture();
            sc.CaptureScreenToFile(saveLocation, ImageFormat.Png);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}