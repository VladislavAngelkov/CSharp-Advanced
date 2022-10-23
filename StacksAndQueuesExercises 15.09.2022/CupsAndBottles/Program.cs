using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] bottlesInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsInfo);
            Stack<int> bottles = new Stack<int>(bottlesInfo);
            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Peek();

                if (currentBottle==currentCup)
                {
                    cups.Dequeue();
                }
                else if (currentCup>currentBottle)
                {
                    currentCup -= currentBottle;

                    while (currentCup>0 && bottles.Any())
                    {
                        currentBottle = bottles.Pop();
                        currentCup -= currentBottle;
                        if (currentCup<0)
                        {
                            wastedWater += Math.Abs(currentCup);
                            cups.Dequeue();
                        }
                        else if (currentCup == 0)
                        {
                            cups.Dequeue();
                        }
                    }
                }
                else if (currentBottle>currentCup)
                {
                    cups.Dequeue();
                    wastedWater += currentBottle - currentCup;
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
