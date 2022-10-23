using System;
using System.Linq;

namespace SquareWithMatrixSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int submatrixRows = 2;
            int submatrixCols = 2;
            int submatrixSum = 0;
            int maxSum = 0;
            int startingRow = 0;
            int startingCol = 0;

            for (int row = 0; row < rows-submatrixRows+1; row++)
            {
                for (int col = 0; col < cols - submatrixCols+1; col++)
                {
                    submatrixSum = CalculateSum(matrix, row, col, submatrixRows, submatrixCols);
                    if (submatrixSum>maxSum)
                    {
                        maxSum = submatrixSum;
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            PrintMatrix(matrix, startingRow, startingCol, submatrixRows, submatrixCols);
            Console.WriteLine(maxSum);
        }

        private static void PrintMatrix(int[,] matrix, int startRow, int StartCol, int rows, int cols)
        {
            for (int row = startRow; row < startRow+rows; row++)
            {
                for (int col = StartCol; col < StartCol+cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static int CalculateSum(int[,] matrix, int row, int col, int rows, int cols)
        {
            int sum = 0;
            for (int r = row; r < row+rows; r++)
            {
                for (int c = col; c < col+cols; c++)
                {
                    sum += matrix[r, c];
                }
            }

            return sum;
        }
    }
}
