using System;
using System.Linq;

namespace JaggedArrayMaipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            }

            for (int row = 0; row < rows-1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row+1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row+1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row+1].Length; col++)
                    {
                        jaggedArray[row+1][col] /= 2;
                    }
                }
            }

            string[] commandsArg = Console.ReadLine().Split(" ");

            while (commandsArg[0] != "End")
            {
                string cmd = commandsArg[0];

                switch (cmd)
                {
                    case "Add":
                        int row = int.Parse(commandsArg[1]);
                        int col = int.Parse(commandsArg[2]);
                        int value = int.Parse(commandsArg[3]);

                        if (row>=0 && row<rows && col >=0 && col< jaggedArray[row].Length)
                        {
                            jaggedArray[row][col] += value;
                        }
                        break;

                    case "Subtract":
                        int rowSub = int.Parse(commandsArg[1]);
                        int colSub = int.Parse(commandsArg[2]);
                        int valueSub = int.Parse(commandsArg[3]);

                        if (rowSub >= 0 && rowSub < rows && colSub >= 0 && colSub < jaggedArray[rowSub].Length)
                        {
                            jaggedArray[rowSub][colSub] -= valueSub;
                        }
                        break;
                }

                commandsArg = Console.ReadLine().Split(" ");
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
