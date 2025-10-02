using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class OeeData : BusinessBase<OeeData>
	{
		#region Business Methods
		protected Guid m_OeeDataId = Guid.NewGuid();
        protected int m_GroupingId = 0;
		protected string m_DivisionId = String.Empty;
		protected string m_MachineId = String.Empty;
		protected int m_Shift = -1;
		protected string m_ArticleNumber = String.Empty;
		protected SmartDate m_StartTime = new SmartDate();
		protected SmartDate m_EndTime = new SmartDate();
		protected double m_AutoTime = 0.0;
		protected double m_NoProductionTime = 0.0;
        protected double m_NotConnectedTime = 0.0;
        protected double m_FlowErrorTime = 0.0;
        protected double m_ChangeOverTime = 0.0;
		protected int m_ProducedItems = 0;
		protected int m_DiscardedItems = 0;

		public Guid OeeDataId
		{
			get
			{
				CanReadProperty("OeeDataId", true);
				return m_OeeDataId;
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

		public SmartDate StartTime
		{
			get
			{
				CanReadProperty("StartTime", true);
				return m_StartTime;
			}
			set
			{
				CanWriteProperty("StartTime", true);
				if (m_StartTime != value)
				{
					m_StartTime = value;
					PropertyHasChanged("StartTime");
				}
			}
		}

		public SmartDate EndTime
		{
			get
			{
				CanReadProperty("EndTime", true);
				return m_EndTime;
			}
			set
			{
				CanWriteProperty("EndTime", true);
				if (m_EndTime != value)
				{
					m_EndTime = value;
					PropertyHasChanged("EndTime");
				}
			}
		}

		public double AutoTime
		{
			get
			{
				CanReadProperty("AutoTime", true);
				return m_AutoTime;
			}
			set
			{
				CanWriteProperty("AutoTime", true);
				if (m_AutoTime != value)
				{
					m_AutoTime = value;
					PropertyHasChanged("AutoTime");
				}
			}
		}

		public double NoProductionTime
		{
			get
			{
				CanReadProperty("NoProductionTime", true);
				return m_NoProductionTime;
			}
			set
			{
				CanWriteProperty("NoProductionTime", true);
				if (m_NoProductionTime != value)
				{
					m_NoProductionTime = value;
					PropertyHasChanged("NoProductionTime");
				}
			}
		}

        public double NotConnectedTime
        {
            get
            {
                CanReadProperty("NotConnectedTime", true);
                return m_NotConnectedTime;
            }
            set
            {
                CanWriteProperty("NotConnectedTime", true);
                if (m_NotConnectedTime != value)
                {
                    m_NotConnectedTime = value;
                    PropertyHasChanged("NotConnectedTime");
                }
            }
        }

        public double FlowErrorTime
        {
            get
            {
                CanReadProperty("FlowErrorTime", true);
                return m_FlowErrorTime;
            }
            set
            {
                CanWriteProperty("FlowErrorTime", true);
                if (m_FlowErrorTime != value)
                {
                    m_FlowErrorTime = value;
                    PropertyHasChanged("FlowErrorTime");
                }
            }
        }

        public double ChangeOverTime
        {
            get
            {
                CanReadProperty("ChangeOverTime", true);
                return m_ChangeOverTime;
            }
            set
            {
                CanWriteProperty("ChangeOverTime", true);
                if (m_ChangeOverTime != value)
                {
                    m_ChangeOverTime = value;
                    PropertyHasChanged("ChangeOverTime");
                }
            }
        }

		public int ProducedItems
		{
			get
			{
				CanReadProperty("ProducedItems", true);
				return m_ProducedItems;
			}
			set
			{
				CanWriteProperty("ProducedItems", true);
				if (m_ProducedItems != value)
				{
					m_ProducedItems = value;
					PropertyHasChanged("ProducedItems");
				}
			}
		}

		public int DiscardedItems
		{
			get
			{
				CanReadProperty("DiscardedItems", true);
				return m_DiscardedItems;
			}
			set
			{
				CanWriteProperty("DiscardedItems", true);
				if (m_DiscardedItems != value)
				{
					m_DiscardedItems = value;
					PropertyHasChanged("DiscardedItems");
				}
			}
		}
		
		// == Public collection properties ==
		protected override object GetIdValue()
		{
			return m_OeeDataId;
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

		public static OeeData NewOeeDataRoot()
		{
			return DataPortal.Create<OeeData>(new RootCriteria());
		}

		internal static OeeData NewOeeDataChild()
		{
			return DataPortal.Create<OeeData>(new ChildCriteria());
		}

		public static OeeData GetOeeDataRoot(Guid oeeDataId)
		{
			return DataPortal.Fetch<OeeData>(
			  new RootCriteria(oeeDataId));
		}

		internal static OeeData GetOeeDataChild(
		  SafeDataReader dr)
		{
			return new OeeData(dr);
		}

		public static void DeleteOeeData(Guid oeeDataId)
		{
			DataPortal.Delete(new RootCriteria(oeeDataId));
		}

		protected OeeData()
		{
			/* require use of factory methods */
		}

		protected OeeData(SafeDataReader dr)
			: this()
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		[Serializable]
		protected class RootCriteria
		{
			private Guid m_OeeDataId = Guid.Empty;

			public Guid OeeDataId
			{
				get { return m_OeeDataId; }
			}

			public RootCriteria(Guid oeeDataId)
			{
				m_OeeDataId = oeeDataId;
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
											@" WHERE OeeDataId = @OeeDataId";

					command.Parameters.AddWithValue(@"@OeeDataId", criteria.OeeDataId);

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
			m_OeeDataId = dr.GetGuid("OeeDataId");
            m_GroupingId = dr.GetInt32("GroupingId");
			m_DivisionId = dr.GetString("DivisionId");
			m_MachineId = dr.GetString("MachineId");
			m_Shift = dr.GetInt32("Shift");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_StartTime = dr.GetSmartDate("StartTime");
			m_EndTime = dr.GetSmartDate("EndTime");
			m_AutoTime = dr.GetDouble("AutoTime");
			m_NoProductionTime = dr.GetDouble("NoProductionTime");
            m_NotConnectedTime = dr.GetDouble("NotConnectedTime");
            m_FlowErrorTime = dr.GetDouble("FlowErrorTime");
            m_ChangeOverTime = dr.GetDouble("ChangeOverTime");
			m_ProducedItems = dr.GetInt32("ProducedItems");
			m_DiscardedItems = dr.GetInt32("DiscardedItems");
		}

		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "INSERT INTO OeeData (" +
											"OeeDataId," +
                                            "GroupingId," +
											"DivisionId," +
											"MachineId," +
											"Shift," +
											"ArticleNumber," +
											"StartTime," +
											"EndTime," +
											"AutoTime," +
											"NoProductionTime," +
                                            "NotConnectedTime," +
                                            "FlowErrorTime," +
                                            "ChangeOverTime," +
											"ProducedItems," +
											"DiscardedItems" +
											") VALUES (" +
											"@OeeDataId," +
                                            "@GroupingId," +
											"@DivisionId," +
											"@MachineId," +
											"@Shift," +
											"@ArticleNumber," +
											"@StartTime," +
											"@EndTime," +
											"@AutoTime," +
											"@NoProductionTime," +
                                            "@NotConnectedTime," +
                                            "@FlowErrorTime," +
                                            "@ChangeOverTime," +
											"@ProducedItems," +
											"@DiscardedItems)";

					command.Parameters.AddWithValue(@"@OeeDataId", m_OeeDataId);
                    command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
                    command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@Shift", m_Shift);
					command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
					command.Parameters.AddWithValue(@"@StartTime", m_StartTime.DBValue);
					command.Parameters.AddWithValue(@"@EndTime", m_EndTime.DBValue);
					command.Parameters.AddWithValue(@"@AutoTime", m_AutoTime);
					command.Parameters.AddWithValue(@"@NoProductionTime", m_NoProductionTime);
                    command.Parameters.AddWithValue(@"@NotConnectedTime", m_NotConnectedTime);
                    command.Parameters.AddWithValue(@"@FlowErrorTime", m_FlowErrorTime);
                    command.Parameters.AddWithValue(@"@ChangeOverTime", m_ChangeOverTime);
					command.Parameters.AddWithValue(@"@ProducedItems", m_ProducedItems);
					command.Parameters.AddWithValue(@"@DiscardedItems", m_DiscardedItems);
				
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
					command.CommandText = "UPDATE OeeData SET " +
                                            "GroupingId=@GroupingId," +
											"DivisionId=@DivisionId," +
											"MachineId=@MachineId," +
											"Shift=@Shift," +
											"ArticleNumber=@ArticleNumber," +
											"StartTime=@StartTime," +
											"EndTime=@EndTime," +
											"AutoTime=@AutoTime," +
											"NoProductionTime=@NoProductionTime," +
                                            "NotConnectedTime=@NotConnectedTime," +
                                            "FlowErrorTime=@FlowErrorTime," +
                                            "ChangeOverTime=@ChangeOverTime," +
											"ProducedItems=@ProducedItems," +
											"DiscardedItems=@DiscardedItems" +
											" WHERE OeeDataId=@OeeDataId";

                    command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
					command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@Shift", m_Shift);
					command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
					command.Parameters.AddWithValue(@"@StartTime", m_StartTime.DBValue);
					command.Parameters.AddWithValue(@"@EndTime", m_EndTime.DBValue);
					command.Parameters.AddWithValue(@"@AutoTime", m_AutoTime);
					command.Parameters.AddWithValue(@"@NoProductionTime", m_NoProductionTime);
                    command.Parameters.AddWithValue(@"@NotConnectedTime", m_NotConnectedTime);
                    command.Parameters.AddWithValue(@"@FlowErrorTime", m_FlowErrorTime);
                    command.Parameters.AddWithValue(@"@ChangeOverTime", m_ChangeOverTime);
					command.Parameters.AddWithValue(@"@ProducedItems", m_ProducedItems);
					command.Parameters.AddWithValue(@"@DiscardedItems", m_DiscardedItems);
					command.Parameters.AddWithValue(@"@OeeDataId", m_OeeDataId);
					
					command.ExecuteNonQuery();
				}
			}
		}

		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new RootCriteria(m_OeeDataId));
		}

		private void DataPortal_Delete(RootCriteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = @"DELETE FROM OeeData WHERE " +
											@"OeeDataId=@OeeDataId";

					command.Parameters.AddWithValue(@"@OeeDataId", criteria.OeeDataId);

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
				command.CommandText = "INSERT INTO OeeData (" +
										"OeeDataId," +
                                        "GroupingId," +
										"DivisionId," +
										"MachineId," +
										"Shift," +
										"ArticleNumber," +
										"StartTime," +
										"EndTime," +
										"AutoTime," +
										"NoProductionTime," +
                                        "NotConnectedTime," +
                                        "FlowErrorTime," +
                                        "ChangeOverTime," +
										"ProducedItems," +
										"DiscardedItems" +
										") VALUES (" +
										"@OeeDataId," +
                                        "@GroupingId," +
										"@DivisionId," +
										"@MachineId," +
										"@Shift," +
										"@ArticleNumber," +
										"@StartTime," +
										"@EndTime," +
										"@AutoTime," +
										"@NoProductionTime," +
                                        "@NotConnectedTime," +
                                        "@FlowErrorTime," +
                                        "@ChangeOverTime," +
										"@ProducedItems," +
										"@DiscardedItems)";

				command.Parameters.AddWithValue(@"@OeeDataId", m_OeeDataId);
                command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
                command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
				command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
				command.Parameters.AddWithValue(@"@Shift", m_Shift);
				command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
				command.Parameters.AddWithValue(@"@StartTime", m_StartTime.DBValue);
				command.Parameters.AddWithValue(@"@EndTime", m_EndTime.DBValue);
				command.Parameters.AddWithValue(@"@AutoTime", m_AutoTime);
				command.Parameters.AddWithValue(@"@NoProductionTime", m_NoProductionTime);
                command.Parameters.AddWithValue(@"@NotConnectedTime", m_NotConnectedTime);
                command.Parameters.AddWithValue(@"@FlowErrorTime", m_FlowErrorTime);
                command.Parameters.AddWithValue(@"@ChangeOverTime", m_ChangeOverTime);
				command.Parameters.AddWithValue(@"@ProducedItems", m_ProducedItems);
				command.Parameters.AddWithValue(@"@DiscardedItems", m_DiscardedItems);

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
				command.CommandText = "UPDATE OeeData SET " +
                                        "GroupingId=@GroupingId," +
                                        "DivisionId=@DivisionId," +
										"MachineId=@MachineId," +
										"Shift=@Shift," +
										"ArticleNumber=@ArticleNumber," +
										"StartTime=@StartTime," +
										"EndTime=@EndTime," +
										"AutoTime=@AutoTime," +
										"NoProductionTime=@NoProductionTime," +
                                        "NotConnectedTime=@NotConnectedTime," +
                                        "FlowErrorTime=@FlowErrorTime," +
                                        "ChangeOverTime=@ChangeOverTime," +
										"ProducedItems=@ProducedItems," +
										"DiscardedItems=@DiscardedItems" +
										" WHERE OeeDataId=@OeeDataId";

                command.Parameters.AddWithValue(@"@GroupingId", m_GroupingId);
				command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
				command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
				command.Parameters.AddWithValue(@"@Shift", m_Shift);
				command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);
				command.Parameters.AddWithValue(@"@StartTime", m_StartTime.DBValue);
				command.Parameters.AddWithValue(@"@EndTime", m_EndTime.DBValue);
				command.Parameters.AddWithValue(@"@AutoTime", m_AutoTime);
				command.Parameters.AddWithValue(@"@NoProductionTime", m_NoProductionTime);
                command.Parameters.AddWithValue(@"@NotConnectedTime", m_NotConnectedTime);
                command.Parameters.AddWithValue(@"@FlowErrorTime", m_FlowErrorTime);
                command.Parameters.AddWithValue(@"@ChangeOverTime", m_ChangeOverTime);
				command.Parameters.AddWithValue(@"@ProducedItems", m_ProducedItems);
				command.Parameters.AddWithValue(@"@DiscardedItems", m_DiscardedItems);
				command.Parameters.AddWithValue(@"@OeeDataId", m_OeeDataId);

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
				command.CommandText = @"DELETE FROM OeeData WHERE " +
										@"OeeDataId=@OeeDataId";

				command.Parameters.AddWithValue(@"@OeeDataId", m_OeeDataId);

				command.ExecuteNonQuery();
			}
		}

		#endregion

		#region Exists

		public static bool Exists(Guid oeeDataId)
		{
			bool exists = false;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT COUNT(*) FROM OeeData WHERE " +
												@"OeeDataId=@OeeDataId";

					command.Parameters.AddWithValue(@"@OeeDataId", oeeDataId);

					int count = (int)command.ExecuteScalar();
					exists = (count > 0);
				}
			}
			return exists;
		}

		#endregion
	}
}