using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }

                people[name] = age;
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, int, bool> pickOlder = (t, a) => a >= t;

            Func<int, int, bool> pickYounger = (t, a) => a < t;

            Func<string, Func<int, int, bool>> pickByCondition = c => c == "older" ? pickOlder : pickYounger;

            Func<string, string> formater = (f) =>
            {
                if (f.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length == 2)
                {
                    return "{0} - {1}";
                }
                else if (f == "age")
                {
                    return "{1}";
                }
                else
                {
                    return "{0}";
                }
            };

            foreach (var item in people.Where(x => pickByCondition(condition)(ageThreshold, x.Value)))
            {
                Console.WriteLine(string.Format(formater(format), item.Key, item.Value ));
            }
        }
    }
}
