using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] caffeineInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> caffeine = new Stack<int>(caffeineInfo);

            int[] drinksInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> drinks = new Queue<int>(drinksInfo);

            int caffeineLeftToTake = 300;

            while (caffeine.Count>0 && drinks.Count>0)
            {
                int currentCaffeine = caffeine.Pop();
                int currentDrink = drinks.Dequeue();
                int currentIntake = currentCaffeine * currentDrink;

                if (currentIntake<=caffeineLeftToTake)
                {
                    caffeineLeftToTake -= currentIntake;
                }
                else
                {
                    drinks.Enqueue(currentDrink);
                    if (caffeineLeftToTake+30<=300)
                    {
                        caffeineLeftToTake += 30;
                    }
                    else
                    {
                        caffeineLeftToTake = 300;
                    }
                }
            }

            if (drinks.Count>0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {300-caffeineLeftToTake} mg caffeine.");
        }
    }
}
