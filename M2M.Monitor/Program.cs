using M2M.Monitor.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace M2M.Monitor
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
                MonitorServer server = null;

                server = new MonitorServer();
                server.RunOnce();
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
