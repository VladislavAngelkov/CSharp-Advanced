using System;
using System.IO;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream bytesReader = new FileStream(bytesFilePath, FileMode.Open))
            {
                using (FileStream binaryReader = new FileStream(binaryFilePath, FileMode.Open))
                {
                    using (FileStream writer = new FileStream(outputPath, FileMode.Create))
                    {
                        byte[] bytes = new byte[bytesReader.Length];
                        bytesReader.Read(bytes);

                        byte[] image = new byte[binaryReader.Length];
                        binaryReader.Read(image);

                        foreach (var imgByte in image)
                        {
                            foreach (var srchdByte in bytes)
                            {
                                if (imgByte == srchdByte)
                                {
                                    writer.Write(new byte[] {imgByte});
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

