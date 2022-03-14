//using System;
//using System.Threading.Tasks;

//namespace Async_Tutorial
//{

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //Mehto1d();
//            //Method2();

//            CallMethod();
//            Console.ReadKey();
//        }

//        public static async void CallMethod()
//        {
//            Task<int> task = Mehto1d();
//            Method2();
//            int count = await task;
//            Method3(count);

//        }
//        public static async Task<int> Mehto1d()
//        {
//            int Count = 0;
//            await Task.Run(() =>
//            {
//                for (int i = 0; i < 5; i++)
//                {
//                    Console.WriteLine("Method 1");
//                    Task.Delay(1000).Wait();

//                }
//            });
//            return Count;
//        }

//        public static void Method2()
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                Console.WriteLine("Method 2");
//                Task.Delay(1000).Wait();

//            }
//        }

//        public static void Method3(int count)
//        {
//            Console.WriteLine("Total Count is : " + count);
//        }
//    }
//}
