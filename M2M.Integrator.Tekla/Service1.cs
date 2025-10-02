using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using M2M.Integrator.Tekla.Library;
using System.Threading;
using NLog;

namespace M2M.Integrator.Tekla
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private ServiceDataCollector m_ServiceDataCollector = null;
        private Thread m_SubscribeThread = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void OnStart(string[] args)
        {
            try
            {
                m_SubscribeThread = new Thread(new ThreadStart(PollServiceDataHandler));
                m_SubscribeThread.Start();

            }
            catch (Exception ex)
            {
                logger.ErrorException("Service start failed.", ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                m_ServiceDataCollector.Stop();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Service stop failed.", ex);
            }
        }

        protected void PollServiceDataHandler()
        {
            m_ServiceDataCollector = new ServiceDataCollector();
            m_ServiceDataCollector.Start();
        }
    }
}
