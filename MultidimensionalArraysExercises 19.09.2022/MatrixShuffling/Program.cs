using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] values = Console.ReadLine().Split(" ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            string[] commandsArg = Console.ReadLine().Split(" ");

            while (commandsArg[0] != "END")
            {
                if (commandsArg[0] != "swap" || commandsArg.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    commandsArg = Console.ReadLine().Split(" ");
                    continue;
                }

                int firstCellRow = int.Parse(commandsArg[1]);
                int firstCellCol = int.Parse(commandsArg[2]);
                int secondCellRow = int.Parse(commandsArg[3]);
                int secondCellCol = int.Parse(commandsArg[4]);

                if (ValidCoordinatesCheck(matrix, firstCellRow, firstCellCol, secondCellRow, secondCellCol))
                {
                    string temp = matrix[firstCellRow, firstCellCol];
                    matrix[firstCellRow, firstCellCol] = matrix[secondCellRow, secondCellCol];
                    matrix[secondCellRow, secondCellCol] = temp;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    commandsArg = Console.ReadLine().Split(" ");
                    continue;
                }

                commandsArg = Console.ReadLine().Split(" ");
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }

        private static bool ValidCoordinatesCheck(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            return row1 >= 0 && row1 < rows && row2 >= 0 && row2 < rows && col1 >= 0 && col1 < cols && col2 >= 0 && col2 < cols;
        }
    }
}
