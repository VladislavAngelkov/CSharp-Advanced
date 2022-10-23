using System;

namespace PownWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];

            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = currentRow[col];
                    if (board[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (board[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            char winCol = default;
            int winRow = default;

            while (true)
            {
                if (IsInRange(whiteRow - 1, whiteCol - 1) && board[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    winCol = GetCol(whiteCol-1);
                    winRow = GetRow(whiteRow-1);
                    Console.WriteLine($"Game over! White capture on {winCol}{winRow}.");
                    return;
                }
                else if (IsInRange(whiteRow - 1, whiteCol + 1) && board[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    winCol = GetCol(whiteCol + 1);
                    winRow = GetRow(whiteRow - 1);
                    Console.WriteLine($"Game over! White capture on {winCol}{winRow}.");
                    return;
                }
                else
                {
                    board[whiteRow, whiteCol] = '-';
                    whiteRow--;
                    board[whiteRow, whiteCol] = 'w';
                    
                    if (whiteRow == 0)
                    {
                        winRow = GetRow(whiteRow);
                        winCol = GetCol(whiteCol);
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {winCol}{winRow}.");
                        return;
                    }
                }

                if (IsInRange(blackRow + 1, blackCol - 1) && board[blackRow + 1, blackCol - 1] == 'w')
                {
                    winCol = GetCol(blackCol - 1);
                    winRow = GetRow(blackRow + 1);
                    Console.WriteLine($"Game over! Black capture on {winCol}{winRow}.");
                    return;
                }
                else if (IsInRange(blackRow + 1, blackCol + 1) && board[blackRow + 1, blackCol + 1] == 'w')
                {
                    winCol = GetCol(blackCol + 1);
                    winRow = GetRow(blackRow + 1);
                    Console.WriteLine($"Game over! Black capture on {winCol}{winRow}.");
                    return;
                }
                else
                {
                    board[blackRow, blackCol] = '-';
                    blackRow++;
                    board[blackRow, blackCol] = 'b';

                    if (blackRow == 7)
                    {
                        winRow = GetRow(blackRow);
                        winCol = GetCol(blackCol);
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {winCol}{winRow}.");
                        return;
                    }
                }
            }
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }

        private static void PrintBoard(char[,] board)
        {
            Console.WriteLine("------------------------------");
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------");
        }

        private static int GetRow(int row)
        {
            return 8 - row;
        }

        private static char GetCol(int col)
        {
            if (col == 0)
            {
                return 'a';
            }
            else if (col == 1)
            {
                return 'b';
            }
            else if (col == 2)
            {
                return 'c';
            }
            else if (col == 3)
            {
                return 'd';
            }
            else if (col == 4)
            {
                return 'e';
            }
            else if (col == 5)
            {
                return 'f';
            }
            else if (col == 6)
            {
                return 'g';
            }
            else
            {
                return 'h';
            }
        }

    }
}
