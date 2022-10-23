using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] createArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> list = new ListyIterator<string>(createArgs.Skip(1).ToArray());

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "Print":
                        list.Print();
                        break;

                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "PrintAll":
                        list.PrintAll();
                        break;

                }

                command = Console.ReadLine();
            }
        }
    }
}
