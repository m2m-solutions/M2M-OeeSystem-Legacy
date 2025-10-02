using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter;

namespace M2M.ChangeOver.Library
{
	[Serializable()]
	public partial class ChangeOverCalculateRequestCollection : BusinessListBase<ChangeOverCalculateRequestCollection, ChangeOverCalculateRequest>
	{
		#region Business Methods

		
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

		public static ChangeOverCalculateRequestCollection GetChangeOverCalculateRequestCollection()
		{
            return DataPortal.Fetch<ChangeOverCalculateRequestCollection>();
		}

        private ChangeOverCalculateRequestCollection()
		{ /* Require use of factory methods */ }

		#endregion


		#region Data Access

		private void DataPortal_Fetch()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
                    command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT " +
											@"Id," +
											@"EventId," +
                                            @"MachineId," +
											@"Timestamp" +
                                            @" FROM ChangeOverCalculateRequests" +
                                            @" ORDER BY " +
											@"MachineId,Timestamp";

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
                            Add(ChangeOverCalculateRequest.GetChangeOverCalculateRequest(dataReader));
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

            foreach (ChangeOverCalculateRequest item in DeletedList)
				item.DeleteSelf();
			DeletedList.Clear();

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