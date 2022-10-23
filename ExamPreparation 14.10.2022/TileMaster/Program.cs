using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TileMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTilesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> whiteTiles = new Stack<int>(whiteTilesInfo);

            int[] grayTilesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> grayTiles = new Queue<int>(grayTilesInfo);

            Dictionary<string, int> locations = new Dictionary<string, int>();

            while (whiteTiles.Count != 0 && grayTiles.Count != 0)
            {
                int whiteTile = whiteTiles.Pop();
                int grayTile = grayTiles.Dequeue();

                if (whiteTile == grayTile)
                {
                    string location = GetLocation(whiteTile, grayTile);
                    if (!locations.ContainsKey(location))
                    {
                        locations.Add(location, 0);
                    }
                    locations[location]++;
                }
                else
                {
                    whiteTile /= 2;
                    whiteTiles.Push(whiteTile);
                    grayTiles.Enqueue(grayTile);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (grayTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grayTiles)}");
            }

            foreach (var location in locations.OrderByDescending(l=>l.Value).ThenBy(l=>l.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }

        private static string GetLocation(int whiteTile, int grayTile)
        {
            if (whiteTile+grayTile == 40)
            {
                return "Sink";
            }
            else if (whiteTile + grayTile == 50)
            {
                return "Oven";
            }
            else if (whiteTile + grayTile == 60)
            {
                return "Countertop";
            }
            else if (whiteTile + grayTile == 70)
            {
                return "Wall";
            }
            else
            {
                return "Floor";
            }
        }
    }
}
