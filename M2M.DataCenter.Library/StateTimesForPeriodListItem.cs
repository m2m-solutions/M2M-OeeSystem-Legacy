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
	public class StateTimesForPeriodListItem : ReadOnlyBase<StateTimesForPeriodListItem>
	{
		#region Business methods

		private EventType m_EventType;
		private int m_StateTime;

		public EventType EventType
		{
			get { return m_EventType; }
		}

		public int StateTimeInSeconds
		{
			get { return m_StateTime; }
		}

		public TimeSpan StateTime
		{
			get
			{
				return new TimeSpan(0, 0, m_StateTime);
			}
		}

		public string State
		{
			get
			{
				string state = "";

				switch (m_EventType)
				{
					case EventType.NotApplicable:
						state = "Övrig";
						break;
					case EventType.Unplanned:
						state = "Oplanerade stopp";
						break;
					case EventType.Planned:
						state = "Planerade stopp";
						break;
					case EventType.Auto:
						state = "Körtid";
						break;
					case EventType.Shutdown:
						state = "Avstängd";
						break;
				}

				return state;
			}
		}

		protected override object GetIdValue()
		{
			return m_EventType;
		}

		#endregion

		#region Constructors

		protected StateTimesForPeriodListItem()
		{
		}

		internal StateTimesForPeriodListItem(EventType )
		{
			m_EventType = (EventType)dataReader.GetInt32("EventType");
			m_StateTime = dataReader.GetInt32("StateTime");
		}

		#endregion
	}
}
