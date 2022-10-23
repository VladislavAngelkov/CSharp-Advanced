using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int numbersToAdd = commands[0];
            int numbersToRemove = commands[1];
            int searchedNumber = commands[2];

            int[] inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> nums = new Queue<int>();

            for (int i = 0; i < numbersToAdd; i++)
            {
                if (i<inputNumbers.Length)
                {
                    nums.Enqueue(inputNumbers[i]);
                }
            }

            for (int i = 0; i < numbersToRemove; i++)
            {
                if (nums.Count>0)
                {
                    nums.Dequeue();
                }
            }

            if (nums.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (nums.Contains(searchedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
        }
    }
}
