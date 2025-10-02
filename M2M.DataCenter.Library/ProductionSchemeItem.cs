using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class ProductionSchemeItem : BusinessBase<ProductionSchemeItem>
	{
		#region Business Methods 
		private Guid m_Id = Guid.NewGuid();
		private int m_Shift = -1;
		private SmartDate m_StartTime = new SmartDate();
		private SmartDate m_EndTime = new SmartDate();
		private string m_DivisionId = String.Empty;
		private string m_MachineId = String.Empty;
        private string m_RecurrenceRule = String.Empty;
		private Guid? m_RecurrenceParentId = null;

		public Guid Id
		{
			get
			{
				CanReadProperty("Id", true);
				return m_Id;
			}
		}

		public int Shift
		{
			get
			{
				CanReadProperty("Shift", true);
				return m_Shift;
			}
			set
			{
				CanWriteProperty("Shift", true);
				if(m_Shift != value)
				{
					m_Shift = value;
					PropertyHasChanged("Shift");
				}
			}
		}

		public DateTime StartTime
		{
			get
			{
				CanReadProperty("StartTime", true);
				return m_StartTime.Date;
			}
			set
			{
				CanWriteProperty("StartTime", true);
				if (m_StartTime.Date != value)
				{
					m_StartTime = new SmartDate(value);
					PropertyHasChanged("StartTime");
				}
			}
		}

		public DateTime EndTime
		{
			get
			{
				CanReadProperty("EndTime", true);
				return m_EndTime.Date;
			}
			set
			{
				CanWriteProperty("EndTime", true);
				if (m_EndTime.Date != value)
				{
					m_EndTime = new SmartDate(value);
					PropertyHasChanged("EndTime");
				}
			}
		}

		public string DivisionId
		{
			get
			{
				CanReadProperty("DivisionId", true);
				return m_DivisionId;
			}
			set
			{
				CanWriteProperty("DivisionId", true);
				if (m_DivisionId != value)
				{
					m_DivisionId = value;
					PropertyHasChanged("DivisionId");
				}
			}
		}

		public string MachineId
		{
			get
			{
				CanReadProperty("MachineId", true);
				return m_MachineId;
			}
			set
			{
				CanWriteProperty("MachineId", true);
				if (m_MachineId != value)
				{
					m_MachineId = value;
					PropertyHasChanged("MachineId");
				}
			}
		}

		public string RecurrenceRule
		{
			get
			{
				CanReadProperty("RecurrenceRule", true);
				return m_RecurrenceRule;
			}
			set
			{
				CanWriteProperty("RecurrenceRule", true);
				if (m_RecurrenceRule != value)
				{
					m_RecurrenceRule = value;
					PropertyHasChanged("RecurrenceRule");
				}
			}
		}

		public Guid? RecurrenceParentId
		{
			get
			{
				CanReadProperty("RecurrenceParentId", true);
				return m_RecurrenceParentId;
			}
			set
			{
				CanWriteProperty("RecurrenceParentId", true);
				if (m_RecurrenceParentId != value)
				{
					m_RecurrenceParentId = value;
					PropertyHasChanged("RecurrenceParentId");
				}
			}
		}

		// == Public collection properties ==
		protected override object GetIdValue()
		{
			return m_Id;
		}


		#endregion
	
		#region Validation Rules

		protected override void AddBusinessRules()
		{

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

		public static ProductionSchemeItem NewProductionSchemeItem()
		{
			return DataPortal.Create<ProductionSchemeItem>();
		}

		public static ProductionSchemeItem GetProductionSchemeItem(Guid id)
		{
			return DataPortal.Fetch<ProductionSchemeItem>(new Criteria(id));
		}

		public static ProductionSchemeItem GetProductionSchemeItem(SafeDataReader dr)
		{
			return new ProductionSchemeItem(dr);
		}

		public static void DeleteProductionSchemeItem(Guid id)
		{
			DataPortal.Delete(new Criteria(id));
		}

		protected ProductionSchemeItem()
		{
			/* require use of factory methods */
		}

		protected ProductionSchemeItem(SafeDataReader dr) : this()
		{
			m_Id = dr.GetGuid("Id");
			m_Shift = dr.GetInt32("Shift");
			m_StartTime = dr.GetSmartDate("StartTime");
			m_EndTime = dr.GetSmartDate("EndTime");
			m_DivisionId = dr.GetString("DivisionId");
			m_MachineId = dr.GetString("MachineId");
			m_RecurrenceRule = dr.GetString("RecurrenceRule");
			m_RecurrenceParentId = dr.GetGuid("RecurrenceParentId");
			if (m_RecurrenceParentId.Value == Guid.Empty)
				m_RecurrenceParentId = null;

			MarkAsChild();
            MarkOld();
		}
	
		#endregion
	
		#region Data Access

		[Serializable]
		private class Criteria
		{
            private readonly Guid m_Id = Guid.Empty;

			public Guid Id
			{
				get { return m_Id; }
			}

			public Criteria(Guid id)
			{
				m_Id = id;
			}
		}

		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id,Shift,StartTime,EndTime,DivisionId,MachineId,RecurrenceRule,RecurrenceParentId" +
	                                      @" FROM ProductionScheme" +
	                                      @" WHERE Id=@Id";

					command.Parameters.AddWithValue(@"@Id", criteria.Id);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if(dataReader.Read())
						{
							m_Id = dataReader.GetGuid("Id");
							m_Shift = dataReader.GetInt32("Shift");
							m_StartTime = dataReader.GetSmartDate("StartTime");
							m_EndTime = dataReader.GetSmartDate("EndTime");
							m_DivisionId = dataReader.GetString("DivisionId");
							m_MachineId = dataReader.GetString("MachineId");
							m_RecurrenceRule = dataReader.GetString("RecurrenceRule");
							m_RecurrenceParentId = dataReader.GetGuid("RecurrenceParentId");
							if (m_RecurrenceParentId.Value == Guid.Empty)
								m_RecurrenceParentId = null;
						}
					}
				}
			}

			ValidationRules.CheckRules();
		}

		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO ProductionScheme " +
	                                      @"(Id,Shift,StartTime,EndTime,DivisionId,MachineId,RecurrenceRule,RecurrenceParentId)" +
	                                      @" VALUES " + 
	                                      @"(@Id,@Shift,@StartTime,@EndTime,@DivisionId,@MachineId,@RecurrenceRule,@RecurrenceParentId)";

					command.Parameters.AddWithValue(@"@Id", m_Id);
					command.Parameters.AddWithValue(@"@Shift", m_Shift);
					command.Parameters.AddWithValue(@"@StartTime", m_StartTime.DBValue);
					command.Parameters.AddWithValue(@"@EndTime", m_EndTime.DBValue);
					command.Parameters.AddWithValue("@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue("@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@RecurrenceRule", m_RecurrenceRule);
                    if(m_RecurrenceParentId != null)
						command.Parameters.AddWithValue(@"@RecurrenceParentId", m_RecurrenceParentId);
                    else
                        command.Parameters.AddWithValue(@"@RecurrenceParentId", DBNull.Value);
					command.ExecuteNonQuery();
				}
			}
		}

		protected override void DataPortal_Update()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE ProductionScheme" +
	                                      @" SET Shift=@Shift,StartTime=@StartTime,EndTime=@EndTime,DivisionId=@DivisionId,MachineId=@MachineId,RecurrenceRule=@RecurrenceRule,RecurrenceParentId=@RecurrenceParentId" +
	                                      @" WHERE Id=@id";

					command.Parameters.AddWithValue(@"@Shift", m_Shift);
					command.Parameters.AddWithValue(@"@StartTime", m_StartTime.DBValue);
					command.Parameters.AddWithValue(@"@EndTime", m_EndTime.DBValue);
                    command.Parameters.AddWithValue(@"@RecurrenceRule", m_RecurrenceRule);
                    if (m_RecurrenceParentId != null)
                        command.Parameters.AddWithValue(@"@RecurrenceParentId", m_RecurrenceParentId);
                    else
                        command.Parameters.AddWithValue(@"@RecurrenceParentId", DBNull.Value);
					command.Parameters.AddWithValue("@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue("@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@Id", m_Id);

					command.ExecuteNonQuery();
				}
			}
		}

		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(m_Id));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE ProductionScheme	WHERE Id=@Id";

					command.Parameters.AddWithValue(@"@Id", criteria.Id);

					command.ExecuteNonQuery();
					MarkNew();
				}
			}
		}

		internal void Insert()
		{
			if (!this.IsDirty)
				return;

			SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];

			using (SqlCommand command = connection.CreateCommand())
			{
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO ProductionScheme " +
                                      @"(Id,Shift,StartTime,EndTime,DivisionId,MachineId,RecurrenceRule,RecurrenceParentId)" +
                                      @" VALUES " +
                                      @"(@Id,@Shift,@StartTime,@EndTime,@DivisionId,@MachineId,@RecurrenceRule,@RecurrenceParentId)";

                command.Parameters.AddWithValue(@"@Id", m_Id);
                command.Parameters.AddWithValue(@"@Shift", m_Shift);
                command.Parameters.AddWithValue(@"@StartTime", m_StartTime.DBValue);
                command.Parameters.AddWithValue(@"@EndTime", m_EndTime.DBValue);
                command.Parameters.AddWithValue("@DivisionId", m_DivisionId);
                command.Parameters.AddWithValue("@MachineId", m_MachineId);
                command.Parameters.AddWithValue(@"@RecurrenceRule", m_RecurrenceRule);
                if (m_RecurrenceParentId != null)
                    command.Parameters.AddWithValue(@"@RecurrenceParentId", m_RecurrenceParentId);
                else
                    command.Parameters.AddWithValue(@"@RecurrenceParentId", DBNull.Value);

				command.ExecuteNonQuery();
			}

			MarkOld();
		}

		internal void Update()
		{
			if (!this.IsDirty)
				return;

			SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];

			using (SqlCommand command = connection.CreateCommand())
			{
                command.CommandType = CommandType.Text;
                command.CommandText = @"UPDATE ProductionScheme" +
                                      @" SET Shift=@Shift,StartTime=@StartTime,EndTime=@EndTime,DivisionId=@DivisionId,MachineId=@MachineId,RecurrenceRule=@RecurrenceRule,RecurrenceParentId=@RecurrenceParentId" +
                                      @" WHERE Id=@id";

				command.Parameters.AddWithValue(@"@Shift", m_Shift);
				command.Parameters.AddWithValue("@StartDate", m_StartTime);
				command.Parameters.AddWithValue("@EndDate", m_EndTime);
				command.Parameters.AddWithValue("@DivisionId", m_DivisionId);
				command.Parameters.AddWithValue("@MachineId", m_MachineId);
                command.Parameters.AddWithValue(@"@RecurrenceRule", m_RecurrenceRule);
                if (m_RecurrenceParentId != null)
                    command.Parameters.AddWithValue(@"@RecurrenceParentId", m_RecurrenceParentId);
                else
                    command.Parameters.AddWithValue(@"@RecurrenceParentId", DBNull.Value);
				command.Parameters.AddWithValue("@Id", m_Id);
				
				command.ExecuteNonQuery();
			}

			MarkOld();
		}

		internal void DeleteSelf()
		{
			if (!this.IsDirty)
				return;

			if (this.IsNew)
				return;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE ProductionScheme	WHERE Id=@Id";

					command.Parameters.AddWithValue("@Id", m_Id);

					command.ExecuteNonQuery();
				}
			}

			MarkNew();
		}

		#endregion

		#region Exists

		public static bool Exists(Guid id)
		{
			bool exists = false;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*)" +
                                          @" FROM ProductionScheme WHERE Id=@Id";
					command.Parameters.AddWithValue(@"@Id", id);

					int count = (int)command.ExecuteScalar();
					exists = (count > 0);
				}
			}
			return exists;
		}

		#endregion
	}
}
