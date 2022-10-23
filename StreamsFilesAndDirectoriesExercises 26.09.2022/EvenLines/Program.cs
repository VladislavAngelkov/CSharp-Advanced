using System;

namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                StringBuilder result = new StringBuilder();

                int counter = 0;

                while (!reader.EndOfStream)
                {
                    string currentLine = reader.ReadLine();

                    char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };

                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < symbolsToReplace.Length; i++)
                        {
                            currentLine = currentLine.Replace(symbolsToReplace[i], '@');
                        }

                        List<string> words = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                        words.Reverse();

                        result.AppendLine(string.Join(" ", words));

                    }

                    counter++;
                }

                return result.ToString();
            }
        }
    }
}

