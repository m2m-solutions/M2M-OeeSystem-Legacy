using System;
using System.Collections.Generic;
using System.Linq;
using M2M.DataCenter;
using M2M.DataCenter.Utilities;

namespace M2M.Integrator.Tekla.Library
{
	public class ObjectIdHelper
	{
		private static List<string> m_MachinesWithNoArticles = null;

		public static string GetObjectId(StateListItem state)
		{
			string objectId = "";

			if (m_MachinesWithNoArticles == null)
			{
				m_MachinesWithNoArticles = new List<string>();
				PlainMachineList machines = PlainMachineList.GetMachineList("Bla_hallen");
				foreach (PlainMachineListItem machine in machines)
				{
					m_MachinesWithNoArticles.Add(machine.MachineId);
				}
			}

			if (m_MachinesWithNoArticles.Contains(state.MachineId))
			{
				objectId = state.MachineId;
			}
			else
			{
				objectId = state.ArticleNumber.SafeSubstring(0, 8);
			}

			return objectId;
		}

	}
}
