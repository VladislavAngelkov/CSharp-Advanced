using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            int firstDiagSum = 0;
            int secondDiagSum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                int[] values = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = values[col];

                    if (row == col)
                    {
                        firstDiagSum += matrix[row, col];
                    }

                    if (row == matrixSize - col - 1)
                    {
                        secondDiagSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(firstDiagSum-secondDiagSum));
        }
    }
}
