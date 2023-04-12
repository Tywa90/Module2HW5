using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LoggerApp.Services;

namespace LoggerApp
{
    internal class Logger
    {
        private static string logConsole = string.Empty;
        private static StringBuilder _sb = new StringBuilder();
        public static StringBuilder Sb { get { return _sb; } }

        public static void DisplayLog(LogType type, string message)
        {
            var date = DateTime.Now.ToLongTimeString();
            logConsole = date + " : " + type + " : " + message;
            Console.WriteLine(logConsole);
            _sb.Append(logConsole + "\n");
        }

        public static void RunFileServices ()
        {
            FileService.Run();
        }
    }
}
