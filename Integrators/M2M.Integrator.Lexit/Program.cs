using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using M2M.Integrator.Lexit.Library;

namespace M2M.Integrator.Lexit
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
            ServicesToRun = new ServiceBase[] { new Integrator() };

            if (Environment.UserInteractive)
            {
                JobServer jobServer = null;

                jobServer = new JobServer();
                jobServer.Start();
                Console.WriteLine("Press any key to stop program");

                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey();

                    if (keyInfo.KeyChar == 'p')
                        jobServer.Pause();

                    if (keyInfo.KeyChar == 'c')
                        jobServer.Continue();
                }
                while (keyInfo.KeyChar == 'p' || keyInfo.KeyChar == 'c');

                jobServer.Stop();
            }
            else
            {
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
