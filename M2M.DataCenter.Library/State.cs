using System;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class State : BusinessBase<State>
	{
		#region Business Methods

		private Guid m_StateId = Guid.NewGuid();
		private string m_MachineId = String.Empty;
		private string m_ArticleNumber = String.Empty;
		private StateType m_StateType = StateType.NotApplicable;
		private SmartDate m_TimeStampOnSet = new SmartDate();
		private SmartDate m_TimeStampOnReset = new SmartDate();
		private int m_NumberOfItemsOnSet = 0;
		private int m_NumberOfItemsOnReset = 0;
        private int m_NumberOfRejectedOnSet = 0;
        private int m_NumberOfRejectedOnReset = 0;

		public Guid StateId
		{
			get
			{
				CanReadProperty("StateId");
				return m_StateId;
			}
		}

		public string MachineId
		{
			get
			{
				CanReadProperty("MachineId");
				return m_MachineId;
			}
			set
			{
				CanWriteProperty("MachineId");
				if (m_MachineId != value)
				{
					m_MachineId = value;
					PropertyHasChanged("MachineId");
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

		public StateType StateType
		{
			get
			{
				CanReadProperty("StateType");
				return m_StateType;
			}
			set
			{
				CanWriteProperty("StateType");
				if (m_StateType != value)
				{
					m_StateType = value;
					PropertyHasChanged("StateType");
				}
			}
		}

		public SmartDate TimeStampOnSet
		{
			get
			{
				CanReadProperty("TimeStampOnSet", true);
				return m_TimeStampOnSet;
			}
			set
			{
				CanWriteProperty("TimeStampOnSet", true);
				if (m_TimeStampOnSet != value)
				{
					m_TimeStampOnSet = value;
					PropertyHasChanged("TimeStampOnSet");
				}
			}
		}

		public SmartDate TimeStampOnReset
		{
			get
			{
				CanReadProperty("TimeStampOnReset", true);
				return m_TimeStampOnReset;
			}
			set
			{
				CanWriteProperty("TimeStampOnReset", true);
				if (m_TimeStampOnReset != value)
				{
					m_TimeStampOnReset = value;
					PropertyHasChanged("TimeStampOnReset");
				}
			}
		}

		public int NumberOfItemsOnSet
		{
			get
			{
				CanReadProperty("NumberOfItemsOnSet", true);
				return m_NumberOfItemsOnSet;
			}
			set
			{
				CanWriteProperty("NumberOfItemsOnSet", true);
				if (m_NumberOfItemsOnSet != value)
				{
					m_NumberOfItemsOnSet = value;
					PropertyHasChanged("NumberOfItemsOnSet");
				}
			}
		}

		public int NumberOfItemsOnReset
		{
			get
			{
				CanReadProperty("NumberOfItemsOnReset", true);
				return m_NumberOfItemsOnReset;
			}
			set
			{
				CanWriteProperty("NumberOfItemsOnReset", true);
				if (m_NumberOfItemsOnReset != value)
				{
					m_NumberOfItemsOnReset = value;
					PropertyHasChanged("NumberOfItemsOnReset");
				}
			}
		}

        public int NumberOfRejectedOnSet
        {
            get
            {
                CanReadProperty("NumberOfRejectedOnSet", true);
                return m_NumberOfRejectedOnSet;
            }
            set
            {
                CanWriteProperty("NumberOfRejectedOnSet", true);
                if (m_NumberOfRejectedOnSet != value)
                {
                    m_NumberOfRejectedOnSet = value;
                    PropertyHasChanged("NumberOfRejectedOnSet");
                }
            }
        }

        public int NumberOfRejectedOnReset
        {
            get
            {
                CanReadProperty("NumberOfRejectedOnReset", true);
                return m_NumberOfRejectedOnReset;
            }
            set
            {
                CanWriteProperty("NumberOfRejectedOnReset", true);
                if (m_NumberOfRejectedOnReset != value)
                {
                    m_NumberOfRejectedOnReset = value;
                    PropertyHasChanged("NumberOfRejectedOnReset");
                }
            }
        }

        public double ElapsedTime
        {
            get
            {
                TimeSpan elapsedTime = new TimeSpan(m_TimeStampOnReset.Date.Ticks - m_TimeStampOnSet.Date.Ticks);

                return elapsedTime.TotalHours;
            }
        }

		protected override object GetIdValue()
		{
			return m_StateId;
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

		public static State NewState()
		{
			return DataPortal.Create<State>();
		}

		public static State GetLatestActiveState(string machineId, StateType stateType)
		{
			return DataPortal.Fetch<State>(new Criteria(machineId, stateType));
		}


        public static State GetLatestState(string machineId, StateType stateType, SmartDate dateLimit)
        {
            return DataPortal.Fetch<State>(new Criteria(machineId, stateType, dateLimit));
        }

		protected State()
		{
			/* require use of factory methods */
		}
		#endregion

		#region Data Access

		[Serializable()]
		private class Criteria
		{
            private readonly string m_MachineId = String.Empty;
            private readonly StateType m_StateType = StateType.NotApplicable;
            private readonly SmartDate m_DateLimit = new SmartDate();

			public string MachineId
			{
				get { return m_MachineId; }
			}

			public StateType StateType
			{
				get { return m_StateType; }
			}

            public SmartDate DateLimit
            {
                get { return m_DateLimit; }
            }

			public Criteria(string machineId, StateType stateType)
			{
				m_MachineId = machineId;
				m_StateType = stateType;
			}

            public Criteria(string machineId, StateType stateType, SmartDate dateLimit)
            {
                m_MachineId = machineId;
                m_StateType = stateType;
                m_DateLimit = dateLimit;
            }
		}


		protected override void DataPortal_Create()
		{

		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
                    if (criteria.DateLimit.IsEmpty)
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT TOP 1 StateId,MachineId,ArticleNumber,StateType,TimeStampOnSet,TimeStampOnReset,NumberOfItemsOnSet,NumberOfItemsOnReset,NumberOfRejectedOnSet,NumberOfRejectedOnReset" +
                                              @" FROM States" +
                                              @" WHERE MachineId=@MachineId AND StateType=@StateType AND TimeStampOnReset IS NULL AND Overridden=0" +
                                              @" ORDER BY TimeStampOnSet DESC";

                        command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);
                        command.Parameters.AddWithValue(@"@StateType", (int)criteria.StateType);
                    }
                    else
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT TOP 1 StateId,MachineId,ArticleNumber,StateType,TimeStampOnSet,TimeStampOnReset,NumberOfItemsOnSet,NumberOfItemsOnReset,NumberOfRejectedOnSet,NumberOfRejectedOnReset" +
                                                " FROM States WHERE " +
                                                "MachineId=@MachineId AND StateType=@StateType AND TimeStampOnReset>@DateLimit AND Overridden=0" +
                                                " ORDER BY TimeStampOnSet DESC";
                        command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);
                        command.Parameters.AddWithValue(@"@StateType", (int)criteria.StateType);
                        command.Parameters.AddWithValue(@"@DateLimit", criteria.DateLimit.DBValue);
                    }


					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if (dataReader.Read())
						{
							m_StateId = dataReader.GetGuid("StateId");
							m_MachineId = dataReader.GetString("MachineId");
							m_ArticleNumber = dataReader.GetString("ArticleNumber");
							m_StateType = (StateType)dataReader.GetInt32("StateType");
							m_TimeStampOnSet = dataReader.GetSmartDate("TimeStampOnSet");
							m_TimeStampOnReset = dataReader.GetSmartDate("TimeStampOnReset");
							m_NumberOfItemsOnSet = dataReader.GetInt32("NumberOfItemsOnSet");
							m_NumberOfItemsOnReset = dataReader.GetInt32("NumberOfItemsOnReset");
                            m_NumberOfRejectedOnSet = dataReader.GetInt32("NumberOfRejectedOnSet");
                            m_NumberOfRejectedOnReset = dataReader.GetInt32("NumberOfRejectedOnReset");
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
					command.CommandText = @"INSERT INTO States " +
                                          @"(StateId,MachineId,ArticleNumber,StateType,TimeStampOnSet,NumberOfItemsOnSet,NumberOfRejectedOnSet)" +
	                                      @" VALUES " +
                                          @"(@StateId,@MachineId,@ArticleNumber,@StateType,@TimeStampOnSet,@NumberOfItemsOnSet,@NumberOfRejectedOnSet)";

					command.Parameters.AddWithValue("@StateId", m_StateId);
					command.Parameters.AddWithValue("@MachineId", m_MachineId);
					command.Parameters.AddWithValue("@ArticleNumber", m_ArticleNumber);
					command.Parameters.AddWithValue("@StateType", (int)m_StateType);
					command.Parameters.AddWithValue("@TimeStampOnSet", m_TimeStampOnSet.DBValue);
					command.Parameters.AddWithValue("@NumberOfItemsOnSet", m_NumberOfItemsOnSet);
                    command.Parameters.AddWithValue("@NumberOfRejectedOnSet", m_NumberOfRejectedOnSet);

					command.ExecuteNonQuery();

					MarkOld();
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
					command.CommandText = @"UPDATE States" +
                                            @" SET TimeStampOnReset=@TimeStampOnReset,NumberOfItemsOnReset=@NumberOfItemsOnReset,NumberOfRejectedOnReset=@NumberOfRejectedOnReset" +
                                            @" WHERE StateId=@StateId";

					command.Parameters.AddWithValue("@StateId", m_StateId);
					command.Parameters.AddWithValue("@TimeStampOnReset", m_TimeStampOnReset.DBValue);
					command.Parameters.AddWithValue("@NumberOfItemsOnReset", m_NumberOfItemsOnReset);
                    command.Parameters.AddWithValue("@NumberOfRejectedOnReset", m_NumberOfRejectedOnReset);

					command.ExecuteNonQuery();
				}
			}
		}

		#endregion
	}
}
