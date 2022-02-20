using System;
using System.Collections.Generic;

namespace övning_generics
{
    class Program
    {
        static void Main(string[] args)
        {

            lghCollection lista = new lghCollection();
            lista.Add(new lgh(1, 1201, 3));
            lista.Add(new lgh(2, 1202, 1));
            lista.Add(new lgh(3, 1301, 5));
            lista.Add(new lgh(4, 1302, 2));
            lista.Add(new lgh(5, 1501, 1));
            lista.Add(new lgh(5, 1501, 1));

            Display(lista);

            


            Console.ReadKey();
        }

        public static void Display(lghCollection display)
        {
            Console.WriteLine("\nId:\tLghNr:\tAntal:");
            foreach (var item in display)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.ID.ToString(), item.LghNr.ToString(), item.Antal.ToString());
            }
        }
    }
}
