using System;
using System.Linq;
using System.ServiceProcess;
using M2M.SystemDiagnostics.Library;

namespace M2M.SystemDiagnostics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new Service1() };

            if (Environment.UserInteractive)
            {
                SystemCheck systemCheck = null;
                systemCheck = new SystemCheck();
                systemCheck.CheckOnce();
                Console.ReadKey();
            }
            else
            {
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
