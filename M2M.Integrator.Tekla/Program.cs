using System;
using System.Linq;
using System.ServiceProcess;
using Quartz;
using Quartz.Impl;
using M2M.Integrator.Tekla.Library;

namespace M2M.Integrator.Tekla
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service1() 
			};

			if (Environment.UserInteractive)
			{
				Console.WriteLine("Press any key to start transfer");
				Console.ReadKey();
				ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
				IScheduler scheduler = schedulerFactory.GetScheduler();
				scheduler.Start();
				JobDetail teklaTransfer = new JobDetail("teklaTransfer", null, typeof(TeklaTransfer));
				
				Trigger trigger = TriggerUtils.MakeImmediateTrigger(0, new TimeSpan());
				trigger.Name = "immediateTrigger";

				scheduler.ScheduleJob(teklaTransfer, trigger);
			
				Console.ReadKey();
				scheduler.Shutdown();
			}
			else
			{
				ServiceBase.Run(ServicesToRun);
			}
        }
    }
}
