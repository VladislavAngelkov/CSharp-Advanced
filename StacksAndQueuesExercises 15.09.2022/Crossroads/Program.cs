using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int totalPassedCars = 0;

            while (command != "END")
            {
                if (command == "green")
                {
                    int timeLeft = greenLightDuration;

                    while (timeLeft>0 && cars.Count>0)
                    {
                        string currentCar = cars.Dequeue();
                        timeLeft -= currentCar.Length;
                        if (timeLeft+freeWindowDuration>=0)
                        {
                            totalPassedCars++;
                        }
                        else
                        {
                            char hittedPart = currentCar[currentCar.Length + timeLeft + freeWindowDuration];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {hittedPart}.");
                            return;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalPassedCars} total cars passed the crossroads.");
        }
    }
}
