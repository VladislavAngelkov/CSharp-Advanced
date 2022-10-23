using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                int cols = values.Length;
                jaggedArray[row] = values;
            }

            string[] commandArg = Console.ReadLine().Split(" ");

            while (commandArg[0] != "END")
            {
                string cmd = commandArg[0];

                switch (cmd)
                {
                    case "Add":
                        int rowToAdd = int.Parse(commandArg[1]);
                        int colToAdd = int.Parse(commandArg[2]);
                        int valueToAdd = int.Parse(commandArg[3]);
                        if (rowToAdd<0 || rowToAdd>=rows || colToAdd<0 || colToAdd>=jaggedArray[rowToAdd].Length)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                            jaggedArray[rowToAdd][colToAdd] += valueToAdd;
                        }
                        break;

                    case "Subtract":
                        int rowToSubtract = int.Parse(commandArg[1]);
                        int colToSubtract = int.Parse(commandArg[2]);
                        int valueToSubtract = int.Parse(commandArg[3]);
                        if (rowToSubtract < 0 || rowToSubtract >= rows || colToSubtract < 0 || colToSubtract >= jaggedArray[rowToSubtract].Length)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                            jaggedArray[rowToSubtract][colToSubtract] -= valueToSubtract;
                        }
                        break;
                }

                commandArg = Console.ReadLine().Split(" ");
            }

            for (int row = 0; row < rows; row++)
            {
                int cols = jaggedArray[row].Length;

                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
