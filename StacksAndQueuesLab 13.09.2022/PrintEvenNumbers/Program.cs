using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            while (queue.Count !=1)
            {
                int currentNumber = queue.Dequeue();

                if (currentNumber%2 == 0)
                {
                    Console.Write($"{currentNumber}, ");
                }
            }

            Console.WriteLine(queue.Dequeue());
        }
    }
}
