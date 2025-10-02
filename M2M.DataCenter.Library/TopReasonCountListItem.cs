using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class TopReasonCountListItem : ReadOnlyBase<TopReasonCountListItem>
	{
		#region Business methods

		private string m_TagId;
		private string m_Reason;
		private int m_NumberOfStops;

		public string TagId
		{
			get { return m_TagId; }
		}

		public string Reason
		{
			get { return m_Reason; }
		}

		public int NumberOfStops
		{
			get { return m_NumberOfStops; }
		}

		protected override object GetIdValue()
		{
			return m_TagId;
		}

		#endregion

		#region Constructors

		protected TopReasonCountListItem()
		{
		}

        internal TopReasonCountListItem(string tagId, string reason, int numberOfStops)
        {
            m_TagId = tagId;
            m_Reason = reason;
            m_NumberOfStops = numberOfStops;
        }

		internal TopReasonCountListItem(SafeDataReader dataReader)
		{
			m_TagId = dataReader.GetString("TagId");
			m_Reason = dataReader.GetString("Reason");
			m_NumberOfStops = dataReader.GetInt32("NumberOfStops");
		}

		#endregion
	}
}
