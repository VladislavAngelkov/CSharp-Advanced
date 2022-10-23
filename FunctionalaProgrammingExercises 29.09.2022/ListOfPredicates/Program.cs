using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperRange = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> numbers = Enumerable.Range(1, upperRange).ToList();

            foreach (var divider in dividers)
            {
                Predicate<int> isDivisibale = CreatePredicate(divider);

                numbers = numbers.Where(num => isDivisibale(num)).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Predicate<int> CreatePredicate(int divider)
        {
            return num => num % divider == 0;
        }
    }
}
