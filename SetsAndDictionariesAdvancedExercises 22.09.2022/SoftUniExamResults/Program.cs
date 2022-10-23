using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> languages = new Dictionary<string, int>();

            HashSet<string> bannedUsers = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "exam finished")
            {
                string[] submission = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string user = submission[0];

                if (submission.Length == 2)
                {
                    if (users.ContainsKey(user))
                    {
                        bannedUsers.Add(user);
                    }

                    users.Remove(user);
                    command = Console.ReadLine();
                    continue;
                }

                if (bannedUsers.Contains(user))
                {
                    command = Console.ReadLine();
                    continue;
                }

                string language = submission[1];
                int points = int.Parse(submission[2]);

                if (!languages.ContainsKey(language))
                {
                    languages.Add(language, 0);
                }

                languages[language]++;

                if (!users.ContainsKey(user))
                {
                    users.Add(user, new Dictionary<string, int>());
                }

                if (!users[user].ContainsKey(language))
                {
                    users[user].Add(language, 0);
                }

                if (users[user][language]<points)
                {
                    users[user][language] = points;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var user in users.OrderByDescending(x => x.Value.Sum(x => x.Value)).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value.Sum(x => x.Value)}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
