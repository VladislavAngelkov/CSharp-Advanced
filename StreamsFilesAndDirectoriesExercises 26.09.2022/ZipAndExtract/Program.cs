namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = "../../../copyMe.png";
            string zipArchiveFilePath = "../../../File";
            string outputFilePath = "../../../Out";

            ZipFileToArchive(inputFilePath, zipArchiveFilePath);

            ExtractFileFromArchive(zipArchiveFilePath, "neshto si", outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (FileStream readInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using (ZipArchive zip = new ZipArchive(readInput))
                {
                    zip.CreateEntry(zipArchiveFilePath);
                }
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (FileStream readZip = new FileStream(zipArchiveFilePath, FileMode.Open))
            {
                using (ZipArchive zip = new ZipArchive(readZip))
                {
                    zip.ExtractToDirectory(outputFilePath);
                }
            }
        }
    }
}
