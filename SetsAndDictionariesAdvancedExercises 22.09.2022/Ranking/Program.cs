using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsAndPasswords = new Dictionary<string, string>();

            string contestInput = Console.ReadLine();

            while (contestInput != "end of contests")
            {
                string[] contestInfo = contestInput.Split(":");
                string contest = contestInfo[0];
                string password = contestInfo[1];

                if (!contestsAndPasswords.ContainsKey(contest))
                {
                    contestsAndPasswords.Add(contest, password);
                }

                contestInput = Console.ReadLine();
            }

            string contestantInput = Console.ReadLine();

            Dictionary<string, Dictionary<string, double>> contestants = new Dictionary<string, Dictionary<string, double>>();

            while (contestantInput != "end of submissions")
            {
                string[] contestantInfo = contestantInput.Split("=>");
                string contest = contestantInfo[0];
                string password = contestantInfo[1];
                string contestant = contestantInfo[2];
                double points = double.Parse(contestantInfo[3]);

                if (contestsAndPasswords.ContainsKey(contest))
                {
                    if (contestsAndPasswords[contest] == password)
                    {
                        if (!contestants.ContainsKey(contestant))
                        {
                            contestants.Add(contestant, new Dictionary<string, double>());
                        }

                        if (!contestants[contestant].ContainsKey(contest))
                        {
                            contestants[contestant].Add(contest, points);
                        }

                        if (contestants[contestant][contest] < points)
                        {
                            contestants[contestant][contest] = points;
                        }
                    }
                }

                contestantInput = Console.ReadLine();
            }

            Console.WriteLine($"Best candidate is {contestants.OrderByDescending(x=>x.Value.Sum(x=>x.Value)).First().Key} with total {contestants.Max(x=>x.Value.Sum(x=>x.Value))} points.");

            Console.WriteLine("Ranking:");

            foreach (var contestant in contestants.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{contestant.Key}");
                foreach (var contest in contestant.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
