using System;
using System.Data.SqlClient;
using Csla;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OEEForDivision : ReadOnlyListBase<OEEForDivision, OEEForDivisionTimePart>
	{
		#region Business methods

        private readonly string m_DivisionId = string.Empty;
		
		#endregion

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory methods

		public static OEEForDivision GetOEEForDivision(string divisionId, OEEForMachine.Criteria criteria)
		{
			return new OEEForDivision(divisionId, criteria);
		}

		protected OEEForDivision()
		{ }

		protected OEEForDivision(string divisionId, OEEForMachine.Criteria criteria)
		{
			m_DivisionId = divisionId;

			Fetch(criteria);
		}

		#endregion

		#region Data Access



		private void Fetch(OEEForMachine.Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

            DateTime criteriaEndDate = DateTime.Today;

            if (!criteria.EndDate.IsEmpty)
                criteriaEndDate = criteria.EndDate.Date;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionStringWithMultipleActiveResultSets))
			{
				connection.Open();
				switch (criteria.ChartSettings.Interval)
				{
					case Intervals.Daily:
						{
                            for (double daysBack = -criteria.ChartSettings.Steps; daysBack < 0; daysBack++)
							{
								DateTime startDate = criteriaEndDate.AddDays(daysBack).Date;
								DateTime endDate = criteriaEndDate.AddDays(daysBack + 1).Date;

								criteria.StartDate = new SmartDate(startDate);
								criteria.EndDate = new SmartDate(endDate);

								OEEForDivisionTimePart item = OEEForDivisionTimePart.GetOEEForDivisionTimePart(m_DivisionId, criteria, connection);
                                if (item.TotalProductionTime > 0)
									this.Add(item);
							}
							break;
						}
                    case Intervals.Weekly:
                        {
                            for (double weeksBack = -criteria.ChartSettings.Steps; weeksBack < 0; weeksBack++)
                            {
                                DateTime startDate = criteriaEndDate.AddDays(7 * weeksBack).FirstDateOfWeek().Date;
                                DateTime endDate = startDate.AddDays(7);

                                if (endDate > criteriaEndDate)
                                    endDate = criteriaEndDate;
                                
                                criteria.StartDate = new SmartDate(startDate);
                                criteria.EndDate = new SmartDate(endDate);

                                OEEForDivisionTimePart item = OEEForDivisionTimePart.GetOEEForDivisionTimePart(m_DivisionId, criteria, connection);
                                if (item.TotalProductionTime > 0)
                                    this.Add(item);
                            }
                            break;
                        }
				}
			}
			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}


		#endregion
	}
}
