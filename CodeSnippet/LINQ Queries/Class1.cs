using System;
using System.Collections.Generic;
using System.Linq;/// if we remove the using.system.Linq directive from our program, the query would not compile, because the Where, OrderBy, and Select methods would have nowhere to bind.
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LINQ_Queries
{
    public class Class1
    {
        static void Main()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            Regex wordCounter = new Regex(@"\b(\w|[-'])+\b");

            IEnumerable<string> query =
                from n in names
                where n.Contains("a")           // Filter elements
                orderby n.Length                // Sort elements
                select n.ToUpper();             // Translate each element (projection)

            //foreach (string name in query) 
            //{
            //    Console.WriteLine(name);
            //}
            //Console.ReadKey();

            //SubQuery
            IEnumerable<string> outerQuery = names
                            .Where(n => n.Length == names.OrderBy(n2 => n2.Length)
                                                        .Select(n2 => n2.Length).First());
            // We can avoid this inefficiency by running the subquery separately ( so that it's no longer a subquery)
            int shortest = names.Min(n => n.Length);

            IEnumerable<string> query2 = from n in names
                                        where n.Length == shortest
                                        select n;

            // Composition Strategies - Progressive Query Building
            IEnumerable<string> query3 = names
                .Select(n => Regex.Replace(n, "[aeiou]", ""))
                .Where(n => n.Length > 2)
                .OrderBy(n => n);

            Console.ReadKey();
        }
    }
}
