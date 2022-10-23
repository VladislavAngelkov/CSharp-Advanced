using System;
using System.Collections.Generic;

namespace RallyRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int trackSize = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            string[,] track = new string[trackSize, trackSize];

            List<int> tunnelRows = new List<int>();
            List<int> tunnelCols = new List<int>();

            for (int row = 0; row < track.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < track.GetLength(1); col++)
                {
                    track[row, col] = currentRow[col];

                    if (track[row, col]=="T")
                    {
                        tunnelRows.Add(row);
                        tunnelCols.Add(col);
                    }
                }
            }

            int firstTunnelEntranceRow = tunnelRows[0];
            int firstTunnelEntranceCol = tunnelCols[0];
            int secondTunnelEntranceRow = tunnelRows[1];
            int secondTunnelEntranceCol = tunnelCols[1];

            int carRow = 0;
            int carCol = 0;
            int traveledDistance = 0;

            string direction = Console.ReadLine();

            while (direction != "End")
            {
                carRow = CalculateRow(carRow, direction);
                carCol = CalculateCol(carCol, direction);

                if (track[carRow, carCol] == "T")
                {
                    track[firstTunnelEntranceRow, firstTunnelEntranceCol] = ".";
                    track[secondTunnelEntranceRow, secondTunnelEntranceCol] = ".";
                    traveledDistance += 30;

                    if (carRow == firstTunnelEntranceRow && carCol == firstTunnelEntranceCol)
                    {
                        carRow = secondTunnelEntranceRow;
                        carCol = secondTunnelEntranceCol;
                    }
                    else
                    {
                        carRow = firstTunnelEntranceRow;
                        carCol = firstTunnelEntranceCol;
                    }
                }
                else if (track[carRow, carCol] == "F")
                {
                    traveledDistance += 10;
                    break;
                }
                else
                {
                    traveledDistance += 10;
                }

                direction = Console.ReadLine();
            }

            track[carRow, carCol] = "C";

            if (direction != "End")
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {traveledDistance} km.");

            PrintTrack(track);
        }

        private static void PrintTrack(string[,] track)
        {
            for (int row = 0; row < track.GetLength(0); row++)
            {
                for (int col = 0; col < track.GetLength(1); col++)
                {
                    Console.Write(track[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int CalculateCol(int carCol, string direction)
        {
            if (direction == "left")
            {
                --carCol;
            }
            else if (direction == "right")
            {
                ++carCol;
            }

            return carCol;
        }

        private static int CalculateRow(int carRow, string direction)
        {
            if (direction == "up")
            {
                --carRow;
            }
            else if (direction == "down")
            {
                ++carRow;
            }

            return carRow;
        }
    }
}
