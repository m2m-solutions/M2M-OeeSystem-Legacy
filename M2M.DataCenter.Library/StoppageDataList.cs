using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using Csla.Data;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    
    public class AggregatedStoppageDataListItem
    {
        public string DivisionId { get; set; }
        public string MachineId { get; set; }
        public string Category { get; set; }
        public string Reason { get; set; }
        public int NumberOfStops { get; set; }
        public double StopRatio { get; set; }
        public double WeightedNumberOfStops { get; set; }
        public double WeightedStopRatio { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public double TimePart { get; set; }
        public int Index { get; set; }
        public DateTime XDate { get; set; }
        public double MaxValue { get; set; }
        
        public double ElapsedTimeInSeconds { get { return ElapsedTime.TotalSeconds; } }
        public double ElapsedTimeInMinutes { get { return ElapsedTime.TotalMinutes; } }
        public double ElapsedTimeInHours { get { return ElapsedTime.TotalHours; } }
        public double AverageTimeInSeconds { get { return ElapsedTime.TotalSeconds / NumberOfStops; } }
        public double AverageTimeInMinutes { get { return ElapsedTime.TotalMinutes / NumberOfStops; } }

        public string ReasonAbbr { get { return this.Reason.SafeSubstring(M2MDataCenter.SystemSettings.StoppageGraphLegendMax, true); } }
        public string ReasonAbbrForList { get { return this.Reason.SafeSubstring(M2MDataCenter.SystemSettings.StoppageListReasonMax, true); } }
        public string ReasonWithDivisionPrefix { get { return BuildReasonString(true, false);  } }
        public string ReasonWithMachinePrefix { get { return BuildReasonString(false, true); } }
        public string ReasonWithFullPrefix { get { return BuildReasonString(true, true); } }

        public double AverageTimeBetweenStops { get; set; }
       
        public string AverageTimeBetweenStopsString
        {
            get
            {
                if (NumberOfStops < 10)
                    return "-";

                return String.Format("{0:N1} {1}", AverageTimeBetweenStops, ResourceStrings.GetString("#-Hours.Abbr"));
            }
        }

        public string Division
        {
            get
            {
                PlainDivisionListItem division = M2MDataCenter.GetDivision(DivisionId);
                if (division == null)
                    return "";
                return division.DisplayName;
            }
        }

        public string DivisionAbbreviated
        {
            get
            {
                PlainDivisionListItem division = M2MDataCenter.GetDivision(DivisionId);
                if (division == null)
                    return "";
                return division.ShortName;
            }
        }

        public string MachineAbbreviated
        {
            get
            {
                PlainMachineListItem machine = M2MDataCenter.GetMachine(DivisionId, MachineId);
                if (machine == null)
                    return "";
                return machine.ShortName;
            }
        }

        private string BuildReasonString(bool showDivision, bool showMachine)
        {
            if(!showDivision && !showMachine || Reason == ResourceStrings.GetString("Other"))
                return ReasonAbbr;

            string reason = "";

            if (showDivision)
                reason += DivisionAbbreviated + ":";

            if (showMachine)
                reason += MachineAbbreviated + ":";

            int length = M2MDataCenter.SystemSettings.StoppageGraphLegendMax - reason.Length;

            return reason + Reason.SafeSubstring(length, true);
        }

        public string Machine
        {
            get
            {
                PlainMachineListItem machine = M2MDataCenter.GetMachine(DivisionId, MachineId);
                if (machine == null)
                    return "";
                return machine.DisplayName;
            }
        }

        public int Week
        {
            get
            {
                return this.XDate.GetWeek();
            }
        }

        public string WeekAsString
        {
            get
            {
                return String.Format("{0}.{1}", ResourceStrings.GetString("#-Week.Abbr"), this.Week);
            }
        }
    }

    

	[Serializable()]
	public class StoppageDataList : ReadOnlyListBase<StoppageDataList, StoppageDataListItem>
	{
        private Criteria m_CurrentCriteria = null;

		#region Business Methods

        public int TotalCount
        {
            get
            {
                return this.Sum(a => a.NumberOfStops);
            }
        }

        public double TotalRatio
        {
            get
            {
                return this.Sum(a => a.StopRatio);
            }
        }

        public double TotalTime
        {
            get
            {
                return this.Sum(a => a.ElapsedTime);
            }
        }

        public AggregatedStoppageDataListItem GetTotalSums()
        {
            AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
            stoppage.DivisionId = "";
            stoppage.MachineId = "";
            stoppage.Reason = "";
            stoppage.Category = "";
            stoppage.NumberOfStops = this.TotalCount;
            stoppage.StopRatio = this.TotalRatio;
            stoppage.ElapsedTime = TimeSpan.FromSeconds(this.TotalTime);
            stoppage.TimePart = 1.0;
            stoppage.Index = 0;
            return stoppage;
        }

        public AggregatedStoppageDataListItem GetMachineSums(string machineId)
        {
            AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
            stoppage.DivisionId = M2MDataCenter.GetMachine(machineId).DivisionId;
            stoppage.MachineId = machineId;
            stoppage.Reason = "";
            stoppage.Category = "";
            stoppage.NumberOfStops = this.Where(a => a.MachineId == machineId).Sum( b => b.NumberOfStops );
            stoppage.StopRatio = this.Where(a => a.MachineId == machineId).Sum(b => b.StopRatio);
            stoppage.ElapsedTime = TimeSpan.FromSeconds(this.Where(a => a.MachineId == machineId).Sum(b => b.ElapsedTime));
            stoppage.TimePart = 1.0;
            stoppage.Index = 0;
            return stoppage;
        }

        public AggregatedStoppageDataListItem GetDivisionSums(string divisionId)
        {
            AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
            stoppage.DivisionId = divisionId;
            stoppage.MachineId = "";
            stoppage.Reason = "";
            stoppage.Category = "";
            stoppage.NumberOfStops = this.Where(a => a.DivisionId == divisionId).Sum(b => b.NumberOfStops);
            stoppage.StopRatio = this.Where(a => a.DivisionId == divisionId).Sum(b => b.StopRatio);
            stoppage.ElapsedTime = TimeSpan.FromSeconds(this.Where(a => a.DivisionId == divisionId).Sum(b => b.ElapsedTime));
            stoppage.TimePart = 1.0;
            stoppage.Index = 0;
            return stoppage;
        }

        public List<AggregatedStoppageDataListItem> GetTopCount()
        {
            return GetTopCount(0, false);
        }

		public List<AggregatedStoppageDataListItem> GetTopCount(int groupCount, bool showOther)
        {
            var grouped = this.GroupBy(a => new { a.DivisionId, a.MachineId, a.StopReason }).OrderByDescending(b => b.Sum(c => c.NumberOfStops));
            List<AggregatedStoppageDataListItem> stoppages = new List<AggregatedStoppageDataListItem>();
            var temp = groupCount > 0 ? grouped.Take(groupCount) : grouped;
            foreach (var item in temp)
            {
               AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                stoppage.DivisionId = item.Key.DivisionId;
                stoppage.MachineId = item.Key.MachineId;
                stoppage.Reason = item.Key.StopReason;
                stoppage.Category = M2MDataCenter.GetCategoryDisplayName(item.First().CategoryId);
                stoppage.NumberOfStops = item.Sum(a => a.NumberOfStops);
                stoppage.StopRatio = item.Sum(a => a.StopRatio);
                stoppage.ElapsedTime = TimeSpan.FromSeconds(item.Sum(a => a.ElapsedTime));
                stoppage.TimePart = stoppage.ElapsedTimeInSeconds / this.TotalTime;
                stoppage.Index = stoppages.Count;
                stoppages.Add(stoppage);
            }

            if (showOther && groupCount > 0)
            {
                temp = grouped.Skip(groupCount);
                if (temp.Count() > 0)
                {
                    AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                    stoppage.DivisionId = "";
                    stoppage.MachineId = "";
                    stoppage.Reason = ResourceStrings.GetString("Other");
                    stoppage.NumberOfStops = temp.Sum(a => a.Sum(b => b.NumberOfStops));
                    stoppage.StopRatio = temp.Sum(a => a.Sum(b => b.StopRatio));
                    stoppage.ElapsedTime = TimeSpan.FromSeconds(temp.Sum(a => a.Sum(b => b.ElapsedTime)));
                    stoppage.TimePart = stoppage.ElapsedTimeInSeconds / this.TotalTime;
                    stoppage.Index = stoppages.Count;
                    stoppages.Add(stoppage);
                }
            }

            return stoppages;
        }

        public List<AggregatedStoppageDataListItem> GetTopCount(string divisionId, int groupCount, bool showOther)
        {
            var grouped = this.Where( a => a.DivisionId == divisionId).GroupBy(a => new { a.MachineId, a.StopReason }).OrderByDescending(b => b.Sum(c => c.NumberOfStops));
            List<AggregatedStoppageDataListItem> stoppages = new List<AggregatedStoppageDataListItem>();
            var temp = groupCount > 0 ? grouped.Take(groupCount) : grouped;
            double totalTime = this.Where(a => a.DivisionId == divisionId).Sum(a => a.ElapsedTime);
            foreach (var item in temp)
            {
                AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                stoppage.DivisionId = divisionId;
                stoppage.MachineId = item.Key.MachineId;
                stoppage.Reason = item.Key.StopReason;
                stoppage.Category = M2MDataCenter.GetCategoryDisplayName(item.First().CategoryId);
                stoppage.NumberOfStops = item.Sum(a => a.NumberOfStops);
                stoppage.StopRatio = item.Sum(a => a.StopRatio);
                stoppage.ElapsedTime = TimeSpan.FromSeconds(item.Sum(a => a.ElapsedTime));
                stoppage.TimePart = stoppage.ElapsedTimeInSeconds / totalTime;
                stoppage.Index = stoppages.Count;
                stoppages.Add(stoppage);
            }

            if (showOther && groupCount > 0)
            {
                temp = grouped.Skip(groupCount);
                if (temp.Count() > 0)
                {
                    AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                    stoppage.DivisionId = "";
                    stoppage.MachineId = "";
                    stoppage.Reason = ResourceStrings.GetString("Other");
                    stoppage.NumberOfStops = temp.Sum(a => a.Sum(b => b.NumberOfStops));
                    stoppage.StopRatio = temp.Sum(a => a.Sum(b => b.StopRatio));
                    stoppage.ElapsedTime = TimeSpan.FromSeconds(temp.Sum(a => a.Sum(b => b.ElapsedTime)));
                    stoppage.TimePart = stoppage.ElapsedTimeInSeconds / totalTime;
                    stoppage.Index = stoppages.Count;
                    stoppages.Add(stoppage);
                }
            }

            return stoppages;
        }

        public List<AggregatedStoppageDataListItem> GetTopTimes()
        {
            return GetTopTimes(0, false);
        }

        public List<AggregatedStoppageDataListItem> GetTopTimes(int groupCount, bool showOther, double totalScheduledTime)
        {
            List<AggregatedStoppageDataListItem> list = GetTopTimes(groupCount, showOther);
            return list.Select(c => { c.AverageTimeBetweenStops = totalScheduledTime / c.NumberOfStops; return c; }).ToList();
        }

        public List<AggregatedStoppageDataListItem> GetTopTimes(int groupCount, bool showOther)
        {
            var grouped = this.GroupBy(a => new { a.DivisionId, a.MachineId, a.StopReason }).OrderByDescending(b => b.Sum(c => c.ElapsedTime));
            List<AggregatedStoppageDataListItem> stoppages = new List<AggregatedStoppageDataListItem>();
            var temp = groupCount > 0 ? grouped.Take(groupCount) : grouped;
            foreach (var item in temp)
            {
                AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                stoppage.DivisionId = item.Key.DivisionId;
                stoppage.MachineId = item.Key.MachineId;
                stoppage.Reason = item.Key.StopReason;
                stoppage.Category = M2MDataCenter.GetCategoryDisplayName(item.First().CategoryId);
                stoppage.NumberOfStops = item.Sum(a => a.NumberOfStops);
                stoppage.StopRatio = item.Sum(a => a.StopRatio);
                stoppage.ElapsedTime = TimeSpan.FromSeconds(item.Sum(a => a.ElapsedTime));
                stoppage.TimePart = stoppage.ElapsedTimeInSeconds / this.TotalTime;
                stoppage.Index = stoppages.Count;
                stoppages.Add(stoppage);
            }

            if (showOther && groupCount > 0)
            {
                temp = grouped.Skip(groupCount);
                if (temp.Count() > 0)
                {
                    AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                    stoppage.DivisionId = "";
                    stoppage.MachineId = "";
                    stoppage.Reason = ResourceStrings.GetString("Other");
                    stoppage.NumberOfStops = temp.Sum(a => a.Sum(b => b.NumberOfStops));
                    stoppage.StopRatio = temp.Sum(a => a.Sum(b => b.StopRatio));
                    stoppage.ElapsedTime = TimeSpan.FromSeconds(temp.Sum(a => a.Sum(b => b.ElapsedTime)));
                    stoppage.TimePart = stoppage.ElapsedTimeInSeconds / this.TotalTime;
                    stoppage.Index = stoppages.Count;
                    stoppages.Add(stoppage);
                }
            }

            return stoppages;
        }

        public List<AggregatedStoppageDataListItem> GetTopTimes(string divisionId, int groupCount, bool showOther)
        {
            var grouped = this.Where(a => a.DivisionId == divisionId).GroupBy(a => new { a.MachineId, a.StopReason }).OrderByDescending(b => b.Sum(c => c.ElapsedTime));
            List<AggregatedStoppageDataListItem> stoppages = new List<AggregatedStoppageDataListItem>();
            var temp = groupCount > 0 ? grouped.Take(groupCount) : grouped;
            double totalTime = this.Where(a => a.DivisionId == divisionId).Sum(a => a.ElapsedTime);
            foreach (var item in temp)
            {
                AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                stoppage.DivisionId = divisionId;
                stoppage.MachineId = item.Key.MachineId;
                stoppage.Reason = item.Key.StopReason;
                stoppage.Category = M2MDataCenter.GetCategoryDisplayName(item.First().CategoryId);
                stoppage.NumberOfStops = item.Sum(a => a.NumberOfStops);
                stoppage.StopRatio = item.Sum(a => a.StopRatio);
                stoppage.ElapsedTime = TimeSpan.FromSeconds(item.Sum(a => a.ElapsedTime));
                stoppage.TimePart = stoppage.ElapsedTimeInSeconds / totalTime;
                stoppage.Index = stoppages.Count;
                stoppages.Add(stoppage);
            }

            if (showOther && groupCount > 0)
            {
                temp = grouped.Skip(groupCount);
                if (temp.Count() > 0)
                {
                    AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                    stoppage.DivisionId = "";
                    stoppage.MachineId = "";
                    stoppage.Reason = ResourceStrings.GetString("Other");
                    stoppage.NumberOfStops = temp.Sum(a => a.Sum(b => b.NumberOfStops));
                    stoppage.StopRatio = temp.Sum(a => a.Sum(b => b.StopRatio));
                    stoppage.ElapsedTime = TimeSpan.FromSeconds(temp.Sum(a => a.Sum(b => b.ElapsedTime)));
                    stoppage.TimePart = stoppage.ElapsedTimeInSeconds / totalTime;
                    stoppage.Index = stoppages.Count;
                    stoppages.Add(stoppage);
                }
            }

            return stoppages;
        }

        public List<AggregatedStoppageDataListItem> GetPeriodicStops(Intervals interval)
        {
            List<AggregatedStoppageDataListItem> stoppages = new List<AggregatedStoppageDataListItem>();

            if (interval < Intervals.Daily || interval > Intervals.Monthly)
                return stoppages;

            bool hasStops = false;

            DateTime currentDate = m_CurrentCriteria.StartTime.Date;

            while (currentDate < m_CurrentCriteria.EndTime.Date)
            {
                DateTime currentStopDate = new DateTime();

                switch (interval)
                {
                    case Intervals.Daily:
                        currentStopDate = currentDate.AddDays(1);
                        break;
                    case Intervals.Weekly:
                        currentStopDate = currentDate.AddDays(7);
                        break;
                    case Intervals.Monthly:
                        currentStopDate = currentDate.AddMonths(1);
                        break;
                }

                var groupedStops = this.Where(d => d.StopDate >= currentDate).Where(a => a.StopDate < currentStopDate).ToList();

                AggregatedStoppageDataListItem stoppage = new AggregatedStoppageDataListItem();
                stoppage.DivisionId = m_CurrentCriteria.DivisionId;
                stoppage.MachineId = m_CurrentCriteria.MachineId;
                stoppage.Category = M2MDataCenter.GetCategoryDisplayName(m_CurrentCriteria.Categories[0]);
                stoppage.NumberOfStops = groupedStops.Sum(a => a.NumberOfStops);
                stoppage.StopRatio = groupedStops.Sum(a => a.StopRatio);
                stoppage.ElapsedTime = TimeSpan.FromSeconds(groupedStops.Sum(a => a.ElapsedTime));
                stoppage.XDate = currentDate;
                stoppage.Index = stoppages.Count;
                stoppages.Add(stoppage);

                hasStops = hasStops || stoppage.NumberOfStops > 0;
                currentDate = currentStopDate;
            }

            if (!hasStops)
                return null;

            return stoppages;
        }

        #endregion
		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static StoppageDataList GetStoppageDataList(Criteria criteria)
		{
			return DataPortal.Fetch<StoppageDataList>(criteria);
		}

		private StoppageDataList()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
            private int m_GroupingId = 0;
			private string m_DivisionId = null;
			private string m_MachineId = null;
			private int m_Shift = -1;
			private string m_ArticleNumber = null;
			private SmartDate m_StartTime = new SmartDate(new DateTime(2000, 1, 1));
			private SmartDate m_EndTime = new SmartDate(DateTime.Today);
            private List<int> m_Categories = new List<int>();
            private string m_StopReason = null;
            private bool? m_SystemError = null;
			private SqlConnection m_Connection = null;
	
			public Criteria()
			{
			}

            public int GroupingId
            {
                get { return m_GroupingId; }
                set { m_GroupingId = value; }
            }

			public string DivisionId
			{
				get { return m_DivisionId; }
				set { m_DivisionId = value; }
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
			}

			public int Shift
			{
				get { return m_Shift; }
				set { m_Shift = value; }
			}

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public SmartDate StartTime
			{
				get { return m_StartTime; }
				set { m_StartTime = value; }
			}

			public SmartDate EndTime
			{
				get { return m_EndTime; }
				set { m_EndTime = value; }
			}

            public List<int> Categories
            {
                get { return m_Categories; }
                set { m_Categories = value; }
            }

            public string StopReason
            {
                get { return m_StopReason; }
                set { m_StopReason = value; }
            }

            public bool? SystemError
            {
                get { return m_SystemError; }
                set { m_SystemError = value; }
            }

            public bool ShowAll
			{
				get
				{
                    return (m_Categories.Count == M2MDataCenter.GetAvailableCategories().Count);
        		}
			}

            public bool ShowNone
            {
                get
                {
                    return (m_Categories.Count == 0 && M2MDataCenter.GetAvailableCategories().Count > 0);
                }
            }
			
			public SqlConnection SqlConnection
			{
				get { return m_Connection; }
				set { m_Connection = value; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

            if (!criteria.ShowNone)
            {


                if (criteria.SqlConnection != null)
                    Fetch(criteria.SqlConnection, criteria);
                else
                {
                    using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
                    {
                        connection.Open();

                        Fetch(connection, criteria);
                    }
                }
            }

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		private void Fetch(SqlConnection connection, Criteria criteria)
		{
            m_CurrentCriteria = criteria;
            using (SqlCommand command = connection.CreateCommand())
			{
				string whereClause = "";
                string innerClause = "";

                if (criteria.GroupingId > 0)
                {
                    if (whereClause != "")
                        whereClause += " AND ";

                    M2MDataCenter.GetDivisionList(criteria.GroupingId);
                    whereClause += "GroupingId=@GroupingId";
                    command.Parameters.AddWithValue(@"@GroupingId", criteria.GroupingId);
                }

				if (!String.IsNullOrEmpty(criteria.DivisionId))
                {
                    if (whereClause != "")
                        whereClause += " AND ";

                    if (criteria.DivisionId.Contains(","))
                    {
                        var divisions = criteria.DivisionId.Split(',');
                        var parameters = new string[divisions.Length];
                        for (int i = 0; i < divisions.Length; i++)
                        {
                            parameters[i] = string.Format("@DivisionId{0}", i);
                            command.Parameters.AddWithValue(parameters[i], divisions[i]);
                        }
                        whereClause += string.Format("DivisionId IN ({0})", string.Join(",",parameters));
                       //command.AddArrayParameters(new int[] { (int)TagType.Stop, (int)TagType.MainAlarm, (int)TagType.UnidentifiedStop }, "TagType");
                    }
                    else
                    {
                        whereClause += "DivisionId=@DivisionId";
                        command.Parameters.AddWithValue("@DivisionId", criteria.DivisionId);
                    }
                }

                if (!String.IsNullOrEmpty(criteria.MachineId))
				{
					if (whereClause != "")
						whereClause += " AND ";

					whereClause += "MachineId=@MachineId";
					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);
				}

				if (!String.IsNullOrEmpty(criteria.ArticleNumber))
				{
					if (whereClause != "")
						whereClause += " AND ";

					whereClause += "ArticleNumber=@ArticleNumber";
					command.Parameters.AddWithValue(@"@ArticleNumber", criteria.ArticleNumber);
				}

				if (criteria.Shift >= 0)
				{
					if (whereClause != "")
						whereClause += " AND ";

					whereClause += "Shift=@Shift";
					command.Parameters.AddWithValue(@"@Shift", criteria.Shift);
				}

                if (!String.IsNullOrEmpty(criteria.StopReason))
                {
                    if (whereClause != "")
                        whereClause += " AND ";

                    whereClause += "StopReason=@StopReason";
                    command.Parameters.AddWithValue(@"@StopReason", criteria.StopReason);
                }

                if (criteria.SystemError.HasValue)
                {
                    if (whereClause != "")
                        whereClause += " AND ";

                    whereClause += "SystemError=@SystemError";
                    command.Parameters.AddWithValue(@"@SystemError", criteria.SystemError.Value);
                }

                if (!criteria.ShowAll)
                {
                    if (whereClause != "")
                        whereClause += " AND ";
                        
                    whereClause += "(";
                    foreach (int categoryId in criteria.Categories)
                    {
                        if (innerClause != "")
                            innerClause += " OR ";

                            innerClause += "Category=@Category" + categoryId.ToString();
                            command.Parameters.AddWithValue("@Category" + categoryId.ToString(), categoryId);
                     }
                    whereClause += innerClause + ")";
                }
  
                if (!criteria.StartTime.IsEmpty)
                {
                    if (whereClause != "")
                        whereClause += " AND ";

                    whereClause += "StopDate>=@StartTime";
                    command.Parameters.AddWithValue("@StartTime", criteria.StartTime.DBValue);
                }

                if (!criteria.EndTime.IsEmpty)
                {
                    if (whereClause != "")
                        whereClause += " AND ";

                    whereClause += "StopDate<@EndTime";
                    command.Parameters.AddWithValue("@EndTime", criteria.EndTime.DBValue);
                }



                if (whereClause != "")
                            whereClause = " WHERE " + whereClause;

				
				command.CommandType = CommandType.Text;
				command.CommandText = @"SELECT " +
										@"StoppageDataId," +
										@"DivisionId," +
										@"MachineId," +
                                        @"GroupingId," +
										@"Shift," +
										@"ArticleNumber," +
                                        @"StopDate," +
                                        @"ElapsedTime," +
                                        @"NumberOfStops," +
                                        @"StopRatio," +
                                        @"Category," +
                                        @"SystemError," +
                                        @"StopReason" +
                                        @" FROM StoppageData WITH (NOLOCK)" +
										whereClause;

                using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
				{
					while (dr.Read())
					{
						Add(StoppageDataListItem.GetStoppageDataListItem(dr));
					}
				}
			}
		}

		#endregion
	}
}

