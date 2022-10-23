using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;

        public CPU(string brand, int cores, double frequency)
        {
            this.brand = brand;
            this.cores = cores;
            this.frequency = frequency;
        }

        public string Brand
        {
            get { return brand; }
        }
        public int Cores
        {
            get { return cores; }
        }
        public double Frequency
        {
            get { return frequency; }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{brand} CPU:");
            message.AppendLine($"Cores: {cores}");
            message.Append($"Frequency: {frequency:f1} GHz");

            return message.ToString();
        }
    }
}
