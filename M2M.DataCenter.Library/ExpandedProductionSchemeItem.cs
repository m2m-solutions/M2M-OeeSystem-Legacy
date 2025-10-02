using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class ExpandedProductionSchemeItem : ReadOnlyBase<ExpandedProductionSchemeItem>
	{
		#region Business Methods

		private Guid m_Id = Guid.NewGuid();
		private int m_Shift = -1;
		private SmartDate m_StartTime = new SmartDate();
		private SmartDate m_EndTime = new SmartDate();
		private string m_DivisionId = String.Empty;
		private string m_MachineId = String.Empty;

		public Guid Id
		{
			get
			{
				return m_Id;
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

		public int Shift
		{
			get
			{
				return m_Shift;
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
		
		protected override object GetIdValue()
		{
			return m_Id;
		}
		#endregion

		#region Factory Methods

		internal static ExpandedProductionSchemeItem GetExpandedProductionSchemeItem(SafeDataReader dr)
		{
			return new ExpandedProductionSchemeItem(dr);
		}

        internal static ExpandedProductionSchemeItem GetExpandedProductionSchemeItem(Guid id, int shift, SmartDate start, SmartDate end, string division, string machine)
        {
            return new ExpandedProductionSchemeItem(id, shift, start, end, division, machine);
        }

		private ExpandedProductionSchemeItem()
		{
			/* require use of factory methods */
		}

        private ExpandedProductionSchemeItem(Guid id, int shift, SmartDate start, SmartDate end, string division, string machine)
        {
            Fetch(id, shift, start, end, division, machine);
        }

		private ExpandedProductionSchemeItem(SafeDataReader dr)
		{
            Fetch(dr.GetGuid("Id"), dr.GetInt32("Shift"), dr.GetSmartDate("StartTime"), dr.GetSmartDate("EndTime"), dr.GetString("DivisionId"), dr.GetString("MachineId"));
		}

		#endregion

		#region Data Access

        private void Fetch(Guid id, int shift, SmartDate start, SmartDate end, string division, string machine)
		{
			m_Id = id;
			m_Shift = shift;
			m_StartTime = start;
			m_EndTime = end;
			m_DivisionId = division;
			m_MachineId = machine;
		}

		#endregion
	}
}