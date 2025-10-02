using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using M2M.DataCenter;

namespace M2M.Integrator.Tekla.Library
{
	[Serializable()]
	public class TransferLogEntry : BusinessBase<TransferLogEntry>
	{
		#region Business Methods

		private int m_TransferId = -1;
		private SmartDate m_TransferDate = new SmartDate();
		private long m_TimeConsumed = 0;
		private string m_Error = String.Empty;

		public int TransferId
		{
			get
			{
				CanReadProperty("TransferId");

				return m_TransferId;
			}
		}

		public long TimeConsumed
		{
			get
			{
				CanReadProperty("TimeConsumed");
				return m_TimeConsumed;
			}
			set
			{
				CanWriteProperty("TimeConsumed");
				if (m_TimeConsumed != value)
				{
					m_TimeConsumed = value;
					PropertyHasChanged("TimeConsumed");
				}
			}
		}

		public SmartDate TransferDate
		{
			get
			{
				CanReadProperty("TransferDate");
				return m_TransferDate;
			}
			set
			{
				CanWriteProperty("TransferDate");
				if (m_TransferDate != value)
				{
					m_TransferDate = value;
					PropertyHasChanged("TransferDate");
				}
			}
		}

		public string Error
		{
			get
			{
				CanReadProperty("Error");
				return m_Error;
			}
			set
			{
				CanWriteProperty("Error");
				if (m_Error != value)
				{
					m_Error = value;
					PropertyHasChanged("Error");
				}
			}
		}

		protected override object GetIdValue()
		{
			return m_TransferId;
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

		public static TransferLogEntry NewTransferLogEntry()
		{
			return DataPortal.Create<TransferLogEntry>();
		}

		private TransferLogEntry()
		{

		}

		#endregion

		#region Data Access

		[Serializable()]
		private class Criteria
		{
			public Criteria()
			{
			}
		}

		protected override void DataPortal_Create()
		{

		}

		private void DataPortal_Fetch(Criteria criteria)
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
					command.CommandText = @"INSERT INTO TeklaTransferLog (" +
										@"TransferDate," +
										@"TimeConsumed," +
										@"[Error]" +
										@")	VALUES (" +
										@"@TransferDate," +
										@"@TimeConsumed," +
										@"@Error)";

					command.Parameters.AddWithValue("@TransferDate", m_TransferDate.DBValue);
					command.Parameters.AddWithValue("@TimeConsumed", m_TimeConsumed);
					command.Parameters.AddWithValue("@Error", m_Error);

					command.ExecuteNonQuery();

					MarkOld();
				}
			}
		}

		protected override void DataPortal_Update()
		{
			
		}

		#endregion

		#region Exists

		public static SmartDate LatestTransfer
		{
			get
			{
				SmartDate latest = new SmartDate();
				using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
				{
					connection.Open();

					using (SqlCommand command = connection.CreateCommand())
					{
						command.CommandType = CommandType.Text;
						command.CommandText = @"SELECT TOP 1 TransferDate" +
											@" FROM TeklaTransferLog" +
											@" ORDER BY TransferDate DESC";

						DateTime? result = command.ExecuteScalar() as DateTime?;
						
						if(result.HasValue)
							latest = new SmartDate(result.Value);
						else
							latest = new SmartDate(new DateTime(2008, 1, 1)); //new SmartDate(DateTime.Today.Subtract(new TimeSpan(7, 0, 0, 0)));
					}
				}
				return latest;
			}
		}

		#endregion
	}
}
