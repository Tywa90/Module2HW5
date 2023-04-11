using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    internal class Starter
    {
        public void Run()
        {
            Actions action = new Actions();
            Logger logger = new Logger();

            for (int i = 0; i < 100; i++)
            {
                int choice = new Random().Next(1, 4); //поменять на 4
                switch (choice)
                {
                    case 1:
                        action.Method1();
                        break;
                    case 2:
                        try
                        {
                            action.Method2();
                        }
                        catch (BusinessException bEx)
                        {
                            string warningMsg = $"Action got this custom Exception : {bEx.Message}";
                            Logger.DisplayLog(LogType.Warning, warningMsg);
                        }
                        break;
                    case 3:
                        try
                        {
                            action.Method3();
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = $"Action failed by а reason: {ex.Message}";
                            Logger.DisplayLog(LogType.Error, errorMsg);
                        }

                        break;
                    default:
                        Console.WriteLine("No one method enter the switcher");
                        break;
                }
            }

            logger.WriteFile();
        }
    }
}
