using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IEnumerable
{
    class Program
    {
        static void Main()
        {
            //IEnumerable<string> enumerable = new string[] { "A", "B", "C" };

            ///Part 2 Enumerator +
            //IEnumerator<string> enumerator = enumerable.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    string s = enumerator.Current;
            //    Console.WriteLine(s);
            //}

            ///Part 1 Only enumerable
            //foreach (var item in enumerable)
            //{
            //    Console.WriteLine(item);
            //}

            ///Tutorial 2 IEnum ICollection
            //QueueAndList();

            ///Part 2-2
            //ObjectIEnumrable();

            ///Part 2-3
            //ICollectionsAndArray();

            ///Part 2-4
            //IList();

            ///Part 2-5
            //IDctionary();
        }

        private static void IDctionary()
        {
            IDictionary<string, decimal> salaryMap = new Dictionary<string, decimal>();
            salaryMap.Add("Hilda", 44000.45M);
            salaryMap.Add("Cheren", 32509.78M);
            salaryMap.Add("Elesa", 68777.13M);
            salaryMap.Remove("Cheren");
            Console.WriteLine(salaryMap.ContainsKey("Hilda"));
            Console.WriteLine(salaryMap.ContainsKey("Cheren"));

            if (salaryMap.ContainsKey("Elesa"))
            {
                Console.WriteLine("Den fjärde gym-ledaren i Unova-regionen");
            }

            Console.WriteLine("{0:C}", salaryMap["Hilda"]);
            Console.WriteLine("{0:C}", salaryMap["Elesa"]);

            decimal total = 0.0M;
            foreach (decimal s in salaryMap.Values)
            {
                total += s;
                Console.WriteLine("{0:C}", total);
            }

            foreach (KeyValuePair<string, decimal> item in salaryMap)
            {
                Console.WriteLine("{0} har en lön på {1}kr.", item.Key, item.Value);
            }
        }

        private static void IList()
        {
            IList<double> doubles = new List<double>();
            doubles.Add(15.20);
            doubles.Add(30.60);
            doubles.Insert(0, 48.97);
            doubles.Add(64.55);
            doubles.Remove(15.20);
            doubles.RemoveAt(2);
            Console.WriteLine("Talet {0} har ett index på {1}.", 30.60, doubles.IndexOf(30.60));
            Console.WriteLine("Talet {0} har ett index på {1}.", 64.55, doubles.IndexOf(64.55));
            for (int i = 0; i < doubles.Count; i++)
            {
                Console.WriteLine(doubles[i]);
            }
        }

        private static void ICollectionsAndArray()
        {
            Console.WriteLine("ISamling:");
            ICollection<int> IntCollection = new Collection<int>();
            IntCollection.Add(100);
            IntCollection.Add(333);
            IntCollection.Add(222);
            IntCollection.Remove(333);
            Console.WriteLine("Contains {0}? {1}!", 100, IntCollection.Contains(100));
            Console.WriteLine("Contains {0}? {1}!", 333, IntCollection.Contains(333));
            foreach (var item in IntCollection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nKopiering till fält:");
            int[] arrayInt = new int[IntCollection.Count];
            IntCollection.CopyTo(arrayInt, 0);
            for (int i = 0; i < arrayInt.Length; i++)
            {
                Console.WriteLine(arrayInt[i]);
            }
        }

        private static void ObjectIEnumrable()
        {
            ProductStorage storage = new ProductStorage();
            foreach (var item in storage)
            {
                if (!item.IsActive)
                {
                    item.Dis(0);
                }
                else
                {
                    item.Dis(14);
                }
            }
        }

        private static void QueueAndList()
        {
            IEnumerable<int> unknown = GetCol(1);

            Console.WriteLine("\n\nLista");
            foreach (var item in unknown)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n------------");
            Console.WriteLine("Kö");
            unknown = GetCol(2);
            foreach (var item in unknown)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n------------");
            Console.WriteLine("Övrig samling / fält");
            unknown = GetCol(3);
            foreach (var item in unknown)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n\n");
        }

        static IEnumerable<int> GetCol(int option)
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5 };

            Queue<int> intQue = new Queue<int>();
            intQue.Enqueue(6);
            intQue.Enqueue(7);
            intQue.Enqueue(8);
            intQue.Enqueue(9);
            intQue.Enqueue(10);

            if (option == 1)
            {
                return intList;
            }
            else if (option == 2)
            {
                return intQue;
            }
            else
            {
                return new int[] { 11, 12, 13, 14, 15 };
            }
        }
    }
}
