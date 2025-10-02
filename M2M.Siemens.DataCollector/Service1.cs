using System;
using System.Linq;
using System.ServiceProcess;

namespace M2M.Siemens.DataCollector
{
	public partial class Service1 : ServiceBase
	{
		public Service1()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
		}

		protected override void OnStop()
		{
		}
	}
}
