using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using M2M.SystemDiagnostics.Library;
using System.Threading;

namespace M2M.SystemDiagnostics
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();

            if (!EventLog.SourceExists("M2MDiagnosticsLogSource"))
                EventLog.CreateEventSource("M2MDiagnosticsLogSource", "M2MDiagnosticsLog");

            eventLog1.Source = "M2MDiagnosticsLogSource";
            eventLog1.Log = "M2MDiagnosticsLog";
            eventLog1.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 0);
        }

        private SystemCheck m_SystemCheck = null;
        private Thread m_Thread = null;

        protected override void OnStart(string[] args)
        {
            try
            {
                m_Thread = new Thread(new ThreadStart(SystemCheckHandler));
                m_Thread.Start();

            }
            catch (Exception ex)
            {
                AddLogRow("Service start exception " + ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                m_SystemCheck.Stop();
                m_SystemCheck.OnLogRequest -= new SystemCheck.LogRequest(SystemCheck_LogRequest);
            }
            catch (Exception ex)
            {
                AddLogRow("Service stop exception " + ex.Message, EventLogEntryType.Error);
            }
        }

        protected void SystemCheckHandler()
        {
            m_SystemCheck = new SystemCheck();
            m_SystemCheck.OnLogRequest += new SystemCheck.LogRequest(SystemCheck_LogRequest);
            m_SystemCheck.Start();
        }

        public void AddLogRow(string message, EventLogEntryType entryType)
        {
            eventLog1.WriteEntry(message, entryType);
        }


        private void SystemCheck_LogRequest(object sender, LogRequestEventArgs e)
        {
            EventLogEntryType entryType;
            
            switch (e.LogType)
            {
                case LogRequestEventArgs.LogRequestEventType.Informational:
                    entryType = EventLogEntryType.Information;
                    break;
                case LogRequestEventArgs.LogRequestEventType.Error:
                    entryType = EventLogEntryType.Error;
                    break;
                default:
                    entryType = EventLogEntryType.Information;
                    break;
            }

            AddLogRow(e.Message, entryType);
        }
    }
}
