using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstSetLength = inputInfo[0];
            int secondSetLength = inputInfo[1];

            if (firstSetLength == 0 || secondSetLength == 0)
            {
                return;
            }

            HashSet<string> firstSet = new HashSet<string>();
            HashSet<string> secondSet = new HashSet<string>();
            HashSet<string> repeatedElements = new HashSet<string>();

            for (int i = 0; i < firstSetLength; i++)
            {
                string currElement = Console.ReadLine();

                firstSet.Add(currElement);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                string currElement = Console.ReadLine();

                secondSet.Add(currElement);
            }

            foreach (var element in firstSet)
            {
                if (secondSet.Contains(element))
                {
                    repeatedElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", repeatedElements));
        }
    }
}
