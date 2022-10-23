﻿using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondReader = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        while (!firstReader.EndOfStream || !secondReader.EndOfStream)
                        {
                            if (!firstReader.EndOfStream)
                            {
                                string firstTextLine = firstReader.ReadLine();
                                writer.WriteLine(firstTextLine);
                            }

                            if (!secondReader.EndOfStream)
                            {
                                string secondTextLine = secondReader.ReadLine();
                                writer.WriteLine(secondTextLine);
                            }
                        }
                    }
                }
            }
        }
    }
}

