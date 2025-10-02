using System;
using System.Linq;
using Csla;
using M2M.DataCenter;
using NLog;
using System.Collections.Generic;
using System.Globalization;

namespace M2M.Monitor.Library
{
	[Serializable]
	public class MonitorServer
	{
        private readonly System.Timers.Timer m_Timer = new System.Timers.Timer();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private int m_CurrentInterval = 5000;
        private DateTime m_LastOeeCalculation = DateTime.MinValue;

        public MonitorServer()
		{
			
		}

        public void RunOnce()
        {
            Execute(true);
        }

        public void Start()
		{

            try
            {
                m_CurrentInterval = M2MDataCenter.SystemSettings.MonitorRefreshInterval;
                m_Timer.Interval = m_CurrentInterval;
                logger.Trace("Interval: {0}", m_Timer.Interval);
                m_Timer.AutoReset = false;
                m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedTime);

                m_Timer.Start();

                logger.Info("Monitor service started");

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
            logger.Info("Monitor stopped");
		}

        private void OnElapsedTime(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                bool calculateOee = (DateTime.Now.Subtract(m_LastOeeCalculation).TotalMinutes > M2MDataCenter.SystemSettings.CalculateInterval);
                Execute(calculateOee);
                if (calculateOee)
                    m_LastOeeCalculation = DateTime.Now;

                M2MDataCenter.ReloadSystemSettings();
                m_CurrentInterval = M2MDataCenter.SystemSettings.MonitorRefreshInterval;
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

        private void Execute(bool calculateOee)
        {
            foreach(PlainDivisionListItem division in M2MDataCenter.GetDivisionList())
            {
                if(division.Settings.MonitorPace.HasValue)
                {
                    ExpandedProductionSchemeItem scheme = ExpandedProductionScheme.GetExpandedProductionScheme(division.DivisionId, new SmartDate(DateTime.Today), new SmartDate(DateTime.Now)).LastOrDefault();
                    if(scheme != null)
                    {
                        List<ExpandedProductionSchemeItem> schemeItems = ExpandedProductionScheme.GetExpandedProductionScheme(division.DivisionId, new SmartDate(DateTime.Today), new SmartDate(DateTime.Now)).OrderBy(s => s.StartTime).ToList();
                        List<ExpandedProductionSchemeItem> schemeItemsThisShift = new List<ExpandedProductionSchemeItem>();
                        foreach(ExpandedProductionSchemeItem schemeItem in schemeItems)
                        {
                            if (schemeItem.Shift == scheme.Shift)
                                schemeItemsThisShift.Add(schemeItem);


                            if (schemeItem.Shift != scheme.Shift)
                                schemeItemsThisShift.Clear();

                        }

                        CalculateMonitorData(division.DivisionId, scheme.Shift, schemeItemsThisShift, calculateOee);
                    }
                }
                
            }
        }

        private void CalculateMonitorData(string divisionId, int shift, List<ExpandedProductionSchemeItem> schemeItems, bool calculateOee)
        {
            MonitorData monitorData = MonitorHelper.GetData(divisionId);

            if(monitorData == null)
            {
                // force calculation if this is the first time we have data
                calculateOee = true;
                monitorData = new MonitorData();
            }

            logger.Trace("Calculate monitor data for {0}, shift: {1}, schemeItems: {2}, scheme start: {3}", divisionId, shift, schemeItems.Count, schemeItems[0].StartTime);
            try
            {
                PlainDivisionListItem division = M2MDataCenter.GetDivision(divisionId);

                List<PaceData> rawData = new List<PaceData>();

                foreach (ExpandedProductionSchemeItem schemeItem in schemeItems)
                {
                    foreach (PlainMachineListItem machine in M2MDataCenter.GetMachineList(schemeItem.DivisionId).Where(m => m.AggregateCounter == true))
                    {
                        rawData.AddRange(AddPaceData(schemeItem, machine.MachineId));
                    }
                }

                AggregatedOeeDataItem paceData = GetTotalData(rawData);

                //if (division.TotalProductionTime * 60 <= M2MDataCenter.SystemSettings.MonitorRefreshInterval)
                //    return;

                //monitorData.Pace = division.TotalAutoTimeForPerformance > 0 ? (division.PerformanceAsPace).ToString() : "-";
                //monitorData.PaceColor = division.TotalAutoTimeForPerformance > 0 ? GetColorForPace(division.Performance * 100, division.Settings.PaceUpperLimit, division.Settings.PaceLowerLimit) : "#000000";
                //monitorData.PaceIdeal = division.TotalAutoTimeForPerformance > 0 ? division.IdealPerformanceAsPace.ToString() : "-";

                monitorData.Pace = paceData.Produced > 0 ? ((int)paceData.Produced).ToString() : "-";
                monitorData.PaceColor = paceData.Produced > 0 ? GetColorForPace((decimal)paceData.Performance, division.Settings.PaceUpperLimit, division.Settings.PaceLowerLimit) : "#000000";
                monitorData.PaceIdeal = paceData.Produced > 0 ? paceData.IdealProducedItems.ToString() : "-";
                monitorData.PaceIdeal2 = paceData.Produced > 0 ? paceData.IdealProducedItems2.ToString() : "-";

                if (calculateOee)
                {
                    MachineList.Criteria criteria = new MachineList.Criteria();
                    criteria.DivisionId = divisionId;
                    criteria.StartDate = new SmartDate(DateTime.Today.AddDays(-3));
                    criteria.EndDate = new SmartDate(DateTime.Now);
                    criteria.Shift = shift;
                
                    DivisionListItem divisionData = DivisionListItem.GetDivisionListItem(criteria);

                    monitorData.Oee = Math.Round(divisionData.OEE * 100, 0).ToString("N0") + "%";

                    int changeOverCount = 0;
                    TimeSpan changeOverTime = new TimeSpan(0);
                    TimeSpan changeOverLatest = new TimeSpan(0);
                    DateTime startTime = DateTime.MinValue;

                    List<MonitorDetail> details = new List<MonitorDetail>();
                    foreach (MachineListItem machine in divisionData.Machines)
                    {
                        MonitorDetail detail = new MonitorDetail();
                        detail.MachineId = machine.MachineId;
                        detail.Value = machine.AvailabilityLossBasedOnActualStops < 1.0m ? (machine.AvailabilityLossBasedOnActualStops * 100.0m).ToString("N1", NumberFormatInfo.InvariantInfo) : "100";
                        detail.Color = GetColorForMachine(machine.AvailabilityLossBasedOnActualStops, divisionData.Machines.GetUpperLimit(divisionData.Settings.UpperLimitCount), divisionData.Machines.GetLowerLimit(divisionData.Settings.LowerLimitCount));
                        details.Add(detail);

                        ChangeOverList.Criteria cCritera = new ChangeOverList.Criteria();
                        cCritera.MachineId = machine.MachineId;
                        cCritera.StartTime = schemeItems[0].StartTime;
                        cCritera.EndTime = new SmartDate(DateTime.Now);
                        ChangeOverList changeOvers = ChangeOverList.GetChangeOverList(cCritera);
                        foreach (ChangeOverListItem changeOver in changeOvers)
                        {
                            if (changeOver.CountThis)
                            {
                                changeOverCount++;
                                changeOverTime += changeOver.ElapsedTime;
                                if (changeOver.StartTime.Date > startTime)
                                {
                                    changeOverLatest = changeOver.ElapsedTime;
                                    startTime = changeOver.StartTime.Date;
                                }
                                    
                            }
                        }
                    }

                    monitorData.ChangeOvers = changeOverCount.ToString();
                    monitorData.Latest = changeOverCount > 0 ? ((int)Math.Round(changeOverLatest.TotalMinutes, 0)).ToString() : "-";
                    monitorData.Average = changeOverCount > 0 ? ((int)Math.Round(changeOverTime.TotalMinutes / changeOverCount, 0)).ToString() : "-";
                    monitorData.Ideal = divisionData.Settings.ChangeOverIdeal.ToString();

                    monitorData.MonitorDetails = details;
                }

                if (MonitorHelper.AddData(divisionId, monitorData))
                {
                    logger.Trace("Data successfully saved");
                }
            }
            catch(Exception ex)
            {
                logger.ErrorException(string.Format("Failed to calculate monitor data for {0}", divisionId), ex);
            }
        }

        private string GetColorForMachine(Decimal actual, Decimal upperLimit, Decimal lowerLimit)
        {
            if (actual > upperLimit)
                return "#FF0000";

            if (actual > lowerLimit)
                return "#FFA500";

            return "#00FF00";
        }

        private string GetColorForPace(Decimal actual, Decimal upperLimit, Decimal lowerLimit)
        {
            if (actual > upperLimit)
                return "#32cd32";

            if (actual > lowerLimit)
                return "#f27825";

            return "#cd3232";
        }

        static private List<PaceData> AddPaceData(ExpandedProductionSchemeItem schemeItem, string machineId)
        {
            RealTimeValues realtimeValues = null;
            List<PaceData> oeeDataObjects = new List<PaceData>();

            //SmartDate currentTime = new SmartDate(DateTime.Now);

            StateListForOee states = StateListForOee.GetStateList(machineId, schemeItem.StartTime, schemeItem.EndTime);

            PaceData currentOeeDataObject = null;

            logger.Trace("{0} state items found for scheme part, start: {1}, end {2}", states.Count, schemeItem.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), schemeItem.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            realtimeValues = RealTimeValues.GetRealTimeValues(machineId);

            foreach (StateItemForOee state in states)
            {
                logger.Trace("State type: {0}, machine: {1}, article: {2}, start: {3}, end: {4}", state.StateType.ToString(), state.MachineId, state.ArticleNumber, state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), state.TimeStampOnReset.IsEmpty ? "null" : state.TimeStampOnReset.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                if (currentOeeDataObject != null)
                {
                    logger.Trace("CurrentOeeDataObject before processing. Machine: {0}, Article: {1}, NoProduction: {2}, Auto: {3}, Produced: {4}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.NoProductionTime, currentOeeDataObject.AutoTime, currentOeeDataObject.ProducedItems);
                }
                else
                {
                    logger.Trace("CurrentOeeDataObject before processing is null.");
                }

                switch (state.StateType)
                {
                    case StateType.NotConnected:
                    case StateType.NoProduction:
                        if (currentOeeDataObject != null)
                        {
                            double noProductionTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset.IsEmpty ? realtimeValues.LastChanged : state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                            currentOeeDataObject.NoProductionTime += noProductionTime;
                            if (currentOeeDataObject.ArticleNumber != state.ArticleNumber.Trim())
                                logger.Debug("Article mismatch. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        else
                        {
                            logger.Warn("State NoProduction not valid - ignoring. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        break;
                    case StateType.ArticleSwitch:
                        currentOeeDataObject = new PaceData();
                        currentOeeDataObject.DivisionId = schemeItem.DivisionId;
                        currentOeeDataObject.MachineId = machineId;
                        currentOeeDataObject.ArticleNumber = state.ArticleNumber.Trim();
                        currentOeeDataObject.Shift = schemeItem.Shift;
                        currentOeeDataObject.StartTime = (schemeItem.StartTime.CompareTo(state.TimeStampOnSet) > 0) ? schemeItem.StartTime : state.TimeStampOnSet;
                        currentOeeDataObject.EndTime = (state.TimeStampOnReset.IsEmpty || schemeItem.EndTime.CompareTo(state.TimeStampOnReset) < 0) ? schemeItem.EndTime : state.TimeStampOnReset;
                        logger.Trace("New oeedata item added. Count: {0}, start: {1}, end: {2}", oeeDataObjects.Count, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        oeeDataObjects.Add(currentOeeDataObject);
                        break;
                    case StateType.Auto:
                        if (currentOeeDataObject != null &&
                                currentOeeDataObject.MachineId == state.MachineId)
                        {
                            if (!state.TimeStampOnReset.IsEmpty)
                            {
                                double autoTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                                currentOeeDataObject.AutoTime += autoTime;

                                if (state.ElapsedTime > 0 && state.NumberOfItems > 0)
                                {
                                    currentOeeDataObject.ProducedItems += CalculateNumberOfItems(state.NumberOfItems, state.ElapsedTime, autoTime);
                                }
                            }
                            else
                            {
                                double autoTime = CalculateElapsedTime(state.TimeStampOnSet, realtimeValues.LastChanged, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                                if (autoTime > 0)
                                {
                                    //CurrentOeeDataObject before processing. Machine: B1BOut01, Article: , NoProduction: 0, Auto: 16716.71, Produced: 26529, Discarded 0 
                                    //AutoTime: 624.19, stateElapsedTime: 0 
                                    //CurrentCycles: 60839224, NumberOfitemsOnset: 60839224, Produced: 0, ProducedTotal: 26529  
                                    //CurrentRejectedCount: 8460, NumberOfRejectedOnSet: 0, Rejected: 8460, RejectedTotal: -2147483648  
                                    //CurrentOeeDataObject after processing. Machine: B1BOut01, Article: , NoProduction: 0, NotConnected: 24.473, Auto: 17340.9, Produced: 26529, Discarded -2147483648

                                    currentOeeDataObject.AutoTime += autoTime;
                                    double stateElapsedTime = realtimeValues.LastChanged.Subtract(state.TimeStampOnSet.Date).TotalSeconds;
                                    logger.Trace("AutoTime: {0}, stateElapsedTime: {1}", autoTime, stateElapsedTime);
                                    int producedItems = realtimeValues.CurrentCycleCount - state.NumberOfItemsOnSet;
                                    if (producedItems > 0)
                                    {
                                        currentOeeDataObject.ProducedItems += CalculateNumberOfItems(producedItems, stateElapsedTime, autoTime);
                                    }

                                    logger.Trace("CurrentCycles: {0}, NumberOfitemsOnset: {1}, Produced: {2}, ProducedTotal: {3} ", realtimeValues.CurrentCycleCount, state.NumberOfItemsOnSet, producedItems, currentOeeDataObject.ProducedItems);
                                }
                            }
                            if (currentOeeDataObject.ArticleNumber != state.ArticleNumber.Trim())
                                logger.Debug("Article mismatch. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        else
                        {
                            logger.Warn("State Auto not valid - ignoring. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        break;
                }

                if (currentOeeDataObject != null)
                {
                    logger.Trace("CurrentOeeDataObject after processing. Machine: {0}, Article: {1}, NoProduction: {2}, Auto: {3}, Produced: {4}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.NoProductionTime, currentOeeDataObject.AutoTime, currentOeeDataObject.ProducedItems);
                }
                else
                {
                    logger.Trace("CurrentOeeDataObject after processing is null.");
                }
            }
            return oeeDataObjects;
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

        static private int CalculateNumberOfItems(int stateProducedItems, double stateTime, double actualTime)
        {
            if (stateTime == 0)
                return 0;

            return ((int)Math.Round((double)stateProducedItems * actualTime / stateTime));
        }

        public AggregatedOeeDataItem GetTotalData(List<PaceData> rawData)
        {
            AggregatedOeeDataItem oeeData = new AggregatedOeeDataItem();

            double totalAutoTime = 0;
            double totalAutoTimeForPerformance = 0;
            double totalScheduledTime = 0;
            double totalNoProductionTime = 0;
            long totalProducedItems = 0;
            double totalProductionTime = 0;
   
            totalAutoTime += rawData.Where(a => a.AggregateAvailability).Sum(a => a.AutoTime);
            totalProductionTime += rawData.Where(a => a.AggregateAvailability).Sum(a => a.ProductionTime);
            totalAutoTimeForPerformance += rawData.Where(a => a.AggregatePerformance).Sum(a => a.AutoTime);
            totalScheduledTime += rawData.Where(a => a.AggregateAvailability).Sum(a => a.TotalTime);
            totalNoProductionTime += rawData.Where(a => a.AggregateAvailability).Sum(a => a.NoProductionTime);
            totalProducedItems += rawData.Where(a => a.AggregateCounter).Sum(a => (long)a.ProducedItems);

            oeeData.XType = XTypes.None;
            oeeData.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
            oeeData.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
            oeeData.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
            oeeData.Produced = totalProducedItems;
   
            if (totalProductionTime > 0)
            {
                oeeData.Availability = totalAutoTime / totalProductionTime;
            }

            if (totalAutoTimeForPerformance > 0)
            {
                oeeData.Performance = 0;

                foreach (var item in rawData)
                {
                    if (!item.AggregatePerformance)
                        continue;

                    double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

                    if (idealRunRate != null && item.RunRate != 0)
                    {
                        oeeData.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTimeForPerformance);
                    }
                }
            }

            return oeeData;
        }
 	}
}
