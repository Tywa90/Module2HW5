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
}
