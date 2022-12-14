using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine(n);
            
            foreach (var name in names)
            {
                print(name);
            }

        }
    }
}
