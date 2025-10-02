using System;
using Csla;
using Csla.Data;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
	[Serializable()]
	public class StoppageDataListItem : ReadOnlyBase<StoppageDataListItem>
	{
		#region Business Methods

		private Guid m_StoppageDataId = Guid.NewGuid();
		private string m_DivisionId = String.Empty;
		private string m_MachineId = String.Empty;
        private int m_GroupingId = 0;
		private int m_Shift = -1;
		private string m_ArticleNumber = String.Empty;
        private string m_StopReason = "";
        private int m_CategoryId = -1;
        private SmartDate m_StopDate = new SmartDate();
		private double m_ElapsedTime = 0.0;
        private bool m_SystemError = false;
        private int m_NumberOfStops = 0;
        private double m_StopRatio = 0.0;

		public Guid StoppageDataId
		{
			get
			{
				return m_StoppageDataId;
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

		public SmartDate StopDate
		{
			get
			{
                return m_StopDate;
			}
		}

        public int Year
        {
            get
            {
                return m_StopDate.Date.Year;
            }
        }

        public int Month
        {
            get
            {
                return m_StopDate.Date.Month;
            }
        }

        public int Week
        {
            get
            {
                return m_StopDate.Date.GetWeek();
            }
        }

		public double ElapsedTime
		{
			get
			{
				return m_ElapsedTime;
			}
		}

        public int NumberOfStops
		{
			get
			{
                return m_NumberOfStops;
			}
		}

        public double StopRatio
        {
            get
            {
                return m_StopRatio;
            }
        }

        public int CategoryId
        {
            get
            {
                return m_CategoryId;
            }
        }

        public bool SystemError
        {
            get
            {
                return m_SystemError;
            }
        }

        public string StopReason
        {
            get
            {
                return m_StopReason;
            }
        }

		protected override object GetIdValue()
		{
			return m_StoppageDataId;
		}
		#endregion

		#region Factory Methods

		internal static StoppageDataListItem GetStoppageDataListItem(SafeDataReader dr)
		{
			return new StoppageDataListItem(dr);
		}

        internal static StoppageDataListItem CreateOtherStopsItem(int numberOfStops)
        {
            return new StoppageDataListItem(numberOfStops);
        }

        internal static StoppageDataListItem CreateOtherStopsItem(double elapsedTime)
        {
            return new StoppageDataListItem(elapsedTime);
        }

		private StoppageDataListItem()
		{
			/* require use of factory methods */
		}

        private StoppageDataListItem(int numberOfStops)
        {
            m_StopReason = ResourceStrings.GetString("Other");
            m_NumberOfStops = numberOfStops;
        }

        private StoppageDataListItem(double elapsedTime)
        {
            m_StopReason = ResourceStrings.GetString("Other");
            m_ElapsedTime = elapsedTime;
        }

		private StoppageDataListItem(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dr)
		{
			m_StoppageDataId = dr.GetGuid("StoppageDataId");
			m_DivisionId = dr.GetString("DivisionId");
			m_MachineId = dr.GetString("MachineId");
            m_GroupingId = dr.GetInt32("GroupingId");
			m_Shift = dr.GetInt32("Shift");
			m_ArticleNumber = dr.GetString("ArticleNumber");
            m_StopDate = dr.GetSmartDate("StopDate");
            m_ElapsedTime = dr.GetDouble("ElapsedTime");
            m_NumberOfStops = dr.GetInt32("NumberOfStops");
            m_StopRatio = dr.GetDouble("StopRatio");
			m_CategoryId = dr.GetInt32("Category");
            m_SystemError = dr.GetBoolean("SystemError");
            m_StopReason = dr.GetString("StopReason");
		}

        

		#endregion
	}
}