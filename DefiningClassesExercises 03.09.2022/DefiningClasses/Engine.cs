using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine()
        {

        }
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }
        public Engine(string model, int power, int displacement):this(model, power)
        {
            Displacement = displacement;
        }
        public Engine(string model, int power, int displacement, string efficiency):this(model, power, displacement)
        {
            Efficiency = efficiency;
        }
        public Engine(string model, int power, string efficiency):this(model, power)
        {
            Efficiency = efficiency;
        }
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        private int speed;
        private int power;
        private string model;
        private int displacement;
        private string efficiency;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
