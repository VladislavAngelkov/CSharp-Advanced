using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int operationsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < operationsCount; i++)
            {
                int[] cmd = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                switch (cmd[0])
                {
                    case 1:
                        int currentNumber = cmd[1];
                        numbers.Push(currentNumber);
                        break;
                    case 2:
                        if (numbers.Count != 0)
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Count != 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Count != 0)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                }
            }

            while (numbers.Count > 1)
            {
                Console.Write($"{numbers.Pop()}, ");
            }

            if (numbers.Count != 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
