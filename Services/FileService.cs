using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp.Services
{
    public class FileService
    {

        public static void SerializationSample()
        {
            var path = "Services\\jsconfig1.json";
            var configFile = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<Config>(configFile);

            Console.WriteLine(config.Logger.LineSeparator);
            Console.WriteLine(config.Logger.TimeFormat);
        }
        public void WriteFile(StringBuilder sb)
        {
            var textLog = sb.ToString();

            File.WriteAllText("log.txt", textLog);
           
        }
    }
}
