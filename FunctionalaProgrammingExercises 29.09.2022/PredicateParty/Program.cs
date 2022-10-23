using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = arguments[0];
                string condition = arguments[1];
                string value = arguments[2];

                Predicate<string> predicate = GetPredicate(condition, value);

                Func<List<string>, List<string>> func = GetFunc(cmd, predicate);

                people = func(people);

                command = Console.ReadLine();
            }

            if (people.Count>0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
       
        public static Predicate<string> GetPredicate(string condition, string value)
        {
            if (condition == "StartsWith")
            {
                return name => name.Substring(0, value.Length) == value;
            }
            else if (condition == "EndsWith")
            {
                return name => name.Substring(name.Length - value.Length, value.Length) == value;
            }
            else if (condition == "Length")
            {
                return name => name.Length == int.Parse(value);
            }
            else
            {
                return null;
            }
        }

        public static Func<List<string>, List<string>> GetFunc(string cmd, Predicate<string> predicate)
        {
            if (cmd == "Double")
            {
                Func<List<string>, List<string>> func = (people) =>
                {
                    List<string> result = new List<string>();

                    for (int i = 0; i < people.Count; i++)
                    {
                        result.Add(people[i]);
                        if (predicate(people[i]))
                        {
                            result.Add(people[i]);
                        }
                    }
                    return result;
                };
                return func;
            }
            else
            {
                Func<List<string>, List<string>> func = (people) =>
                {
                    List<string> result = new List<string>();

                    for (int i = 0; i < people.Count; i++)
                    {
                        if (!predicate(people[i]))
                        {
                            result.Add(people[i]);
                        }
                    }

                    return result;
                };
                return func;
            }
        }
    }
}
