using System;
using System.Linq;
using System.ServiceProcess;
using M2M.Siemens.Library;

namespace M2M.Siemens.DataCollector
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
				SiemensFileWatcher siemensFileWatcher = new SiemensFileWatcher();
				siemensFileWatcher.Start();
				Console.WriteLine("Press any key to stop program");
				Console.ReadKey();
				siemensFileWatcher.Stop();
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
