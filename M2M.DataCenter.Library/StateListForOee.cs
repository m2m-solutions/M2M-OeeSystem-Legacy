using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class StateListForOee : ReadOnlyListBase<StateListForOee, StateItemForOee>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static StateListForOee GetStateList(string machineId, SmartDate startTime, SmartDate endTime)
		{
            return DataPortal.Fetch<StateListForOee>(new Criteria(machineId, startTime, endTime));
		}


		private StateListForOee()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
            private readonly string m_MachineId;
            private readonly SmartDate m_StartTime;
            private readonly SmartDate m_EndTime;

            public Criteria(string machineId, SmartDate startTime, SmartDate endTime)
			{
                m_MachineId = machineId;
				m_StartTime = startTime;
				m_EndTime = endTime;
			}

			public string MachineId
			{
				get { return m_MachineId; }
			}

			public SmartDate StartTime
			{
				get { return m_StartTime; }
			}

			public SmartDate EndTime
			{
				get { return m_EndTime; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT StateId,MachineId,ArticleNumber,StateType,TimeStampOnSet,TimeStampOnReset,NumberOfItemsOnSet,NumberOfItemsOnReset,NumberOfRejectedOnSet,NumberOfRejectedOnReset" +
                                          @" FROM States WITH (NOLOCK)" +
                                          @" WHERE MachineId =@MachineId" +
	                                      @" AND	TimeStampOnSet < @rangeEnd" +
                                          @" AND (TimeStampOnReset IS NULL OR TimeStampOnReset > @rangeStart)" +
                                          @" AND Overridden = 0" +
                                          @" ORDER BY TimeStampOnSet ASC,(CASE WHEN StateType = 2 THEN 0 ELSE 1 END), (CASE WHEN TimeStampOnReset IS NULL THEN 1 ELSE 0 END), TimeStampOnReset ASC";

                    command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
					command.Parameters.AddWithValue("@RangeStart", criteria.StartTime.DBValue);
					command.Parameters.AddWithValue("@RangeEnd", criteria.EndTime.DBValue);

					using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					{
						while (dr.Read())
						{
							Add(StateItemForOee.GetStateItem(dr));
						}
					}
				}
			}

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		#endregion
	}
}

