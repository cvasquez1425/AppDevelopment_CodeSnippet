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

            foreach (string name in query) 
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
    }
}
