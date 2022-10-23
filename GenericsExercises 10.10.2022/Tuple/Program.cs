using System;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] adressInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = string.Join(" ", adressInfo.Take(2));
            string adress = adressInfo[2];
            Tuple<string, string> nameAndAdress = new Tuple<string, string>(name, adress);

            string[] beerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string drinker = beerInfo[0];
            int litters = int.Parse(beerInfo[1]);
            Tuple<string, int> beer = new Tuple<string, int>(drinker, litters);

            string[] numInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int intNum = int.Parse(numInfo[0]);
            double doubleNum = double.Parse(numInfo[1]);
            Tuple<int, double> numbers = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine($"{nameAndAdress.FirstItem} -> {nameAndAdress.SecondItem}");
            Console.WriteLine($"{beer.FirstItem} -> {beer.SecondItem}");
            Console.WriteLine($"{numbers.FirstItem} -> {numbers.SecondItem}");
        }
    }
}
