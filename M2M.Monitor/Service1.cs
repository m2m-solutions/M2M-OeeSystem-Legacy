using M2M.Monitor.Library;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M2M.Monitor
{
    public partial class Service1 : ServiceBase
    {
        private MonitorServer m_MonitorServer = null;
        private Thread m_SubscribeThread = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            m_SubscribeThread = new Thread(new ThreadStart(MonitorHandler));
            m_SubscribeThread.Start();
        }

        protected override void OnStop()
        {
            try
            {
                m_MonitorServer.Stop();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Service stop exception.", ex);
            }
        }

        protected void MonitorHandler()
        {
            m_MonitorServer = new MonitorServer();
            m_MonitorServer.Start();
        }
    }
}
