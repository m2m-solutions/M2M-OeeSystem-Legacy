using System;
using Csla;
using M2M.DataCenter;

namespace M2M.OeeCalculator.Library
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

	[Serializable]
	public class CalculatorServer
	{
		public delegate void LogRequest(object sender, LogRequestEventArgs e);

		public event LogRequest OnLogRequest;

        private System.Timers.Timer m_Timer = new System.Timers.Timer();
        private int m_Interval = 60000;
        
        public int Interval
        {
            get { return m_Interval; }
            set { m_Interval = value; }
        }

		public CalculatorServer()
		{
			
		}

		public void Start()
		{

            try
            {
                m_Timer.Interval = m_Interval;
                m_Timer.AutoReset = false;
                m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedTime);

                m_Timer.Start();

                LogInfo("Calculating stoppage data started");

            }
            catch (Exception e)
            {
                LogError("Calculation failed. " + e.Message);
            }
        }

		public void Stop()
		{
            m_Timer.Stop();
            LogInfo("Calculating stoppage data stopped");
		}

        private void OnElapsedTime(object source, System.Timers.ElapsedEventArgs e)
        {
            SmartDate startTime = new SmartDate(DateTime.Today);
            SmartDate endTime = new SmartDate(DateTime.Now);

            PlainDivisionList divisions = PlainDivisionList.GetDivisionList(true);

            foreach (PlainDivisionListItem division in divisions)
            {
                LogInfo(String.Format("Calculating stoppage for division {0}", division.DivisionId));
                try
                {
                    StoppageDataCollection stoppageDataObjects = StoppageDataCollection.GetStoppageDataCollection(division.DivisionId, startTime, endTime);
                    stoppageDataObjects.Clear();
                    stoppageDataObjects.Save();

                    ExpandedProductionScheme productionScheme = ExpandedProductionScheme.GetExpandedProductionScheme(division.DivisionId, startTime, endTime);

                    foreach (ExpandedProductionSchemeItem schemeItem in productionScheme)
                    {
                        AddStoppageData(schemeItem);
                    }
                }
                catch (Exception ex)
                {
                    LogError(String.Format("Failed to calculate Stoppage data.\nDivision: {0}\nStart: {1}\nEnd: {2}\n\nErrorMessage:\n{3}", division.DivisionId, startTime.Date, endTime.Date, ex.Message));
                }
            }

            m_Timer.Interval = m_Interval;
        }

        static private void AddStoppageData(ExpandedProductionSchemeItem schemeItem)
        {
            //StoppageDataCollection stoppageDataObjects = StoppageDataCollection.NewStoppageDataCollection();

            //EventList.Criteria criteria = new EventList.Criteria();
            //criteria.StartDate = schemeItem.StartTime;
            //criteria.EndDate = schemeItem.EndTime;
            //criteria.D
            //EventList events = EventList.GetEventList(schemeItem.DivisionId, schemeItem.StartTime, schemeItem.EndTime);

            //StoppageData currentStoppageDataObject = null;

            //foreach (StateItemForOee state in states)
            //{
            //    switch (state.StateType)
            //    {
            //        case StateType.NoProduction:
            //            if (currentOeeDataObject != null)
            //            {
            //                if (currentOeeDataObject.MachineId == state.MachineId &&
            //                    currentOeeDataObject.ArticleNumber == state.ArticleNumber.Trim() &&
            //                    !state.TimeStampOnReset.IsEmpty)
            //                {
            //                    double noProductionTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
            //                    currentOeeDataObject.NoProductionTime += noProductionTime;
            //                }
            //            }
            //            break;
            //        case StateType.ArticleSwitch:
            //            currentOeeDataObject = oeeDataObjects.Add(schemeItem.DivisionId, state.MachineId, state.ArticleNumber.Trim(), schemeItem.Shift);
            //            currentOeeDataObject.StartTime = (schemeItem.StartTime.CompareTo(state.TimeStampOnSet) > 0) ? schemeItem.StartTime : state.TimeStampOnSet;
            //            currentOeeDataObject.EndTime = (state.TimeStampOnReset.IsEmpty || schemeItem.EndTime.CompareTo(state.TimeStampOnReset) < 0) ? schemeItem.EndTime : state.TimeStampOnReset;
            //            break;
            //        case StateType.Auto:
            //            if (currentOeeDataObject != null)
            //            {
            //                if (currentOeeDataObject.MachineId == state.MachineId &&
            //                    currentOeeDataObject.ArticleNumber == state.ArticleNumber.Trim() &&
            //                    !state.TimeStampOnReset.IsEmpty)
            //                {
            //                    double autoTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
            //                    currentOeeDataObject.AutoTime += autoTime;
            //                    currentOeeDataObject.ProducedItems += CalculateProducedItems(state.NumberOfItems, state.ElapsedTime, autoTime);
            //                }
            //            }
            //            break;
            //    }
            //}
            //oeeDataObjects.Save();
        }

        static private double CalculateElapsedTime(SmartDate stateStart, SmartDate stateEnd, SmartDate schemeStart, SmartDate schemeEnd)
        {
            SmartDate start = new SmartDate();
            SmartDate end = new SmartDate();

            if (schemeStart.CompareTo(stateStart) > 0)
                start = schemeStart;
            else
                start = stateStart;

            if (schemeEnd.CompareTo(stateEnd) > 0)
                end = stateEnd;
            else
                end = schemeEnd;

            TimeSpan elapsedTime = end.Subtract(start.Date);

            return elapsedTime.TotalSeconds;
        }

        static private int CalculateProducedItems(int stateProducedItems, double stateTime, double actualTime)
        {
            return ((int)Math.Round((double)stateProducedItems * actualTime / stateTime));
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

		//------------------------------------------------------------------------
		// read the item definitions from the XML file
		
		
	}
}
