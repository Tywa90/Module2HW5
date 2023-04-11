using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerApp
{
    internal class Logger
    {
        private static string logConsole = string.Empty;
        private static StringBuilder sb = new StringBuilder();

        public static void DisplayLog(LogType type, string message)
        {
            var date = DateTime.Now.ToLongTimeString();
            logConsole = date + " : " + type + " : " + message;
            Console.WriteLine(logConsole);
            sb.Append(logConsole + "\n");
        }

        public void WriteFile()
        {
            var textLog = sb.ToString();

            File.WriteAllText("log.txt", textLog);
        }
    }
}
