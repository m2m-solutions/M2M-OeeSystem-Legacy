using System;
using System.Linq;
using System.ServiceProcess;
using M2M.ChangeOver.Library;

namespace M2M.ChangeOver
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
                Engine engine = null;

                engine = new Engine();
                engine.RunOnce();
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
