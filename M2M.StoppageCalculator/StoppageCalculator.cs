using System;
using System.Linq;
using System.ServiceProcess;
using M2M.StoppageCalculator.Library;
using System.Threading;
using NLog;

namespace M2M.StoppageCalculator
{
    public partial class StoppageCalculator : ServiceBase
    {
        public StoppageCalculator()
        {
            InitializeComponent();
        }

        private StoppageCalculatorServer m_StoppageCalculatorServer = null;
        private Thread m_SubscribeThread = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void OnStart(string[] args)
        {
            m_SubscribeThread = new Thread(new ThreadStart(StoppageCalculatorHandler));
            m_SubscribeThread.Start();
        }

        protected override void OnStop()
        {
            try
            {
                m_StoppageCalculatorServer.Stop();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Service stop exception.", ex);
            }
        }

        protected void StoppageCalculatorHandler()
        {
            m_StoppageCalculatorServer = new StoppageCalculatorServer();
            m_StoppageCalculatorServer.Start();
        }
    }
}
