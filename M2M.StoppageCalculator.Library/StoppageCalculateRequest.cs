using System;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter;

namespace M2M.StoppageCalculator.Library
{
	[Serializable()]
	public partial class StoppageCalculateRequest : BusinessBase<StoppageCalculateRequest>
	{
		#region Business Methods
		protected int m_Id = 0;
		protected string m_DivisionId = String.Empty;
        protected string m_MachineId = String.Empty;
		protected SmartDate m_StartDate = new SmartDate();
		protected SmartDate m_EndDate = new SmartDate();

		public int Id
		{
			get
			{
				CanReadProperty("Id", true);
				return m_Id;
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

		public SmartDate StartDate
		{
			get
			{
				CanReadProperty("StartDate", true);
				return m_StartDate;
			}
			set
			{
				CanWriteProperty("StartDate", true);
				if (m_StartDate != value)
				{
					m_StartDate = value;
					PropertyHasChanged("StartDate");
				}
			}
		}

		public SmartDate EndDate
		{
			get
			{
				CanReadProperty("EndDate", true);
				return m_EndDate;
			}
			set
			{
				CanWriteProperty("EndDate", true);
				if (m_EndDate != value)
				{
					m_EndDate = value;
					PropertyHasChanged("EndDate");
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

		public static StoppageCalculateRequest NewStoppageCalculateRequest()
		{
			return DataPortal.Create<StoppageCalculateRequest>();
		}

		internal static StoppageCalculateRequest GetStoppageCalculateRequest(
		  SafeDataReader dr)
		{
			return new StoppageCalculateRequest(dr);
		}

		protected StoppageCalculateRequest()
		{
			/* require use of factory methods */
		}

        protected StoppageCalculateRequest(SafeDataReader dr)
			: this()
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		[Serializable]
		protected class RootCriteria
		{
		}

		[Serializable()]
		private class ChildCriteria
		{ }

		protected override void DataPortal_Create()
		{
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
			m_Id = dr.GetInt32("Id");
			m_DivisionId = dr.GetString("DivisionId");
            m_MachineId = dr.GetString("MachineId");
			m_StartDate = dr.GetSmartDate("StartDate");
			m_EndDate = dr.GetSmartDate("EndDate");
		}


		protected override void DataPortal_Insert()
		{

            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO StoppageCalculateRequests (" +
                                                "DivisionId," +
                                                "MachineId," +
                                                "StartDate," +
                                                "EndDate" +
                                                ") VALUES (" +
                                                "@DivisionId," +
                                                "@MachineId," +
                                                "@StartDate," +
                                                "@EndDate)";

                    command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);
                    command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
                    command.Parameters.AddWithValue(@"@StartDate", m_StartDate.DBValue);
                    command.Parameters.AddWithValue(@"@EndDate", m_EndDate.DBValue);

                    command.ExecuteNonQuery();
                }
            }
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
                command.CommandText = @"DELETE FROM StoppageCalculateRequests WHERE " +
										@"Id=@Id";

				command.Parameters.AddWithValue(@"@Id", m_Id);

				command.ExecuteNonQuery();
			}
		}

		#endregion

	}
}