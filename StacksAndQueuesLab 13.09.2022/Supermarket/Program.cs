using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Queue<string> customers = new Queue<string>();

            while (command != "End")
            {
                if (command != "Paid")
                {
                    customers.Enqueue(command);
                }
                else
                {
                    while (customers.Count != 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
