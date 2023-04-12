﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FileCreate();
        }
        public static void SerializationSample()
        {
            var path = "Services\\jsconfig1.json";
            var configFile = File.ReadAllText(path);
            Config = JsonConvert.DeserializeObject<Config>(configFile);

            Console.WriteLine(Config.Logger.LineSeparator);
            Console.WriteLine(Config.Logger.TimeFormat);
        }
        public static void DirectoryPath()
        {
            LogDirPath = Config.Logger.DirectoryPath;
            BackUpDirPath = Config.Logger.BackUpDirectoryPath;

            LogDirPath = LogDirPath.Trim('/');
            BackUpDirPath = BackUpDirPath.Trim('/');
        }
        public static void DirectoryCheck()
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
        public static void FileCreate()
        {
            var textLog = Logger.Sb.ToString();

            var fullDate = DateTime.Now;
            string timeString = fullDate.ToLongTimeString();
            string dateString = fullDate.ToShortDateString();
            timeString = timeString.Replace(':', '.');

            string fileName = $"{timeString} {dateString}";

            File.WriteAllText($"{LogDirPath}\\{fileName}.txt", textLog);
            File.WriteAllText($"{BackUpDirPath}\\{fileName}.txt", textLog);

            FilesCounter(LogDirPath);
            FilesCounter(BackUpDirPath);
        }
        private static void FilesCounter(string dirName)
        {
            string[] filesArray = Directory.GetFiles(dirName);

            if (filesArray.Length > 3)
            {
                //int j = 0;
                //string[] tempArr = new string[3];
                //for (int i = filesArray.Length; i > filesArray.Length - 3; i--)
                //{
                //    tempArr[j] = filesArray[i-1];
                //    j++;

                //}
                int counterToDelFiles = filesArray.Length - 3;
                for (int i = 0; i < counterToDelFiles; i++)
                {
                    File.Delete(filesArray[i]);
                }
            }
        }

    }
}
