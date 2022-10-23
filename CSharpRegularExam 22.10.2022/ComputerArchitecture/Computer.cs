using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            this.model = model;
            this.capacity = capacity;
            multiprocessor = new List<CPU>();
        }

        public string Model
        {
            get { return model; }
        }
        public int Capacity
        {
            get { return capacity; }
        }
        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
        }
        public int Count
        {
            get { return multiprocessor.Count; }
        }

        public void Add(CPU cpu)
        {
            if (multiprocessor.Count<capacity)
            {
                multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            if (multiprocessor.Any(c=>c.Brand == brand))
            {
                multiprocessor.Remove(multiprocessor.First(c => c.Brand == brand));
                return true;
            }
            return false;
        }
        public CPU MostPowerful()
        {
            if (multiprocessor.Any())
            {
                return multiprocessor.OrderByDescending(c => c.Frequency).First();
            }
            return null;
        }
        public CPU GetCPU(string brand)
        {
            if (multiprocessor.Any(c=>c.Brand == brand))
            {
                return multiprocessor.First(c => c.Brand == brand);
            }
            return null;
        }
        public string Report()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"CPUs in the Computer {model}:");
            message.Append(string.Join(Environment.NewLine, this.multiprocessor));

            return message.ToString();
        }
    }
}
