using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lairInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = lairInfo[0];
            int cols = lairInfo[1];

            char[,] lair = new char[rows, cols];

            int currRow = 0;
            int currCol = 0;
            bool isAlive = true;

            for (int row = 0; row < rows; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    lair[row, col] = values[col];

                    if (values[col] == 'P')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToUpper().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];

                switch (currentCommand)
                {
                    case 'U':
                        lair[currRow, currCol] = '.';
                        currRow -= 1;

                        if (IsINRange(rows, cols, currRow, currCol))
                        {
                            if (lair[currRow, currCol] == 'B')
                            {
                                SpreadBunnies(lair, ref isAlive);
                                PrintLair(lair);
                                Console.WriteLine($"dead: {currRow} {currCol}");
                                return;
                            }
                            else
                            {
                                lair[currRow, currCol] = 'P';
                                lair = SpreadBunnies(lair, ref isAlive);

                                if (!isAlive)
                                {
                                    PrintLair(lair);
                                    Console.WriteLine($"dead: {currRow} {currCol}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            SpreadBunnies(lair, ref isAlive);
                            PrintLair(lair);
                            Console.WriteLine($"won: {currRow + 1} {currCol}");
                            return;
                        }
                        break;

                    case 'D':
                        lair[currRow, currCol] = '.';
                        currRow += 1;

                        if (IsINRange(rows, cols, currRow, currCol))
                        {
                            if (lair[currRow, currCol] == 'B')
                            {
                                SpreadBunnies(lair, ref isAlive);
                                PrintLair(lair);
                                Console.WriteLine($"dead: {currRow} {currCol}");
                                return;
                            }
                            else
                            {
                                lair[currRow, currCol] = 'P';
                                lair = SpreadBunnies(lair, ref isAlive);

                                if (!isAlive)
                                {
                                    PrintLair(lair);
                                    Console.WriteLine($"dead: {currRow} {currCol}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            SpreadBunnies(lair, ref isAlive);
                            PrintLair(lair);
                            Console.WriteLine($"won: {currRow - 1} {currCol}");
                            return;
                        }
                        break;

                    case 'L':
                        lair[currRow, currCol] = '.';
                        currCol -= 1;

                        if (IsINRange(rows, cols, currRow, currCol))
                        {
                            if (lair[currRow, currCol] == 'B')
                            {
                                SpreadBunnies(lair, ref isAlive);
                                PrintLair(lair);
                                Console.WriteLine($"dead: {currRow} {currCol}");
                                return;
                            }
                            else
                            {
                                lair[currRow, currCol] = 'P';
                                lair = SpreadBunnies(lair, ref isAlive);

                                if (!isAlive)
                                {
                                    PrintLair(lair);
                                    Console.WriteLine($"dead: {currRow} {currCol}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            SpreadBunnies(lair, ref isAlive);
                            PrintLair(lair);
                            Console.WriteLine($"won: {currRow} {currCol + 1}");
                            return;
                        }
                        break;

                    case 'R':
                        lair[currRow, currCol] = '.';
                        currCol += 1;

                        if (IsINRange(rows, cols, currRow, currCol))
                        {
                            if (lair[currRow, currCol] == 'B')
                            {
                                SpreadBunnies(lair, ref isAlive);
                                PrintLair(lair);
                                Console.WriteLine($"dead: {currRow} {currCol}");
                                return;
                            }
                            else
                            {
                                lair[currRow, currCol] = 'P';
                                lair = SpreadBunnies(lair, ref isAlive);

                                if (!isAlive)
                                {
                                    PrintLair(lair);
                                    Console.WriteLine($"dead: {currRow} {currCol}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            SpreadBunnies(lair, ref isAlive);
                            PrintLair(lair);
                            Console.WriteLine($"won: {currRow} {currCol - 1}");
                            return;
                        }
                        break;
                }
            }
        }

        private static void PrintLair(char[,] lair)
        {
            int rows = lair.GetLength(0);
            int cols = lair.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{lair[row, col]}");
                }

                Console.WriteLine();
            }
        }

        private static char[,] SpreadBunnies(char[,] lair, ref bool isAlive)
        {
            int rows = lair.GetLength(0);
            int cols = lair.GetLength(1);
            isAlive = true;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if (IsINRange(rows, cols, row - 1, col))
                        {
                            if (lair[row - 1, col] == 'P')
                            {
                                isAlive = false;
                                lair[row - 1, col] = 'b';
                            }
                            else if (lair[row - 1, col] != 'B')
                            {
                                lair[row - 1, col] = 'b';
                            }
                        }

                        if (IsINRange(rows, cols, row, col - 1))
                        {
                            if (lair[row, col - 1] == 'P')
                            {
                                isAlive = false;
                                lair[row, col - 1] = 'b';
                            }
                            else if (lair[row, col - 1] != 'B')
                            {
                                lair[row, col - 1] = 'b';
                            }

                        }

                        if (IsINRange(rows, cols, row, col + 1))
                        {
                            if (lair[row, col + 1] == 'P')
                            {
                                isAlive = false;
                                lair[row, col + 1] = 'b';
                            }
                            else if (lair[row, col + 1] != 'B')
                            {
                                lair[row, col + 1] = 'b';
                            }
                        }

                        if (IsINRange(rows, cols, row + 1, col))
                        {
                            if (lair[row + 1, col] == 'P')
                            {
                                isAlive = false;
                                lair[row + 1, col] = 'b';
                            }
                            else if (lair[row + 1, col] != 'B')
                            {
                                lair[row + 1, col] = 'b';
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lair[row, col] == 'b')
                    {
                        lair[row, col] = 'B';
                    }
                }
            }

            return lair;
        }

        private static bool IsINRange(int rows, int cols, int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
