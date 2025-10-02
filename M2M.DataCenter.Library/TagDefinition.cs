using System;
using System.Collections.Generic;
using System.Text;

using OPCDA.NET;
using M2M.DataCenter;

namespace M2M.DataCenter
{
	public class TagDefinition : ItemDef
	{
		private EventType m_EventType = EventType.Informational;
		private Actions m_Actions = Actions.NoAction;

		public EventType EventType
		{
			get
			{
				return m_EventType;
			}
		}

		public Actions Actions
		{
			get
			{
				return m_Actions;
			}
		}

		public bool WriteEventOnSet
		{
			get
			{
				return ((m_Actions & Actions.WriteEventOnSet) == Actions.WriteEventOnSet);
			}
		}

		public bool UpdateEventOnReset
		{
			get
			{
				return ((m_Actions & Actions.UpdateEventOnReset) == Actions.UpdateEventOnReset);
			}
		}

		public TagDefinition()
		{
		}
	}
}
