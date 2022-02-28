using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Tutorial_2
{
    class Program
    {
        static void Main()
        {
            List<object> DS = new List<object>()
            {
                "Gloria", "Victor", 99, "Leon", 867, 100
            };

            Console.WriteLine("Part 1");

            Console.WriteLine("\nAll number objects");
            IEnumerable<int> dbInt = DS.OfType<int>().ToList();
            foreach (var id in dbInt)
            {
                Console.WriteLine(id + " ");
            }

            Console.WriteLine("\nAll text objects");
            var dbString = (from n in DS where n is string select n).ToList();
            foreach (string t in dbString)
            {
                Console.WriteLine(t);
            }

            ///Off type with condition 
            Console.WriteLine("\nOfType with condition");
            var dbIn = DS.OfType<int>().Where(n => n >= 100).ToList();
            foreach (int cent in dbIn)
            {
                Console.WriteLine(cent);
            }

            ///Query syntax
            Console.WriteLine("\nQuery Syntax");     
            var dbS = (from name in DS
                       where name is string && name.ToString().Length > 4
                       select name.ToString());
            foreach (var item in dbS)
            {
                Console.WriteLine(item);
            }

            ///Part 2 Except 
            Console.WriteLine("\nPart II Except");
            List<int> dbInt1 = new List<int>()
            {
                1, 2, 30, 4, 5, 6
            };
            List<int> dbInt2 = new List<int>()
            {
                11, 30, 5, 8, 9, 10, 6
            };

            ///Method syntax
            Console.WriteLine("\nMethod syntax");
            var exMethod = dbInt1.Except(dbInt2).ToList();
            foreach (var item in exMethod)
            {
                Console.WriteLine(item);
            }

            ///StringComparer
            ///Query syntax
            Console.WriteLine("Query syntax");
            string[] arrStr1 = { "HuIbury", "Circhester", "Hammerlocke", "Stow-On-Side", "Motostoke"};
            string[] arrStr2 = { "Hulbury", "Hammerlocke", "Wyndon", "Stow-On-Side", "motostoke" };
            var querySyn = (from s in arrStr2 select s).Except(arrStr1, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (string city in querySyn)
            {
                Console.WriteLine(city);
            }

            ///Method syntax
            Console.WriteLine("Method syntax");
            var MAS = arrStr1.Except(arrStr2, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (string city in MAS)
            {
                Console.WriteLine(city);
            }
        }
    }
}
