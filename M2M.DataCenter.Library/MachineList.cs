using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class MachineList : ReadOnlyListBase<MachineList, MachineListItem>
	{

        public Decimal GetUpperLimit(int take)
        {
            return this.OrderByDescending(a => a.AvailabilityLossBasedOnActualStops).Take(take+1).Min(b => b.AvailabilityLossBasedOnActualStops);
        }

        public Decimal GetLowerLimit(int take)
        {
            return this.OrderByDescending(a => a.AvailabilityLossBasedOnActualStops).Take(take+1).Min(b => b.AvailabilityLossBasedOnActualStops);
        }

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static MachineList GetMachineList(string divisionId, bool advancedFilter)
		{
			return DataPortal.Fetch<MachineList>(new Criteria(divisionId, advancedFilter));
		}

		public static MachineList GetMachineList(Criteria criteria)
		{
			return DataPortal.Fetch<MachineList>(criteria);
		}

		protected MachineList()
		{
			/* require use of factory methods */
		}
		
		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_DivisionId = null;
			private string m_ArticleNumber = null;
			private SmartDate m_StartDate = new SmartDate();
			private SmartDate m_EndDate = new SmartDate();
			private int m_Shift = -1;
            private readonly bool m_AdvancedFilter = true;
            private SqlConnection m_Connection = null;

			public string DivisionId
			{
				get { return m_DivisionId; }
				set { m_DivisionId = value; }
			}

			public Criteria()
			{
				
			}

			public Criteria(bool advancedFilter)
			{
				m_AdvancedFilter = advancedFilter;
			}

			public Criteria(string divisionId, bool advancedFilter)
			{
				m_DivisionId = divisionId;
				m_AdvancedFilter = advancedFilter;
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

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public int Shift
			{
				get { return m_Shift; }
				set { m_Shift = value; }
			}

			public bool AdvancedFilter
			{
				get { return m_AdvancedFilter; }
			}

			public SqlConnection Connection
			{
				get { return m_Connection; }
				set { m_Connection = value; }
			}
		}

		private void Fetch(Criteria criteria, SqlConnection connection)
		{
			using (SqlCommand command = connection.CreateCommand())
			{
                string whereClause = "";
                if (!String.IsNullOrEmpty(criteria.DivisionId))
                {
                    whereClause = " WHERE d.DivisionId=@DivisionId";
                    command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);
                }

				command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT m.MachineId,m.DisplayName,m.Notes,m.DivisionId,d.DisplayName as DivisionName" +
                                      @" FROM Machines m JOIN Divisions d ON m.DivisionId=d.DivisionId" +
                                      whereClause +
                                      @" ORDER BY DivisionName,MachineId ASC";
				
				
				using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
				{
					while (dataReader.Read())
					{
						if (criteria.AdvancedFilter)
						{
                            OeeDataList.Criteria oeeDataCriteria = new OeeDataList.Criteria();
                            oeeDataCriteria.MachineId = dataReader.GetString("MachineId");
                            oeeDataCriteria.DivisionId = dataReader.GetString("DivisionId");
                            oeeDataCriteria.StartTime = criteria.StartDate;
                            oeeDataCriteria.EndTime = criteria.EndDate;
                            oeeDataCriteria.Shift = criteria.Shift;
                            oeeDataCriteria.ArticleNumber = criteria.ArticleNumber;
                            
                            Add(MachineListItem.GetMachineListItem(dataReader, oeeDataCriteria));
                        }
						else
						{
							Add(MachineListItem.GetMachineListItem(dataReader));
						}
					}
				}
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			if (criteria.Connection != null)
			{
				Fetch(criteria, criteria.Connection);
			}
			else
			{
				using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
				{
					connection.Open();
					Fetch(criteria, connection);
				}
			}
			IsReadOnly = true;	
			RaiseListChangedEvents = true;
		}
		#endregion
	}
}