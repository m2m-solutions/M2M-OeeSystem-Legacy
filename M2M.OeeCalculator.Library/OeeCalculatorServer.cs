using System;
using Csla;
using M2M.DataCenter;
using NLog;
using System.Collections.Generic;

namespace M2M.OeeCalculator.Library
{
	[Serializable]
	public class OeeCalculatorServer
	{
        private readonly System.Timers.Timer m_Timer = new System.Timers.Timer();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private int m_CurrentInterval = 600000;
        
        public OeeCalculatorServer()
		{
			
		}

        public void RunOnce()
        {
            Execute();
        }

        public void Start()
		{

            try
            {
                m_CurrentInterval = M2MDataCenter.SystemSettings.CalculateInterval * 60 * 1000;
                m_Timer.Interval = m_CurrentInterval;
                logger.Trace("Interval: {0}", m_Timer.Interval);
                m_Timer.AutoReset = false;
                m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedTime);

                m_Timer.Start();

                logger.Info("OeeCalculator service started");

            }
            catch (Exception ex)
            {
                logger.ErrorException("Start failed", ex);
                throw ex;
            }
        }

		public void Stop()
		{
            m_Timer.Stop();
            logger.Info("OeeCalculator stopped");
		}

        private void Execute()
        {
            ExecuteOeeCalculateRequests();

            SmartDate startTime = new SmartDate(DateTime.Today);
            SmartDate endTime = new SmartDate(DateTime.Now);

            // re-calculate previous day if necessary 
            if (endTime.Subtract(startTime.Date).TotalMinutes <= (M2MDataCenter.SystemSettings.CalculateInterval * 2))
            {
                OeeCalculator.CalculateAllOeeData(new SmartDate(startTime.Date.AddDays(-1)), startTime);
            }

            OeeCalculator.CalculateAllOeeData(startTime, endTime);
        }

        private void OnElapsedTime(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Execute();

                M2MDataCenter.ReloadSystemSettings();
                m_CurrentInterval = M2MDataCenter.SystemSettings.CalculateInterval * 60 * 1000;
                logger.Trace("Interval: {0}", m_Timer.Interval);
            }
            catch (Exception ex)
            {
                logger.ErrorException("Previously unhandled exception", ex);
            }
            finally
            {
                m_Timer.Interval = m_CurrentInterval;
            }
        }

        private void ExecuteOeeCalculateRequests()
        {
            try
            {
                OeeCalculateRequestCollection requests = OeeCalculateRequestCollection.GetOeeCalculateRequestCollection();
                List<int> deleteList = new List<int>();
                logger.Trace("OeeCalculateRequests count: {0}", requests.Count);
                foreach (OeeCalculateRequest request in requests)
                {
                    DateTime date = request.StartDate.Date;
                    try
                    {
                        logger.Trace("OeeCalculateRequest: {0}, {1} - {2}", request.DivisionId, request.StartDate.ToString("yyyy-MM-dd HH:mm:ss.fff"), request.EndDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        // Calculate day-by-day (otherwise we risk timeouts while processing)
                        int count = 0;
                        while (date <= request.EndDate.Date)
                        {
                            if (date > DateTime.Now)
                                break;

                            DateTime endDate = date.AddDays(1);
                            if (endDate > DateTime.Now)
                                endDate = DateTime.Now;

                            logger.Trace("CalculateOeeData for: {0}, {1} - {2}", request.DivisionId, date.ToString("yyyy-MM-dd HH:mm:ss.fff"), endDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            OeeCalculator.CalculateOeeData(request.DivisionId, request.MachineId, date, endDate);

                            date = date.AddDays(1);
                            count++;
                        }
                        logger.Trace("Days calculated: {0}", count);
                        deleteList.Add(request.Id);
                    }
                    catch (Exception ex)
                    {
                        logger.ErrorException(String.Format("Failed to execute request for division {0} on date {1}", request.DivisionId, date.ToShortDateString()), ex);
                    }
                }

                foreach (int requestId in deleteList)
                    requests.Remove(requests.GetItem(requestId));

                requests.Save();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to execute requests", ex);
            }
       }
	}
}
