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
	public class OEEForMachineListItem : ReadOnlyBase<OEEForMachineListItem>
	{
		#region Business methods

		private string m_XValue = String.Empty;
		private StateList m_States = null;

		public string XValue
		{
			get { return m_XValue; }
		}

		public Decimal Availability
		{
			get 
			{
				if (m_States == null)
					return 0;

				return m_States.Availability; 
			}
		}

		public Decimal Performance
		{
			get
			{
				if (m_States == null)
					return 0;

				return m_States.Performance;
			}
		}

		public Decimal Quality
		{
			get
			{
				if (m_States == null)
					return 0;

				return m_States.Quality;
			}
		}

		public Decimal OEE
		{
			get { return Availability * Performance * Quality; }
		}

		public void CalculateAvailability()
		{
			if(m_States != null)
				m_States.CalculateAvailability();
		}

		public void CalculatePerformance(int? machineIdealRunRate, Dictionary<string, int?> articleIdealRunRates)
		{
			if (m_States != null)
				m_States.CalculatePerformance(machineIdealRunRate, articleIdealRunRates);
		}

		public void CalculateQuality()
		{
			if (m_States != null)
				m_States.CalculateQuality();
		}

		protected override object GetIdValue()
		{
			return m_XValue;
		}

		private void SetXValue(Intervals interval, SmartDate startDate)
		{
			switch (interval)
			{
				case Intervals.Daily:
					{
						switch (startDate.Date.DayOfWeek)
						{
							case DayOfWeek.Monday:
								m_XValue = "Må";
								break;
							case DayOfWeek.Tuesday:
								m_XValue = "Ti";
								break;
							case DayOfWeek.Wednesday:
								m_XValue = "On";
								break;
							case DayOfWeek.Thursday:
								m_XValue = "To";
								break;
							case DayOfWeek.Friday:
								m_XValue = "Fr";
								break;
							case DayOfWeek.Saturday:
								m_XValue = "Lö";
								break;
							case DayOfWeek.Sunday:
								m_XValue = "Sö";
								break;
						}
						break;
					}
			}
		}

		#endregion

		#region Constructors

		protected OEEForMachineListItem()
		{
		}

		internal OEEForMachineListItem(OEEForMachineList.Criteria criteria)
		{
			SetXValue(criteria.Interval, criteria.StartDate);
			
			StateList.Criteria stateCriteria = new StateList.Criteria();
			stateCriteria.ArticleNumber = criteria.ArticleNumber;
			stateCriteria.MachineId = criteria.MachineId;
			stateCriteria.EndDate = criteria.StartDate;
			stateCriteria.StartTime = criteria.StartTime;
			stateCriteria.EndTime = criteria.EndTime;
			stateCriteria.ExcludeWeekends = criteria.ExcludeWeekends;

			m_States = StateList.GetStateList(stateCriteria);
			
		}

		#endregion
	}
}
