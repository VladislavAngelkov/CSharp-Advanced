using System;
using System.Linq;

namespace WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());
            char[,] wall = new char[wallSize, wallSize];

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                char[] wallElemetnsAtCurrentRaw = Console.ReadLine().ToCharArray();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = wallElemetnsAtCurrentRaw[col];
                    if (wall[row, col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            bool isElecticuted = false;
            int rods = 0;
            wall[currentRow, currentCol] = '*';
            int holes = 1;

            string command = Console.ReadLine();

            while (command != "End")
            {
                int nextRow = CalculateRow(command, currentRow);
                int nextCol = CalculateCol(command, currentCol);

                if (IsInRange(wall, nextRow, nextCol))
                {
                    if (wall[nextRow, nextCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rods++;
                    }
                    else if (wall[nextRow, nextCol] == 'C')
                    {
                        wall[nextRow, nextCol] = 'E';
                        wall[currentRow, currentCol] = '*';
                        holes ++;
                        isElecticuted = true;
                        break;
                    }
                    else if (wall[nextRow, nextCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{nextRow}, {nextCol}]!");
                        currentRow = nextRow;
                        currentCol = nextCol;
                    }
                    else
                    {
                        wall[nextRow, nextCol] = '*';
                        holes++;
                        currentRow = nextRow;
                        currentCol = nextCol;
                    }
                }

                command = Console.ReadLine();
            }

            if (isElecticuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
                wall[currentRow, currentCol] = 'V';
            }

            PrintWall(wall);
        }

        private static void PrintWall(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write($"{wall[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInRange(char[,] wall, int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < wall.GetLength(0) && nextCol >= 0 && nextCol < wall.GetLength(1);
        }

        private static int CalculateCol(string command, int currentCol)
        {
            if (command == "left")
            {
                currentCol--;
            }
            else if (command == "right")
            {
                currentCol++;
            }

            return currentCol;
        }

        private static int CalculateRow(string command, int currentRow)
        {
            if (command == "up")
            {
                currentRow--;
            }
            else if (command == "down")
            {
                currentRow++;
            }

            return currentRow;
        }
    }
}
