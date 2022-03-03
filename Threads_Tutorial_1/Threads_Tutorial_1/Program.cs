using System;
using System.Threading;

namespace Threads_Tutorial_1
{
    class Program
    {
        static void Main()
        {
            //Method1();
            //Method2();

            ///Foreground threads by default
            //TwoThreads();

            ///Background thread
            //BackgroundThread();
            Thread t1 = new Thread(Method1)
            {
                Name = "Tråd 1"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Tråd 2"
            };
            Thread t3 = new Thread(Method3)
            {
                Name = "Tråd 3"
            };
            t1.Start();
            t2.Start();
            t3.Start();
        }

        private static void BackgroundThread()
        {
            Thread tback = new Thread(Background);
            tback.IsBackground = true;
            tback.Start();
            Console.WriteLine("Huvudtråden avslutad......");
        }

        private static void TwoThreads()
        {
            ///Create thread
            Thread thread1 = new Thread(Method1);
            Thread thread2 = new Thread(Method2);

            ///Invoke thread
            thread1.Start();
            thread2.Start();
        }

        static void Method1()
        {
            Console.WriteLine("2:a metod startade, som använde " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("1:a metoden började " + i.ToString());
                //Thread.Sleep(2000);
            }
            Console.WriteLine("1:a metod avslutad som använde " + Thread.CurrentThread.Name);
        }

        static void Method2()
        {
            Console.WriteLine("2:a metod startade genom " + Thread.CurrentThread.Name);
            for (int i = 11; i <= 20; i++)
            {
                if (i == 15)
                {
                    Console.WriteLine("Operation 2A påbörjad");
                    Thread.Sleep(5000);
                    Console.WriteLine("Operation 2A avslutad");
                }
                Console.WriteLine("2:a metoden började " + i.ToString());
                //Thread.Sleep(2000);
            }
            Console.WriteLine("2:a metod avslutad som använde " + Thread.CurrentThread.Name);
        }

        static void Method3()
        {
            Console.WriteLine("3:e metoden startade genom att använda " + Thread.CurrentThread.Name);
            for (int i = 6; i < 11; i++)
            {
                if (i == 9)
                {
                    Console.WriteLine("Operation 3B påbörjad");
                    Thread.Sleep(3600);
                    Console.WriteLine("Operation 3B avslutad");
                }
                else
                {
                    Thread.Sleep(1800);
                }
                Console.WriteLine("3:e metoden började " + i.ToString());
                //Thread.Sleep(2000);
            }
            Console.WriteLine("3:e metoden avslutades genom att använda " + Thread.CurrentThread.Name);
        }

        static void Background()
        {
            Console.WriteLine("Bakgrundsmetoden startade .....");
            Console.ReadLine();
            Console.WriteLine("Bakgrundsmetoden slutade");
        }
    }
}
