using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            char[,] board = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    board[row, col] = values[col];
                }
            }

            int maxKnightsAttacked = 0;
            int maxRow = 0;
            int maxCol = 0;
            int removedKnights = 0;

            int currentKnightsAttacked = 0;
            bool thereIsAHit = true;

            while (thereIsAHit)
            {
                thereIsAHit = false;
                maxKnightsAttacked = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (board[row, col] != 'K')
                        {
                            continue;
                        }

                        if (IsINRange(rows, cols, row - 2, col - 1))
                        {
                            if (board[row - 2, col - 1] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }
                        if (IsINRange(rows, cols, row - 2, col + 1))
                        {
                            if (board[row - 2, col + 1] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }
                        if (IsINRange(rows, cols, row - 1, col - 2))
                        {
                            if (board[row - 1, col - 2] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }
                        if (IsINRange(rows, cols, row - 1, col + 2))
                        {
                            if (board[row - 1, col + 2] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }
                        if (IsINRange(rows, cols, row + 1, col - 2))
                        {
                            if (board[row + 1, col - 2] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }
                        if (IsINRange(rows, cols, row + 1, col + 2))
                        {
                            if (board[row + 1, col + 2] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }
                        if (IsINRange(rows, cols, row + 2, col - 1))
                        {
                            if (board[row + 2, col - 1] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }
                        if (IsINRange(rows, cols, row + 2, col + 1))
                        {
                            if (board[row + 2, col + 1] == 'K')
                            {
                                currentKnightsAttacked++;
                                thereIsAHit = true;
                            }
                        }

                        if (currentKnightsAttacked > maxKnightsAttacked)
                        {
                            maxKnightsAttacked = currentKnightsAttacked;
                            maxRow = row;
                            maxCol = col;
                        }

                        currentKnightsAttacked = 0;
                        
                    }
                }

                if (thereIsAHit)
                {
                    board[maxRow, maxCol] = 'O';
                    removedKnights++;
                }
            }

            Console.WriteLine(removedKnights);
        }

        private static bool IsINRange(int rows, int cols, int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
