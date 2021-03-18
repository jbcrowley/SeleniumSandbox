using NUnit.Framework;
using System.Linq;

namespace SeleniumSandbox.LINQTests
{
    [TestFixture]
    public class LINQTests
    {
        [Test]
        public void Query1()
        {
            string[] names = { "Tom", "Dick", "Harry" };

            // lambda query
            var filteredNames1 = names.Where(n => n.Length >= 4);

            // query comprehension syntax
            var filteredNames2 = from n in names
                                 where n.Length >= 4
                                 select n;
        }

        [Test]
        public void Query2()
        {
            string[] names = { "Tom", "Dick", "Harry" };

            // Only names with 4 or more characters: "Dick", "Harry"
            var filteredNames = names.Where(n => n.Length >= 4);

            // Ordered by length of name:  "Tom", "Dick", "Harry"
            var orderedNames = names.OrderBy(n => n.Length);

            // Ordered by name:  "Dick", "Harry", "Tom"
            var orderedNames2 = names.OrderBy(n => n);

            // All names are uppercase: "TOM", "DICK", "HARRY"
            var transformedNames = names.Select(n => n.ToUpper());
        }

        [Test]
        public void Query3()
        {
            string[] names = { "Tom", "Dick", "Harry" };

            // Count only names with 4 or more characters: 2 ("Dick", "Harry")
            var filteredNames = names.Where(n => n.Length >= 4).Count();
            var filteredNamesShort = names.Count(n => n.Length >= 4);
        }
    }
}