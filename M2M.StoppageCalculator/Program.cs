using System;
using System.Linq;
using System.ServiceProcess;
using M2M.StoppageCalculator.Library;

namespace M2M.StoppageCalculator
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
                StoppageCalculatorServer stoppageCalculatorServer = null;

                stoppageCalculatorServer = new StoppageCalculatorServer();
                stoppageCalculatorServer.RunOnce();
                Console.WriteLine("Press any key to exit program");
                Console.ReadKey();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new StoppageCalculator() 
			    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
