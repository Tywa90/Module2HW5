using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public class BusinessException : Exception
    {
        public BusinessException(string? message)
            : base(message)
        {
            //Logger.DisplayLog(LogType.Warning, message);
        }
    }
}
