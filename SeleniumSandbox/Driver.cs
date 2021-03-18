using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSandbox
{
    public sealed class Driver
    {
        // Jon Skeet Singleton
        // https://csharpindepth.com/articles/singleton#cctor

        // private static readonly IWebDriver Instance = null;
        public static readonly IWebDriver Instance = null;

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Driver()
        {
            string browserName = "chrome";
            switch (browserName)
            {
                case "chrome":
                    Instance = new ChromeDriver();
                    break;
            }
        }

        private Driver()
        {
        }

        //public static IWebDriver Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}
    }
}