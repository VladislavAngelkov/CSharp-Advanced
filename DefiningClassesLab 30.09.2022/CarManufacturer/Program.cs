using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] tiresInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Tire[]> allTires = new List<Tire[]>();

            while (tiresInfo[0] != "No")
            {
                int firstTireYear = int.Parse(tiresInfo[0]);
                double firstTirePressure = double.Parse(tiresInfo[1]);
                int secondTireYear = int.Parse(tiresInfo[2]);
                double secondTirePressure = double.Parse(tiresInfo[3]);
                int thirdTireYear = int.Parse(tiresInfo[4]);
                double thirdTirePressure = double.Parse(tiresInfo[5]);
                int fourthTireYear = int.Parse(tiresInfo[6]);
                double fourthTirePressure = double.Parse(tiresInfo[7]);

                Tire firstTire = new Tire(firstTireYear, firstTirePressure);
                Tire secondTire = new Tire(secondTireYear, secondTirePressure);
                Tire thirdTire = new Tire(thirdTireYear, thirdTirePressure);
                Tire fourthTire = new Tire(fourthTireYear, fourthTirePressure);

                Tire[] tires = new Tire[] { firstTire, secondTire, thirdTire, fourthTire };
                allTires.Add(tires);

                tiresInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<Engine> engines = new List<Engine>();

            string[] engInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (engInfo[0] != "Engines")
            {
                int horsePower = int.Parse(engInfo[0]);
                double cubicCapacity = double.Parse(engInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);

                engInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<Car> cars = new List<Car>();

            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (carInfo[0] != "Show")
            {
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity= double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], allTires[tiresIndex]);

                cars.Add(car);

                carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars.Where(x=>x.Year>=2017 && x.Engine.HorsePower>330 && x.Tires.Sum(y=>y.Pressure)<10 && x.Tires.Sum(y => y.Pressure) > 9))
            {
                car.Drive(20);
                //Console.WriteLine(car.WhoAmI());
            }

            foreach (var car in cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) < 10 && x.Tires.Sum(y => y.Pressure) > 9))
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
