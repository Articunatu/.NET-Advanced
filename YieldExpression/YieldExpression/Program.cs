using System;
using System.Collections.Generic;

namespace YieldExpression
{
    class Program
    {

        static List<int> intList = new List<int>();

        public static void FillV()
        {
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.Add(4);
            intList.Add(5);
            intList.Add(6);
            intList.Add(7);
        }
        static void Main(string[] args)
        {
            FillV();
            foreach (var item in FilterWithYeild())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        ///Creates a separate list
        static IEnumerable<int> Filter()
        {
            List<int> Temp = new List<int>();
            foreach (var i in intList)
            {
                if (i > 4)
                {
                    Temp.Add(i);
                }
            }
            return Temp;
        }

        ///
        static IEnumerable<int> FilterWithYeild()
        {
            foreach (var I in intList)
            {
                if (I > 4)
                {
                    yield return I;
                }
            }
        }
    }
}
