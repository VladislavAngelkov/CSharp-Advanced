using System;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            //numbers = numbers.OrderByDescending(x => x).ToArray();

            //Console.WriteLine(string.Join(" ", numbers.Take(3)));

            Console.WriteLine(string.Join(" ", Console.ReadLine().Split(" ").Select(int.Parse).OrderByDescending(x=>x).Take(3).ToArray()));
        }
    }
}
