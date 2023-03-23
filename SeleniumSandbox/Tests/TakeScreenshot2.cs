using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class TakeScreenshot2
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
        public void TakeScreenshot_3()
        {
            Rectangle rectangle = ScreenCapture2.GetCurrentWindowSize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int innerHeight = (int)(long)js.ExecuteScript("return window.innerHeight");
            int outerHeight = (int)(long)js.ExecuteScript("return window.outerHeight");
            int width = (int)(long)js.ExecuteScript("return document.documentElement.clientWidth");
            // https://stackoverflow.com/a/34143777/2386774

            // adjust returned rectangle for invisible borders and chrome of browser
            // Rectangle correctedRectangle = new Rectangle(rectangle.X + 8, rectangle.Y, rectangle.Width - 16, rectangle.Height - 8);
            Rectangle correctedRectangle = new Rectangle(rectangle.X + 8, rectangle.Y + outerHeight - innerHeight, width, innerHeight);
            Bitmap image = ScreenCapture2.CaptureWindow(correctedRectangle);
            string datetime = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff");
            string saveLocation = @$"C:\temp\Screenshot3.{datetime}.png";
            image.Save(saveLocation, ImageFormat.Png);
        }

        [Test]
        public void TakeScreenshot_2()
        {
            Bitmap image = ScreenCapture2.CaptureActiveWindow();
            string datetime = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff");
            string saveLocation = @$"C:\temp\Screenshot2.{datetime}.png";
            image.Save(saveLocation, ImageFormat.Png);
        }

        [Test]
        public void GetFullPageScreenshot()
        {
            string datetime = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int height = (int)(long)js.ExecuteScript("return window.innerHeight");
            int width = (int)(long)js.ExecuteScript("return document.documentElement.clientWidth");
            string saveLocation = @$"C:\temp\Screenshot.{datetime}.png";
            //Rectangle bounds = this.Bounds;
            //using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            //{
            //    using (Graphics g = Graphics.FromImage(bitmap))
            //    {
            //        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            //    }
            //    bitmap.Save("C://test.jpg", ImageFormat.Jpeg);
            //}

            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Rectangle bounds2 = Screen.GetWorkingArea(Point.Empty);
            // Rectangle bounds = new Rectangle();

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save(saveLocation, ImageFormat.Png);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}