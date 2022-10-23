using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            string[,] matrix = new string[rows, cols];

            int numberOfSquares = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] values = Console.ReadLine().Split(" ");
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row+1, col] && matrix[row, col] == matrix[row, col+1] && matrix[row, col] == matrix[row + 1, col+1])
                    {
                        numberOfSquares++;
                    }
                }
            }

            Console.WriteLine(numberOfSquares);
        }
    }
}
