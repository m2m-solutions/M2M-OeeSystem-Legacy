using System;
using System.Linq;
using Csla;
using NLog;
using M2M.DataCenter;

namespace M2M.StoppageCalculator.Library
{
    public class StoppageCalculator
	{
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void CalculateAllStoppageData(SmartDate startTime, SmartDate endTime)
		{
			PlainDivisionList divisions = PlainDivisionList.GetDivisionList();
            logger.Info("Calculate stoppage data for {0} divisions", divisions.Count);
            foreach (PlainDivisionListItem division in divisions)
            {
                
                    try
                    {
                        CalculateStoppageData(division.DivisionId, "", startTime, endTime);
                    }
                    catch (Exception ex)
                    {
                        logger.ErrorException(String.Format("Failed to calculate stoppage data.\nDivision: {0}\nStart: {1}\nEnd: {2}\n", division.DivisionId, startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")), ex);
                    }
            }
		}

        public static void CalculateStoppageData(string divisionId, string machineId, SmartDate startTime, SmartDate endTime)
		{
            DeleteStoppageData(divisionId, machineId, startTime, endTime);

            StoppageDataCollection stoppageDataObjects = StoppageDataCollection.NewStoppageDataCollection();

            if(machineId != "")
                logger.Trace("Calculating stoppage data for machine {0} between {1} and {2}", machineId, startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            else
                logger.Trace("Calculating stoppage data for division {0} between {1} and {2}", divisionId, startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            StoppageList.Criteria stoppageCriteria = new StoppageList.Criteria();
            stoppageCriteria.DivisionId = divisionId;
            stoppageCriteria.MachineId = machineId;
            stoppageCriteria.StartTime = startTime;
            stoppageCriteria.EndTime = endTime;
            stoppageCriteria.Categories = M2MDataCenter.GetAvailableCategories();

            StoppageList stoppages = StoppageList.GetStoppageList(stoppageCriteria);
            logger.Trace("Total number of stoppages found: {0}", stoppages.Count());
            var grouped = stoppages.GroupBy(a => new { a.MachineId, a.ArticleNumber, a.Shift, a.DisplayName });

            foreach (var group in grouped)
            {
                StoppageData stoppage = StoppageData.NewStoppageDataRoot();
                stoppage.GroupingId = M2MDataCenter.GetDivision(divisionId).GroupingId;
                stoppage.ArticleNumber = group.First().ArticleNumber;
                stoppage.CategoryId = group.First().CategoryId;
                stoppage.DivisionId = divisionId;
                stoppage.ElapsedTime = group.Sum(a => a.ElapsedTime.TotalSeconds);
                stoppage.MachineId = group.First().MachineId;
                stoppage.NumberOfStops = group.Count();
                stoppage.Shift = group.First().Shift;
                stoppage.SystemError = group.First().TagType >= TagType.CommunicationError;
                stoppage.StopDate = startTime;
                stoppage.StopReason = group.First().DisplayName;
                stoppage.StopRatio = group.Sum(a => a.StopRatio);
                logger.Trace("StoppageData: {0}, {1}, {2} stops, elapsed time {3}, ratio {4}", stoppage.MachineId, stoppage.StopReason, stoppage.NumberOfStops, stoppage.ElapsedTime, stoppage.StopRatio);    
                stoppageDataObjects.Add(stoppage);
            }
           
            stoppageDataObjects.Save();
		}

        private static void DeleteStoppageData(string divisionId, string machineId, SmartDate startTime, SmartDate endTime)
		{
            StoppageDataCollection stoppageDataObjects = StoppageDataCollection.GetStoppageDataCollection(divisionId, machineId, startTime, endTime);
            stoppageDataObjects.Clear();
            stoppageDataObjects.Save();
		}
	}
}
