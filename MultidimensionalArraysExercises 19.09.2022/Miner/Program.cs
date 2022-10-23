using System;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            int currRow = 0;
            int currCol = 0;
            int totalCoals = 0;

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[,] field = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] values = Console.ReadLine().Split(" ");

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = values[col];

                    if (values[col] == "s")
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (values[col] == "c")
                    {
                        totalCoals++;
                    }
                }
            }

            int gatheredCoal = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];


                switch (currentCommand)
                {
                    case "up":
                        if (IsInRange(rows, currRow - 1, currCol))
                        {
                            if (field[currRow - 1, currCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow - 1}, {currCol})");
                                return;
                            }
                            else if (field[currRow - 1, currCol] == "c")
                            {
                                gatheredCoal++;
                                field[currRow - 1, currCol] = "*";
                                currRow = currRow - 1;
                            }
                            else
                            {
                                currRow = currRow - 1;
                            }
                        }
                        break;

                    case "down":
                        if (IsInRange(rows, currRow + 1, currCol))
                        {
                            if (field[currRow + 1, currCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow + 1}, {currCol})");
                                return;
                            }
                            else if (field[currRow + 1, currCol] == "c")
                            {
                                gatheredCoal++;
                                field[currRow + 1, currCol] = "*";
                                currRow = currRow + 1;
                            }
                            else
                            {
                                currRow = currRow + 1;
                            }
                        }
                        break;

                    case "left":
                        if (IsInRange(rows, currRow, currCol - 1))
                        {
                            if (field[currRow, currCol - 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol - 1})");
                                return;
                            }
                            else if (field[currRow, currCol - 1] == "c")
                            {
                                gatheredCoal++;
                                field[currRow, currCol - 1] = "*";
                                currCol = currCol - 1;
                            }
                            else
                            {
                                currCol = currCol - 1;
                            }
                        }
                        break;

                    case "right":
                        if (IsInRange(rows, currRow, currCol + 1))
                        {
                            if (field[currRow, currCol + 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol + 1})");
                                return;
                            }
                            else if (field[currRow, currCol + 1] == "c")
                            {
                                gatheredCoal++;
                                field[currRow, currCol + 1] = "*";
                                currCol = currCol + 1;
                            }
                            else
                            {
                                currCol = currCol + 1;
                            }
                        }
                        break;
                }

                if (gatheredCoal == totalCoals)
                {
                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                    return;
                }
            }

            Console.WriteLine($"{totalCoals - gatheredCoal} coals left. ({currRow}, {currCol})");
        }

        private static bool IsInRange(int fieldSize, int row, int col)
        {
            return row >= 0 && row < fieldSize && col >= 0 && col < fieldSize;
        }
    }
}
