﻿using System;
using System.Threading;

namespace _03___Threads_Asynchronization
{
    class Competition
    {
        static Car car1 = new Car { Name = "Pegeuot" };
        static Car car2 = new Car { Name = "Toyota" };

        static readonly int distance = 5000; ///10 km

        static int timePassed = 1;

        static Random random = new Random();

        static int counter = 0;

        static bool end;

        static void Main()
        {
            Thread thread1 = new Thread(FirstDrive);
            Thread thread2 = new Thread(SecondDrive);
            Thread thread3 = new Thread(Timer);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            while (!end)
            {
                Console.ReadKey();
                Status();
            }
        }

        static void FirstDrive()
        {
            Console.WriteLine(car1.Name + " började köra!");
            for (int i = 0; car1.CurrentDistance < distance; i++)
            {
                Thread.Sleep(1000);
                car1.CurrentDistance += car1.Velocity;
                if (timePassed % 30 == 0 && timePassed != 0)
                {
                    int possibility = random.Next(1, 50);
                    if (possibility < 20)
                    {
                        CheckProblem(car1, possibility);
                    }
                }
            }
            ReachGoal(car1);
        }

        static void SecondDrive()
        {
            Console.WriteLine(car2.Name + " började köra!");
            for (int timePassed = 0; car2.CurrentDistance < distance; timePassed++)
            {
                Thread.Sleep(1000);
                car2.CurrentDistance += car2.Velocity;
                if (timePassed % 30 == 0 && timePassed != 0)
                {
                    int possibility = random.Next(1, 50);

                    if (possibility < 20)
                    {
                        CheckProblem(car2, possibility);
                    }

                }
            }
            ReachGoal(car2);
        }

        ///Increments timer every 2 seconds
        static void Timer()
        {
            for (int i = 0; i < 750; i++)
            {

                Thread.Sleep(1000);
                timePassed += 1;

                if (timePassed % 5 == 0)
                {
                    Console.WriteLine(timePassed + " sekunder");
                }
                if (end == true)
                {
                    break;
                }
            }
        }

        static void Status()
        {
            Console.WriteLine();
            Console.WriteLine(car1.Name + "s sträcka: " + Math.Round(car1.CurrentDistance / 1000, 2) + "km"
                + "  hastighet: " + Math.Round(car1.Velocity, 2) + "km/h");
            Console.WriteLine(car2.Name + "s sträcka: " + Math.Round(car2.CurrentDistance / 1000, 2) + "km"
                + "  hastighet: " + Math.Round(car2.Velocity, 2) + "km/h");
            Console.WriteLine("Passerad tid: " + timePassed + "sekunder");
            Console.WriteLine();
        }

        static void CheckProblem(Car car, int pos)
        {
            int sec = 0;
            string problem;
            if (pos == 1)
            {
                ///Fuel
                problem = " har fått slut på bensin, stannar för att tanka i 30 sekunder";
                sec = 30000;
                //car.MotorMalfuntion = true;
            }
            else if (pos < 4)
            {
                ///Punctation
                problem = " har fått punktering, stannar för att byta däck i 20 sekunder";
                sec = 20000;
            }
            else if (pos < 14)
            {
                ///Motor     
                car.Velocity -= 1 / 3.6;
                problem = " har fått problem med sin motor, hastigheten minskas med 1 km/h" +
                    "\nNuvarande hastighet: " + car.Velocity.ToString();
                sec = 0;
            }
            else
            {
                ///Bird
                problem = " har fått besök av en fågel på vindrutan, " +
                    "stannar i 10 sekunder för att tvätta rutan";
                sec = 10000;
            }
            Console.WriteLine(car.Name + problem);
            if (sec != 0)
            {
                Thread.Sleep(sec);
                Console.WriteLine(car.Name +" börjar köra igen.\n");
            }
        }

        static void ReachGoal(Car car)
        {
            Console.Write($"{car.Name} har gått i mål! ");
            if (counter == 0)
            {
                Console.WriteLine("Den var först och vann loppet!");
            }
            else
            {
                Console.WriteLine("Men vinsten gick till bilen innan...");
                end = true;
            }
            counter++;
        }
    }
}
