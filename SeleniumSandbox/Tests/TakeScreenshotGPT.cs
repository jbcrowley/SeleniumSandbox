using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class TakeScreenshotGPT
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
        public void TakeScreenshot_GPT()
        {
            // Take a full page screenshot of the specified URL
            string url = "https://stackoverflow.com/questions/44085722/how-to-get-screenshot-of-full-webpage-using-selenium-and-java";
            Bitmap bitmap = TakeFullPageScreenshot(url);

            // Save the bitmap to a file
            string datetime = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff");
            string saveLocation = @$"C:\temp\ScreenshotGPT.{datetime}.png";
            bitmap.Save(saveLocation, ImageFormat.Png);
        }

        public Bitmap TakeFullPageScreenshot(string url)
        {
            // Set the viewport size to the full size of the page
            // driver.Manage().Window.Size = new Size(driver.Manage().Window.Size.Width, 0);

            // Take multiple screenshots and combine them into one image
            List<Image> images = new List<Image>();
            int browserHeight = driver.Manage().Window.Size.Height;
            int previousHeight = -browserHeight;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            while (true)
            {
                // Scroll to the next page
                js.ExecuteScript($"window.scrollTo(0, {previousHeight + browserHeight});");
                Thread.Sleep(500);

                // Take a screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string datetime = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff");
                string saveLocation = @$"C:\temp\ScreenshotGPT_partial.{datetime}.png";
                screenshot.SaveAsFile(saveLocation, ScreenshotImageFormat.Png);

                // Load the screenshot into an Image object
                Image image = Image.FromFile(saveLocation);
                images.Add(image);

                // Check if the page is fully captured
                int currentHeight = image.Height; // TODO: This needs to be related to the browser viewport in some way... how far down we've scrolled, etc.
                if (currentHeight == previousHeight)
                {
                    break;
                }

                // Calculate the new height
                previousHeight = currentHeight;
            }

            // Create a new bitmap to hold the combined image
            Bitmap bitmap = new Bitmap(images[0].Width, images.Sum(x => x.Height));

            // Draw the images onto the bitmap
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                int y = 0;
                foreach (Image image in images)
                {
                    graphics.DrawImage(image, 0, y);
                    y += image.Height;
                }
            }

            // Return the bitmap
            return bitmap;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}