using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
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

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < numbersToAdd; i++)
            {
                if (i<inputNumbers.Length)
                {
                    nums.Push(inputNumbers[i]);
                }
            }

            for (int i = 0; i < numbersToRemove; i++)
            {
                if (nums.Count != 0)
                {
                    nums.Pop();
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
