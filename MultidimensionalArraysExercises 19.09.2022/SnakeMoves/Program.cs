using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            char[,] isle = new char[rows, cols];

            char[] snake = Console.ReadLine().ToCharArray();
            int totalLength = 0;

            for (int row = 0; row < rows; row ++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        isle[row, col] = snake[totalLength % snake.Length];
                        totalLength++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        isle[row, col] = snake[totalLength % snake.Length];
                        totalLength++;
                    }
                }

            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(isle[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
