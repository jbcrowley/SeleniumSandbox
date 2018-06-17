using NUnit.Framework;
using System;
using System.Collections;
using System.Reflection;
using SC = System.ComponentModel;

namespace SeleniumSandbox
{
    [TestFixture]
    public class NUnitComplexDataDriven
    {
        [Test, TestCaseSource(typeof(TestData), "OtherVehicleLoanCases")]
        public void NUnitDataDriven(User user, OtherVehicleLoanData otherAutoLoanData)
        {
            System.Console.WriteLine($"{user.username}, {user.password}, {otherAutoLoanData.type.GetDescription()}, {otherAutoLoanData.rate}");
        }
    }

    public class TestData
    {
        public static IEnumerable OtherVehicleLoanCases
        {
            get
            {
                yield return new TestCaseData(new User(username: "121021", password: "Passw0rd"), new OtherVehicleLoanData(type: OtherVehicleLoanType.Boat, rate: "1.5"));
                yield return new TestCaseData(new User(username: "123456", password: "Passw0rd"), new OtherVehicleLoanData(type: OtherVehicleLoanType.Motorcycle, rate: "9.5"));
                yield return new TestCaseData(new User(username: "234567", password: "Passw0rd"), new OtherVehicleLoanData(type: OtherVehicleLoanType.RV, rate: "11.5"));
            }
        }
    }

    public class User
    {
        public string username;
        public string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

    public class OtherVehicleLoanData
    {
        public OtherVehicleLoanType type;
        public string rate;

        public OtherVehicleLoanData(OtherVehicleLoanType type, string rate)
        {
            this.type = type;
            this.rate = rate;
        }
    }

    public enum OtherVehicleLoanType
    {
        Boat,
        [SC.Description("Recreational Vehicle")]
        RV,
        Motorcycle
    }

    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = (SC.DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(SC.DescriptionAttribute));

            return (attribute != null) ? attribute.Description : value.ToString();
        }
    }
}