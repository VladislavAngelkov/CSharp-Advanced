using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int maxSum = 0;
            int currentSum = 0;
            int startingRow = 0;
            int startingCol = 0;

            for (int row = 0; row < rows-2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    currentSum += matrix[row, col];
                    currentSum += matrix[row + 1, col];
                    currentSum += matrix[row + 2, col];
                    currentSum += matrix[row, col + 1];
                    currentSum += matrix[row + 1, col + 1];
                    currentSum += matrix[row + 2, col + 1];
                    currentSum += matrix[row, col + 2];
                    currentSum += matrix[row + 1, col + 2];
                    currentSum += matrix[row + 2, col + 2];

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        startingRow = row;
                        startingCol = col;
                    }

                    currentSum = 0;
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startingRow; row < startingRow+3; row++)
            {
                for (int col = startingCol; col < startingCol+3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
