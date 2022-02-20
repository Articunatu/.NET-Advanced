using System;

namespace _01___Generic_Box
{
    class Program
    {
        static void Main()
        {
            BoxCollection boxes = new BoxCollection();
            Box box = new Box(4,5,6);
            boxes.Add(box);
            box = new Box(7, 3, 2);
            boxes.Add(box);
            box = new Box(1, 42, 1);
            boxes.Add(box);
            boxes.Display();

            box = new Box(4, 5, 6);
            boxes.Add(box);
            boxes.Remove(boxes[0]);
            boxes.Display();

            try
            {
                if (boxes.Contains(boxes[2]))
                {
                    Console.WriteLine("Ja, angiven låda finns!");
                }
                else
                {
                    Console.WriteLine("Nej, den lådan finns inte....");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Nej, den lådan finns inte...."); 
            }
            

            if (boxes[0].EqualsVol(boxes[1]))
            {
                Console.WriteLine("Ja, lådorna har samma volym");
            }
            else
            {
                Console.WriteLine("Nej, lådorna har INTE samma volym");
            }
        }        
    }
}
