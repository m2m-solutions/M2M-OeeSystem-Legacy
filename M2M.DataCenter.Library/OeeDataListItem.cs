using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OeeDataListItem : ReadOnlyBase<OeeDataListItem>
	{
		#region Business Methods

		private Guid m_OeeDataId = Guid.NewGuid();
		private string m_DivisionId = String.Empty;
		private string m_MachineId = String.Empty;
        private int m_GroupingId = 0;
		private int m_Shift = -1;
		private string m_ArticleNumber = String.Empty;
		private SmartDate m_StartTime = new SmartDate();
		private SmartDate m_EndTime = new SmartDate();
		private double m_AutoTime = 0.0;
        private double m_NoProductionTime = 0.0;
        private double m_NotConnectedTime = 0.0;
        private double m_FlowErrorTime = 0.0;
        private double m_ChangeOverTime = 0.0;
		private int m_ProducedItems = 0;
		private int m_DiscardedItems = 0;
        private bool m_AggregateAvailability = true;
        private bool m_AggregatePerformance = true;
        private bool m_AggregateCounter = true;

		public Guid OeeDataId
		{
			get
			{
				return m_OeeDataId;
			}
		}

		public string DivisionId
		{
			get
			{
				return m_DivisionId;
			}
		}

		public string MachineId
		{
			get
			{
				return m_MachineId;
			}
		}

        public int GroupingId
        {
            get
            {
                return m_GroupingId;
            }
        }

        public bool AggregateAvailability
        {
            get
            {
                return m_AggregateAvailability;
            }
        }

        public bool AggregatePerformance
        {
            get
            {
                return m_AggregatePerformance;
            }
        }

        public bool AggregateCounter
        {
            get
            {
                return m_AggregateCounter;
            }
        }

		public int Shift
		{
			get
			{
				return m_Shift;
			}
		}

		public string ArticleNumber
		{
			get
			{
				return m_ArticleNumber;
			}
		}

		public SmartDate StartTime
		{
			get
			{
				return m_StartTime;
			}
		}

		public SmartDate EndTime
		{
			get
			{
				return m_EndTime;
			}
		}

		public double AutoTime
		{
			get
			{
				return m_AutoTime;
			}
		}

        public double NoProductionTime
		{
			get
			{
				return m_NoProductionTime;
			}
		}

        public double ProductionTime
        {
            get
            {
                return TotalTime - m_NoProductionTime - m_NotConnectedTime;
            }
        }

        public double NotConnectedTime
        {
            get
            {
                return m_NotConnectedTime;
            }
        }

        public double FlowErrorTime
        {
            get
            {
                return m_FlowErrorTime;
            }
        }

        public double ChangeOverTime
        {
            get
            {
                return m_ChangeOverTime;
            }
        }

        public double StopTime
        {
            get
            {
                return ProductionTime - m_AutoTime;
            }
        }

        public double ActualStopTime
        {
            get
            {
                return StopTime - m_FlowErrorTime;
            }
        }

		public int ProducedItems
		{
			get
			{
				return m_ProducedItems;
			}
		}

		public int DiscardedItems	
		{
			get
			{
				return m_DiscardedItems;
			}
		}

		public double TotalTime
		{
			get
			{
				TimeSpan totalTime = m_EndTime.Subtract(m_StartTime.Date);
				return totalTime.TotalSeconds;
			}
		}

		public double RunRate
		{
			get
			{
				double runRate = 0;

				if (AutoTime != 0 && ProducedItems != 0)
				{
					runRate = 1000 * (AutoTime / (double)ProducedItems);
				}

				return runRate;
			}
		}

		protected override object GetIdValue()
		{
			return m_OeeDataId;
		}
		#endregion

		#region Factory Methods

		internal static OeeDataListItem GetOeeDataListItem(SafeDataReader dr)
		{
			return new OeeDataListItem(dr);
		}

		private OeeDataListItem()
		{
			/* require use of factory methods */
		}

		private OeeDataListItem(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dr)
		{
			m_OeeDataId = dr.GetGuid("OeeDataId");
			m_DivisionId = dr.GetString("DivisionId");
			m_MachineId = dr.GetString("MachineId");
            m_GroupingId = dr.GetInt32("GroupingId");
			m_Shift = dr.GetInt32("Shift");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_StartTime = dr.GetSmartDate("StartTime");
			m_EndTime = dr.GetSmartDate("EndTime");
			m_AutoTime = dr.GetDouble("AutoTime");
			m_NoProductionTime = dr.GetDouble("NoProductionTime");
            m_NotConnectedTime = dr.GetDouble("NotConnectedTime");
            m_FlowErrorTime = dr.GetDouble("FlowErrorTime");
            m_ChangeOverTime = dr.GetDouble("ChangeOverTime");
			m_ProducedItems = dr.GetInt32("ProducedItems");
			m_DiscardedItems = dr.GetInt32("DiscardedItems");
            m_AggregateAvailability = M2MDataCenter.GetMachine(m_DivisionId, m_MachineId).AggregateAvailability;
            m_AggregatePerformance = M2MDataCenter.GetMachine(m_DivisionId, m_MachineId).AggregatePerformance;
            m_AggregateCounter = M2MDataCenter.GetMachine(m_DivisionId, m_MachineId).AggregateCounter;
		}

		#endregion
	}
}