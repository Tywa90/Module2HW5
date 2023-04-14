using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoggerApp.Services
{
    public class FileService
    {
        public static Config Config { get; set; }
        public static string LogDirPath { get; set; }
        public static string BackUpDirPath { get; set; }

        public static void Run()
        {
            SerializationSample();
            DirectoryPath();
            DirectoryCheck();
            CreateFiles();
            DeleteFiles(LogDirPath);
            DeleteFiles(BackUpDirPath);
        }

        private static void SerializationSample()
        {
            var path = "Services\\jsconfig1.json";
            var configFile = File.ReadAllText(path);
            Config = JsonConvert.DeserializeObject<Config>(configFile);
        }

        private static void DirectoryPath()
        {
            LogDirPath = Config.Logger.DirectoryPath;
            BackUpDirPath = Config.Logger.BackUpDirectoryPath;

            LogDirPath = LogDirPath.Trim('/');
            BackUpDirPath = BackUpDirPath.Trim('/');
        }

        private static void DirectoryCheck()
        {
            if (!Directory.Exists(LogDirPath))
            {
                Console.WriteLine("Enter");
                Directory.CreateDirectory(LogDirPath);
            }

            if (!Directory.Exists(BackUpDirPath))
            {
                Console.WriteLine("Enter");
                Directory.CreateDirectory(BackUpDirPath);
            }
        }

        private static void CreateFiles()
        {
            FileName filename = new FileName();
            string name = filename.SetFromConfig(Config);

            var textLog = Logger.Sb.ToString();

            File.WriteAllText($"{LogDirPath}\\{name}.txt", textLog);
            File.WriteAllText($"{BackUpDirPath}\\{name}.txt", textLog);
        }

        private static void DeleteFiles(string dirName)
        {
            string[] filesArray = Directory.GetFiles(dirName);

            if (filesArray.Length > 3)
            {
                DateTime[] dateArr = new DateTime[filesArray.Length];
                for (int i = 0; i < filesArray.Length; i++)
                {
                    dateArr[i] = File.GetCreationTime(filesArray[i]);
                }

                int counterToDelFiles = filesArray.Length - 3;
                for (int i = 0; i < counterToDelFiles; i++)
                {
                    for (int j = 0; j < filesArray.Length; j++)
                    {
                        if (dateArr[i].CompareTo(dateArr[j]) < 0)
                        {
                            File.Delete(filesArray[i]);
                        }
                    }
                }
            }
        }
    }
}
