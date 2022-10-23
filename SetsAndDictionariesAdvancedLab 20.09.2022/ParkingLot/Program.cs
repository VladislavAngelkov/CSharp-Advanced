using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ");

            while (input[0] != "END")
            {
                string cmd = input[0];
                string car = input[1];

                if (cmd == "IN")
                {
                    cars.Add(car);
                }
                else if (cars.Contains(car))
                {
                    cars.Remove(car);
                }
                
                input = Console.ReadLine().Split(", ");
            }

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
