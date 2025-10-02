using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class ExpandedProductionScheme : ReadOnlyListBase<ExpandedProductionScheme, ExpandedProductionSchemeItem>
	{
		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static ExpandedProductionScheme GetExpandedProductionScheme(string divisionId, SmartDate startTime, SmartDate endTime)
		{
			return DataPortal.Fetch<ExpandedProductionScheme>(new Criteria(divisionId, startTime, endTime));
		}

		private ExpandedProductionScheme()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
            private readonly string m_DivisionId;
            private readonly SmartDate m_StartTime;
            private readonly SmartDate m_EndTime;
		
			public Criteria(string divisionId, SmartDate startTime, SmartDate endTime)
			{
				m_DivisionId = divisionId;
				m_StartTime = startTime;
				m_EndTime = endTime;
			}

			public string DivisionId
			{
				get { return m_DivisionId; }
			}

			public SmartDate StartTime
			{
				get { return m_StartTime; }
			}

			public SmartDate EndTime
			{
				get { return m_EndTime; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT p.Id,p.DivisionId,p.MachineId,p.Shift,dbo.MaxDateValue(ISNULL(o.StartDate,p.StartTime),@RangeStart) as StartTime,dbo.MinDateValue(ISNULL(o.EndDate,p.EndTime), @RangeEnd) as EndTime" +
                                          @" FROM ProductionScheme p" +
                                          @" OUTER APPLY dbo.ExpandRecurrence(p.RecurrenceRule,@RangeStart,@RangeEnd) AS o" +
                                          @" WHERE p.DivisionId= @DivisionId" +
                                          @" AND (((p.RecurrenceRule = '' OR p.RecurrenceRule IS NULL) AND p.StartTime < @RangeEnd AND p.EndTime > @RangeStart)" +
                                          @" OR ((p.RecurrenceRule <> '' OR p.RecurrenceRule IS NOT NULL) AND o.StartDate < @RangeEnd AND o.EndDate > @RangeStart))" +
                                          @" ORDER BY StartTime ASC, (CASE WHEN EndTime IS NULL THEN 1 ELSE 0 END), EndTime ASC";

                    command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);
                    command.Parameters.AddWithValue(@"@RangeStart", criteria.StartTime.DBValue);
                    command.Parameters.AddWithValue(@"@RangeEnd", criteria.EndTime.DBValue);

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            Add(ExpandedProductionSchemeItem.GetExpandedProductionSchemeItem(dr));
                        }
                    }
                }

                //using (SqlCommand command = connection.CreateCommand())
                //{
                //    command.CommandType = CommandType.Text;
                //    command.CommandText = @"SELECT Id,DivisionId,MachineId,Shift,StartTime,EndTime,RecurrenceRule,RecurrenceParentId" +
                //                          @" FROM ProductionScheme" +
                //                          @" WHERE DivisionId= @DivisionId" +
                //                          @" ORDER BY StartTime ASC";

                //    command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);
                    
                //    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                //    {
                //        while (dr.Read())
                //        {
                //            string recurrenceRule = dr.GetString("RecurrenceRule");
                //            if (recurrenceRule != "")
                //            {
                //                List<OccurrenceInfo> occurrencies = (List<OccurrenceInfo>)SchedulerManager.ExpandRecurrence(recurrenceRule, criteria.StartTime.Date, criteria.EndTime.Date, true);
                //                foreach (OccurrenceInfo occ in occurrencies)
                //                {
                //                    if (occ.Start < criteria.EndTime.Date && occ.End > criteria.StartTime.Date)
                //                        Add(ExpandedProductionSchemeItem.GetExpandedProductionSchemeItem(dr.GetGuid("Id"), dr.GetInt32("Shift"), new SmartDate(occ.Start), new SmartDate(occ.End), dr.GetString("DivisionId"), dr.GetString("MachineId")));
                //                }
                //            }
                //            else if (dr.GetSmartDate("StartTime") < criteria.EndTime && dr.GetSmartDate("EndTime") > criteria.StartTime)
                //            {
                //                Add(ExpandedProductionSchemeItem.GetExpandedProductionSchemeItem(dr.GetGuid("Id"), dr.GetInt32("Shift"), dr.GetSmartDate("StartTime"), dr.GetSmartDate("EndTime"), dr.GetString("DivisionId"), dr.GetString("MachineId")));
                //            }
                //            //Add(ExpandedProductionSchemeItem.GetExpandedProductionSchemeItem(dr));
                //        }
                //    }
                //}
			}

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		#endregion
	}
}

