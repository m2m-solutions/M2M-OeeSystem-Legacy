using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class Division : BusinessBase<Division>
	{
		#region Business Methods 
		protected string m_DivisionId = String.Empty;
		protected string m_DisplayName = String.Empty;
        protected int m_GroupingId = 0;
		protected string m_Notes = String.Empty;

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

		public string DisplayName
		{
			get
			{
				CanReadProperty("DisplayName", true);
				return m_DisplayName;
			}
			set
			{
				CanWriteProperty("DisplayName", true);
				if (m_DisplayName != value)
				{
					m_DisplayName = value;
					PropertyHasChanged("DisplayName");
				}
			}
		}

        public int GroupingId
        {
            get
            {
                CanReadProperty("GroupingId", true);
                return m_GroupingId;
            }
            set
            {
                CanWriteProperty("GroupingId", true);
                if (m_GroupingId != value)
                {
                    m_GroupingId = value;
                    PropertyHasChanged("GroupingId");
                }
            }
        }
        
		public string Notes
		{
			get
			{
				CanReadProperty("Notes", true);
				return m_Notes;
			}
			set
			{
				CanWriteProperty("Notes", true);
				if (m_Notes != value)
				{
					m_Notes = value;
					PropertyHasChanged("Notes");
				}
			}
		}

		// == Public collection properties ==
		protected override object GetIdValue()
		{
			return m_DivisionId;
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

		public static Division NewDivision()
		{
			return DataPortal.Create<Division>();
		}

		public static Division GetDivision(string divisionId)
		{
			return DataPortal.Fetch<Division>(new Criteria(divisionId));
		}

		public static void DeleteDivision(string divisionId)
		{
			DataPortal.Delete(new Criteria(divisionId));
		}

		protected Division()
		{
			/* require use of factory methods */
		}
	
		#endregion
	
		#region Data Access

		[Serializable]
		private class Criteria
		{
			private string m_DivisionId = null;

			public string DivisionId
			{
				get { return m_DivisionId; }
			}

			public Criteria(string divisionId)
			{
				m_DivisionId = divisionId;
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
                    command.CommandText = @"SELECT DivisionId,DisplayName,GroupingId,Notes" +
                                          @" FROM Divisions" + 
	                                      @" WHERE DivisionId=@DivisionId";

					command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if(dataReader.Read())
						{
							m_DivisionId = dataReader.GetString("DivisionId");
							m_DisplayName = dataReader.GetString("DisplayName");
                            m_GroupingId = dataReader.GetInt32("GroupingId");
							m_Notes = dataReader.GetString("Notes");
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
                    command.CommandText = @"INSERT INTO Divisions " +
                                          @"(DivisionId,DisplayName,GroupingId,Notes)" +
                                          @" VALUES " +
                                          @"(@DivisionId,@DisplayName,@GroupingId,@Notes)";

					command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue(@"@DisplayName", m_DisplayName);
                    command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
					command.Parameters.AddWithValue(@"@Notes", m_Notes);
					
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
                    command.CommandText = @"UPDATE Divisions" +
	                                      @" SET DisplayName=@DisplayName,GroupingId=@GroupingId,Notes=@Notes" +
	                                      @" WHERE " +
	                                      @"DivisionId=@DivisionId";

					command.Parameters.AddWithValue(@"@DisplayName", m_DisplayName);
                    command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
					command.Parameters.AddWithValue(@"@Notes", m_Notes);
					command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);

					command.ExecuteNonQuery();
				}
			}
		}

		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(m_DivisionId));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE Divisions WHERE DivisionId=@DivisionId";

					command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);

					command.ExecuteNonQuery();
					MarkNew();
				}
			}
		}

		#endregion

		#region Exists

		public static bool Exists(Guid divisionId)
		{
			bool exists = false;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*)" + 
	                                      @" FROM Divisions WHERE DivisionId=@DivisionId";
					command.Parameters.AddWithValue(@"@DivisionId", divisionId);

					int count = (int)command.ExecuteScalar();
					exists = (count > 0);
				}
			}
			return exists;
		}

		#endregion
	}
}