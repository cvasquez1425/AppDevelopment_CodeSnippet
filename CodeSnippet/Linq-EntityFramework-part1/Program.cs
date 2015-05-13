using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_EntityFramework_part1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new MovieReviews())
            {
                var query =
                    from m in ctx.Movies
                    where m.Release_Date > new DateTime(2000, 1, 1)
                    select m;

                foreach (var movie in query.Take(15))
                {
                    Console.WriteLine(movie.Title, movie.Reviews, movie.Release_Date);
                }

                Console.WriteLine("Press any key to exit....");
                Console.ReadKey();

            }
        }
    }
}
