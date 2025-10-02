using System;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;
using System.Collections.Generic;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OEEForFacilityTimePart : ReadOnlyListBase<OEEForFacilityTimePart, OEEForDivisionTimePart>
	{
		#region Business methods

        private readonly SmartDate m_XValue = new SmartDate();
        private readonly Intervals m_Interval = Intervals.NotDefined;
        private Decimal m_Availability = 0;
		private Decimal m_Performance = 0;
		private Decimal m_Quality = 1;

        private Decimal m_AvailabilityLossBasedOnActualStops = 0;
        private Decimal m_AvailabilityLossBasedOnFlowErrors = 0;

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

        public Decimal AvailabilityLossBasedOnActualStops
        {
            get
            {
                return m_AvailabilityLossBasedOnActualStops;
            }
        }

        public Decimal AvailabilityLossBasedOnFlowErrors
        {
            get
            {
                return m_AvailabilityLossBasedOnFlowErrors;
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

        public double TotalTime { get { return this.Sum(a => a.TotalTime); } }
        public double TotalProductionTime { get { return this.Sum(a => a.TotalProductionTime); } }
        public double TotalNoProductionTime { get { return this.Sum(a => a.TotalNoProductionTime); } }
        public double TotalNotConnectedTime { get { return this.Sum(a => a.TotalNotConnectedTime); } }
        public double TotalAutoTimeForAvailability { get { return this.Sum(a => a.TotalAutoTimeForAvailability); } }
        public double TotalAutoTimeForPerformance { get { return this.Sum(a => a.TotalAutoTimeForPerformance); } }
        public double TotalFlowErrorTime { get { return this.Sum(a => a.TotalFlowErrorTime); } }
        public double TotalChangeOverTime { get { return this.Sum(a => a.TotalChangeOverTime); } }
        public double TotalActualStopTime { get { return this.Sum(a => a.TotalActualStopTime); } }
      
		private void CalculateAvailability()
		{
            double totalTime = TotalProductionTime;

            if (totalTime > 0)
            {
                m_Availability = Convert.ToDecimal(this.Sum(a => a.TotalAutoTimeForAvailability) / totalTime);
            }
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
            double totalAutoTime = this.Sum(a => a.TotalAutoTimeForPerformance);

            if (totalAutoTime > 0)
            {
                foreach (OEEForDivisionTimePart division in this.Items)
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

		#region Factory methods

		public static OEEForFacilityTimePart GetOEEForFacilityTimePart(OEEForMachine.Criteria criteria, SqlConnection connection)
		{
			return new OEEForFacilityTimePart(criteria, connection);
		}

		protected OEEForFacilityTimePart()
		{ }

		protected OEEForFacilityTimePart(OEEForMachine.Criteria criteria, SqlConnection connection)
		{
			m_XValue = criteria.StartDate;
			m_Interval = criteria.ChartSettings.Interval;

			Fetch(criteria, connection);
		}

		#endregion

		#region Data Access

		

		private void Fetch(OEEForMachine.Criteria criteria, SqlConnection connection)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			List<PlainDivisionListItem> divisions = M2MDataCenter.GetDivisionsAccessibleForUser();

			foreach (PlainDivisionListItem division in divisions)
			{
                
                criteria.DivisionId = division.DivisionId;

                OEEForDivisionTimePart item = OEEForDivisionTimePart.GetOEEForDivisionTimePart(criteria.DivisionId, criteria, connection);
                if (item.TotalProductionTime > 0)
                    this.Add(item);
          }

			CalculateAvailability();
            CalculateAvailabilityLossBasedOnActualStops();
            CalculateAvailabilityLossBasedOnFlowErrors();
			CalculatePerformance();
			CalculateQuality();
	
			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}


		#endregion
	}
}
