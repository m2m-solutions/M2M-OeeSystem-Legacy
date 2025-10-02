using System;
using Csla;
using M2M.DataCenter;
using NLog;
using System.Collections.Generic;

namespace M2M.StoppageCalculator.Library
{
	[Serializable]
	public class StoppageCalculatorServer
	{
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly System.Timers.Timer m_Timer = new System.Timers.Timer();
        private int m_CurrentInterval = 600000;
        
        public StoppageCalculatorServer()
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
                m_Timer.AutoReset = false;
                m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedTime);

                m_Timer.Start();

                logger.Info("StoppageCalculator service started");

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
            logger.Info("StoppageCalculator stopped");
		}

        private void Execute()
        {
            ExecuteStoppageCalculateRequests();
            
            SmartDate startTime = new SmartDate(DateTime.Today);
            SmartDate endTime = new SmartDate(DateTime.Now);

            // re-calculate previous day if necessary 
            if (endTime.Subtract(startTime.Date).TotalMinutes <= (M2MDataCenter.SystemSettings.CalculateInterval * 2))
            {
                StoppageCalculator.CalculateAllStoppageData(new SmartDate(startTime.Date.AddDays(-1)), startTime);
            }

            StoppageCalculator.CalculateAllStoppageData(startTime, endTime);
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

        private void ExecuteStoppageCalculateRequests()
        {
            try
            {
                StoppageCalculateRequestCollection requests = StoppageCalculateRequestCollection.GetStoppageCalculateRequestCollection();
                List<int> deleteList = new List<int>();
                logger.Trace("StoppageCalculateRequests count: {0}", requests.Count);
                foreach (StoppageCalculateRequest request in requests)
                {
                    DateTime date = request.StartDate.Date;
                    try
                    {
                        
                        logger.Trace("StoppageCalculateRequest: {0}, {1} - {2}", request.DivisionId, request.StartDate.ToString("yyyy-MM-dd HH:mm:ss.fff"), request.EndDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        // Calculate day-by-day (otherwise we risk timeouts while processing)
                        int count = 0;
                        while (date <= request.EndDate.Date)
                        {

                            StoppageCalculator.CalculateStoppageData(request.DivisionId, request.MachineId, date, date.AddDays(1));

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

                foreach(int requestId in deleteList)
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
