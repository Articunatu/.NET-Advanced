using System;
using System.Linq;

namespace LinqEX
{
    class Program
    {
        static void Main(string[] args)
        {
            //Linq1();
            //Linq3();
            //Linq4();

        }

        private static void Linq4()
        {
            int[] numbers = new int[6] { 5, 9, 5, 1, 9, 5 };
            var n = from x in numbers
                    group x by x into y
                    select y;
            Console.WriteLine("\nThe number and the Frequency are : \n");
            foreach (var arrNo in n)
            {
                Console.WriteLine("Number " + arrNo.Key + " appears " + arrNo.Count() + " times");
            }
        }

        private static void Linq3()
        {
            int[] numbers = new int[4] { 9, 8, 6, 5 };
            var sqaured = from int n in numbers
                          let s = n * n
                          select new { Tal = n, Kvadrat = s };

            foreach (var item in sqaured)
            {
                Console.WriteLine(item);
            }
        }

        private static void Linq1()
        {
            int[] numbers = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] evenNrs = numbers.Where(a => a % 2 == 0).ToArray();
            Console.WriteLine("Jämna tal:");
            foreach (var item in evenNrs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
