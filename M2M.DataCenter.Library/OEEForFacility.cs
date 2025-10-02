using System;
using System.Data.SqlClient;
using Csla;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OEEForFacility : ReadOnlyListBase<OEEForFacility, OEEForFacilityTimePart>
	{
		#region Business methods

		#endregion

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory methods

		public static OEEForFacility GetOEEForFacility(OEEForMachine.Criteria criteria)
		{
			return new OEEForFacility(criteria);
		}

		protected OEEForFacility()
		{ }

		protected OEEForFacility(OEEForMachine.Criteria criteria)
		{
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
								
								OEEForFacilityTimePart item = OEEForFacilityTimePart.GetOEEForFacilityTimePart(criteria, connection);
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

                                OEEForFacilityTimePart item = OEEForFacilityTimePart.GetOEEForFacilityTimePart(criteria, connection);
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
