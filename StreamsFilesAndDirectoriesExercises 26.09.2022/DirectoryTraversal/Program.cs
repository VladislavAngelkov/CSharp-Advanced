using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo info = new DirectoryInfo(inputFolderPath);

            FileInfo[] files = info.GetFiles();

            Dictionary<string, Dictionary<string, double>> extensions = new Dictionary<string, Dictionary<string, double>>();

            foreach (FileInfo file in files)
            {
                string currExtention = file.Extension;
                string currName = file.Name;
                double currSize = file.Length;

                if (!extensions.ContainsKey(currExtention))
                {
                    extensions.Add(currExtention, new Dictionary<string, double>());
                }

                extensions[currExtention].Add(currName, currSize);
            }

            extensions = extensions.OrderByDescending(x => x.Value.Count).ThenBy(x=>x.Key).ToDictionary(x => x.Key, y => y.Value);

            StringBuilder builder = new StringBuilder();

            foreach (var extension in extensions.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                builder.AppendLine($"{extension.Key}");

                foreach (var file in extension.Value.OrderByDescending(x=>x.Value))
                {
                    builder.AppendLine($"--{file.Key} - {file.Value / 1024}kb");
                }
            }

            return builder.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += reportFileName;

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(textContent);
            }
        }
    }
}

