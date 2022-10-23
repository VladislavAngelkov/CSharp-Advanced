using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rows][];

            pascalTriangle[0] = new long[1] { 1 };

            for (int row = 1; row < rows; row++)
            {
                pascalTriangle[row] = new long[row+1];
                for (int col = 0; col <= row; col++)
                {
                    long topNum = 0;
                    long topLeftNum = 0;
                    if (col==pascalTriangle[row-1].Length)
                    {
                        topLeftNum = pascalTriangle[row - 1][col - 1];
                    }
                    else if (col == 0)
                    {
                        topNum = pascalTriangle[row - 1][col];
                    }
                    else
                    {
                        topLeftNum = pascalTriangle[row - 1][col - 1];
                        topNum = pascalTriangle[row - 1][col];
                    }

                    pascalTriangle[row][col] = topNum + topLeftNum;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                int cols = pascalTriangle[row].Length;

                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{pascalTriangle[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
