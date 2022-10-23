using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        string[] words = wordsReader.ReadToEnd().ToLower().Split(new char[] { ' ', ',', '.', '!', '?', '-', '…' }, StringSplitOptions.RemoveEmptyEntries);

                        string[] text = textReader.ReadToEnd().ToLower().Split(new char[] { ' ', ',', '.', '!', '?', '-', '…' }, StringSplitOptions.RemoveEmptyEntries);

                        Dictionary<string, int> wordsOccurences = new Dictionary<string, int>();

                        foreach (var textWord in text)
                        {
                            foreach (var word in words)
                            {
                                if (word == textWord)
                                {
                                    if (!wordsOccurences.ContainsKey(word))
                                    {
                                        wordsOccurences.Add(word, 0);
                                    }

                                    wordsOccurences[word]++;
                                }
                            }
                        }

                        foreach (var word in wordsOccurences.OrderByDescending(x=>x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");     
                        }
                    }
                }
            }
        }
    }
}

