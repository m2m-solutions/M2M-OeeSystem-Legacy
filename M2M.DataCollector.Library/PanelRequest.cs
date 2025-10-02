using System;
using System.Data;
using System.Data.SqlClient;
using Csla;

using M2M.DataCenter;

namespace M2M.DataCollector.Library
{
	[Serializable()]
	public class PanelRequest : BusinessBase<PanelRequest>
	{
		#region Business Methods

		private Guid m_EventId = Guid.NewGuid();
        private string m_TagId = String.Empty;
        private string m_MachineId = String.Empty; 
		private SmartDate m_EventRaised = new SmartDate();
		private string m_DisplayName = "";

		public Guid EventId
		{
			get
			{
				CanReadProperty("EventId");
				return m_EventId;
			}
            set
            {
                CanWriteProperty("EventId");
                if (m_EventId != value)
                {
                    m_EventId = value;
                    PropertyHasChanged("EventId");
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

		public string DisplayName
        {
            get
            {
                CanReadProperty("DisplayName");
                return m_DisplayName;
            }
            set
            {
                CanWriteProperty("DisplayName");
                if (m_DisplayName != value)
                {
                    m_DisplayName = value;
                    PropertyHasChanged("DisplayName");
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

		public static PanelRequest NewRequest()
		{
			return DataPortal.Create<PanelRequest>();
		}

        private PanelRequest()
		{

		}
		
		#endregion

		#region Data Access

		[Serializable()]
		private class Criteria
		{
        }


		protected override void DataPortal_Create()
		{
			
		}

		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;

                    command.CommandText += @"INSERT INTO PendingPanelRequests " + 
	                                      @"(EventId,TagId,MachineId,EventRaised,DisplayName)" + 
	                                      @" VALUES " +
                                          @"(@EventId,@TagId,@MachineId,@EventRaised,@DisplayName);";

					command.Parameters.AddWithValue("@EventId", m_EventId);
                    command.Parameters.AddWithValue("@TagId", m_TagId);
                    command.Parameters.AddWithValue("@MachineId", m_MachineId);
					command.Parameters.AddWithValue("@EventRaised", m_EventRaised.DBValue);
                    command.Parameters.AddWithValue("@DisplayName", m_DisplayName);
					
					command.ExecuteNonQuery();

					MarkOld();
				}
			}
		}

		#endregion
        
	}
}
