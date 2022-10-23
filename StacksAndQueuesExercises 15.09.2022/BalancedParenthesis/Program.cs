using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] expression = Console.ReadLine().ToCharArray();

            if (expression[0] == ')' || expression[0] == ']' || expression[0] == '}')
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> parenthesis = new Stack<char>();



            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == '[' || expression[i] == '{')
                {
                    parenthesis.Push(expression[i]);
                }
                else if (expression[i] == ')')
                {
                    if (parenthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (parenthesis.Pop() != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (expression[i] == ']')
                {
                    if (parenthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (parenthesis.Pop() != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (expression[i] == '}')
                {
                    if (parenthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (parenthesis.Pop() != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
