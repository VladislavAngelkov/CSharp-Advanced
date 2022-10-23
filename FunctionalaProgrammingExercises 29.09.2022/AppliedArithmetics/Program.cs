using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            Func<int, int> add = num => { return num+1; };
            Func<int, int> subtract = num => { return num-1; };
            Func<int, int> multiply = num => { return num * 2; };


            Func<string, Func<int, int>> pickFunk = command =>
            {
                if (command == "add")
                {
                    return add;
                }
                else if (command == "subtract")
                {
                    return subtract;
                }
                else 
                {
                    return multiply;
                }
            };

            

            while (command != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    numbers = numbers.Select(pickFunk(command)).ToList();
                }

                command = Console.ReadLine();
            }
        }
    }
}
