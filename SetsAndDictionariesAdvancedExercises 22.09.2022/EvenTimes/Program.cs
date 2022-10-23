using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesOfInput = int.Parse(Console.ReadLine());

            Dictionary<string, int> repeatingTimes = new Dictionary<string, int>();

            for (int i = 0; i < linesOfInput; i++)
            {
                string currentInput = Console.ReadLine();

                if (!repeatingTimes.ContainsKey(currentInput))
                {
                    repeatingTimes.Add(currentInput, 0);
                }

                repeatingTimes[currentInput]++;
            }

            Console.WriteLine(repeatingTimes.First(x=>x.Value%2==0).Key);
        }
    }
}
