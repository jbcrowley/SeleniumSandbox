using NUnit.Framework;
using System;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class FormatStringNumberAsNegative
    {
        [Test]
        public void SampleTest()
        {
            decimal d = -10.00m;
            Console.WriteLine(d.ToString());

            string s = "-10.00";
            decimal n = decimal.Parse(s);
            if (n < 0)
            {
                Console.WriteLine(n.ToString("C"));
            }
        }
    }
}