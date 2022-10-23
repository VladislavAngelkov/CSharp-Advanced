using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo info = new DirectoryInfo(folderPath);

            FileInfo[] files = info.GetFiles("*", SearchOption.AllDirectories);

            double folderSize = 0;

            foreach (FileInfo file in files)
            {
                folderSize += file.Length;
            }

            folderSize = folderSize / 1024;

            File.WriteAllText(outputFilePath, folderSize.ToString());

            //using (StreamWriter writer = new StreamWriter(outputFilePath))
            //{
            //    writer.Write(folderSize);
            //}
        }
    }
}

