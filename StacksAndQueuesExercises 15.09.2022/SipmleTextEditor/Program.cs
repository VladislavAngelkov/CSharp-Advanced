using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SipmleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            Stack<string[]> commands = new Stack<string[]>();
            Stack<string> deletedTexts = new Stack<string>();

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArg = Console.ReadLine().Split(" ");

                string cmd = commandArg[0];

                switch (cmd)
                {
                    case "1":
                        string textToAdd = string.Join("", commandArg.Skip(1));
                        text.Append(textToAdd);
                        commands.Push(commandArg);
                        break;

                    case "2":
                        int countOfElementsToRemove = int.Parse(commandArg[1]);
                        deletedTexts.Push(text.ToString().Substring(text.Length - countOfElementsToRemove, countOfElementsToRemove));
                        text.Remove(text.Length - countOfElementsToRemove, countOfElementsToRemove);
                        commands.Push(commandArg);
                        break;

                    case "3":
                        int index = int.Parse(commandArg[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;

                    case "4":
                        string[] lastCommand = commands.Pop();

                        if (lastCommand[0] == "1")
                        {
                            string textToRemove = lastCommand[1];
                            text.Remove(text.Length - textToRemove.Length, textToRemove.Length);
                        }
                        else if (lastCommand[0] == "2")
                        {
                            text.Append(deletedTexts.Pop());
                        }
                        break;
                        
                }
            }
        }
    }
}
