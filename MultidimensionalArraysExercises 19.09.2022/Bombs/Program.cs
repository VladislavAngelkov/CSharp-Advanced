using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            string[] bombsCoordinates = Console.ReadLine().Split(" ");

            for (int i = 0; i < bombsCoordinates.Length; i++)
            {
                int[] currBombCoordinates = bombsCoordinates[i].Split(",").Select(int.Parse).ToArray();
                int row = currBombCoordinates[0];
                int col = currBombCoordinates[1];

                int bombPower = matrix[row, col];

                if (bombPower <= 0)
                {
                    continue;
                }

                matrix[row, col] = 0;

                if (IsInRange(rows, cols, row - 1, col - 1))
                {
                    if (matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= bombPower;
                    }
                }

                if (IsInRange(rows, cols, row - 1, col))
                {
                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombPower;
                    }
                }

                if (IsInRange(rows, cols, row - 1, col + 1))
                {
                    if (matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= bombPower;
                    }
                }

                if (IsInRange(rows, cols, row, col - 1))
                {
                    if (matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombPower;
                    }
                }

                if (IsInRange(rows, cols, row, col + 1))
                {
                    if (matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombPower;
                    }
                }

                if (IsInRange(rows, cols, row + 1, col - 1))
                {
                    if (matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= bombPower;
                    }
                }

                if (IsInRange(rows, cols, row + 1, col))
                {
                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombPower;
                    }
                }

                if (IsInRange(rows, cols, row + 1, col + 1))
                {
                    if (matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= bombPower;
                    }
                }

            }

            int aliveCellCounter = 0;
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellCounter++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellCounter}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInRange(int rows, int cols, int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
