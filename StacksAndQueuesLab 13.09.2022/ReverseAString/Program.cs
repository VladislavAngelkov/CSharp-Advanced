using System;
using System.Collections;
using System.Collections.Generic;

namespace ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                stack.Push(text[i]);
            }

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
