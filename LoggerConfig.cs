using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{

    public class LoggerConfig1
    {
        public int LineSeparator { get; set; }
        public string TimeFormat { get; set; }
        public string DirectoryPath { get; set; }
        public string BackUpDirectoryPath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
    }
}
