using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
           List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            Dictionary<string, Predicate<string>> predicates = new Dictionary<string, Predicate<string>>();

            while (command != "Print")
            {
                string[] commArgs = command.Split(" ");
                string cmd = commArgs[0];
                string filterName = string.Join(" ", commArgs.Skip(1));

                string[] filterArgs = filterName.Split(";");
                string condition = filterArgs[1];
                string value = filterArgs[2];

                Predicate<string> predicate = GetPredicate(condition, value);

                if (cmd == "Add")
                {
                    if (!predicates.ContainsKey(filterName))
                    {
                        predicates.Add(filterName, predicate);
                    }
                }
                else
                {
                    if (predicates.ContainsKey(filterName))
                    {
                        predicates.Remove(filterName);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var predicate in predicates)
            {
                names = names.Where(n => predicate.Value(n)).ToList();
            }

            Console.WriteLine(string.Join(" ", names));
        }

        public static Predicate<string> GetPredicate(string condition, string value)
        {
            Predicate<string> predicate = name =>
            {
                string substr = "";
                if (condition == "Starts with")
                {
                    substr = name.Substring(0, value.Length);
                }
                else if (condition == "Ends with")
                {
                    substr = name.Substring(name.Length - value.Length, value.Length);
                }
                else if (condition == "Length")
                {
                    return name.Length != int.Parse(value);
                }
                else
                {
                    return !name.Contains(value);
                }

                return substr != value;
            };

            return predicate;
        }
    }
}
