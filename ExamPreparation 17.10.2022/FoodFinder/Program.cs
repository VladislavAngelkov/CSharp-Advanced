using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vowelsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> vowels = new Queue<string>(vowelsInfo);
            int vowelsCount = vowels.Count;

            string[] consonantsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> consonants = new Stack<string>(consonantsInfo);

            List<string> words = new List<string>
            {
                "pear", "flour", "pork", "olive"
            };

            while (consonants.Count > 0)
            {
                string currentVowel = vowels.Dequeue();
                string currentConsonant = consonants.Pop();

                for (int i = 0; i < words.Count; i++)
                {
                    if (words[i].Contains(currentVowel))
                    {
                        string vowelReplacement = currentVowel.ToUpper();
                        words[i] = words[i].Replace(currentVowel, vowelReplacement);
                    }
                    if (words[i].Contains(currentConsonant))
                    {
                        words[i] = words[i].Replace(currentConsonant, currentConsonant.ToUpper());
                    }
                }

                vowels.Enqueue(currentVowel);
            }

            Console.WriteLine($"Words found: {words.Where(w => !w.Any(l => char.IsLower(l))).Count()}");

            foreach (var word in words.Where(w => !w.Any(l => char.IsLower(l))))
            {
                Console.WriteLine(word.ToLower());
            }
        }
    }
}
