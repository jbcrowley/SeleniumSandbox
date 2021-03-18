using ExcelDataReader;
using FileHelpers;
using NUnit.Framework;
using SeleniumSandbox.Files;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace SeleniumSandbox.FileHelpers.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SampleTest()
        {
            string path = @"C:\Users\jbcro\Downloads";
            string fileName = WatchForDownloadedFile(path, "*.csv");
            FileHelperEngine<Transactions1> engine = new FileHelperEngine<Transactions1>();
            Transactions1[] transactions = engine.ReadFile(Path.Combine(path, fileName));
            var list = transactions.Select(t => new { TransactionDate = t.TransactionDate.ToString("M/d/yyyy"), t.CheckNumber, t.Description, Amount = Math.Max(t.DebitAmount, t.CreditAmount) });
        }

        [Test]
        public void Test()
        {
            string date = "20200331";
            string time = "103721";
            DateTime dt = DateTime.ParseExact($"{date} {time}", "yyyyMMdd hhmmss", CultureInfo.InvariantCulture);
            Console.WriteLine(dt.ToString("F"));
        }

        [Test]
        public void Test2()
        {
            string[] filesBefore = GetFilesFromDirectory(@"C:\Users\jbcro\Downloads", "*.csv");
            DateTime timeout = DateTime.Now.AddSeconds(15);
            string[] files = GetFilesFromDirectory(@"C:\Users\jbcro\Downloads", "*.csv");
            while (filesBefore.Length == files.Length && DateTime.Now < timeout)
            {
                Thread.Sleep(500);
                files = GetFilesFromDirectory(@"C:\Users\jbcro\Downloads", "*.csv");
            }

            if (filesBefore.Length < files.Length)
            {
                // file was downloaded
                string newFile = files.Except(filesBefore).First();
            }
            else
            {
                throw new TimeoutException("A new file was not downloaded within the timeout period.");
            }
        }

        [Test]
        public void Test3()
        {
            DateTime today = DateTime.Today;
            today.AddDays(1);
        }

        [Test]
        public void Test4()
        {
            string[] text = new[] { "Warning. This member has an active Cease and Desist order." };
            var a = text.Select(t => t.Split(new[] { ". " }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());

        }

        [Test]
        public void Test5()
        {
            string a1 = "$1.00";
            decimal d1 = decimal.Parse(a1, NumberStyles.Currency);

            string a2 = "1.00";
            decimal d2 = decimal.Parse(a2, NumberStyles.Currency);
        }

        [Test]
        public void Test6()
        {
            string filename = @"c:\Users\jbcro\Downloads\CaseList_2020-04-24_11-21-14.xlsx";
            DataSet result = GetDataSetFromExcel(filename);

            string[] columnNames = result.Tables[0].Rows[4].ItemArray.Cast<string>().ToArray();
        }

        [Test]
        public void Test7()
        {
            string[] com1 = { "COM6", "COM7" };
            string[] com2 = { "COM6", "COM7", "COM8" };

            string[] diff = com2.Except(com1).ToArray();
        }

        public DataSet GetDataSetFromExcel(string filename)
        {
            using (FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    return reader.AsDataSet();
                }
            }
        }

        public string[] GetFilesFromDirectory(string path, string filter)
        {
            return Directory.GetFiles(path, filter);
        }

        /// <summary>
        /// Watches the specified Windows path for a file that matches the provided filter and returns the name of the the newly downloaded file.
        /// </summary>
        /// <param name="path">The Windows folder to watch.</param>
        /// <param name="filter">The filter string used to determine what files to look for in the directory.</param>
        /// <param name="timeout">[Optional] The time to wait (in seconds) before timing out. The default is 15s.</param>
        /// <returns>The name of the newly downloaded file</returns>
        public string WatchForDownloadedFile(string path, string filter, int timeout = 15)
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;
                watcher.Filter = filter;
                watcher.Created += OnCreated;
                watcher.EnableRaisingEvents = true;

                var result = watcher.WaitForChanged(WatcherChangeTypes.Created, timeout * 1000);

                if (result.TimedOut)
                {
                    throw new Exception($"File download was not completed within {timeout}s");
                }

                return result.Name;
            }
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: {0}", e.Name);
        }

        [Test]
        public void GetNewDownloadedFile()
        {
            string path = @"C:\Users\jbcro\Downloads";

            var directory = new DirectoryInfo(path);
            var files = directory.GetFiles().Where(f => f.Extension == ".csv");
            int startCount = files.Count();
            DateTime timeout = DateTime.Now.AddSeconds(15);
            while (directory.GetFiles().Where(f => f.Extension == ".csv").Count() == startCount && DateTime.Now < timeout)
            {
                Thread.Sleep(500);
            }
            var myFile = files.Where(f => f.Extension == ".csv").OrderBy(f => f.CreationTime).First();
            Console.WriteLine(myFile.Name);
        }
    }
}