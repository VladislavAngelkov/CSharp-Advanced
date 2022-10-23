using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            Dictionary<double, int> countOfDoubles = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!countOfDoubles.ContainsKey(numbers[i]))
                {
                    countOfDoubles.Add(numbers[i], 0);
                }

                countOfDoubles[numbers[i]] += 1;
            }

            foreach (var num in countOfDoubles)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
