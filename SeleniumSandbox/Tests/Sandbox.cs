using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumSandbox.Tests
{
    [TestFixture]
    public class Sandbox
    {
        static Random rnd = new Random();

        [Test]
        [Category("Sandbox")]
        public void SampleTest()
        {
            string[] filterList = new[] { "SAVINGS", "MASTERCARD CASH BACK", "MASTERCARD RWDS", "TRAVEL REWARDS" };
            string[] fullList = new[] { "- Select Account -", "TRAVEL REWARDS ****01234", "SAVINGS ****01234", "SAVINGS ****01235" };
            string[] namesList = fullList.Select(s => s.Split(new[] { " *" }, StringSplitOptions.None)[0]).ToArray();
            // string[] fullList = new[] { "- Select Account -", "TRAVEL REWARDS ****01234", "SAVINGS  ****01234", "SAVINGS  ****01235" };
            var results = namesList.Where(e => !filterList.Contains(e)).Select(e => e).ToArray();
        }

        [Test]
        [Category("Sandbox")]
        public void GenerateAbilitiesMethods()
        {
            int count = 1000000;
            int sum = 0;
            double average;

            // 3d6 strict
            for (int j = 0; j < count; j++)
            {
                List<int> rolls = new List<int>();
                for (int i = 0; i < 3; i++)
                {
                    rolls.Add(rnd.Next(1, 7));
                }

                sum += rolls.Sum();
            }

            average = (double)sum / count;

            Console.WriteLine($"3d6 strict");
            Console.WriteLine($"average: {average}");
            Console.WriteLine();


            // 3d6 3x, use highest
            sum = 0;
            for (int j = 0; j < count; j++)
            {
                List<int> rollSum = new List<int>();
                for (int k = 0; k < 3; k++)
                {
                    List<int> rolls = new List<int>();
                    for (int i = 0; i < 3; i++)
                    {
                        rolls.Add(rnd.Next(1, 7));
                    }

                    rollSum.Add(rolls.Sum());
                }

                sum += rollSum.Max();
            }

            average = (double)sum / count;

            Console.WriteLine($"3d6 3x, use highest");
            Console.WriteLine($"average: {average}");
            Console.WriteLine();


            // 4d6 drop lowest
            sum = 0;
            for (int j = 0; j < count; j++)
            {
                List<int> rolls = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    rolls.Add(rnd.Next(1, 7));
                }

                rolls = rolls.OrderBy(x => x).ToList();
                rolls.RemoveAt(0);

                sum += rolls.Sum();
            }

            average = (double)sum / count;

            Console.WriteLine($"4d6 drop lowest");
            Console.WriteLine($"average: {average}");
            Console.WriteLine();


            // 4d6 drop lowest, reroll 1s
            sum = 0;
            for (int j = 0; j < count; j++)
            {
                List<int> rolls = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    int roll = rnd.Next(1, 7);
                    while (roll == 1)
                    {
                        roll = rnd.Next(1, 7);
                    }
                    rolls.Add(roll);
                }

                rolls = rolls.OrderBy(x => x).ToList();
                rolls.RemoveAt(0);

                sum += rolls.Sum();
            }

            average = (double)sum / count;

            Console.WriteLine($"4d6 drop lowest, reroll 1s");
            Console.WriteLine($"average: {average}");
            Console.WriteLine();

            // 2d6 + 6
            sum = 0;
            for (int j = 0; j < count; j++)
            {
                List<int> rolls = new List<int>();
                for (int i = 0; i < 2; i++)
                {
                    rolls.Add(rnd.Next(1, 7));
                }

                rolls.Add(6);
                sum += rolls.Sum();
            }

            average = (double)sum / count;

            Console.WriteLine($"2d6 + 6");
            Console.WriteLine($"average: {average}");
        }

        [Test]
        [Category("Sandbox")]
        public void GenerateCharacterAbilties()
        {
            for (int k = 0; k < 10; k++)
            {
                List<int> final = new List<int>();
                for (int j = 0; j < 6; j++)
                {
                    List<int> rolls = new List<int>();
                    for (int i = 0; i < 4; i++)
                    {
                        rolls.Add(rnd.Next(1, 7));
                    }

                    rolls = rolls.OrderBy(x => x).ToList();
                    rolls.RemoveAt(0);

                    final.Add(rolls.Sum());
                }

                final = final.OrderBy(x => x).ToList();
                Console.WriteLine($"final rolls: {String.Join(",", final)}");
            }
        }

        [Test]
        [Category("Sandbox")]
        public void SampleTest2()
        {
            Uri uri = new Uri("https:");
            Uri uri2 = new Uri("https://web.google.com");
            string s = uri.Host;
        }

        [Test]
        [Category("Sandbox")]
        public void SampleTest3()
        {
            string now = DateTime.Now.ToString();
            string username = Environment.UserName;
            string domain = Environment.UserDomainName;
        }

        [Test]
        [Category("Sandbox")]
        public void SampleTest4()
        {
            decimal decimalTest = 12345.67m;
            string stringTest = "1234.56";
            string newString = (decimalTest / 10).ToString();
            // newString = newString[0..^1]; C# 8.0
            newString = newString.Remove(newString.Length - 1);
            Assert.AreEqual(stringTest, newString);
        }

        [Test]
        [Category("Sandbox")]
        public void SampleTest5()
        {
            string dateTimeString1 = "12/01/2020, 10:00 AM";
            string dateTimeString2 = "01/01/2020, 9:00 PM";
            bool test1 = DateTime.TryParseExact(dateTimeString1, "MM/dd/yyyy, h:mm tt", null, System.Globalization.DateTimeStyles.None, out _);
            bool test2 = DateTime.TryParseExact(dateTimeString2, "MM/dd/yyyy, h:mm tt", null, System.Globalization.DateTimeStyles.None, out _);
        }
    }
}