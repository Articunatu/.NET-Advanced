using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Tutorial
{
    static class AsyncAwait
    {
        static void Main()
        {
            //Task task = new Task(CallMethod);
            //task.Start();
            //task.Wait();

            string FilePath = @"C:\Users\chris\OneDrive\Skrivbord\toread.txt";
            string[] lines = File.ReadAllLines(FilePath);
            List<string> LI = new List<string>();
            LI = File.ReadAllLines(FilePath).ToList();
            foreach (var item in LI)
            {
                Console.WriteLine(item);
            }

            LI.Add("Hej från dej");
            File.WriteAllLines(FilePath, LI);
        }

        static async void CallMethod()
        {
            string filePath = "C:\\Users\\chris\\OneDrive\\Skrivbord\toread.txt";
            Task<int> t = ReadFile(filePath);

            Console.WriteLine("Work 1.......Started ");
            Console.WriteLine("Work 2.......Started ");
            int l = await t;
            Console.WriteLine("Total Length " + 1);

            Console.WriteLine("Work 1 ..... Ended");
            Console.WriteLine("Work 2 ..... Ended");
        }

        static async Task<int> ReadFile(string file)
        {
            int Length = 0;
            Console.WriteLine("File reading is start ....");
            using (StreamReader reader = new StreamReader(file))
            {
                string s = await reader.ReadToEndAsync();
                Length = s.Length;
            }
            Console.WriteLine("File reading is ended");
            return Length;
        }
    }
}
