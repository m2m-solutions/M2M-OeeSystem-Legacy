using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using M2M.OeeCalculator.Library;
using NLog;

namespace M2M.OeeCalculator
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private OeeCalculatorServer m_OeeCalculatorServer = null;
        private Thread m_SubscribeThread = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void OnStart(string[] args)
        {
            m_SubscribeThread = new Thread(new ThreadStart(OeeCalculatorHandler));
            m_SubscribeThread.Start();
        }

        protected override void OnStop()
        {
            try
            {
                m_OeeCalculatorServer.Stop();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Service stop exception.", ex);
            }
        }

        protected void OeeCalculatorHandler()
        {
            m_OeeCalculatorServer = new OeeCalculatorServer();
            m_OeeCalculatorServer.Start();
        }
    }
}
