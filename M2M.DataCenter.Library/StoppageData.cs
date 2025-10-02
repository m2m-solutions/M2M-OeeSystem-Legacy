using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class StoppageData : BusinessBase<StoppageData>
	{
		#region Business Methods
		protected Guid m_StoppageDataId = Guid.NewGuid();
        protected int m_GroupingId = 0;
		protected string m_DivisionId = String.Empty;
		protected string m_MachineId = String.Empty;
		protected int m_Shift = -1;
		protected string m_ArticleNumber = String.Empty;
        protected string m_StopReason = "";
        protected int m_CategoryId = -1;
        protected bool m_SystemError = false;
        protected SmartDate m_StopDate = new SmartDate();
        protected double m_ElapsedTime = 0.0;
        protected int m_NumberOfStops = 0;
        protected double m_StopRatio = 0.0;
        

		public Guid StoppageDataId
		{
			get
			{
				CanReadProperty("StoppageDataId", true);
				return m_StoppageDataId;
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
				if (m_Shift != value)
				{
					m_Shift = value;
					PropertyHasChanged("Shift");
				}
			}
		}

		public string ArticleNumber
		{
			get
			{
				CanReadProperty("ArticleNumber", true);
				return m_ArticleNumber;
			}
			set
			{
				CanWriteProperty("ArticleNumber", true);
				if (m_ArticleNumber != value)
				{
					m_ArticleNumber = value;
					PropertyHasChanged("ArticleNumber");
				}
			}
		}

        public string StopReason
        {
            get
            {
                CanReadProperty("StopReason", true);
                return m_StopReason;
            }
            set
            {
                CanWriteProperty("StopReason", true);
                if (m_StopReason != value)
                {
                    m_StopReason = value;
                    PropertyHasChanged("StopReason");
                }
            }
        }

		public SmartDate StopDate
		{
			get
			{
                CanReadProperty("StopDate", true);
                return m_StopDate;
			}
			set
			{
                CanWriteProperty("StopDate", true);
                if (m_StopDate != value)
				{
                    m_StopDate = value;
                    PropertyHasChanged("StopDate");
				}
			}
		}

		public double ElapsedTime
		{
			get
			{
				CanReadProperty("ElapsedTime", true);
				return m_ElapsedTime;
			}
			set
			{
				CanWriteProperty("ElapsedTime", true);
				if (m_ElapsedTime != value)
				{
					m_ElapsedTime = value;
					PropertyHasChanged("ElapsedTime");
				}
			}
		}

		public int NumberOfStops
		{
			get
			{
				CanReadProperty("NumberOfStops", true);
				return m_NumberOfStops;
			}
			set
			{
				CanWriteProperty("NumberOfStops", true);
				if (m_NumberOfStops != value)
				{
					m_NumberOfStops = value;
					PropertyHasChanged("NumberOfStops");
				}
			}
		}

        public double StopRatio
        {
            get
            {
                CanReadProperty("StopRatio", true);
                return m_StopRatio;
            }
            set
            {
                CanWriteProperty("StopRatio", true);
                if (m_StopRatio != value)
                {
                    m_StopRatio = value;
                    PropertyHasChanged("StopRatio");
                }
            }
        }

		public int CategoryId
		{
			get
			{
                CanReadProperty("CategoryId", true);
				return m_CategoryId;
			}
			set
			{
                CanWriteProperty("CategoryId", true);
                if (m_CategoryId != value)
				{
                    m_CategoryId = value;
                    PropertyHasChanged("CategoryId");
				}
			}
		}

        public bool SystemError
        {
            get
            {
                CanReadProperty("SystemError", true);
                return m_SystemError;
            }
            set
            {
                CanWriteProperty("SystemError", true);
                if (m_SystemError != value)
                {
                    m_SystemError = value;
                    PropertyHasChanged("SystemError");
                }
            }
        }
		
		// == Public collection properties ==
		protected override object GetIdValue()
		{
			return m_StoppageDataId;
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

		public static StoppageData NewStoppageDataRoot()
		{
			return DataPortal.Create<StoppageData>(new RootCriteria());
		}

		internal static StoppageData NewStoppageDataChild()
		{
			return DataPortal.Create<StoppageData>(new ChildCriteria());
		}

		public static StoppageData GetStoppageDataRoot(Guid StoppageDataId)
		{
			return DataPortal.Fetch<StoppageData>(
			  new RootCriteria(StoppageDataId));
		}

		internal static StoppageData GetStoppageDataChild(
		  SafeDataReader dr)
		{
			return new StoppageData(dr);
		}

		public static void DeleteStoppageData(Guid StoppageDataId)
		{
			DataPortal.Delete(new RootCriteria(StoppageDataId));
		}

		protected StoppageData()
		{
			/* require use of factory methods */
		}

		protected StoppageData(SafeDataReader dr)
			: this()
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		[Serializable]
		protected class RootCriteria
		{
			private Guid m_StoppageDataId = Guid.Empty;

			public Guid StoppageDataId
			{
				get { return m_StoppageDataId; }
			}

			public RootCriteria(Guid StoppageDataId)
			{
				m_StoppageDataId = StoppageDataId;
			}

			public RootCriteria()
			{
			}
		}

		[Serializable()]
		private class ChildCriteria
		{ }

		private void DataPortal_Create(RootCriteria criteria)
		{
			DoCreate();
		}

		private void DataPortal_Create(ChildCriteria criteria)
		{
			MarkAsChild();
			DoCreate();
		}

		private void DoCreate()
		{
			ValidationRules.CheckRules();
		}

		private void DataPortal_Fetch(RootCriteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT " +
											@"StoppageDataId," +
                                            @"GroupingId," +
											@"DivisionId," +
											@"MachineId," +
											@"Shift," +
											@"ArticleNumber," +
											@"StopDate," +
											@"ElapsedTime," +
											@"StopReason," +
											@"NumberOfStops," +
                                            @"StopRation," +
                                            @"SystemError," +
											@"Category" +
											@" FROM StoppageData" +
											@" WHERE StoppageDataId = @StoppageDataId";

					command.Parameters.AddWithValue(@"@StoppageDataId", criteria.StoppageDataId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if (dataReader.Read())
						{
							DoFetch(dataReader);
						}
					}
				}
			}

			ValidationRules.CheckRules();
		}

		private void Fetch(SafeDataReader dr)
		{
			MarkAsChild();
			DoFetch(dr);
			MarkOld();
		}

		private void DoFetch(SafeDataReader dr)
		{
			m_StoppageDataId = dr.GetGuid("StoppageDataId");
            m_GroupingId = dr.GetInt32("GroupingId");
			m_DivisionId = dr.GetString("DivisionId");
			m_MachineId = dr.GetString("MachineId");
			m_Shift = dr.GetInt32("Shift");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_StopDate = dr.GetSmartDate("StopDate");
			m_ElapsedTime = dr.GetDouble("ElapsedTime");
			m_StopReason = dr.GetString("StopReason");
			m_NumberOfStops = dr.GetInt32("NumberOfStops");
            m_StopRatio = dr.GetDouble("StopRatio");
			m_CategoryId = dr.GetInt32("Category");
            m_SystemError = dr.GetBoolean("SystemError");
		}

		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "INSERT INTO StoppageData (" +
											"StoppageDataId," +
                                            "GroupingId," +
											"DivisionId," +
											"MachineId," +
											"Shift," +
											"ArticleNumber," +
											"StopDate," +
											"ElapsedTime," +
											"StopReason," +
                                            "SystemError," +
											"NumberOfStops," +
                                            "StopRatio," +
											"Category" +
											") VALUES (" +
											"@StoppageDataId," +
                                            "@GroupingId," +
											"@DivisionId," +
											"@MachineId," +
											"@Shift," +
											"@ArticleNumber," +
											"@StopDate," +
											"@ElapsedTime," +
											"@StopReason," +
                                            "@SystemError," +
											"@NumberOfStops," +
                                            "@StopRatio," +
											"@Category)";

					command.Parameters.AddWithValue(@"@StoppageDataId", m_StoppageDataId);
                    command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
					command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@Shift", m_Shift);
					command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
					command.Parameters.AddWithValue(@"@StopDate", m_StopDate.DBValue);
					command.Parameters.AddWithValue(@"@ElapsedTime", m_ElapsedTime);
					command.Parameters.AddWithValue(@"@StopReason", m_StopReason);
                    command.Parameters.AddWithValue(@"@SystemError", m_SystemError);
                    command.Parameters.AddWithValue(@"@NumberOfStops", m_NumberOfStops);
                    command.Parameters.AddWithValue(@"@StopRatio", m_StopRatio);
					command.Parameters.AddWithValue(@"@Category", m_CategoryId);
				
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
					command.CommandText = "UPDATE StoppageData SET " +
                                            "GroupingId=@GroupingId," +
											"DivisionId=@DivisionId," +
											"MachineId=@MachineId," +
											"Shift=@Shift," +
											"ArticleNumber=@ArticleNumber," +
											"StopDate=@StopDate," +
											"ElapsedTime=@ElapsedTime," +
											"StopReason=@StopReason," +
											"NumberOfStops=@NumberOfStops," +
                                            "StopRatio=@StopRatio," +
                                            "SystemError=@SystemError," +
											"Category=@Category" +
											" WHERE StoppageDataId=@StoppageDataId";

                    command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
					command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@Shift", m_Shift);
					command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
					command.Parameters.AddWithValue(@"@StopDate", m_StopDate.DBValue);
					command.Parameters.AddWithValue(@"@ElapsedTime", m_ElapsedTime);
					command.Parameters.AddWithValue(@"@StopReason", m_StopReason);
					command.Parameters.AddWithValue(@"@NumberOfStops", m_NumberOfStops);
                    command.Parameters.AddWithValue(@"@StopRatio", m_StopRatio);
                    command.Parameters.AddWithValue(@"@SystemError", m_SystemError);
					command.Parameters.AddWithValue(@"@Category", m_CategoryId);
					command.Parameters.AddWithValue(@"@StoppageDataId", m_StoppageDataId);
					
					command.ExecuteNonQuery();
				}
			}
		}

		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new RootCriteria(m_StoppageDataId));
		}

		private void DataPortal_Delete(RootCriteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = @"DELETE FROM StoppageData WHERE " +
											@"StoppageDataId=@StoppageDataId";

					command.Parameters.AddWithValue(@"@StoppageDataId", criteria.StoppageDataId);

					command.ExecuteNonQuery();
				}
			}
		}

		internal void Insert()
		{
			if (!this.IsDirty)
				return;

			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized");

			SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];
			
			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandText = "INSERT INTO StoppageData (" +
										"StoppageDataId," +
                                        "GroupingId," +
										"DivisionId," +
										"MachineId," +
										"Shift," +
										"ArticleNumber," +
										"StopDate," +
										"ElapsedTime," +
										"StopReason," +
										"NumberOfStops," +
                                        "StopRatio," +
                                        "SystemError," +
										"Category" +
										") VALUES (" +
										"@StoppageDataId," +
                                        "@GroupingId," +
										"@DivisionId," +
										"@MachineId," +
										"@Shift," +
										"@ArticleNumber," +
										"@StopDate," +
										"@ElapsedTime," +
										"@StopReason," +
										"@NumberOfStops," +
                                        "@StopRatio," +
                                        "@SystemError," +
										"@Category)";

				command.Parameters.AddWithValue(@"@StoppageDataId", m_StoppageDataId);
                command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
				command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
				command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
				command.Parameters.AddWithValue(@"@Shift", m_Shift);
				command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
				command.Parameters.AddWithValue(@"@StopDate", m_StopDate.DBValue);
				command.Parameters.AddWithValue(@"@ElapsedTime", m_ElapsedTime);
				command.Parameters.AddWithValue(@"@StopReason", m_StopReason);
				command.Parameters.AddWithValue(@"@NumberOfStops", m_NumberOfStops);
                command.Parameters.AddWithValue(@"@StopRatio", m_StopRatio);
                command.Parameters.AddWithValue(@"@SystemError", m_SystemError);
				command.Parameters.AddWithValue(@"@Category", m_CategoryId);

				command.ExecuteNonQuery();
			}
		
			MarkOld();
		}

		internal void Update()
		{
			if (!this.IsDirty)
				return;

			if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized");

			SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];
			
			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandText = "UPDATE StoppageData SET " +
                                        "GroupingId=@GroupingId," +
                                        "DivisionId=@DivisionId," +
										"MachineId=@MachineId," +
										"Shift=@Shift," +
										"ArticleNumber=@ArticleNumber," +
										"StopDate=@StopDate," +
										"ElapsedTime=@ElapsedTime," +
										"StopReason=@StopReason," +
										"NumberOfStops=@NumberOfStops," +
                                        "StopRatio=@StopRatio," +
                                        "SystemError=@SystemError," +
										"Category=@Category" +
										" WHERE StoppageDataId=@StoppageDataId";

                command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
                command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
				command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
				command.Parameters.AddWithValue(@"@Shift", m_Shift);
				command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
				command.Parameters.AddWithValue(@"@StopDate", m_StopDate.DBValue);
				command.Parameters.AddWithValue(@"@ElapsedTime", m_ElapsedTime);
				command.Parameters.AddWithValue(@"@StopReason", m_StopReason);
				command.Parameters.AddWithValue(@"@NumberOfStops", m_NumberOfStops);
                command.Parameters.AddWithValue(@"@StopRatio", m_StopRatio);
                command.Parameters.AddWithValue(@"@SystemError", m_SystemError);
				command.Parameters.AddWithValue(@"@Category", m_CategoryId);
				command.Parameters.AddWithValue(@"@StoppageDataId", m_StoppageDataId);

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

			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized");

			SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];
			
			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandText = @"DELETE FROM StoppageData WHERE " +
										@"StoppageDataId=@StoppageDataId";

				command.Parameters.AddWithValue(@"@StoppageDataId", m_StoppageDataId);

				command.ExecuteNonQuery();
			}
		}

		#endregion

		#region Exists

		public static bool Exists(Guid StoppageDataId)
		{
			bool exists = false;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT COUNT(*) FROM StoppageData WHERE " +
												@"StoppageDataId=@StoppageDataId";

					command.Parameters.AddWithValue(@"@StoppageDataId", StoppageDataId);

					int count = (int)command.ExecuteScalar();
					exists = (count > 0);
				}
			}
			return exists;
		}

		#endregion
	}
}