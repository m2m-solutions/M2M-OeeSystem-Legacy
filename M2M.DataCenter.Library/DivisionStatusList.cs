using System;
using System.Collections.Generic;

namespace M2M.DataCenter
{
	[Serializable]
	public class DivisionStatusList
	{
	    [Serializable]
	    public class StatusItem
	    {
            private int m_TotalCount = 0;
            private int m_RunningCount = 0;
            
			public StatusItem()
			{
			}

			public string Status
			{
				get { return m_TotalCount > 0 ? String.Format("{0} / {1}", m_RunningCount, m_TotalCount) : "-"; }
			}

			public int RunningCount
			{
				get { return m_RunningCount; }
				set { m_RunningCount = value; }
			}

			public int TotalCount
			{
				get { return m_TotalCount; }
				set { m_TotalCount = value; }
			}
	    }

        private readonly Dictionary<string, StatusItem> m_StatusItems = new Dictionary<string, StatusItem>();

	    public DivisionStatusList()
	    {
	    }

		public void LoadStatusList(DivisionList divisionList)
		{
            foreach (DivisionListItem division in divisionList)
            {
                PlainMachineList machines = M2MDataCenter.GetMachineList(division.DivisionId);
                StatusItem statusItem = new StatusItem();

                foreach (PlainMachineListItem machine in machines)
                {
                    statusItem.TotalCount++;

                    RealTimeValues status = RealTimeValues.GetRealTimeValues(machine.MachineId);
                    if (status.ProductionSwitch && status.IsConnected && status.Auto)
                        statusItem.RunningCount++;
                }
                m_StatusItems.Add(division.DivisionId, statusItem);
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
