using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class PlainDivisionListItem : ReadOnlyBase<PlainDivisionListItem>
	{
		#region Business Methods 
		private string m_DivisionId = String.Empty;
		private string m_DisplayName = String.Empty;
        private string m_ShortName = String.Empty;
        private int m_GroupingId = 0;
		private string m_Notes = String.Empty;

        private DivisionSettingList m_Settings = null;
		private PlainMachineList m_Machines = null;

		public string DivisionId
		{
			get
			{
				return m_DivisionId;
			}
		}

		public string DisplayName
		{
			get
			{
				return m_DisplayName;
			}
		}

        public string ShortName
        {
            get
            {
                return m_ShortName;
            }
        }

        public int GroupingId
        {
            get
            {
                return m_GroupingId;
            }
        }

		public string Notes
		{
			get
			{
				return m_Notes;
			}
		}

        public DivisionSettingList Settings
        {
            get
            {
                return m_Settings;
            }
        }

		public PlainMachineList Machines
		{
			get
			{
				return m_Machines;
			}
			set
			{
				m_Machines = value;
			}
		}

		protected override object GetIdValue()
		{
			return m_DivisionId;
		}


		#endregion
	
		#region Factory Methods

		internal static PlainDivisionListItem GetDivisionListItem(SafeDataReader dr)
		{
			return new PlainDivisionListItem(dr);
		}


		protected PlainDivisionListItem(): base()
		{
			/* require use of factory methods */
		}

		protected PlainDivisionListItem(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion
	
		#region Data Access

		private void Fetch(SafeDataReader dataReader)
		{	
			m_DivisionId = dataReader.GetString("DivisionId");
			m_DisplayName = dataReader.GetString("DisplayName");
            m_ShortName = dataReader.GetString("ShortName");
            m_GroupingId = dataReader.GetInt32("GroupingId");
			m_Notes = dataReader.GetString("Notes");

            m_Settings = DivisionSettingList.GetDivisionSettingList(m_DivisionId);
			m_Machines = PlainMachineList.GetMachineList(m_DivisionId);
		}

		#endregion
	
	}
}