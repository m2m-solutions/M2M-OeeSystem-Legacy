using System;
using System.Data.SqlClient;
using Csla;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OEEForMachineTimePart : ReadOnlyBase<OEEForMachineTimePart>
	{
		#region Business methods

        private readonly string m_MachineId = "";

        private readonly SmartDate m_XValue = new SmartDate();
        private readonly Intervals m_Interval = Intervals.NotDefined;
        private readonly OeeDataList m_OeeData = null;
		
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

        public bool AggregateCounter { get { return M2MDataCenter.GetMachine(m_MachineId).AggregateCounter; } }
        public bool AggregateAvailability { get { return M2MDataCenter.GetMachine(m_MachineId).AggregateAvailability; } }
        public bool AggregatePerfomance { get { return M2MDataCenter.GetMachine(m_MachineId).AggregatePerformance; } }

        public double XValue
        {
            get
            {
                return m_XValue.Date.ToOADate();
            }
        }

        public string XValueAsString
        {
            get
            {
                switch (m_Interval)
                {
                    case Intervals.Daily:
                        return m_XValue.Date.ToString("ddd d'/'M");
                    case Intervals.Weekly:
                        return String.Format("{0}. {1}", ResourceStrings.GetString("#-Week.Abbr"), m_XValue.Date.GetWeek());
                    default:
                        return "";   
                }
            }
        }

        public Decimal Availability
		{
			get
			{
				return m_Availability;
			}
		}

        public Decimal AvailabilityLoss
        {
            get
            {
                return m_AvailabilityLossBasedOnActualStops + m_AvailabilityLossBasedOnFlowErrors;
            }
        }

        public Decimal AvailabilityLossBasedOnFlowErrors
        {
            get
            {
                return m_AvailabilityLossBasedOnFlowErrors;
            }
        }

        public Decimal AvailabilityLossBasedOnActualStops
        {
            get
            {
                return m_AvailabilityLossBasedOnActualStops;
            }
        }
        
		public Decimal Performance
		{
			get
			{
				return m_Performance;
			}
		}

		public Decimal Quality
		{
			get
			{
				return m_Quality;
			}
		}

		public Decimal OEE
		{
			get { return Availability * Performance * Quality; }
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

        public double TotalNoProductionTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalNoProductionTime;
            }
        }

        public double TotalNotConnectedTime
        {
            get
            {
                if (m_OeeData == null)
                    return 0;

                return m_OeeData.TotalNotConnectedTime;
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

		public int DiscardedItems
		{
			get
			{
				if (m_OeeData == null)
					return 0;

				return m_OeeData.DiscardedItems;
			}
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
			if (totalAutoTime != 0)
			{
				double performance = 0;

				foreach (OeeDataListItem item in m_OeeData)
				{
					double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

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

		protected override object GetIdValue()
		{
			return m_XValue;
		}

		public OeeDataList OeeData
		{
			get
			{
				return m_OeeData;
			}
		}

		#endregion

		#region Constructors

		protected OEEForMachineTimePart()
		{
		}

		internal OEEForMachineTimePart(SqlConnection connection, OEEForMachine.Criteria criteria)
		{
            m_MachineId = criteria.MachineId;

            m_XValue = criteria.StartDate;
            m_Interval = criteria.ChartSettings.Interval;

            OeeDataList.Criteria oeeDataCriteria = new OeeDataList.Criteria();
            oeeDataCriteria.ArticleNumber = criteria.ArticleNumber;
            oeeDataCriteria.MachineId = criteria.MachineId;
            oeeDataCriteria.DivisionId = criteria.DivisionId;
            oeeDataCriteria.StartTime = criteria.StartDate;
            oeeDataCriteria.EndTime = criteria.EndDate;
            oeeDataCriteria.Shift = criteria.Shift;
            oeeDataCriteria.SqlConnection = connection;

			m_OeeData = OeeDataList.GetOeeDataList(oeeDataCriteria);

            CalculateAvailability();
            CalculateAvailabilityLossBasedOnActualStops();
            CalculateAvailabilityLossBasedOnFlowErrors();
            CalculatePerformance();
            CalculateQuality();
			
		}

		#endregion
	}
}
