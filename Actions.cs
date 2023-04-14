using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public class Actions
    {
        private readonly string _message1;
        private readonly string _message2;
        private readonly string _message3;

        public Actions()
        {
            _message1 = "Start method";
            _message2 = "Skipped logic in method";
            _message3 = "I broke a logic";
        }

        public bool Method1()
        {
            Logger.DisplayLog(LogType.Info, _message1);
            return true;
        }

        public void Method2()
        {
            throw new BusinessException(_message2);
        }

        public void Method3()
        {
            throw new Exception(_message3);
        }
    }
}
