using System;
using System.Linq;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < numberOfLines; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            double value = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Compare(value));
        }
    }
}
