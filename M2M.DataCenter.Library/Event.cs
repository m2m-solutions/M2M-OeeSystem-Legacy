using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class Event : BusinessBase<Event>
	{
		#region Business Methods

		private Guid m_EventId = Guid.NewGuid();
        private string m_DivisionId = String.Empty;
        private string m_MachineId = String.Empty;
		private string m_ArticleNumber = String.Empty;
		private string m_TagId = String.Empty; 
		private SmartDate m_EventRaised = new SmartDate();
		private SmartDate m_TimeForNextEvent = new SmartDate();
		private int m_ReasonCode = 0;
		private int m_CurrentNumberOfItems = 0;
		private int m_RunRate = 0;

		public Guid EventId
		{
			get
			{
				CanReadProperty("EventId");
				return m_EventId;
			}
		}

        public string DivisionId
        {
            get
            {
                CanReadProperty("DivisionId");
                return m_DivisionId;
            }
            set
            {
                CanWriteProperty("DivisionId");
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

		public string TagId
		{
			get
			{
				CanReadProperty("TagId");
				return m_TagId;
			}
			set
			{
				CanWriteProperty("TagId");
				if (m_TagId != value)
				{
					m_TagId = value;
					PropertyHasChanged("TagId");
				}
			}
		}

		public int ReasonCode
		{
			get
			{
				CanReadProperty("ReasonCode");
				return m_ReasonCode;
			}
			set
			{
				CanWriteProperty("ReasonCode");
				if (m_ReasonCode != value)
				{
					m_ReasonCode = value;
					PropertyHasChanged("ReasonCode");
				}
			}
		}

		public int CurrentNumberOfItems
		{
			get
			{
				CanReadProperty("CurrentNumberOfItems");
				return m_CurrentNumberOfItems;
			}
			set
			{
				CanWriteProperty("CurrentNumberOfItems");
				if (m_CurrentNumberOfItems != value)
				{
					m_CurrentNumberOfItems = value;
					PropertyHasChanged("CurrentNumberOfItems");
				}
			}
		}

		public int RunRate
		{
			get
			{
				CanReadProperty("RunRate");
				return m_RunRate;
			}
			set
			{
				CanWriteProperty("RunRate");
				if (m_RunRate != value)
				{
					m_RunRate = value;
					PropertyHasChanged("RunRate");
				}
			}
		}

		public string PaceAsString
		{
			get
			{
				string result = "";

				if (m_RunRate > 0)
					result = String.Format("{0} / tim", 3600 * 1000 / m_RunRate);

				return result;
			}
		}
		
		public SmartDate EventRaised
		{
			get
			{
				CanReadProperty("EventRaised", true);
				return m_EventRaised;
			}
			set
			{
				CanWriteProperty("EventRaised", true);
				if (m_EventRaised != value)
				{
					m_EventRaised = value;
					PropertyHasChanged("EventRaised");
				}
			}
		}

		public SmartDate TimeForNextEvent
		{
			get
			{
				CanReadProperty("TimeForNextEvent", true);
				return m_TimeForNextEvent;
			}
			set
			{
				CanWriteProperty("TimeForNextEvent", true);
				if (m_TimeForNextEvent != value)
				{
					m_TimeForNextEvent = value;
					PropertyHasChanged("TimeForNextEvent");
				}
			}
		}

		protected override object GetIdValue()
		{
			return m_EventId;
		}

		#endregion

		#region Validation Rules

		protected override void AddBusinessRules()
		{

		}

		#endregion

		#region Authorization Rules

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

		#endregion

		#region Factory Methods

		public static Event NewEvent()
		{
			return DataPortal.Create<Event>();
		}

		public static Event GetActiveEvent(string machineId, string tagId)
		{
			return DataPortal.Fetch<Event>(new Criteria(machineId, tagId, true));
		}

        public static Event GetLatestEvent(string machineId, string tagId)
        {
            return DataPortal.Fetch<Event>(new Criteria(machineId, tagId, false));
        }

        public static Event GetActiveEvent(string machineId)
        {
            return DataPortal.Fetch<Event>(new Criteria(machineId, true));
        }

        public static Event GetLatestEvent(string machineId)
        {
            return DataPortal.Fetch<Event>(new Criteria(machineId, false));
        }

        private Event()
		{

		}
		
		#endregion

		#region Data Access

		[Serializable()]
		private class Criteria
		{
            private readonly string m_MachineId = null;
            private readonly string m_TagId = null;
            private readonly bool m_Active = false;

            public string MachineId
			{
				get { return m_MachineId; }
			}

			public string TagId
			{
				get { return m_TagId; }
			}

            public bool Active
            {
                get { return m_Active; }
            }

			public Criteria(string machineId, bool active)
			{
				m_MachineId = machineId;
                m_Active = active;
			}

			public Criteria(string machineId, string tagId, bool active)
			{
				m_MachineId = machineId;
				m_TagId = tagId;
                m_Active = active;
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
                    string whereClause = " WHERE MachineId=@MachineId";
                    command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);

                    if (criteria.TagId != null)
                    {
                        whereClause += " AND TagId=@TagId";
                        command.Parameters.AddWithValue(@"@TagId", criteria.TagId);
                    }

                    if (criteria.Active)
                    {
                        whereClause += " AND TimeForNextEvent IS NULL AND Overridden=0";
                    }

                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 EventId,DivisionId,MachineId,ArticleNumber,TagId,ReasonCode,EventRaised,TimeForNextEvent,CurrentNumberOfItems,RunRate" +
                                          @" FROM Events" +
                                          whereClause +
                                          @" ORDER BY EventRaised DESC";


                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            Fetch(dataReader);
                        }
                    }
                }
            }
		}

        private void Fetch(SafeDataReader dr)
		{
            
			m_EventId = dr.GetGuid("EventId");
            m_DivisionId = dr.GetString("DivisionId");
			m_MachineId = dr.GetString("MachineId");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_ReasonCode = dr.GetInt32("ReasonCode");
            m_TagId = dr.GetString("TagId");
            m_EventRaised = dr.GetSmartDate("EventRaised");
			m_TimeForNextEvent = dr.GetSmartDate("TimeForNextEvent");
			m_CurrentNumberOfItems = dr.GetInt32("CurrentNumberOfItems");
			m_RunRate = dr.GetInt32("RunRate");
						
			MarkOld();
		}

		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
                connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;

                    if (m_TimeForNextEvent.IsEmpty)
                    {
                        // if TimeForNextEvent has a value, this is just informational
                        command.CommandText = @"UPDATE Events SET " +
                                          @"TimeForNextEvent=@EventRaised" +
                                          @" WHERE " +
                                          @"EventId=(SELECT TOP 1 EventId FROM Events WITH (NOLOCK) WHERE MachineId=@MachineId AND TimeForNextEvent IS NULL AND Overridden=0 ORDER BY EventRaised DESC);";
	                                      
                    }

					command.CommandText += @"INSERT INTO Events " + 
	                                      @"(EventId,DivisionId,MachineId,ArticleNumber,TagId,ReasonCode,RunRate,EventRaised,TimeForNextEvent,CurrentNumberOfItems)" + 
	                                      @" VALUES " + 
	                                      @"(@EventId,@DivisionId,@MachineId,@ArticleNumber,@TagId,@ReasonCode,@RunRate,@EventRaised,@TimeForNextEvent,@CurrentNumberOfItems);";

					command.Parameters.AddWithValue("@EventId", m_EventId);
                    command.Parameters.AddWithValue("@DivisionId", m_DivisionId);
					command.Parameters.AddWithValue("@MachineId", m_MachineId);
					command.Parameters.AddWithValue("@ArticleNumber", m_ArticleNumber);
					command.Parameters.AddWithValue("@TagId", m_TagId);
					command.Parameters.AddWithValue("@ReasonCode", m_ReasonCode);
					command.Parameters.AddWithValue("@RunRate", m_RunRate);
					command.Parameters.AddWithValue("@CurrentNumberOfItems", m_CurrentNumberOfItems);
					command.Parameters.AddWithValue("@EventRaised", m_EventRaised.DBValue);
					command.Parameters.AddWithValue("@TimeForNextEvent", m_TimeForNextEvent.DBValue);
				
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
				
				Update(connection);
			}
		}

		internal void Update(SqlConnection connection)
		{
			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandType = CommandType.Text;
				command.CommandText = @"UPDATE Events" +
                                      @" SET TagId=@TagId,ReasonCode=@ReasonCode,RunRate=@RunRate,TimeForNextEvent=@TimeForNextEvent,CurrentNumberOfItems=@CurrentNumberOfItems" +
	                                  @" WHERE " +
	                                  @"EventId=@EventId";

				command.Parameters.AddWithValue("@TagId", m_TagId);
				command.Parameters.AddWithValue("@ReasonCode", m_ReasonCode);
				command.Parameters.AddWithValue("@RunRate", m_RunRate);
				command.Parameters.AddWithValue("@CurrentNumberOfItems", m_CurrentNumberOfItems);
				command.Parameters.AddWithValue("@TimeForNextEvent", m_TimeForNextEvent.DBValue);
                command.Parameters.AddWithValue("@EventId", m_EventId);
		
				command.ExecuteNonQuery();
			}
		}
		
		internal void DeleteSelf()
		{
			if (!this.IsDirty)
				return;

			if (this.IsNew)
				return;

			using (SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["connection"])
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE Events WHERE EventId=@EventId";
					command.Parameters.AddWithValue("@EventId", m_EventId);

					command.ExecuteNonQuery();

					MarkNew();
				}
			}
		}

		#endregion

		#region Exists

		public static bool Exists(Guid eventId)
		{
			bool exists = false;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*)" + 
	                                      @" FROM Events WHERE EventId=@EventId";
					command.Parameters.AddWithValue(@"@EventId", eventId);

					int count = (int)command.ExecuteScalar();
					exists = (count > 0);
				}
			}
			return exists;
		}

		#endregion

        
	}
}
