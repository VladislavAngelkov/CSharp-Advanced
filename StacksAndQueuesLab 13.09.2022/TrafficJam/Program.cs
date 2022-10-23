using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passingCarsPerGreenLight = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            Queue<string> waitingCars = new Queue<string>();

            int passedCars = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < passingCarsPerGreenLight; i++)
                    {
                        if (waitingCars.Count!=0)
                        {
                            string currentCar = waitingCars.Dequeue();
                            Console.WriteLine($"{currentCar} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    waitingCars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
