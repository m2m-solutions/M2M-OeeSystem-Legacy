using System;
using System.Data.SqlClient;
using Csla;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OEEForMachine : ReadOnlyListBase<OEEForMachine, OEEForMachineTimePart>
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

		public static OEEForMachine GetOEEForMachine(Criteria criteria)
		{
			return DataPortal.Fetch<OEEForMachine>(criteria);
		}

		protected OEEForMachine()
		{ }

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_DivisionId = null;
			private string m_MachineId = null;
			private string m_ArticleNumber = null;
			private SmartDate m_StartDate = new SmartDate();
			private SmartDate m_EndDate = new SmartDate();
			private int m_Shift = -1;
			private ChartSettings m_ChartSettings = null;

			public Criteria()
			{
			}

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public string DivisionId
			{
				get { return m_DivisionId; }
				set { m_DivisionId = value; }
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

			public int Shift
			{
				get { return m_Shift; }
				set { m_Shift = value; }
			}

			public ChartSettings ChartSettings
			{
				get { return m_ChartSettings; }
				set { m_ChartSettings = value; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (SqlConnection connection = new SqlConnection(ApplicationSettings.SystemConnectionString))
			{
				connection.Open();

                DateTime criteriaEndDate = DateTime.Today;

                if (!criteria.EndDate.IsEmpty)
                    criteriaEndDate = criteria.EndDate.Date;

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

						
								OEEForMachineTimePart item = new OEEForMachineTimePart(connection, criteria);
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
                   
                                OEEForMachineTimePart item = new OEEForMachineTimePart(connection, criteria);
                                if (item.TotalProductionTime > 0 )
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
