using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter;

namespace M2M.OeeCalculator.Library
{
	[Serializable()]
	public partial class OeeCalculateRequestCollection : BusinessListBase<OeeCalculateRequestCollection, OeeCalculateRequest>
	{
		#region Business Methods

        public OeeCalculateRequest GetItem(int id)
        {
            foreach (OeeCalculateRequest item in this)
            {
                if ((item.Id == id))
                {
                    return item;
                }
            }
            return null;

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

		public static OeeCalculateRequestCollection GetOeeCalculateRequestCollection()
		{
            return DataPortal.Fetch<OeeCalculateRequestCollection>();
		}

        private OeeCalculateRequestCollection()
		{ /* Require use of factory methods */ }

		#endregion


		#region Data Access

		[Serializable()]
		private class Criteria
		{
            
            public Criteria() 
            {
            }
		}

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
											@"DivisionId," +
                                            @"MachineId," +
											@"StartDate," +
											@"EndDate" +
                                            @" FROM OeeCalculateRequests" +
                                            @" ORDER BY " +
											@"DivisionId,MachineId,StartDate";

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
                            Add(OeeCalculateRequest.GetOeeCalculateRequest(dataReader));
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

            foreach (OeeCalculateRequest item in DeletedList)
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