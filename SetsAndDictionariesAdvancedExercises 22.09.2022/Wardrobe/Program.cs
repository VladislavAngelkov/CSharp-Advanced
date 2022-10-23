using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesOfInput = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < linesOfInput; i++)
            {
                string[] info = Console.ReadLine().Split(" -> ");
                string color = info[0];

                string[] clothes = info[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var clothePiece in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothePiece))
                    {
                        wardrobe[color].Add(clothePiece, 0);
                    }

                    wardrobe[color][clothePiece]++;
                }
            }

            string[] desiredClothePieceInfo = Console.ReadLine().Split(" ");
            string desiredColor = desiredClothePieceInfo[0];
            string desiredClothePiece = desiredClothePieceInfo[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothes in color.Value)
                {
                    if (color.Key == desiredColor && clothes.Key == desiredClothePiece)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
