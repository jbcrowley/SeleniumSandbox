using System.Collections;
using NUnit.Framework;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class NUnitSimpleDataDriven
    {
        [Test, TestCaseSource(typeof(MySimpleDataClass), "TestCases")]
        public void NUnitDataDriven(string username, string password)
        {
            System.Console.WriteLine($"{username}, {password}");
        }
    }

    public class MySimpleDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("121021", "Passw0rd");
                yield return new TestCaseData("123456", "Passw0rd");
                yield return new TestCaseData("234567", "Passw0rd");
                yield return new TestCaseData("345678", "Passw0rd");
            }
        }
    }
}