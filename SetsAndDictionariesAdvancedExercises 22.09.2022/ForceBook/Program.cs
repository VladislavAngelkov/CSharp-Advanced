using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> sides = new Dictionary<string, HashSet<string>>();

            Dictionary<string, string> users = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string user = "";
                string side = "";
                

                if (input.Contains(" | "))
                {
                    string[] info = input.Split(" | ");
                    side = info[0];
                    user = info[1];

                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, side);

                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new HashSet<string>());
                        }

                        sides[side].Add(user);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] info = input.Split(" -> ");
                    user = info[0];
                    side = info[1];

                    if (users.ContainsKey(user))
                    {
                        sides[users[user]].Remove(user);

                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new HashSet<string>());
                        }

                        sides[side].Add(user);
                        users[user] = side;

                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new HashSet<string>());
                        }
                        sides[side].Add(user);
                        users.Add(user, side);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var side in sides.Where(x=>x.Value.Count != 0).OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var user in side.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
