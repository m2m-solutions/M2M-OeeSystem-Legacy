using System;

using System.ServiceProcess;
using System.Threading;
using M2M.DataCollector.Library;
using NLog;

namespace M2M.DataCollector
{
	public partial class Service1 : ServiceBase
	{
		public Service1()
		{
			InitializeComponent();
            
		}

		//--------------------------------------------------------------------
		// Service variables
		private OpcClientServer m_OpcClientServer = null;
		private Thread m_SubscribeThread = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

		protected override void OnStart(string[] args)
		{
            logger.Trace("Start called");

            m_SubscribeThread = new Thread(new ThreadStart(OpcConnectionHandler));
			m_SubscribeThread.Start();
		}

		protected override void OnStop()
		{
            try
            {
                m_OpcClientServer.Stop();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Service stop exception.", ex);
            }
		}

        protected override void OnPause()
        {
            logger.Trace("Pause called");
            m_OpcClientServer.Pause();
        }

        protected override void OnContinue()
        {
            logger.Trace("Continue called");
            m_OpcClientServer.Continue();
        }

		protected void OpcConnectionHandler()
		{
			m_OpcClientServer = new OpcClientServer();
			m_OpcClientServer.Start();
		}
	}
}
