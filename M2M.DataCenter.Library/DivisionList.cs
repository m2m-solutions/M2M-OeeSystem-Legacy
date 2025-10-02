using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class DivisionList : ReadOnlyListBase<DivisionList, DivisionListItem>
	{
		#region Business Methods

		private Decimal m_Availability = 0;
		private Decimal m_Performance = 0;
		private Decimal m_Quality = 1;

        private Decimal m_AvailabilityLossBasedOnActualStops = 0;
        private Decimal m_AvailabilityLossBasedOnFlowErrors = 0;
		
		public Decimal Availability
		{
			get
			{
				return m_Availability;
			}
		}

		public string AvailabilityAsString
		{
			get
			{
                string format = Availability == 1.0m ? "p0" : "p2";

                return Availability.ToString(format, NumberFormatInfo.InvariantInfo);
			}
		}

        public Decimal AvailabilityLoss
        {
            get
            {
                return m_AvailabilityLossBasedOnActualStops + m_AvailabilityLossBasedOnFlowErrors;
            }
        }

        public string AvailabilityLossAsString
        {
            get
            {
                string format = AvailabilityLoss == 1.0m ? "p0" : "p2";

                return AvailabilityLoss.ToString(format, NumberFormatInfo.InvariantInfo);
            }
        }

        public string AvailabilityLossExtendedAsString
        {
            get
            {
                return String.Format("({0} = {1} + {2})", AvailabilityLossAsString, AvailabilityLossBasedOnActualStopsAsString, AvailabilityLossBasedOnFlowErrorsAsString);
            }
        }

        public Decimal AvailabilityLossBasedOnActualStops
        {
            get
            {
                return m_AvailabilityLossBasedOnActualStops;
            }
        }

        public string AvailabilityLossBasedOnActualStopsAsString
        {
            get
            {
                string format = AvailabilityLossBasedOnActualStops == 1.0m ? "p0" : "p2";

                return AvailabilityLossBasedOnActualStops.ToString(format, NumberFormatInfo.InvariantInfo);
            }
        }

        public Decimal AvailabilityLossBasedOnFlowErrors
        {
            get
            {
                return m_AvailabilityLossBasedOnFlowErrors;
            }
        }

        public string AvailabilityLossBasedOnFlowErrorsAsString
        {
            get
            {
                string format = AvailabilityLossBasedOnFlowErrors == 1.0m ? "p0" : "p2";

                return AvailabilityLossBasedOnFlowErrors.ToString(format, NumberFormatInfo.InvariantInfo);
            }
        }

		public Decimal Performance
		{
			get
			{
				return m_Performance;
			}
		}

		public string PerformanceAsString
		{
			get
			{
                string format = Performance == 1.0m ? "p0" : "p2";

                return Performance.ToString(format, NumberFormatInfo.InvariantInfo);
			}
		}

		public Decimal Quality
		{
			get
			{
				return m_Quality;
			}
		}

		public string QualityAsString
		{
			get
			{
                string format = Quality == 1.0m ? "p0" : "p2";

                return Quality.ToString(format, NumberFormatInfo.InvariantInfo);
			}
		}

		public Decimal OEE
		{
			get
			{
				return m_Availability * m_Performance * m_Quality;
			}
		}

		public string OEEAsString
		{
			get
			{
                string format = OEE == 1.0m ? "p0" : "p2";

                return OEE.ToString(format, NumberFormatInfo.InvariantInfo);
			}
		}

        public double Pace
        {
            get
            {
                if (this.Sum(a => a.TotalProductionTimeSpecial) <= 0)
                    return -1;

                return (double)this.Sum(a => (long)a.ProducedItems) / this.Sum(a => a.TotalProductionTimeSpecial) * 3600.0;
            }
        }

        public string PaceAsString
        {
            get
            {
                if (Pace < 0)
                    return "-";

                return ((int)Math.Round(Pace)).ToString();
            }
        }

		public void CalculateAvailability()
		{
            double totalTime = this.Sum(a => a.TotalProductionTime);

			if (totalTime > 0)
			{
                m_Availability = Convert.ToDecimal(this.Sum(a => a.TotalAutoTimeForAvailability) / totalTime);
			}
		}

        internal void CalculateAvailabilityBasedOnActualStops()
        {
            double totalTime = this.Sum(a => a.TotalProductionTime);

            if (totalTime > 0)
                m_AvailabilityLossBasedOnActualStops = Convert.ToDecimal(this.Sum(a => a.TotalActualStopTime) / totalTime);
        }

        internal void CalculateAvailabilityBasedOnFlowErrors()
        {
            double totalTime = this.Sum(a => a.TotalProductionTime);

            if (totalTime > 0)
                m_AvailabilityLossBasedOnFlowErrors = Convert.ToDecimal(this.Sum(a => a.TotalFlowErrorTime) / totalTime);
        }

		public void CalculatePerformance()
		{
            double totalAutoTime = this.Sum(a => a.TotalAutoTimeForPerformance);

			if (totalAutoTime > 0)
			{
				foreach (DivisionListItem division in this.Items)
				{
					m_Performance += division.Performance * Convert.ToDecimal(division.TotalAutoTimeForPerformance);
				}

				m_Performance = m_Performance / Convert.ToDecimal(totalAutoTime);
			}
		}

		private void CalculateQuality()
		{
            long producedItems = this.Sum(a => (long)a.ProducedItems);

            if (producedItems > 0)
                m_Quality = Convert.ToDecimal((double)(producedItems - this.Sum(a => (long)a.DiscardedItems)) / (double)producedItems);
		}

		#endregion
		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static DivisionList GetDivisionList(bool advancedFilter)
        {
            return DataPortal.Fetch<DivisionList>(new Criteria(advancedFilter));
		}

		public static DivisionList GetDivisionList(Criteria criteria)
		{
			return DataPortal.Fetch<DivisionList>(criteria);
		}

		protected DivisionList()
		{
			/* require use of factory methods */
		}
		
		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private SmartDate m_StartDate = new SmartDate();
			private SmartDate m_EndDate = new SmartDate();
			private string m_ArticleNumber = null;
			private int m_Shift = -1;
            private readonly bool m_AdvancedFilter = true;
            private int m_GroupingId = 0;

			public Criteria()
			{

			}

			public Criteria(bool advancedFilter)
            {
                m_AdvancedFilter = advancedFilter;
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

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public int Shift
			{
				get { return m_Shift; }
				set { m_Shift = value; }
			}

			public bool AdvancedFilter
			{
				get { return m_AdvancedFilter; }
			}

			public int GroupingId
            {
                get { return m_GroupingId; }
                set { m_GroupingId = value; }
            }
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
            RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionStringWithMultipleActiveResultSets))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
                    command.CommandType = CommandType.Text;

                    string whereClause = "";

                    if (criteria.GroupingId > 0)
                    {
                        whereClause = " WHERE GroupingId=@GroupingId";
                        command.Parameters.AddWithValue("@GroupingId", criteria.GroupingId);
                    }
		
					
                    command.CommandText = @"SELECT DivisionId,DisplayName,GroupingId,Notes" +
                                          @" FROM Divisions" + whereClause +
                                          @" ORDER BY DivisionId ASC";

                    
					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							if (M2MDataCenter.User.CanAccessDivision(dataReader.GetString("DivisionId")))
							{
								if (criteria.AdvancedFilter)
								{
									MachineList.Criteria oeeDataCriteria = new MachineList.Criteria();
									oeeDataCriteria.DivisionId = dataReader.GetString("DivisionId");
									oeeDataCriteria.ArticleNumber = criteria.ArticleNumber;
									oeeDataCriteria.StartDate = criteria.StartDate;
									oeeDataCriteria.EndDate = criteria.EndDate;
									oeeDataCriteria.Shift = criteria.Shift;
									oeeDataCriteria.Connection = connection;

									Add(DivisionListItem.GetDivisionListItem(dataReader, oeeDataCriteria));

								}
								else
								{
									Add(DivisionListItem.GetDivisionListItem(dataReader));
								}
							}
						}
					}

					if (criteria.AdvancedFilter)
					{
						CalculateAvailability();
                        CalculateAvailabilityBasedOnActualStops();
                        CalculateAvailabilityBasedOnFlowErrors();
						CalculatePerformance();
						CalculateQuality();
					}
				}
			}

			IsReadOnly = true;	
			RaiseListChangedEvents = true;
		}
		#endregion
	}
}