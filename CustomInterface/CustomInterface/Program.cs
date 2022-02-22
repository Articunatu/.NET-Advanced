using System;

namespace CustomInterface
{
    class Program
    {
        static void Main()
        {
            Deck deck = new Deck();

            foreach (Card c in deck.GetAll())
            {
                Console.WriteLine(c.MyProperty);
            }
        }
    }
}
