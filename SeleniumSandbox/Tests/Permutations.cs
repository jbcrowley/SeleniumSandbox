using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace SeleniumSandbox.Tests
{
    class Permutations
    {
        private static Dictionary<string, int> dict;

        [Test]
        [Category("Permutations")]
        public void WordTest()
        {
            // https://github.com/dwyl/english-words
            // https://stackoverflow.com/questions/2012738/c-issues-using-dictionary-with-languages-other-than-english
            dict = LoadDictionary();
            string str = "abbc";
            char[] arr = str.ToCharArray();
            GetPer(arr);
        }


        private void Swap(ref char a, ref char b)
        {
            if (a == b)
            {
                return;
            }

            char temp = a;
            a = b;
            b = temp;
        }

        public void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                string s = new string(list);
                Console.WriteLine($"{s}: {dict.ContainsKey(s)}");
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
            }
        }

        private Dictionary<string, int> LoadDictionary()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(@"C:\Users\jbcro\source\repos\SeleniumSandbox\SeleniumSandbox\Files\words_dictionary.json"));
        }
    }
}