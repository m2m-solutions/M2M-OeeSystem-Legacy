using System;
using Csla;
using NLog;
using M2M.DataCenter;

namespace M2M.OeeCalculator.Library
{
	public class OeeCalculator
	{
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void CalculateAllOeeData(SmartDate startTime, SmartDate endTime)
		{
			PlainDivisionList divisions = PlainDivisionList.GetDivisionList();
            logger.Info("Calculate OEE for {0} divisions", divisions.Count);
            foreach (PlainDivisionListItem division in divisions)
            {
                logger.Trace("Calculating OEE for division {0} between {1} and {2}", division.DivisionId, startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                try
                {
                    CalculateOeeData(division.DivisionId, "", startTime, endTime);
                }
                catch (Exception ex)
                {
                    logger.ErrorException(String.Format("Failed to calculate OEE.\nDivision: {0}\nStart: {1}\nEnd: {2}\n", division.DivisionId, startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")), ex);
                }
            }
		}

		public static void CalculateOeeData(string divisionId, string machineId, SmartDate startTime, SmartDate endTime)
		{
            DeleteOeeData(divisionId, machineId, startTime, endTime);

            ExpandedProductionScheme productionScheme = ExpandedProductionScheme.GetExpandedProductionScheme(divisionId, startTime, endTime);
            logger.Trace("{0} scheme items found", productionScheme.Count);
            foreach (ExpandedProductionSchemeItem schemeItem in productionScheme)
            {
                if (machineId != "")
                {
                    AddOeeData(schemeItem, machineId);
                }
                else
                {
                    foreach (PlainMachineListItem machine in M2MDataCenter.GetMachineList(schemeItem.DivisionId))
                        AddOeeData(schemeItem, machine.MachineId);
                }
            }

		}

		private static void DeleteOeeData(string divisionId, string machineId, SmartDate startTime, SmartDate endTime)
		{
			OeeDataCollection ooeDataObjects = OeeDataCollection.GetOeeDataCollection(divisionId, machineId, startTime, endTime);
			ooeDataObjects.Clear();
			ooeDataObjects.Save();
		}

        static private void AddOeeData(ExpandedProductionSchemeItem schemeItem, string machineId)
        {
            RealTimeValues realtimeValues = null;
            OeeDataCollection oeeDataObjects = OeeDataCollection.NewOeeDataCollection();

            SmartDate currentTime = new SmartDate(DateTime.Now);

            StateListForOee states = StateListForOee.GetStateList(machineId, schemeItem.StartTime, schemeItem.EndTime);
            
            OeeData currentOeeDataObject = null;

            logger.Trace("{0} state items found for scheme part, start: {1}, end {2}", states.Count, schemeItem.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), schemeItem.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            realtimeValues = RealTimeValues.GetRealTimeValues(machineId);

            foreach (StateItemForOee state in states)
            {
                logger.Trace("State type: {0}, machine: {1}, article: {2}, start: {3}, end: {4}", state.StateType.ToString(), state.MachineId, state.ArticleNumber, state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), state.TimeStampOnReset.IsEmpty ? "null" : state.TimeStampOnReset.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                if (currentOeeDataObject != null)
                {
                    logger.Trace("CurrentOeeDataObject before processing. Machine: {0}, Article: {1}, NoProduction: {2}, Auto: {3}, Produced: {4}, Discarded {5}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.NoProductionTime, currentOeeDataObject.AutoTime, currentOeeDataObject.ProducedItems, currentOeeDataObject.DiscardedItems);
                }
                else
                {
                    logger.Trace("CurrentOeeDataObject before processing is null.");
                }

                switch (state.StateType)
                {
                    case StateType.NotConnected: 
                        if (currentOeeDataObject != null)
                        {
                            double notConnectedTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset.IsEmpty ? currentTime : state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                            currentOeeDataObject.NotConnectedTime += notConnectedTime;
                            if(currentOeeDataObject.ArticleNumber != state.ArticleNumber.Trim())
                                logger.Debug("Article mismatch. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        else
                        {
                            logger.Warn("State NotConnected not valid - ignoring. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        break;
                    case StateType.NoProduction:
                        if (currentOeeDataObject != null)
                        {
                            double noProductionTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset.IsEmpty ? currentTime : state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
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
                        currentOeeDataObject = oeeDataObjects.Add(schemeItem.DivisionId, state.MachineId, state.ArticleNumber.Trim(), schemeItem.Shift);
                        currentOeeDataObject.StartTime = (schemeItem.StartTime.CompareTo(state.TimeStampOnSet) > 0) ? schemeItem.StartTime : state.TimeStampOnSet;
                        currentOeeDataObject.EndTime = (state.TimeStampOnReset.IsEmpty || schemeItem.EndTime.CompareTo(state.TimeStampOnReset) < 0) ? schemeItem.EndTime : state.TimeStampOnReset;
                        logger.Trace("New oeedata item added. Count: {0}, start: {1}, end: {2}", oeeDataObjects.Count, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        break;
                    case StateType.FlowError:
                        if (currentOeeDataObject != null &&
                            currentOeeDataObject.MachineId == state.MachineId)
                        {
                            double flowErrorTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset.IsEmpty ? currentTime : state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                            currentOeeDataObject.FlowErrorTime += flowErrorTime;
                            if (currentOeeDataObject.ArticleNumber != state.ArticleNumber.Trim())
                                logger.Debug("Article mismatch. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        else
                        {
                            logger.Warn("State Flowerror not valid - ignoring. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        break;
                    case StateType.ChangeOver:
                        if (currentOeeDataObject != null &&
                            currentOeeDataObject.MachineId == state.MachineId)
                        {
                            double changeOverTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset.IsEmpty ? currentTime : state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                            currentOeeDataObject.ChangeOverTime += changeOverTime;
                            if (currentOeeDataObject.ArticleNumber != state.ArticleNumber.Trim())
                                logger.Debug("Article mismatch. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        else
                        {
                            logger.Warn("State Changeover not valid - ignoring. Machine: {0}, article: {1}, StateType: {2}, TimeStamp: {3}, currentDataObject: {4}", state.MachineId, state.ArticleNumber, state.StateType.ToString(), state.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), currentOeeDataObject != null ? String.Format("Machine: {0}, Article: {1}, Timestamp: {2}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) : "null");
                        }
                        break;
                    case StateType.Auto:
                        if (currentOeeDataObject != null &&
                                currentOeeDataObject.MachineId == state.MachineId)
                        {
                            if (!state.TimeStampOnReset.IsEmpty)
                            {
                                double autoTime = CalculateElapsedTime(state.TimeStampOnSet, state.TimeStampOnReset, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                                currentOeeDataObject.AutoTime += autoTime;
                                logger.Trace("AutoTime: {0}, stateElapsedTime: {1} (has endtime)", autoTime, state.ElapsedTime);
                                if (state.ElapsedTime > 0 && state.NumberOfItems > 0)
                                {
                                    currentOeeDataObject.ProducedItems += CalculateNumberOfItems(state.NumberOfItems, state.ElapsedTime, autoTime);
                                }
                               
                                if (state.ElapsedTime > 0 && state.NumberOfRejected != 0)
                                {
                                    currentOeeDataObject.DiscardedItems += CalculateNumberOfItems(state.NumberOfRejected, state.ElapsedTime, autoTime);
                                }
                            }
                            else
                            {
                                double autoTime = CalculateElapsedTime(state.TimeStampOnSet, currentTime, currentOeeDataObject.StartTime, currentOeeDataObject.EndTime);
                                if (autoTime > 0)
                                {
                                    //CurrentOeeDataObject before processing. Machine: B1BOut01, Article: , NoProduction: 0, Auto: 16716.71, Produced: 26529, Discarded 0 
                                    //AutoTime: 624.19, stateElapsedTime: 0 
                                    //CurrentCycles: 60839224, NumberOfitemsOnset: 60839224, Produced: 0, ProducedTotal: 26529  
                                    //CurrentRejectedCount: 8460, NumberOfRejectedOnSet: 0, Rejected: 8460, RejectedTotal: -2147483648  
                                    //CurrentOeeDataObject after processing. Machine: B1BOut01, Article: , NoProduction: 0, NotConnected: 24.473, Auto: 17340.9, Produced: 26529, Discarded -2147483648
                                    
                                    currentOeeDataObject.AutoTime += autoTime;
                                    double stateElapsedTime = realtimeValues.LastChanged.Subtract(state.TimeStampOnSet.Date).TotalSeconds;
                                    logger.Trace("AutoTime: {0}, stateElapsedTime: {1} (no endtime)", autoTime, stateElapsedTime);
                                    int producedItems = realtimeValues.CurrentCycleCount - state.NumberOfItemsOnSet;
                                    if (producedItems > 0)
                                    {
                                        currentOeeDataObject.ProducedItems += CalculateNumberOfItems(producedItems, stateElapsedTime, autoTime);
                                    }

                                    logger.Trace("CurrentCycles: {0}, NumberOfitemsOnset: {1}, Produced: {2}, ProducedTotal: {3} ", realtimeValues.CurrentCycleCount, state.NumberOfItemsOnSet, producedItems, currentOeeDataObject.ProducedItems);
                                    
                                    int rejectedItems = realtimeValues.CurrentRejectedCount - state.NumberOfRejectedOnSet;
                                    if (rejectedItems != 0)
                                    {
                                        currentOeeDataObject.DiscardedItems  += CalculateNumberOfItems(rejectedItems, stateElapsedTime, autoTime);
                                    }

                                    logger.Trace("CurrentRejectedCount: {0}, NumberOfRejectedOnSet: {1}, Rejected: {2}, RejectedTotal: {3} ", realtimeValues.CurrentRejectedCount, state.NumberOfRejectedOnSet, rejectedItems, currentOeeDataObject.DiscardedItems);
                                    
                                }
                            }
                            if (currentOeeDataObject.ArticleNumber!= state.ArticleNumber.Trim())
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
                    logger.Trace("CurrentOeeDataObject after processing. Machine: {0}, Article: {1}, NoProduction: {2}, NotConnected: {3}, Auto: {4}, Produced: {5}, Discarded {6}", currentOeeDataObject.MachineId, currentOeeDataObject.ArticleNumber, currentOeeDataObject.NoProductionTime, currentOeeDataObject.NotConnectedTime, currentOeeDataObject.AutoTime, currentOeeDataObject.ProducedItems, currentOeeDataObject.DiscardedItems);
                }
                else
                {
                    logger.Trace("CurrentOeeDataObject after processing is null.");
                }
            }
            oeeDataObjects.Save();
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
	}
}
