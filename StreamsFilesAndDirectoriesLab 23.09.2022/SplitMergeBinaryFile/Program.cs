using System;
using System.IO;


namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceReader = new FileStream(sourceFilePath, FileMode.Open))
            {
                int firstPartSize = (int)sourceReader.Length / 2;
                if (sourceReader.Length % 2 == 1)
                {
                    firstPartSize++;
                }

                byte[] firstPart = new byte[firstPartSize];
                byte[] secondPart = new byte[(int)sourceReader.Length / 2];

                sourceReader.Read(firstPart);
                sourceReader.Read(secondPart);

                using (FileStream firstPartWriter = new FileStream(partOneFilePath, FileMode.Create))
                {
                    firstPartWriter.Write(firstPart);
                }

                using (FileStream secondPartWriter = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    secondPartWriter.Write(secondPart);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream writer = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream firstPartReader = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] firstPart = new byte[firstPartReader.Length];

                    firstPartReader.Read(firstPart);

                    writer.Write(firstPart);
                }

                using (FileStream secondPartReader = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] secondPart = new byte[secondPartReader.Length];

                    secondPartReader.Read(secondPart);
                    writer.Write(secondPart);
                }

            }
        }
    }
}

