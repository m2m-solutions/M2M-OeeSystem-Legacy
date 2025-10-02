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
	public class TopStopTimeReasonListItem : ReadOnlyBase<TopStopTimeReasonListItem>
	{
		#region Business methods

		private string m_TagId;
		private string m_Reason;
		private int m_StopTime;

		public string TagId
		{
			get { return m_TagId; }
		}

		public string Reason
		{
			get { return m_Reason; }
		}

		public int StopTimeInSeconds
		{
			get { return m_StopTime; }
		}

		public TimeSpan StopTime
		{
			get
			{
				return new TimeSpan(0, 0, m_StopTime);
			}
		}


		protected override object GetIdValue()
		{
			return m_TagId;
		}

		#endregion

		#region Constructors

		protected TopStopTimeReasonListItem()
		{
		}

        internal TopStopTimeReasonListItem(string tagId, string reason, int stopTime)
        {
            m_TagId = tagId;
            m_Reason = reason;
            m_StopTime = stopTime;
        }

		internal TopStopTimeReasonListItem(SafeDataReader dataReader)
		{
			m_TagId = dataReader.GetString("TagId");
			m_Reason = dataReader.GetString("Reason");
			m_StopTime = dataReader.GetInt32("StopTime");
		}

		#endregion
	}
}
