using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(" ");

            int numberOfTosses = int.Parse(Console.ReadLine());

            Queue<string> leftKids = new Queue<string>(kids);

            int counter = 0;

            while (leftKids.Count > 1)
            {
                string currentKid = leftKids.Dequeue();

                counter++;

                if (counter%numberOfTosses == 0)
                {
                    Console.WriteLine($"Removed {currentKid}");
                }
                else
                {
                    leftKids.Enqueue(currentKid);
                }
            }

            Console.WriteLine($"Last is {leftKids.Dequeue()}");
        }
    }
}
