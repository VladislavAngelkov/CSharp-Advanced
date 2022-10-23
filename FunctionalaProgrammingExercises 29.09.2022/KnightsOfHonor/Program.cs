using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string title = "Sir";
            Action<string, string> printWithTitle = (name, title) => Console.WriteLine($"{title} {name}");

            foreach (var name in names)
            {
                printWithTitle(name, title);
            }
        }
    }
}
