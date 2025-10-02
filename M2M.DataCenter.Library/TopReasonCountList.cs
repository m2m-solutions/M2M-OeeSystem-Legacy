using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Threading;

using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class TopReasonCountList : ReadOnlyListBase<TopReasonCountList, TopReasonCountListItem>
	{
		#region Business methods

		public int MaxValue
		{
			get 
			{
				int maxValue = 0;

				foreach (TopReasonCountListItem item in this)
				{
					if ((item.NumberOfStops > maxValue))
					{
						maxValue = item.NumberOfStops;
					}
				}
				return maxValue;
			}
		}

		public int TotalNumberOfStops
		{
			get
			{
				int stops = 0;

				foreach (TopReasonCountListItem item in this)
				{
					stops += item.NumberOfStops;
				}

				return stops;
			}
		}

		#endregion

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory methods

		public static TopReasonCountList GetTopReasonCountList(Criteria criteria)
		{
			return DataPortal.Fetch<TopReasonCountList>(criteria);
		}

		protected TopReasonCountList()
		{ }

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
            private string m_DivisionId = null;
			private string m_MachineId = null;
			private string m_ArticleNumber = null;
			private SmartDate m_StartDate = new SmartDate();
			private SmartDate m_EndDate = new SmartDate();
			private ShiftType m_Shift = ShiftType.NotDefined;
			private List<int> m_Categories = new List<int>(); 

			public Criteria()
			{
			}

            public string DivisionId
            {
                get { return m_DivisionId; }
                set { m_DivisionId = value; }
            }

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
			}

			public SmartDate StartDate
			{
				get { return m_StartDate; }
				set { m_StartDate = value; }
			}

			public SmartDate EndDate
			{
				get { return m_EndDate; }
				set { m_EndDate = value; }
			}

			public ShiftType Shift
			{
				get { return m_Shift; }
				set { m_Shift = value; }
			}

			public List<int> Categories
            {
                get { return m_Categories; }
                set { m_Categories = value; }
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
                    string reasonSource = "t.DisplayName";
                    string extendedWhereClause = "";
                    //TODO: Add support for reason codes, obsolete?
                    //
                    //if (M2MDataCenter.GetReasonCodeList().Count > 0)
                    //{
                    //    reasonSource = "e.ReasonCode";
                    //    extendedWhereClause = " AND e.ReasonCode<>98";
                    //}

                    if (criteria.Categories.Count > 0 && criteria.Categories.Count == M2MDataCenter.GetAvailableCategories().Count)
                    {
                        if (extendedWhereClause != "")
                            extendedWhereClause += " AND (";

                        string innerInnerClause = "";

                        foreach (int categoryId in criteria.Categories)
                        {
                            if (innerInnerClause != "")
                                innerInnerClause += " OR ";

                            innerInnerClause += "t.CategoryId=@CategoryId" + categoryId.ToString();
                            command.Parameters.AddWithValue("@CategoryId" + categoryId.ToString(), categoryId);
                        }
                        innerInnerClause += "))";
                        extendedWhereClause += innerInnerClause;
                    }

					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT t.TagId,COUNT(t.TagId) as NumberOfStops," +
                                          reasonSource + @" as Reason" +
	                                      @" FROM Events e JOIN TagInfo t ON e.TagId=t.TagId" +
	                                      @" WHERE e.MachineId=COALESCE(@MachineId,e.MachineId)" +
	                                      @" AND e.ArticleNumber=COALESCE(@ArticleNumber,e.ArticleNumber)" +
	                                      @" AND e.EventRaised <= COALESCE(@EndDate,e.EventRaised)" +
                                          @" AND (e.EventAcknowledged IS NULL OR e.EventAcknowledged >= COALESCE(@StartDate,e.EventAcknowledged))" +
                                          @" AND (t.TagType=@TagType4 OR t.TagType=@TagType5)" +
                                          extendedWhereClause +
	                                      @" GROUP BY t.TagId," + reasonSource +
	                                      @" ORDER BY NumberOfStops DESC";

                  	if(!String.IsNullOrEmpty(criteria.ArticleNumber))
                        command.Parameters.AddWithValue("@ArticleNumber", criteria.ArticleNumber);
                    else
                        command.Parameters.AddWithValue("@ArticleNumber", DBNull.Value);
                    if (!String.IsNullOrEmpty(criteria.MachineId))
                        command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
                    else
                        command.Parameters.AddWithValue("@MachineId", DBNull.Value);
					command.Parameters.AddWithValue("@StartDate", criteria.StartDate.DBValue);
					command.Parameters.AddWithValue("@EndDate", criteria.EndDate.DBValue);
                    command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
                    command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);

					using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					{
                        int remainingStopCount = 0;

                        while (dr.Read())
                        {
                            TopReasonCountListItem item = new TopReasonCountListItem(dr);

                            if (item.NumberOfStops > 0)
                            {
                                if (this.Items.Count < 5)
                                    this.Add(item);
                                else
                                    remainingStopCount += item.NumberOfStops;
                            }
                        }

                        if (remainingStopCount > 0)
                        {
                            this.Add(new TopReasonCountListItem("", "Övriga", remainingStopCount));
                        }
					}
				}
			}

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		#endregion
	}
}
