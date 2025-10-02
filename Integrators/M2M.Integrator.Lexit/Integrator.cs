using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using M2M.Integrator.Lexit.Library;
using NLog;

namespace M2M.Integrator.Lexit
{
    public partial class Integrator : ServiceBase
    {
        private JobServer m_JobServer = null;
        private Thread m_WorkerThread = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Integrator()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                m_WorkerThread = new Thread(new ThreadStart(IntegratorHandler));
                m_WorkerThread.Start();

            }
            catch (Exception ex)
            {
                logger.ErrorException("Service start exception.", ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                m_JobServer.Stop();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Service stop exception.", ex);
            }
        }

        protected void IntegratorHandler()
        {
            m_JobServer = new JobServer();
            m_JobServer.Start();
        }
    }
}
