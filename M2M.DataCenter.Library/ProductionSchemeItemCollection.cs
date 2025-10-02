using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class ProductionSchemeItemCollection : BusinessListBase<ProductionSchemeItemCollection, ProductionSchemeItem>
	{

		#region Business Methods

		public ProductionSchemeItem Add(DateTime startTime, DateTime endTime, int shift, string divisionId, string machineId, string recurrenceRule, Guid recurrenceParentId)
		{
			ProductionSchemeItem item = ProductionSchemeItem.NewProductionSchemeItem();

			item.StartTime = startTime;
			item.EndTime = endTime;
			item.Shift = shift;
			item.DivisionId = divisionId;
			item.MachineId = machineId;
			item.RecurrenceRule = recurrenceRule;
			item.RecurrenceParentId = recurrenceParentId;

			Add(item);
			return item;
		}

		public ProductionSchemeItem GetItem(Guid id)
		{
			foreach (ProductionSchemeItem item in this)
			{
				if (item.Id == id)
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

		public static ProductionSchemeItemCollection NewProductionSchemeItemCollection()
		{
			return new ProductionSchemeItemCollection();
		}

		public static ProductionSchemeItemCollection GetProductionSchemeItemCollection()
		{
			return DataPortal.Fetch<ProductionSchemeItemCollection>(new Criteria());
		}

		public static ProductionSchemeItemCollection GetProductionSchemeItemCollection(string divisionId)
		{
			return DataPortal.Fetch<ProductionSchemeItemCollection>(new Criteria(divisionId));
		}

		protected ProductionSchemeItemCollection()
		{
		}

		#endregion


		#region Data Access

		[Serializable()]
		private class Criteria
		{
			private string m_DivisionId = String.Empty;

			public string DivisionId
			{
				get { return m_DivisionId; }
			}
			public Criteria()
			{

			}

			public Criteria(string divisionId)
			{
				m_DivisionId = divisionId;
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
                    string whereClause = "";
                    if (!String.IsNullOrEmpty(criteria.DivisionId))
                    {
                        whereClause = " WHERE DivisionId=@DivisionId";
                        command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);
                    }

					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id,Shift,StartTime,EndTime,DivisionId,MachineId,RecurrenceRule,RecurrenceParentId" +
                                          @" FROM ProductionScheme" +
	                                      whereClause;

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(ProductionSchemeItem.GetProductionSchemeItem(dataReader));
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

			foreach (ProductionSchemeItem item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();

			foreach (ProductionSchemeItem item in this)
			{
				if (item.IsNew)
				{
					item.Insert();
				}
				else
				{
					item.Update();
				}
			}

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