using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp.Services
{
    public class FileName : INameCreator
    {
        public string SetFromConfig(Config config)
        {
            string configTimeFilter = config.Logger.TimeFormat;
            configTimeFilter = configTimeFilter.Replace('h', 'H');

            DateTime now = DateTime.Now;
            string timeString = now.ToString(configTimeFilter);
            timeString = timeString.Replace(':', '.');
            string dateString = now.ToShortDateString();

            string dateTimeName = $"{timeString} {dateString}";
            string getName = string.Format(config.Logger.FileName, dateTimeName);

            return getName;
        }
    }
}
