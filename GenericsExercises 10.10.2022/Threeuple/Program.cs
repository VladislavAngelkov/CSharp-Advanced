using System;
using System.Linq;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] adressInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = string.Join(" ", adressInfo.Take(2));
            string street = adressInfo[2];
            string town = string.Join(" ", adressInfo.Skip(3));
            Threeuple<string, string, string> adress = new Threeuple<string, string, string>(name, street, town);

            string[] beerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string drinker = beerInfo[0];
            int litters = int.Parse(beerInfo[1]);
            bool isDrunk = beerInfo[2] == "drunk";
            Threeuple<string, int, bool> beer = new Threeuple<string, int, bool>(drinker, litters, isDrunk);

            string[] bankInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string customer = bankInfo[0];
            double balance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];
            Threeuple<string, double, string> bank = new Threeuple<string, double, string>(customer, balance, bankName);

            Console.WriteLine($"{adress.FirsItem} -> {adress.SecondItem} -> {adress.ThirdItem}");
            Console.WriteLine($"{beer.FirsItem} -> {beer.SecondItem} -> {beer.ThirdItem}");
            Console.WriteLine($"{bank.FirsItem} -> {bank.SecondItem} -> {bank.ThirdItem}");
;        }
    }
}
