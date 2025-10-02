using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class Maintenance : BusinessBase<Maintenance>
	{
		#region Business Methods

		private string m_MachineId = String.Empty;
        private int m_Moments = 0;
		private int m_MomentsTransferred = 0;
        private int m_MomentsLastRead = 0;
		private Decimal m_Uptime = 0;
		private Decimal m_UptimeTransferred = 0;
        
		public string MachineId
		{
			get
			{
				CanReadProperty("MachineId");
				return m_MachineId;
			}
		}

        public int Moments
		{
			get
			{
				CanReadProperty("Moments");
				return m_Moments;
			}
			set
			{
				CanWriteProperty("Moments");
				if (m_Moments != value)
				{
					m_Moments = value;
					PropertyHasChanged("Moments");
				}
			}
		}

		public int MomentsTransferred
		{
			get
			{
				CanReadProperty("MomentsTransferred");
				return m_MomentsTransferred;
			}
			set
			{
				CanWriteProperty("MomentsTransferred");
				if (m_MomentsTransferred != value)
				{
					m_MomentsTransferred = value;
					PropertyHasChanged("MomentsTransferred");
				}
			}
		}

        public int MomentsLastRead
        {
            get
            {
                CanReadProperty("MomentsLastRead");
                return m_MomentsLastRead;
            }
            set
            {
                CanWriteProperty("MomentsLastRead");
                if (m_MomentsLastRead != value)
                {
                    m_MomentsLastRead = value;
                    PropertyHasChanged("MomentsLastRead");
                }
            }
        }

		public Decimal Uptime
		{
			get
			{
				CanReadProperty("Uptime");
				return m_Uptime;
			}
			set
			{
				CanWriteProperty("Uptime");
				if (m_Uptime != value)
				{
					m_Uptime = value;
					PropertyHasChanged("Uptime");
				}
			}
		}

		public Decimal UptimeTransferred
		{
			get
			{
				CanReadProperty("UptimeTransferred");
				return m_UptimeTransferred;
			}
			set
			{
				CanWriteProperty("UptimeTransferred");
				if (m_UptimeTransferred != value)
				{
					m_UptimeTransferred = value;
					PropertyHasChanged("UptimeTransferred");
				}
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

		public static Maintenance NewMaintenanceObject(string machineId)
		{
			return DataPortal.Create<Maintenance>(new Criteria(machineId));
		}

		public static Maintenance GetMaintenanceObject(string machineId)
		{
			return DataPortal.Fetch<Maintenance>(new Criteria(machineId));
		}

        private Maintenance()
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
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT MachineId,Uptime,UptimeTransferred,Moments,MomentsTransferred,MomentsLastRead" + 
                                        " FROM Maintenance WHERE MachineId= @MachineId";
					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if (dataReader.Read())
						{
							m_MachineId = dataReader.GetString("MachineId");
                            m_Uptime = dataReader.GetDecimal("Uptime");
                            m_UptimeTransferred = dataReader.GetDecimal("UptimeTransferred");
                            m_Moments = dataReader.GetInt32("Moments");
                            m_MomentsTransferred = dataReader.GetInt32("MomentsTransferred");
                            m_MomentsLastRead = dataReader.GetInt32("MomentsLastRead");
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
                    command.CommandText = "INSERT INTO Maintenance (MachineId,Uptime,UptimeTransferred,Moments,MomentsTransferred,MomentsLastRead)" +
                                           " VALUES(@MachineId,@Uptime,@UptimeTransferred,@Moments,@MomentsTransferred,@MomentsLastRead)";

					command.Parameters.AddWithValue("@MachineId", m_MachineId);
                    command.Parameters.AddWithValue("@Uptime", m_Uptime);
                    command.Parameters.AddWithValue("@UptimeTransferred", m_UptimeTransferred);
					command.Parameters.AddWithValue("@Moments", m_Moments);
                    command.Parameters.AddWithValue("@MomentsTransferred", m_MomentsTransferred);
                    command.Parameters.AddWithValue("@MomentsLastRead", m_MomentsLastRead);
					

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
                    command.CommandText = "UPDATE Maintenance SET" +
                                        " Uptime = @Uptime," +
                                        "UptimeTransferred = @UptimeTransferred," +
                                        "Moments = @Moments," +
                                        "MomentsTransferred = @MomentsTransferred," +
                                        "MomentsLastRead = @MomentsLastRead" +
                                        " WHERE MachineId=@MachineId";

                    command.Parameters.AddWithValue("@Uptime", m_Uptime);
                    command.Parameters.AddWithValue("@UptimeTransferred", m_UptimeTransferred);
                    command.Parameters.AddWithValue("@Moments", m_Moments);
                    command.Parameters.AddWithValue("@MomentsTransferred", m_MomentsTransferred);
                    command.Parameters.AddWithValue("@MomentsLastRead", m_MomentsLastRead);
                    command.Parameters.AddWithValue("@MachineId", m_MachineId);

					command.ExecuteNonQuery();

					MarkOld();
				}
			}
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
                    command.CommandText = @"SELECT COUNT(*) FROM Maintenance WHERE " +
                                                @"MachineId=@MachineId";

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
