using System;
using System.Collections.Generic;

namespace SopmleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split(" ");

            Stack<string> operations = new Stack<string>();
            Stack<int> numbers = new Stack<int>();
            int num = 0;

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(expression[i], out num))
                {
                    numbers.Push(num);
                }
                else
                {
                    operations.Push(expression[i]);
                }
            }

            int result = numbers.Pop();

            while (numbers.Count != 0)
            {
                string operation = operations.Pop();
                int currentNumber = numbers.Pop();

                if (operation == "+")
                {
                    result += currentNumber;
                }
                else
                {
                    result -= currentNumber;
                }
            }

            Console.WriteLine(result);
        }
    }
}
