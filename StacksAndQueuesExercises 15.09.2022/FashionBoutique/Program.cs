using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(clothesInfo);

            int rackCapacity = int.Parse(Console.ReadLine());

            int currentRackCapacityTaken = 0;

            int racksCount = 1;

            while (clothes.Count != 0)
            {
                int currentClothes = clothes.Pop();

                if (rackCapacity - currentRackCapacityTaken > currentClothes)
                {
                    currentRackCapacityTaken += currentClothes;
                }
                else if (rackCapacity - currentRackCapacityTaken == currentClothes)
                {
                    if (clothes.Count != 0)
                    {
                        racksCount++;
                        currentRackCapacityTaken = 0;
                    }
                }
                else
                {
                    racksCount++;
                    currentRackCapacityTaken = currentClothes;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
