using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerApp.Services;

namespace LoggerApp
{
    public interface INameCreator
    {
        string SetFromConfig(Config config);
    }
}
