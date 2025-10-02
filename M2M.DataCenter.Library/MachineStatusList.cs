using System;
using System.Collections.Generic;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
	[Serializable]
	public class MachineStatusList
	{
	    [Serializable]
	    public class StatusItem
	    {
	        private string m_ArticleNumber = ResourceStrings.GetString("NotAvailable2");
            private string m_Status = ResourceStrings.GetString("NotAvailable2");
			private string m_TotalUptime = "-";
			private string m_ActualUptime = "-";
			private string m_TotalNumberOf = "-";
			private string m_ActualNumberOf = "-";
            private string m_ActiveStop = "";
            private bool m_Running = false;
            private bool m_InProduction = false;
            private bool m_IsConnected = false;
            private bool m_FlowErrorActive = false;
            
			public StatusItem()
			{
			}

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public string Status
			{
				get { return m_Status; }
				set { m_Status = value; }
			}

			public string TotalUptime
			{
				get { return m_TotalUptime; }
				set { m_TotalUptime = value; }
			}

			public string ActualUptime
			{
				get { return m_ActualUptime; }
				set { m_ActualUptime = value; }
			}

			public string TotalNumberOf
			{
				get { return m_TotalNumberOf; }
				set { m_TotalNumberOf = value; }
			}

			public string ActualNumberOf
			{
				get { return m_ActualNumberOf; }
				set { m_ActualNumberOf = value; }
			}

            public string ActiveStop
            {
                get { return m_ActiveStop; }
                set { m_ActiveStop = value; }
            }

            public bool Running
            {
                get { return m_Running; }
                set { m_Running = value; }
            }

            public bool InProduction
            {
                get { return m_InProduction; }
                set { m_InProduction = value; }
            }

            public bool IsConnected
            {
                get { return m_IsConnected; }
                set { m_IsConnected = value; }
            }

            public bool FlowErrorActive
            {
                get { return m_FlowErrorActive; }
                set { m_FlowErrorActive = value; }
            }
	    }

        private readonly Dictionary<string, StatusItem> m_StatusItems = new Dictionary<string, StatusItem>();

	    public MachineStatusList()
	    {
	    }

		public void LoadStatusList(MachineList machineList)
		{
			foreach (MachineListItem machine in machineList)
			{
                bool activeAlert = false;
				StatusItem statusItem = new StatusItem();
				RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(machine.MachineId);

				if (realTimeValues != null)
				{
                    statusItem.Running = realTimeValues.Auto;
                    statusItem.InProduction = realTimeValues.ProductionSwitch;
                    statusItem.IsConnected = realTimeValues.IsConnected;
                    statusItem.FlowErrorActive =realTimeValues.FlowErrorActive;
                    statusItem.Status = realTimeValues.Status;
					statusItem.ArticleNumber = realTimeValues.ArticleNumber;
                    activeAlert = !statusItem.Running && statusItem.IsConnected && statusItem.InProduction;
                }

                Maintenance maintenance = Maintenance.GetMaintenanceObject(machine.MachineId);
                
				if (maintenance != null)
				{
					statusItem.TotalUptime = String.Format("{0:n0} {1}", maintenance.Uptime, ResourceStrings.GetString("#-Hours.Abbr"));
                    statusItem.TotalNumberOf = String.Format("{0:n0} {1}", maintenance.Moments, " " + ResourceStrings.GetString(machine.MomentUnit, StringFormatters.ToLower));
                }

                if (activeAlert)
                {
                    Event lastEvent = Event.GetActiveEvent(machine.MachineId);
                    if (!lastEvent.EventRaised.IsEmpty)
                    {
                        TagInfo tag = TagInfo.GetTagInfo(lastEvent.TagId);

                        if (tag.TagType == TagType.MainAlarm)
                            statusItem.ActiveStop = M2MDataCenter.GetReasonText(tag.TagId, tag.ReasonCode);
                        else if (tag.TagType == TagType.Stop || tag.TagType == TagType.UnidentifiedStop)
                            statusItem.ActiveStop = tag.DisplayName;

                    }
                }

                m_StatusItems.Add(machine.MachineId, statusItem);
			}
		}

	    public StatusItem GetStatusItem(string machineId)
	    {
			StatusItem statusItem; 
			if(m_StatusItems.TryGetValue(machineId, out statusItem))
			{
				return statusItem;
			}

			// return empty status item
			return new StatusItem();
	    }
	}
}
