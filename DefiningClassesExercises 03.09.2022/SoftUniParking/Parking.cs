using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new Dictionary<string, Car>();
        }

        private Dictionary<string, Car> cars;
        private int capacity;

        public Dictionary<string, Car> Cars
        {
            get { return cars; }
        }
        public int Count
        {
            get { return cars.Count; }
        }
        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";

            }
            else if (capacity == cars.Count)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";

            }
            else
            {
                cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }

        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars[registrationNumber];
            return car;
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNum in registrationNumbers)
            {
                this.RemoveCar(regNum);
            }
        }
    }
}
