using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int treshold = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> isGreater = (name, threshold) =>
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }
                return sum >= threshold;
            };

            Func<List<string>, Func<string, int, bool>, string> firstName = (names, func) =>
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (func(names[i], treshold))
                    {
                        return names[i];
                    }
                }
                return null;
            };

            Console.WriteLine(firstName(names, isGreater));

        }
    }
}
