using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int lowerRange = Math.Min(range[0], range[1]);
            int upperRange = Math.Max(range[0], range[1]);

            string condition = Console.ReadLine().ToLower();

            Predicate<int> isEven = num => num % 2 == 0;
            Predicate<int> isOdd = num => num % 2 != 0;
            Func<string, Predicate<int>> oddOrEven = condition => condition == "even" ? isEven : isOdd;

            List<int> numbers = new List<int>();

            for (int number = lowerRange; number <= upperRange; number++)
            {
                numbers.Add(number);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(num=>oddOrEven(condition)(num))));
        }
    }
}
