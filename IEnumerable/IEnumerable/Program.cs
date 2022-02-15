using System;
using System.Collections.Generic;

namespace IEnumerable
{
    class Program
    {
        static void Main()
        {
            IEnumerable<string> enumerable = new string[] { "A", "B", "C"};

            ///Part 2 Enumerator +
            IEnumerator<string> enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string s = enumerator.Current;
                Console.WriteLine(s);
            }

            ///Part 1 Only enumerable
            //foreach (var item in enumerable)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
