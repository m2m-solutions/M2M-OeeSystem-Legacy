using System;
using System.Linq;
using System.ServiceProcess;
using M2M.OeeCalculator.Library;

namespace M2M.OeeCalculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            { 
                OeeCalculatorServer oeeCalculatorServer = null;
                
                oeeCalculatorServer = new OeeCalculatorServer();
                oeeCalculatorServer.RunOnce();
                Console.WriteLine("Press any key to exit program");
                Console.ReadKey();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new Service1() 
			    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
