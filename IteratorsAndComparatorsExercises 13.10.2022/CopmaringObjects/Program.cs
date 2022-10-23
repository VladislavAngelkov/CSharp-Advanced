using System;
using System.Collections.Generic;

namespace CopmaringObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();

            while (input[0] != "END")
            {
                persons.Add(new Person(input));

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int matches = 0;
            int notMatches = 0;

            int personIndex = int.Parse(Console.ReadLine());

            Person personToCompare = persons[personIndex-1];

            foreach (var person in persons)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    matches++;
                }
                else
                {
                    notMatches++;
                }
            }

            if (matches<=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {notMatches} {persons.Count}");
            }

        }
    }
}
