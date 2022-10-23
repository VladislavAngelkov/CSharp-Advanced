using System;
using System.Linq;

namespace NewBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number for field size:"); 
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            char[,] lair = new char[rows, cols];

            int currRow = 0;
            int currCol = 0;
            bool isAlive = true;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Random rnd = new Random();
                    int x = rnd.Next();
                    if (row == rows/2 && col == cols/2)
                    {
                        lair[row, col] = 'P';
                        currRow = row;
                        currCol = col;
                    }
                    else if (x%(rows*3)==0)
                    {
                        lair[row, col] = 'B';
                    }
                    else
                    {
                        lair[row, col] = '.';
                    }
                }
            }

            PrintLair(lair);

            Console.WriteLine("Navigate with keyboard arrows!");

            while (true)
            {
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
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

                    case ConsoleKey.DownArrow:
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

                    case ConsoleKey.LeftArrow:
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

                    case ConsoleKey.RightArrow:
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

                PrintLair(lair);
            }
        }

        private static void PrintLair(char[,] lair)
        {
            int rows = lair.GetLength(0);
            int cols = lair.GetLength(1);

            Console.Clear();

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
