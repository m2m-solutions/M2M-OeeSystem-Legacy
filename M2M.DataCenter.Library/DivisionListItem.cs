using System;
using System.Linq;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class DivisionListItem : ReadOnlyBase<DivisionListItem>
	{
		#region Business Methods 
		private string m_DivisionId = String.Empty;
		private string m_DisplayName = String.Empty;
		private string m_Notes = String.Empty;
		private Decimal m_Availability = 0;
        private Decimal m_AvailabilityLossBasedOnActualStops = 0;
        private Decimal m_AvailabilityLossBasedOnFlowErrors = 0;
		private Decimal m_Performance = 0;
		private Decimal m_Quality = 1;
        private int m_GroupingId = 0;

        private DivisionSettingList m_Settings = null;
		private MachineList m_Machines = null;

        public string DivisionId { get { return m_DivisionId; } }
		public string DisplayName { get { return m_DisplayName; } }
        public int GroupingId { get { return m_GroupingId; } }
		public string Notes { get { return m_Notes; } }

        public double TotalAutoTimeForAvailability { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateAvailability == true).Sum(a => a.TotalAutoTime) : 0; } }
        public double TotalAutoTimeForPerformance { get { return m_Machines != null ? m_Machines.Where(a => a.AggregatePerformance == true).Sum(a => a.TotalAutoTime) : 0; } }
        public double TotalTime { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateAvailability == true).Sum(a => a.TotalTime) : 0; } }
        public double TotalProductionTime { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateAvailability == true).Sum(a => a.TotalProductionTime) : 0; } }
        public double TotalFlowErrorTime { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateAvailability == true).Sum(a => a.TotalFlowErrorTime) : 0; } }
        public double TotalChangeOverTime { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateAvailability == true).Sum(a => a.TotalChangeOverTime) : 0; } }
        public double TotalActualStopTime { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateAvailability == true).Sum(a => a.TotalActualStopTime) : 0; } }
        public long ProducedItems { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateCounter == true).Sum(a => (long)a.ProducedItems) : 0; } }
        public long IdealProducedItems { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateCounter == true).Sum(a => (long)a.IdealProducedItems) : 0; } }
        public long IdealProducedItems2 { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateCounter == true).Sum(a => (long)a.IdealProducedItems2) : 0; } }
        public double TotalProductionTimeSpecial { get { return m_Machines != null ? m_Machines.Where(a => a.AggregateCounter == true).Sum(a => a.TotalProductionTime) : 0; } } 
        public long DiscardedItems { get { return m_Machines != null ? m_Machines.Sum(a => (long)a.DiscardedItems) : 0; } }
		
		public Decimal Availability { get { return m_Availability; } }
		public string AvailabilityAsString 
        { 
            get 
            {
                string format = Availability == 1.0m ? "p0" : "p2";
                return Availability.ToString(format, NumberFormatInfo.InvariantInfo); 
            } 
        }
        public Decimal AvailabilityLoss { get { return m_AvailabilityLossBasedOnActualStops + m_AvailabilityLossBasedOnFlowErrors; } }
        public string AvailabilityLossAsString 
        { 
            get 
            {
                string format = AvailabilityLoss == 1.0m ? "p0" : "p2";
                return AvailabilityLoss.ToString(format, NumberFormatInfo.InvariantInfo); 
            } 
        }
        public string AvailabilityLossExtendedAsString { get { return String.Format("({0} = {1} + {2})", AvailabilityLossAsString, AvailabilityLossBasedOnActualStopsAsString, AvailabilityLossBasedOnFlowErrorsAsString); } }
        public Decimal AvailabilityLossBasedOnActualStops { get { return m_AvailabilityLossBasedOnActualStops; } }
        public string AvailabilityLossBasedOnActualStopsAsString 
        { 
            get 
            {
                string format = AvailabilityLossBasedOnActualStops == 1.0m ? "p0" : "p2";
                return AvailabilityLossBasedOnActualStops.ToString(format, NumberFormatInfo.InvariantInfo); 
            } 
        }
        public Decimal AvailabilityLossBasedOnFlowErrors { get { return m_AvailabilityLossBasedOnFlowErrors; } }
        public string AvailabilityLossBasedOnFlowErrorsAsString 
        { 
            get 
            {
                string format = AvailabilityLossBasedOnFlowErrors == 1.0m ? "p0" : "p2";
                return AvailabilityLossBasedOnFlowErrors.ToString(format, NumberFormatInfo.InvariantInfo); 
            } 
        }
        public Decimal Performance { get { return m_Performance; } }
        public string PerformanceAsString 
        { 
            get 
            {
                string format = Performance == 1.0m ? "p0" : "p2";
                return Performance.ToString(format, NumberFormatInfo.InvariantInfo); 
            } 
        }
        public Decimal Quality { get { return m_Quality; } }
        public string QualityAsString 
        { 
            get 
            {
                string format = Quality == 1.0m ? "p0" : "p2";
                return Quality.ToString(format, NumberFormatInfo.InvariantInfo);
            } 
        }
        public Decimal OEE { get { return m_Availability * m_Performance * m_Quality; } }
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
                if (TotalProductionTimeSpecial <= 0)
                    return -1.0;

                return (double)ProducedItems / TotalProductionTimeSpecial * 3600.0;
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

        public int PerformanceAsPace
        {
            get
            {
                if (TotalAutoTimeForPerformance <= 0)
                    return 0;

                return (int)Math.Round((double)ProducedItems / TotalAutoTimeForPerformance * 3600.0, 0);
            }
        }

        public int IdealPerformanceAsPace
        {
            get
            {
                if (TotalAutoTimeForPerformance <= 0)
                    return 0;

                return (int)Math.Round((double)IdealProducedItems / TotalAutoTimeForPerformance * 3600.0, 0);
            }
        }

		public MachineList Machines { get { return m_Machines; } set { m_Machines = value; } }

        public DivisionSettingList Settings
        {
            get
            {
                return m_Settings;
            }
        }

		private void CalculateAvailability()
        {
            double totalTime = TotalProductionTime;

            if (totalTime > 0)
                m_Availability = Convert.ToDecimal(TotalAutoTimeForAvailability / totalTime);
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

		private void CalculatePerformance()
        {
            double totAutoTime = TotalAutoTimeForPerformance;

            if (totAutoTime > 0)
            {
                foreach (MachineListItem machine in m_Machines.Where( a => a.AggregatePerformance == true))
                {
                    if (machine.TotalAutoTime > 0)
                    {
                        m_Performance += machine.Performance * Convert.ToDecimal(machine.TotalAutoTime) / Convert.ToDecimal(totAutoTime);
                    }
                }
            }
        }

        private void CalculateQuality()
        {
            long producedItems = ProducedItems;

            if (producedItems > 0)
                m_Quality = Convert.ToDecimal((double)(producedItems - DiscardedItems) / (double)producedItems);
        }

		protected override object GetIdValue()
		{
			return m_DivisionId;
		}


		#endregion
	
		#region Factory Methods

		internal static DivisionListItem GetDivisionListItem(SafeDataReader dr)
		{
			return new DivisionListItem(dr, null);
		}

		internal static DivisionListItem GetDivisionListItem(SafeDataReader dr, MachineList.Criteria criteria)
		{
			return new DivisionListItem(dr, criteria);
		}

		public static DivisionListItem GetDivisionListItem(MachineList.Criteria criteria)
		{
			return DataPortal.Fetch<DivisionListItem>(criteria);
		}

		protected DivisionListItem(): base()
		{
			/* require use of factory methods */
		}

		protected DivisionListItem(SafeDataReader dr, MachineList.Criteria criteria)
		{
			Fetch(dr, criteria);
		}

		#endregion
	
		#region Data Access

		private void Fetch(MachineList.Criteria criteria, SqlConnection connection)
		{
			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandType = CommandType.Text;
				command.CommandText = @"SELECT DivisionId,DisplayName,GroupingId,Notes" +
									  @" FROM Divisions" +
									  @" WHERE DivisionId=@DivisionId";

				command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);

				using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
				{
					if (dataReader.Read())
					{
						m_DivisionId = dataReader.GetString("DivisionId");
						m_DisplayName = dataReader.GetString("DisplayName");
                        m_GroupingId = dataReader.GetInt32("GroupingId");
						m_Notes = dataReader.GetString("Notes");
					}
				}
			}
		}

		private void DataPortal_Fetch(MachineList.Criteria criteria)
		{
			if (criteria.Connection != null)
			{
				Fetch(criteria, criteria.Connection);
			}
			else
			{
				using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
				{
					connection.Open();
					Fetch(criteria, connection);
				}
			}

            m_Settings = DivisionSettingList.GetDivisionSettingList(m_DivisionId);
            m_Machines = MachineList.GetMachineList(criteria);

            CalculateAvailability();
            CalculateAvailabilityLossBasedOnActualStops();
            CalculateAvailabilityLossBasedOnFlowErrors();
			CalculatePerformance();
			CalculateQuality();
		}

		private void Fetch(SafeDataReader dataReader, MachineList.Criteria criteria)
		{	
			m_DivisionId = dataReader.GetString("DivisionId");
			m_DisplayName = dataReader.GetString("DisplayName");
			m_Notes = dataReader.GetString("Notes");

			if (criteria != null)
			{
                m_Settings = DivisionSettingList.GetDivisionSettingList(m_DivisionId);
				m_Machines = MachineList.GetMachineList(criteria);

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