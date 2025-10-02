using System.ServiceProcess;
using System;
using M2M.DataCollector.Library;

namespace M2M.DataCollector
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
                OpcClientServer opcClientServer = null;
                
                opcClientServer = new OpcClientServer();
                opcClientServer.Start();
                Console.WriteLine("Press any key to stop program");
                
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey();

                    if (keyInfo.KeyChar == 'p')
                        opcClientServer.Pause();

                    if (keyInfo.KeyChar == 'c')
                        opcClientServer.Continue();
                }
                while (keyInfo.KeyChar == 'p' || keyInfo.KeyChar == 'c');

                opcClientServer.Stop();
            }
            else
            {
                ServiceBase.Run(ServicesToRun);
            }
		}
	}
}