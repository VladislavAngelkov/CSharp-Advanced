using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthLimit = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isShorterOrEven = CreatePredicate(lengthLimit);

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(name=>isShorterOrEven(name))));
        }

        private static Predicate<string> CreatePredicate(int lengthLimit)
        {
            return name => name.Length <= lengthLimit;
        }
    }
}
