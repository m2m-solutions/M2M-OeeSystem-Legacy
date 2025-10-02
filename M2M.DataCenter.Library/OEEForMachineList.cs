using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Threading;

using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OEEForMachineList : ReadOnlyListBase<OEEForMachineList, OEEForMachineListItem>
	{
		#region Business methods

		private MachineSettingList m_Settings = null;
		private ArticleSettingList m_ArticleSettings = null;

		public int? IdealRunRate
		{
			get
			{
				if (m_Settings == null || m_Settings.GetItem("IdealRunRate") == null)
					return null;

				return (int?)m_Settings.GetItem("IdealRunRate").Value;
			}
		}

		
		#endregion

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory methods

		public static OEEForMachineList GetOEEForMachineList(Criteria criteria)
		{
			return DataPortal.Fetch<OEEForMachineList>(criteria);
		}

		protected OEEForMachineList()
		{ }

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_MachineId = null;
			private string m_ArticleNumber = null;
			private SmartDate m_StartDate = new SmartDate();
			private SmartDate m_EndDate = new SmartDate();
			private TimeSpan m_StartTime = new TimeSpan(0);
			private TimeSpan m_EndTime = new TimeSpan(0);
			private bool m_ExcludeWeekends = false;
			private Intervals m_Interval = Intervals.NotDefined;

			public Criteria()
			{
			}


			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
			}

			public SmartDate StartDate
			{
				get { return m_StartDate; }
				set { m_StartDate = value; }
			}

			public SmartDate EndDate
			{
				get { return m_EndDate; }
				set { m_EndDate = value; }
			}

			public TimeSpan StartTime
			{
				get { return m_StartTime; }
				set { m_StartTime = value; }
			}

			public TimeSpan EndTime
			{
				get { return m_EndTime; }
				set { m_EndTime = value; }
			}

			public bool ExcludeWeekends
			{
				get { return m_ExcludeWeekends; }
				set { m_ExcludeWeekends = value; }
			}

			public Intervals Interval
			{
				get { return m_Interval; }
				set { m_Interval = value; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			m_Settings = MachineSettingList.GetMachineSettingList(criteria.MachineId);
			m_ArticleSettings = ArticleSettingList.GetArticleSettingList(criteria.MachineId);

			Dictionary<string, int?> articleIdealRunRates = new Dictionary<string, int?>();

			foreach (ArticleSettingListItem setting in m_ArticleSettings)
			{
				if (setting.Setting == "IdealRunRate" && setting.Value != null)
				{
					articleIdealRunRates.Add(setting.ArticleNumber, (int?)setting.Value);
				}
			}

			switch (criteria.Interval)
			{
				case Intervals.Daily:
					{
						for (double daysBack = 14; daysBack > 0; daysBack--)
						{
							DateTime startDate = DateTime.Now.AddDays(daysBack).Date;
							DateTime endDate = DateTime.Now.AddDays(daysBack-1).Date;

							if (!criteria.ExcludeWeekends || (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday))
							{
								OEEForMachineListItem item = new OEEForMachineListItem(criteria);
								this.Add(item);

								item.CalculateAvailability();
								item.CalculatePerformance(IdealRunRate, articleIdealRunRates);
								item.CalculateQuality();
							}
						}
						break;
					}
			}
		}


		#endregion
	}
}
