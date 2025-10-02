using System;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class MachineListItem : ReadOnlyBase<MachineListItem>
	{
		#region Business Methods 
		private string m_MachineId = String.Empty;
		private string m_DisplayName = String.Empty;
		private string m_Notes = String.Empty;
		private string m_DivisionId = String.Empty;
		
		private MachineSettingList m_Settings = null;
		private ArticleList m_Articles = null;
		private OeeDataList m_OeeData = null;
		
		private Decimal m_Availability = 0;
		private Decimal m_Performance = 0;
		private Decimal m_Quality = 1;

        private Decimal m_AvailabilityLossBasedOnActualStops = 0;
        private Decimal m_AvailabilityLossBasedOnFlowErrors = 0;

		public string MachineId
		{
			get
			{
				return m_MachineId;
			}
		}

		public string DisplayName
		{
			get
			{
				return m_DisplayName;
			}
		}

		public string Notes
		{
			get
			{
				return m_Notes;
			}
		}

		public string DivisionId
		{
			get
			{
				return m_DivisionId;
			}
		}

		public int? IdealRunRate
		{
			get
			{
				if (m_Settings == null)
					return null;

				return (int?)m_Settings.IdealRunRate.Value;
			}
		}

		public RunRateUnit RunRateUnit
		{
			get
			{
				if (m_Settings == null)
					return RunRateUnit.CycleTimeInMilliSeconds;

				return m_Settings.RunRateUnit;
			}
		}

		public double? CycleTimeInMilliSeconds
		{
			get
			{
				if (m_Settings == null || !m_Settings.IdealRunRate.HasValue)
					return null;

				int idealRunRate = (int)m_Settings.IdealRunRate.Value;
				RunRateUnit unit = m_Settings.RunRateUnit;

				double cycleTimeInMilliSeconds;

				switch (unit)
				{
					case RunRateUnit.CyclesPerHour:
						cycleTimeInMilliSeconds = 60.0 * 60.0 * 1000.0 / (double)idealRunRate;
						break;
					case RunRateUnit.CyclesPerMinute:
						cycleTimeInMilliSeconds = 60.0 * 1000.0 / (double)idealRunRate;
						break;
					case RunRateUnit.CycleTimeInMilliSeconds:
					default:
						cycleTimeInMilliSeconds = idealRunRate;
						break;

				}
				return (double?)cycleTimeInMilliSeconds;
			}
		}

		public double? GetIdealCycleTime(string articleNumber)
		{
			double? idealCycleTime = CycleTimeInMilliSeconds;

			ArticleListItem article = m_Articles.GetItem(articleNumber);

			if (article != null && article.CycleTimeInMilliSeconds != null)
				idealCycleTime = article.CycleTimeInMilliSeconds;

			return idealCycleTime;
		}

        public bool AggregateCounter
        {
            get
            {
                if (m_Settings == null)
                    return true;

                return m_Settings.AggregateCounter;
            }
        }


        public bool AggregateAvailability
        {
            get
            {
                if (m_Settings == null)
                    return true;

                return m_Settings.AggregateAvailability;
            }
        }

        public bool AggregatePerformance
        {
            get
            {
                if (m_Settings == null)
                    return true;

                return m_Settings.AggregatePerformance;
            }
        }

        public bool AllowNegativeScrap
        {
            get
            {
                if (m_Settings == null)
                    return false;

                return m_Settings.AllowNegativeScrap;
            }
        }

        public int AllowedCycleDiff
        {
            get
            {
                if (m_Settings == null)
                    return 5;

                return m_Settings.AllowedCycleDiff;
            }
        }

        public int MinValidAutoTime
        {
            get
            {
                if (m_Settings == null)
                    return 0;

                return m_Settings.MinValidAutoTime;
            }
        }

		public MomentUnit MomentUnit
        {
            get
            {
                if (m_Settings == null)
                    return MomentUnit.Cycles;

                return m_Settings.MomentUnit;
            }
        }

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
                if (TotalProductionTime <= 0)
                    return -1;

                return  (double)ProducedItems / TotalProductionTime * 3600.0;
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

		public double TotalTime
		{
			get
			{
				if (m_OeeData == null)
					return 0;

				return m_OeeData.TotalTime;
			}
		}

        public double TotalProductionTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalProductionTime;
            }
        }

        public double TotalNoProductionTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalNoProductionTime;
            }
        }

        public double TotaNotConnectedTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalNotConnectedTime;
            }
        }

		public double TotalAutoTime
		{
			get
			{
				if (m_OeeData == null)
					return 0;

				return m_OeeData.TotalAutoTime;
			}
		}

		public double TotalStopTime
		{
			get
			{
				if (m_OeeData == null)
					return 0;

				return m_OeeData.TotalStopTime;
			}
		}

        public double TotalFlowErrorTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalFlowErrorTime;
            }
        }

        public double TotalChangeOverTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalChangeOverTime;
            }
        }

        public double TotalActualStopTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalActualStopTime;
            }
        }

		public int ProducedItems
		{
			get
			{
				if (m_OeeData == null)
					return 0;

				return m_OeeData.ProducedItems;
			}
		}

        public int IdealProducedItems
        {
            get
            {
                if (m_OeeData == null || m_Performance <= 0)
                    return 0;

                return (int)Math.Round(m_OeeData.ProducedItems/m_Performance, 0);
            }
        }

        public int IdealProducedItems2
        {
            get
            {
                if (m_OeeData == null || m_Performance <= 0 || m_Availability <= 0)
                    return 0;

                return (int)Math.Round(m_OeeData.ProducedItems / (m_Availability * m_Performance), 0);
            }
        }

		public int DiscardedItems
		{
			get
			{
				if (m_OeeData == null)
					return 0;

				return m_OeeData.DiscardedItems;
			}
		}

        


		public MachineSettingList Settings
		{
			get
			{
				return m_Settings;
			}
		}

		public OeeDataList OeeData
		{
			get
			{
				return m_OeeData;
			}
		}


		protected override object GetIdValue()
		{
			return m_MachineId;
		}

		internal void CalculateAvailability()
		{
			double totalTime = TotalProductionTime;

			if (totalTime > 0)
				m_Availability = Convert.ToDecimal(TotalAutoTime / totalTime);
		}

        internal void CalculateAvailabilityLossBasedOnActualStops()
        {
            double totalTime = TotalProductionTime;

            if (totalTime > 0)
                m_AvailabilityLossBasedOnActualStops = Convert.ToDecimal(TotalActualStopTime / totalTime);
        }

        internal void CalculateAvailabilityLossBasedOnFlowErrors()
        {
            double totalTime = TotalProductionTime;

            if (totalTime > 0)
                m_AvailabilityLossBasedOnFlowErrors = Convert.ToDecimal(TotalFlowErrorTime / totalTime);
        }

		internal void CalculatePerformance()
		{
			double totalAutoTime = TotalAutoTime;
			if (totalAutoTime > 0)
			{
				double performance = 0;

				foreach (OeeDataListItem item in m_OeeData)
				{
					double? idealRunRate = M2MDataCenter.GetIdealCycleTime(m_DivisionId, m_MachineId, item.ArticleNumber.Trim());

					if (idealRunRate != null && item.RunRate != 0)
					{
						performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTime);
					}
				}

				m_Performance = Convert.ToDecimal(performance);
			}
		}

		internal void CalculateQuality()
		{
			if (ProducedItems > 0)
				m_Quality = Convert.ToDecimal((double)(ProducedItems - DiscardedItems) / (double)ProducedItems);
		}

		#endregion
	
		#region Factory Methods

		internal static MachineListItem GetMachineListItem(SafeDataReader dr)
		{
			return new MachineListItem(dr, null);
		}

		internal static MachineListItem GetMachineListItem(SafeDataReader dr, OeeDataList.Criteria criteria)
		{
			return new MachineListItem(dr, criteria);
		}

		public static MachineListItem GetMachineListItem(OeeDataList.Criteria criteria)
		{
			return DataPortal.Fetch<MachineListItem>(criteria);
		}

		protected MachineListItem(): base()
		{
			/* require use of factory methods */
		}

		protected MachineListItem(SafeDataReader dr, OeeDataList.Criteria criteria)
		{
			Fetch(dr, criteria);
		}

		#endregion
	
		#region Data Access

		private void DataPortal_Fetch(OeeDataList.Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT MachineId,DisplayName,Notes,DivisionId" +
                                          @" FROM Machines" +
                                          @" WHERE MachineId=@MachineId";


					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if (dataReader.Read())
						{
							m_MachineId = dataReader.GetString("MachineId");
							m_DisplayName = dataReader.GetString("DisplayName");
							m_Notes = dataReader.GetString("Notes");
							m_DivisionId = dataReader.GetString("DivisionId");
						}
					}
				}
			}

			m_Settings = MachineSettingList.GetMachineSettingList(m_MachineId);
			m_Articles = ArticleList.GetArticleList(m_MachineId);
			m_OeeData = OeeDataList.GetOeeDataList(criteria);

			CalculateAvailability();
            CalculateAvailabilityLossBasedOnActualStops();
            CalculateAvailabilityLossBasedOnFlowErrors();
			CalculatePerformance();
			CalculateQuality();
		}

		private void Fetch(SafeDataReader dataReader, OeeDataList.Criteria criteria)
		{	
			m_MachineId = dataReader.GetString("MachineId");
			m_DisplayName = dataReader.GetString("DisplayName");
			m_Notes = dataReader.GetString("Notes");
			m_DivisionId = dataReader.GetString("DivisionId");

			if (criteria != null)
			{
				m_Settings = MachineSettingList.GetMachineSettingList(m_MachineId);
				m_Articles = ArticleList.GetArticleList(m_MachineId);
				m_OeeData = OeeDataList.GetOeeDataList(criteria);

				CalculateAvailability();
                CalculateAvailabilityLossBasedOnActualStops();
                CalculateAvailabilityLossBasedOnFlowErrors();
				CalculatePerformance();
				CalculateQuality();
			}
		}

		#endregion
	
	}
}