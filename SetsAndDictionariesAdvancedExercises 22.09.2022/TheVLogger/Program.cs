using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    public class Vlogger
    {
        public Vlogger(string username)
        {
            Username = username;
            Followers = new HashSet<Vlogger>();
            Following = new HashSet<Vlogger>();
        }
        public string Username { get; set; }
        public HashSet<Vlogger> Followers { get; set; }
        public HashSet<Vlogger> Following { get; set; }

        public override bool Equals(object obj)
        {
            Vlogger otherVlogger = obj as Vlogger;
            return this.Username == otherVlogger.Username;
        }

        public override int GetHashCode()
        {
            return this.Username.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Vlogger> vloggers = new HashSet<Vlogger>();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Statistics")
            {
                if (command[1] == "joined")
                {
                    string vloggerName = command[0];

                    Vlogger vlogger = new Vlogger(vloggerName);
                    vloggers.Add(vlogger);
                }
                else
                {
                    string firstVloggerUN = command[0];
                    string secondVloggerUN = command[2];

                    Vlogger firstVlogger = new Vlogger(firstVloggerUN);
                    Vlogger secondVlogger = new Vlogger(secondVloggerUN);

                    if (vloggers.Contains(firstVlogger) && vloggers.Contains(secondVlogger) && firstVloggerUN != secondVloggerUN)
                    {
                        vloggers.First(x => x.Username == firstVloggerUN).Following.Add(secondVlogger);
                        vloggers.First(x => x.Username == secondVloggerUN).Followers.Add(firstVlogger);
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            vloggers = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).ToHashSet();
            Vlogger mostPopular = (Vlogger)vloggers.First();
            Console.WriteLine($"1. {mostPopular.Username} : {mostPopular.Followers.Count} followers, {mostPopular.Following.Count} following");

            foreach (var follower in mostPopular.Followers.OrderBy(x=>x.Username))
            {
                Console.WriteLine($"*  {follower.Username}");
            }

            int counter = 2;

            foreach (var vlogger in vloggers.Skip(1))
            {
                Console.WriteLine($"{counter}. {vlogger.Username} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");

                counter++;
            }
        }
    }
}
