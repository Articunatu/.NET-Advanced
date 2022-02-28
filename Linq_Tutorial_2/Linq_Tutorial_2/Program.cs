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
            string[] arrStr1 = { "HuIbury", "Circhester", "Hammerlocke", "Stow-On-Side", "Motostoke" };
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

            List<int> dbint3 = new List<int>()
            {
                1,2,3,4,5,6
            };
            List<int> dbint4 = new List<int>()
            {
                1,3,5,8,9,10
            };

            ///Intersect
            Console.WriteLine("----Method syntax------");
            var methSynth = dbint3.Intersect(dbint4).ToList();
            foreach (var item in methSynth)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----Query syntax-----");
            var querSynth = (from n in dbint3 select n).Intersect(dbint4).ToList();
            foreach (var item in querSynth)
            {
                Console.WriteLine(item);
            }

            ///Intersect ignorecase
            string[] arrStr3 = { "HuIbury", "Circhester", "Hammerlocke", "Stow-On-Side", "Motostoke" };
            string[] arrStr4 = { "Hulbury", "Hammerlocke", "Wyndon", "Stow-On-Side", "motostoke" };

            ///Method syntax
            Console.WriteLine("----Method syntax------");
            var ms = arrStr3.Intersect(arrStr4, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (var item in ms)
            {
                Console.WriteLine(item);
            }

            ///Query syntax
            Console.WriteLine("---Query syntax----");
            var qs = (from c in arrStr3 select c).Intersect(arrStr4, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (var item in qs)
            {
                Console.WriteLine(item);
            }

            ///Union syntax
            Console.WriteLine("UNION");
            List<int> listInt1 = new List<int>()
            {
                1,2,3,4,5,6
            };
            List<int> listInt2 = new List<int>()
            {
                1,3,5,8,9,10
            };

            ///Method
            Console.WriteLine("Method synth");
            var uniMeth = listInt1.Union(listInt2).ToList();
            foreach (var item in uniMeth)
            {
                Console.WriteLine(item);
            }

            ///Query
            Console.WriteLine("Query synth");
            var uniQue = (from n in listInt1 select n)
                         .Union(listInt2).ToList();
            foreach (var item in uniQue)
            {
                Console.WriteLine(item);
            }

            List<Person> people1 = new List<Person>()
            {
                new Person(){ID = 1, Name = "Peony"},
                new Person(){ID = 2, Name = "Mustard"},
                new Person(){ID = 3, Name = "Klara"},
                new Person(){ID = 4, Name = "Avery"},
            };
            List<Person> people2 = new List<Person>()
            {
                new Person(){ID = 4, Name = "Avery"},
                new Person(){ID = 5, Name = "Raihan"},
                new Person(){ID = 6, Name = "Piers"},
                new Person(){ID = 7, Name = "Mustard"},
            };

            ///Method
            Console.WriteLine();
            var namedPerson = people1.Select(p => p.Name).Union(people2.Select(p => p.Name)).ToList();
            foreach (var item in namedPerson)
            {
                Console.WriteLine(item);
            }

            ///Query
            Console.WriteLine();
            var idedPerson = (from i in people1 select i.Name)
                .Union(people2.Select(y => y.Name)).ToList();
            foreach (var item in idedPerson)
            {
                Console.WriteLine(item);
            }
        }
    }
}
