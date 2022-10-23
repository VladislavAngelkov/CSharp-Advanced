using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int divisionNum = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> reverse = numbers =>
            {
                List<int> result = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    result.Add(numbers[i]);
                }

                return result;
            };

            Func<int, bool> isDivisable = CreateFunc(divisionNum);
            numbers = reverse(numbers.Where(num=>isDivisable(num)).ToList());

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Func<int, bool> CreateFunc(int divider)
        {
            return x => x % divider != 0;
        }
    }
}
