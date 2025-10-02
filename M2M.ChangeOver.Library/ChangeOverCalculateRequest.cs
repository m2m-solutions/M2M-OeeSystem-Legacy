using System;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.ChangeOver.Library
{
	[Serializable()]
	public partial class ChangeOverCalculateRequest : BusinessBase<ChangeOverCalculateRequest>
	{
		#region Business Methods
		protected int m_Id = 0;
		protected Guid m_EventId = Guid.Empty;
        protected string m_MachineId = "";
		protected SmartDate m_Timestamp = new SmartDate();
		
		public int Id
		{
			get
			{
				CanReadProperty("Id", true);
				return m_Id;
			}
		}

        public Guid EventId
		{
			get
			{
                CanReadProperty("EventId", true);
                return m_EventId;
			}
			set
			{
                CanWriteProperty("EventId", true);
                if (m_EventId != value)
				{
                    m_EventId = value;
                    PropertyHasChanged("EventId");
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

		public SmartDate Timestamp
		{
			get
			{
				CanReadProperty("Timestamp", true);
				return m_Timestamp;
			}
			set
			{
				CanWriteProperty("Timestamp", true);
				if (m_Timestamp != value)
				{
					m_Timestamp = value;
					PropertyHasChanged("Timestamp");
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

		internal static ChangeOverCalculateRequest GetChangeOverCalculateRequest( SafeDataReader dr)
		{
			return new ChangeOverCalculateRequest(dr);
		}

		protected ChangeOverCalculateRequest()
		{
			/* require use of factory methods */
		}

        protected ChangeOverCalculateRequest(SafeDataReader dr)
			: this()
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		protected override void DataPortal_Create()
		{
            ValidationRules.CheckRules();
		}

		private void Fetch(SafeDataReader dr)
		{
			MarkAsChild();
            m_Id = dr.GetInt32("Id");
            m_EventId = dr.GetGuid("EventId");
            m_MachineId = dr.GetString("MachineId");
            m_Timestamp = dr.GetSmartDate("Timestamp");
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
                command.CommandText = @"DELETE FROM ChangeOverCalculateRequests WHERE " +
										@"Id=@Id";

				command.Parameters.AddWithValue(@"@Id", m_Id);

				command.ExecuteNonQuery();
			}
		}

		#endregion

	}
}