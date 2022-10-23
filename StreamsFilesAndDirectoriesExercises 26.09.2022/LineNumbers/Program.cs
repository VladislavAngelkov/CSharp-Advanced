using System;
using System.IO;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = "../../../text.txt";
            string outputFilePath = "../../../output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] text = File.ReadAllLines(inputFilePath);

            StringBuilder result = new StringBuilder();
            int counter = 1;
            int letterCount = 0;
            int punctuationCount = 0;

            foreach (string line in text)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsLetter(line[i]))
                    {
                        letterCount++;
                    }
                    else if (char.IsPunctuation(line[i]))
                    {
                        punctuationCount++;
                    }
                }

                result.AppendLine($"Line {counter}: {line} ({letterCount})({punctuationCount})");
                counter++;

                letterCount = 0;
                punctuationCount = 0;
            }

            File.WriteAllText(outputFilePath, result.ToString());
        }
    }

}
