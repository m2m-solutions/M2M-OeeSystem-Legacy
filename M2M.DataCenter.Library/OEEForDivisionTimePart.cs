using System;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OEEForDivisionTimePart : ReadOnlyListBase<OEEForDivisionTimePart, OEEForMachineTimePart>
	{
		#region Business methods

        private readonly string m_DivisionId = string.Empty;
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

		public double TotalTime
		{
			get
			{
				return this.Where( a=> a.AggregateAvailability).Sum( a => a.TotalTime );
			}
		}

        public double TotalProductionTime
        {
            get
            {
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalProductionTime);
            }
        }

        public double TotalAutoTimeForAvailability
		{
			get
			{
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalAutoTime);
			}
		}

        public double TotalAutoTimeForPerformance
        {
            get
            {
                return this.Where(a => a.AggregatePerfomance).Sum(a => a.TotalAutoTime);
            }
        }

        public double TotalFlowErrorTime
		{
			get
			{
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalFlowErrorTime);
			}
		}

        public double TotalChangeOverTime
        {
            get
            {
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalChangeOverTime);
            }
        }

        public double TotalActualStopTime
        {
            get
            {
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalActualStopTime);
            }
        }

        public double TotalStopTime
        {
            get
            {
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalStopTime);
            }
        }

        public double TotalNoProductionTime
        {
            get
            {
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalNoProductionTime);
            }
        }

        public double TotalNotConnectedTime
        {
            get
            {
                return this.Where(a => a.AggregateAvailability).Sum(a => a.TotalNotConnectedTime);
            }
        }

		public long ProducedItems
		{
			get
			{
                return this.Where(a => a.AggregatePerfomance).Sum(a => (long)a.ProducedItems);
			}
		}

        public long DiscardedItems
		{
			get
			{
                return this.Sum(a => (long)a.DiscardedItems);
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

		public Decimal AvailabilityInPercent
		{
			get
			{
				return Availability * 100;
			}
		}

		private void CalculatePerformance()
		{
            
            double totAutoTime = TotalAutoTimeForPerformance;

            if (totAutoTime != 0)
            {
                foreach (OEEForMachineTimePart machine in this.Where(a => a.AggregatePerfomance))
                {
                    if (machine.TotalAutoTime != 0)
                    {
                        m_Performance += machine.Performance * Convert.ToDecimal(machine.TotalAutoTime) / Convert.ToDecimal(totAutoTime);
                    }
                }
            }
      }

		public Decimal PerformanceInPercent
		{
			get
			{
				return Performance * 100;
			}
		}

		private void CalculateQuality()
		{
            long producedItems = ProducedItems;
            
            if (producedItems > 0)
                m_Quality = Convert.ToDecimal((double)(producedItems - DiscardedItems) / (double)producedItems);
		}

		public Decimal QualityInPercent
		{
			get
			{
				return Quality * 100;
			}
		}

		public Decimal OEEInPercent
		{
			get
			{
				return OEE * 100;
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

		public static OEEForDivisionTimePart GetOEEForDivisionTimePart(string divisionId, OEEForMachine.Criteria criteria, SqlConnection connection)
		{
			return new OEEForDivisionTimePart(divisionId, criteria, connection);
		}

		protected OEEForDivisionTimePart()
		{ }

		protected OEEForDivisionTimePart(string divisionId, OEEForMachine.Criteria criteria, SqlConnection connection)
		{
			m_DivisionId = divisionId;
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

            
            PlainMachineList machines = M2MDataCenter.GetMachineList(m_DivisionId);

            foreach (PlainMachineListItem machine in machines)
			{
                criteria.MachineId = machine.MachineId;

                OEEForMachineTimePart item = new OEEForMachineTimePart(connection, criteria);
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
