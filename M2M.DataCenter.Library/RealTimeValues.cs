using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
	[Serializable()]
	public class RealTimeValues : BusinessBase<RealTimeValues>
	{
		#region Business Methods

		private string m_MachineId = String.Empty;
		private bool m_Auto = false;
		private bool m_ProductionSwitch = false;
		private string m_ArticleNumber = String.Empty;
		private int m_CurrentCycleCount = 0;
		private int m_LastReadCycleCount = 0;
        private int m_CurrentRejectedCount = 0;
        private int m_LastReadRejectedCount = 0;
		private bool m_IsConnected = false;
        private bool m_FlowErrorActive = false;
        private bool m_ValidAuto = false;
        private bool m_ChangeOverActive = false;
        private SmartDate m_LastChanged = new SmartDate();

        public string MachineId
		{
			get
			{
				CanReadProperty("MachineId");
				return m_MachineId;
			}
		}

		public bool Auto
		{
			get
			{
				CanReadProperty("Auto");
				return m_Auto;
			}
			set
			{
				CanWriteProperty("Auto");
				if (m_Auto != value)
				{
					m_Auto = value;
					PropertyHasChanged("Auto");
				}
			}
		}

		public bool ProductionSwitch
		{
			get
			{
				CanReadProperty("ProductionSwitch");
				return m_ProductionSwitch;
			}
			set
			{
				CanWriteProperty("ProductionSwitch");
				if (m_ProductionSwitch != value)
				{
					m_ProductionSwitch = value;
					PropertyHasChanged("ProductionSwitch");
				}
			}
		}

		public string ArticleNumber
		{
			get
			{
				CanReadProperty("ArticleNumber");
				return m_ArticleNumber;
			}
			set
			{
				CanWriteProperty("ArticleNumber");
				if (m_ArticleNumber != value)
				{
					m_ArticleNumber = value;
					PropertyHasChanged("ArticleNumber");
				}
			}
		}

		public int CurrentCycleCount
		{
			get
			{
                CanReadProperty("CurrentCycleCount");
                return m_CurrentCycleCount;
			}
			set
			{
                CanWriteProperty("CurrentCycleCount");
                if (m_CurrentCycleCount != value)
				{
                    m_CurrentCycleCount = value;
                    PropertyHasChanged("CurrentCycleCount");
				}
			}
		}

		public int LastReadCycleCount
		{
			get
			{
                CanReadProperty("LastReadCycleCount");
				return m_LastReadCycleCount;
			}
			set
			{
                CanWriteProperty("LastReadCycleCount");
                if (m_LastReadCycleCount != value)
				{
                    m_LastReadCycleCount = value;
                    PropertyHasChanged("LastReadCycleCount");
				}
			}
		}

        public int CurrentRejectedCount
        {
            get
            {
                CanReadProperty("CurrentRejectedCount");
                return m_CurrentRejectedCount;
            }
            set
            {
                CanWriteProperty("CurrentRejectedCount");
                if (m_CurrentRejectedCount != value)
                {
                    m_CurrentRejectedCount = value;
                    PropertyHasChanged("CurrentRejectedCount");
                }
            }
        }

        public int LastReadRejectedCount
        {
            get
            {
                CanReadProperty("LastReadRejectedCount");
                return m_LastReadRejectedCount;
            }
            set
            {
                CanWriteProperty("LastReadRejectedCount");
                if (m_LastReadRejectedCount != value)
                {
                    m_LastReadRejectedCount = value;
                    PropertyHasChanged("LastReadRejectedCount");
                }
            }
        }

		public bool IsConnected
        {
            get
            {
                CanReadProperty("IsConnected");
                return m_IsConnected;
            }
            set
            {
                CanWriteProperty("IsConnected");
                if (m_IsConnected != value)
                {
                    m_IsConnected = value;
                    PropertyHasChanged("IsConnected");
                }
            }
        }

        public bool FlowErrorActive
        {
            get
            {
                CanReadProperty("FlowErrorActive");
                return m_FlowErrorActive;
            }
            set
            {
                CanWriteProperty("FlowErrorActive");
                if (m_FlowErrorActive != value)
                {
                    m_FlowErrorActive = value;
                    PropertyHasChanged("FlowErrorActive");
                }
            }
        }

        public bool FirstValidAutoFound
        {
            get
            {
                CanReadProperty("ValidAuto");
                return m_ValidAuto;
            }
            set
            {
                CanWriteProperty("ValidAuto");
                if (m_ValidAuto != value)
                {
                    m_ValidAuto = value;
                    PropertyHasChanged("ValidAuto");
                }
            }
        }

        public bool ChangeOverActive
        {
            get
            {
                CanReadProperty("ChangeOverActive");
                return m_ChangeOverActive;
            }
            set
            {
                CanWriteProperty("ChangeOverActive");
                if (m_ChangeOverActive != value)
                {
                    m_ChangeOverActive = value;
                    PropertyHasChanged("ChangeOverActive");
                }
            }
        }

        public SmartDate LastChanged
        {
            get
            {
                CanReadProperty("LastChanged");
                return m_LastChanged;
            }
            set
            {
                CanWriteProperty("LastChanged");
                if (m_LastChanged != value)
                {
                    m_LastChanged = value;
                    PropertyHasChanged("LastChanged");
                }
            }
        }

		public string Status
		{
			get
			{
                if(!IsConnected)
                    return ResourceStrings.GetString("CommunicationError.Abbr");
				else if (!ProductionSwitch)
				    return ResourceStrings.GetString("NotInProduction");
                
                return Auto ? ResourceStrings.GetString("Running") : ResourceStrings.GetString("Stopped");
			}
		}

        protected override object GetIdValue()
		{
			return m_MachineId;
		}

		#endregion

		#region Validation Rules

		protected override void AddBusinessRules()
		{

		}

		#endregion

		#region Authorization Rules

		protected override void AddAuthorizationRules()
		{

		}

		#endregion

		#region Factory Methods

		public static RealTimeValues NewRealTimeValues(string machineId)
		{
			return DataPortal.Create<RealTimeValues>(new Criteria(machineId));
		}

		public static RealTimeValues GetRealTimeValues(string machineId)
		{
			return DataPortal.Fetch<RealTimeValues>(new Criteria(machineId));
		}

		private RealTimeValues()
		{
			
		}


		#endregion

		#region Data Access

		[Serializable()]
		protected class Criteria
		{
            private readonly string m_MachineId = null;
		
			public string MachineId
			{
				get { return m_MachineId; }
			}

			public Criteria(string machineId)
			{
				m_MachineId = machineId;
			}
		}


		protected void DataPortal_Create(Criteria criteria)
		{
			m_MachineId = criteria.MachineId;
            m_LastChanged = DateTime.Now;
        }

		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT MachineId,ProductionSwitch,Automat,ArticleNumber,CurrentCycleCount,LastReadCycleCount,CurrentRejectedCount,LastReadRejectedCount,IsConnected,FlowErrorActive,ValidAuto,ChangeOverActive,LastChanged" +
	                                      @" FROM RealTimeValues" +
	                                      @" WHERE MachineId=@MachineId";
					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
                        if (dataReader.Read())
                        {
                            m_MachineId = dataReader.GetString("MachineId");
                            m_Auto = dataReader.GetBoolean("Automat");
                            m_ProductionSwitch = dataReader.GetBoolean("ProductionSwitch");
                            m_ArticleNumber = dataReader.GetString("ArticleNumber");
                            m_CurrentCycleCount = dataReader.GetInt32("CurrentCycleCount");
                            m_LastReadCycleCount = dataReader.GetInt32("LastReadCycleCount");
                            m_CurrentRejectedCount = dataReader.GetInt32("CurrentRejectedCount");
                            m_LastReadRejectedCount = dataReader.GetInt32("LastReadRejectedCount");
                            m_IsConnected = dataReader.GetBoolean("IsConnected");
                            m_FlowErrorActive = dataReader.GetBoolean("FlowErrorActive");
                            m_ValidAuto = dataReader.GetBoolean("ValidAuto");
                            m_ChangeOverActive = dataReader.GetBoolean("ChangeOverActive");
                            m_LastChanged = dataReader.GetSmartDate("LastChanged");
                        }
                	}
				}
			}

		}

		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"INSERT INTO RealTimeValues " +
                                          @"(MachineId,ProductionSwitch,Automat,ArticleNumber,CurrentCycleCount,LastReadCycleCount,CurrentRejectedCount,LastReadRejectedCount,IsConnected,FlowErrorActive,ValidAuto,ChangeOverActive,LastChanged)" +
                                          @" VALUES " +
                                          @"(@MachineId,@ProductionSwitch,@Automat,@ArticleNumber,@CurrentCycleCount,@LastReadCycleCount,@CurrentRejectedCount,@LastReadRejectedCount,@IsConnected,@FlowErrorActive,@ValidAuto,@ChangeOverActive,@LastChanged) ";

					command.Parameters.AddWithValue("@MachineId", m_MachineId);
					command.Parameters.AddWithValue("@Automat", m_Auto);
					command.Parameters.AddWithValue("@ProductionSwitch", m_ProductionSwitch);
					command.Parameters.AddWithValue("@ArticleNumber", m_ArticleNumber);
                    command.Parameters.AddWithValue("@CurrentCycleCount", m_CurrentCycleCount);
                    command.Parameters.AddWithValue("@LastReadCycleCount", m_LastReadCycleCount);
                    command.Parameters.AddWithValue("@CurrentRejectedCount", m_CurrentRejectedCount);
                    command.Parameters.AddWithValue("@LastReadRejectedCount", m_LastReadRejectedCount);
                    command.Parameters.AddWithValue("@IsConnected", m_IsConnected);
                    command.Parameters.AddWithValue("@FlowErrorActive", m_FlowErrorActive);
                    command.Parameters.AddWithValue("@ValidAuto", m_ValidAuto);
                    command.Parameters.AddWithValue("@ChangeOverActive", m_ChangeOverActive);
                    command.Parameters.AddWithValue("@LastChanged", m_LastChanged.DBValue);

					command.ExecuteNonQuery();

					MarkOld();
				}
			}
		}

		protected override void DataPortal_Update()
		{
			if (!this.IsDirty)
				return;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"UPDATE RealTimeValues" +
	                                      @" SET ProductionSwitch=@ProductionSwitch," +
		                                  @"Automat=@Automat," +
		                                  @"ArticleNumber=@ArticleNumber," +
                                          @"CurrentCycleCount=@CurrentCycleCount," +
                                          @"LastReadCycleCount=@LastReadCycleCount," +
                                          @"CurrentRejectedCount=@CurrentRejectedCount," +
                                          @"LastReadRejectedCount=@LastReadRejectedCount," +
                                          @"IsConnected=@IsConnected," +
                                          @"FlowErrorActive=@FlowErrorActive," +
                                          @"ValidAuto=@ValidAuto," +
                                          @"ChangeOverActive=@ChangeOverActive," +
                                          @"LastChanged=@LastChanged" +
	                                      @" WHERE " +
	                                      @"MachineId=@MachineId";

					command.Parameters.AddWithValue("@Automat", m_Auto);
					command.Parameters.AddWithValue("@ProductionSwitch", m_ProductionSwitch);
					command.Parameters.AddWithValue("@ArticleNumber", m_ArticleNumber);
                    command.Parameters.AddWithValue("@CurrentCycleCount", m_CurrentCycleCount);
                    command.Parameters.AddWithValue("@LastReadCycleCount", m_LastReadCycleCount);
                    command.Parameters.AddWithValue("@CurrentRejectedCount", m_CurrentRejectedCount);
                    command.Parameters.AddWithValue("@LastReadRejectedCount", m_LastReadRejectedCount);
                    command.Parameters.AddWithValue("@IsConnected", m_IsConnected);
                    command.Parameters.AddWithValue("@FlowErrorActive", m_FlowErrorActive);
                    command.Parameters.AddWithValue("@ValidAuto", m_ValidAuto);
                    command.Parameters.AddWithValue("@ChangeOverActive", m_ChangeOverActive);
                    command.Parameters.AddWithValue("@LastChanged", m_LastChanged.DBValue);
                    command.Parameters.AddWithValue("@MachineId", m_MachineId);

					command.ExecuteNonQuery();

					MarkOld();
				}
			}
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
					command.CommandText = "DELETE RealTimeValues WHERE MachineId=@MachineId";

					command.Parameters.AddWithValue("@MachineId", m_MachineId);

					command.ExecuteNonQuery();
				}
			}

			MarkNew();
		}

		#endregion

		#region Exists

		public static bool Exists(string machineId)
		{
			bool exists = false;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*)" +
                                          @" FROM RealTimeValues WHERE MachineId=@MachineId";
					command.Parameters.AddWithValue(@"@MachineId", machineId);

					int count = (int)command.ExecuteScalar();
					exists = (count > 0);
				}
			}
			return exists;
		}

		#endregion
	}
}
