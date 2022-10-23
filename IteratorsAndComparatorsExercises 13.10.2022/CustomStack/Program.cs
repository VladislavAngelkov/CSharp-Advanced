using System;
using System.Linq;

namespace CustomStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string[] commandInfo = Console.ReadLine().Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

            while (commandInfo[0] != "END")
            {
                string cmd = commandInfo[0];

                switch (cmd)
                {
                    case "Push":
                        string[] arguments = commandInfo.Skip(1).ToArray();
                        stack.Push(arguments);
                        break;

                    case "Pop":
                        stack.Pop();
                        break;
                }

                commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
