using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp.Services
{
    [Serializable]
    public class Config
    {
        public LoggerConfig Logger { get; set; }
    }
    public class LoggerConfig
    {
        public int LineSeparator { get; set; }
        public string TimeFormat { get; set; }
        public string DirectoryPath { get; set; }
        public string BackUpDirectoryPath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
    }
}
