using System;
using System.Threading;

namespace _03___Threads_Asynchronization
{
    class Competition
    {
        static Car car1 = new Car { Name = "Pegeuot" };
        static Car car2 = new Car { Name = "Toyota" };

        static readonly int distance = 10000; ///10 km
        static void Main()
        {
            Thread thread1 = new Thread(FirstDrive);
            Thread thread2 = new Thread(SecondDrive);
        }

        static void FirstDrive()
        {
            for (double i = 0; i < distance; i++)
            {
                if (i % car1.Velocity == 0)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        static void SecondDrive()
        {
            for (double i = 0; i < distance; i++)
            {
                if (i % car1.Velocity == 0)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        static void CheckProblem()
        {

        }
    }
}
