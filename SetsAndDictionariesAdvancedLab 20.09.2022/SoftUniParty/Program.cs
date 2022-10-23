using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string guest = Console.ReadLine();

            HashSet<string> VIPGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            while (guest != "PARTY")
            {
                if (char.IsDigit(guest[0]))
                {
                    VIPGuests.Add(guest);
                }
                else
                {
                    regularGuests.Add(guest);
                }

                guest = Console.ReadLine();
            }

            guest = Console.ReadLine();

            while (guest != "END")
            {
                if (char.IsDigit(guest[0]))
                {
                    if (VIPGuests.Contains(guest))
                    {
                        VIPGuests.Remove(guest);
                    }
                }
                else
                {
                    if (regularGuests.Contains(guest))
                    {
                        regularGuests.Remove(guest);
                    }
                }

                guest = Console.ReadLine();
            }

            Console.WriteLine($"{VIPGuests.Count + regularGuests.Count}");

            foreach (var g in VIPGuests)
            {
                Console.WriteLine(g);
            }

            foreach (var g in regularGuests)
            {
                Console.WriteLine(g);
            }
        }
    }
}
