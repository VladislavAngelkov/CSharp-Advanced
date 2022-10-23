using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<long[]> pumps = new Queue<long[]>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split(" ").Select(long.Parse).ToArray());
            }

            int visitedPumps = 0;
            BigInteger fuelInTheTank = 0;
            long distanceTotrvel = 0;
            int pumpIteration = 0;
            int startingPumpIndex = 0;

            while (visitedPumps < numberOfPumps)
            {
                long[] currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                fuelInTheTank += currentPump[0];
                distanceTotrvel = currentPump[1];
                pumpIteration++;

                if (fuelInTheTank >= distanceTotrvel)
                {
                    visitedPumps++;
                    fuelInTheTank -= distanceTotrvel;
                }
                else
                {
                    visitedPumps = 0;
                    startingPumpIndex = pumpIteration % numberOfPumps;
                    fuelInTheTank = 0;
                }
            }

            Console.WriteLine(startingPumpIndex);
        }
    }
}
