using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp.Services
{
    public interface INameCreator
    {
        string SetFromConfig(Config config);
    }
}
