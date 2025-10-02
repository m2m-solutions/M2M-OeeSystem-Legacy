using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class OeeDataCollection : BusinessListBase<OeeDataCollection, OeeData>
	{
		#region Business Methods

		public OeeData Add(string divisionId, string machineId, string articleNumber, int shift)
		{
			OeeData item = OeeData.NewOeeDataChild();
            item.GroupingId = M2MDataCenter.GetDivision(divisionId).GroupingId;
            item.DivisionId = divisionId;
			item.MachineId = machineId;
			item.ArticleNumber = articleNumber;
			item.Shift = shift;
			Add(item);
			return item;
		}

		#endregion

		#region Authorization Rules

		public static bool CanAddObject()
		{
			return CanEditObject();
		}

		public static bool CanEditObject()
		{
			return true;
		}

		public static bool CanDeleteObject()
		{
			return CanEditObject();
		}

		public static bool CanGetObject()
		{

			return true;
		}


		#endregion


		#region Factory Methods

		public static OeeDataCollection NewOeeDataCollection()
		{
			return new OeeDataCollection();
		}

		public static OeeDataCollection GetOeeDataCollection(string divisionId, string machineId, SmartDate startTime, SmartDate endTime)
		{
			return DataPortal.Fetch<OeeDataCollection>(new Criteria(divisionId, machineId, startTime, endTime));
		}

		private OeeDataCollection()
		{ /* Require use of factory methods */ }

		#endregion


		#region Data Access

		[Serializable()]
		private class Criteria
		{
			private string m_DivisionId;
            private string m_MachineId;
			private SmartDate m_StartTime;
			private SmartDate m_EndTime;

			public string DivisionId
			{
				get { return m_DivisionId; }
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


			public Criteria(string divisionId, string machineId, SmartDate startTime, SmartDate endTime)
			{ 
				m_DivisionId = divisionId;
                m_MachineId = machineId;
				m_StartTime = startTime;
				m_EndTime = endTime;
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
                    string machineCriteria = criteria.MachineId != "" ? @"MachineId=@MachineId AND " : "";

					command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT " +
											@"OeeDataId," +
                                            @"GroupingId," +
                                            @"DivisionId," +
											@"MachineId," +
											@"Shift," +
											@"ArticleNumber," +
											@"StartTime," +
											@"EndTime," +
											@"AutoTime," +
											@"NoProductionTime," +
                                            @"NotConnectedTime," +
                                            @"FlowErrorTime," +
                                            @"ChangeOverTime," +
											@"ProducedItems," +
											@"DiscardedItems" +
											@" FROM OeeData" +
											@" WHERE " +
											@"DivisionId=@DivisionId AND " +
                                            machineCriteria +
											@"StartTime<@EndTime AND " +
											@"EndTime>@StartTime";

					command.Parameters.AddWithValue("@DivisionId", criteria.DivisionId);
                    if (criteria.MachineId != "")
                        command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
                    command.Parameters.AddWithValue("@EndTime", criteria.EndTime.DBValue);
					command.Parameters.AddWithValue("@StartTime", criteria.StartTime.DBValue);
					
					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(OeeData.GetOeeDataChild(dataReader));
						}
					}
				}
			}

			RaiseListChangedEvents = true;
		}

		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			SqlConnection connection;
			
			bool createdConnection = false;
			if (ApplicationContext.LocalContext["cn"] != null)
			{
				connection = (SqlConnection)ApplicationContext.LocalContext["cn"];
			}
			else
			{
				createdConnection = true;
				connection = new SqlConnection(Database.SystemConnectionString);
				connection.Open();
				ApplicationContext.LocalContext["cn"] = connection;
			}

			foreach (OeeData item in DeletedList)
				item.DeleteSelf();
			DeletedList.Clear();

			foreach (OeeData item in this)
				if (item.IsNew)
					item.Insert();
				else
					item.Update();

			if (createdConnection && (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client))
			{
				ApplicationContext.LocalContext.Remove("cn");
				connection.Dispose();
			}

			RaiseListChangedEvents = true;
		}

		#endregion
	}
}