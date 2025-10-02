using System;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using M2M.DataCenter;
using System.Net.Mail;
using System.Data.OleDb;

namespace M2M.SystemDiagnostics.Library
{
    public class LogRequestEventArgs : System.EventArgs
    {
        public enum LogRequestEventType
        {
            Informational,
            Error
        }

        private LogRequestEventType m_LogType = LogRequestEventType.Informational;
        private string m_Message = "";

        public LogRequestEventArgs(LogRequestEventType logType, string message)
            : base()
        {
            m_LogType = logType;
            m_Message = message;
        }

        public LogRequestEventType LogType
        {
            get { return m_LogType; }
        }

        public string Message
        {
            get { return m_Message; }
        }
    }

    public class SystemCheck
    {
        public delegate void LogRequest(object sender, LogRequestEventArgs e);

		public event LogRequest OnLogRequest;

        private System.Timers.Timer m_Timer = new System.Timers.Timer();
        private bool m_IsStarted = false;

        public SystemCheck()
		{
			
		}

		public void Start()
		{

            try
            {
                m_Timer.Interval = ApplicationSettings.Interval;
                m_Timer.AutoReset = false;
                m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedTime);

                m_IsStarted = true;
                m_Timer.Start();
                
                LogInfo("Performs system check");

            }
            catch (Exception e)
            {
                LogError("System check failed. " + e.Message);
            }
        }

		public void Stop()
		{
            m_Timer.Stop();
            m_IsStarted = false;
            LogInfo("System check stopped");
		}

        private void OnElapsedTime(object source, System.Timers.ElapsedEventArgs e)
        {
            PerformSystemCheck();
            m_Timer.Interval = ApplicationSettings.Interval;
        }

        public void CheckOnce()
        {
            System.Diagnostics.Debug.Assert(!m_IsStarted);

            PerformSystemCheck();
        }

        private void PerformSystemCheck()
        {
            StringBuilder errorMessage = new StringBuilder();
            
            Exception exception = null;
            try
            {
                
                try
                {
                    // Check connection to database
                    using (SqlConnection connection = new SqlConnection(ApplicationSettings.SystemConnectionString))
                    {
                        connection.Open();
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                    errorMessage.AppendLine("Failed to connect to " + ApplicationSettings.SystemConnectionString);
                    errorMessage.AppendLine();
                    errorMessage.AppendLine(exception.ToString());
                    return;
                }



                if (!M2MDataCenter.IsServiceStarted(M2MDataCenter.SystemSettings.OpcServerServiceName))
                    errorMessage.AppendLine(M2MDataCenter.SystemSettings.OpcServerServiceName + " is not started");
               
                if (!M2MDataCenter.IsServiceStarted(M2MDataCenter.SystemSettings.DataCollectorServiceName))
                    errorMessage.AppendLine(M2MDataCenter.SystemSettings.DataCollectorServiceName + " is not started");
               
                if (!M2MDataCenter.IsServiceStarted(M2MDataCenter.SystemSettings.DataCalculatorServiceName))
                    errorMessage.AppendLine(M2MDataCenter.SystemSettings.DataCalculatorServiceName + " is not started");
               
                if(M2MDataCenter.GetAvailableModules().Contains("Tekla"))
                {
                    try
                    {
                        // Check connection to database
                        using (OleDbConnection connection = new OleDbConnection(M2MDataCenter.SystemSettings.TeklaConnectionString))
                        {
                            connection.Open();
                        }
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        errorMessage.AppendLine("Failed to connect to " + M2MDataCenter.SystemSettings.TeklaConnectionString);
                        errorMessage.AppendLine();
                        errorMessage.AppendLine(exception.ToString());
                        return;
                    }

                    if (!M2MDataCenter.IsServiceStarted("M2M.Integrator.Tekla"))
                    {
                        errorMessage.AppendLine("M2M.Integrator.Tekla is not started");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("System check error " + ex.Message);
            }
            finally
            {
                if(errorMessage.Length > 0)
                    SendErrorMail(errorMessage.ToString());
            }
        }

        private void SendErrorMail(string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(ApplicationSettings.MailSender, ApplicationSettings.MailRecipient, ApplicationSettings.MailSubject, message);
                SmtpClient client = new SmtpClient();
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                LogError("Failed to send mail. " + ex.Message);
            }
        }

        //---------------------------------------------------------
		// LogEvent Helper Methods.

		private void LogError(string message)
		{
			if (OnLogRequest != null)
				OnLogRequest(this, new LogRequestEventArgs(LogRequestEventArgs.LogRequestEventType.Error, message));
		}

		public void LogInfo(string message)
		{
			if (OnLogRequest != null)
				OnLogRequest(this, new LogRequestEventArgs(LogRequestEventArgs.LogRequestEventType.Informational, message));
		}
	}
}
