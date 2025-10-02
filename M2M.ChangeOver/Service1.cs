using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using M2M.ChangeOver.Library;
using NLog;

namespace M2M.ChangeOver
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private Engine m_Engine = null;
        private Thread m_SubscribeThread = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void OnStart(string[] args)
        {
            logger.Trace("Start called");

            m_SubscribeThread = new Thread(new ThreadStart(EngineHandler));
            m_SubscribeThread.Start();
        }

        protected override void OnStop()
        {
            logger.Trace("Stop called");
            try
            {
                m_Engine.Stop();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Service stop failed.", ex);
            }
        }

        protected void EngineHandler()
        {
            m_Engine = new Engine();
            m_Engine.Start();
        }
    }
}
