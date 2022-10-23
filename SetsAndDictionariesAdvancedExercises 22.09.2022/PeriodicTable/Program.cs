using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesOfInput = int.Parse(Console.ReadLine());

            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < linesOfInput; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    string currewntElement = input[j];

                    elements.Add(currewntElement);
                }
            }



            Console.WriteLine(string.Join(" ", elements.OrderBy(x=>x)));
        }
    }
}
