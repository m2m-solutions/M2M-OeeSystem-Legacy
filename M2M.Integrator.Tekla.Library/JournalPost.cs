//#define test
using System;
using System.Data;
using System.Data.OleDb;
using Csla;
using M2M.DataCenter;

namespace M2M.Integrator.Tekla.Library
{
	[Serializable()]
	public partial class JournalPost : BusinessBase<JournalPost>
	{
		#region Business Methods 
		protected int m_Id = -1;
		protected string m_MachineId = String.Empty;
		protected SmartDate m_JournalDate = new SmartDate();
		protected EntryUnit m_EntryUnit = EntryUnit.NotDefined;
        protected Decimal m_EntryValue = 0;
		
		public int Id
		{
			get
			{
				CanReadProperty("Id", true);
				return m_Id;
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

		public SmartDate JournalDate
		{
			get
			{
				CanReadProperty("JournalDate", true);
				return m_JournalDate;
			}
			set
			{
				CanWriteProperty("JournalDate", true);
				if (m_JournalDate != value)
				{
					m_JournalDate = value;
					PropertyHasChanged("JournalDate");
				}
			}
		}

		public EntryUnit EntryUnit
		{
			get
			{
				CanReadProperty("EntryUnit", true);
				return m_EntryUnit;
			}
			set
			{
				CanWriteProperty("EntryUnit", true);
				if (m_EntryUnit != value)
				{
					m_EntryUnit = value;
					PropertyHasChanged("EntryUnit");
				}
			}
		}

        public Decimal EntryValue
        {
            get
            {
                CanReadProperty("EntryValue", true);
                return m_EntryValue;
            }
            set
            {
                CanWriteProperty("EntryValue", true);
                if (m_EntryValue != value)
                {
                    m_EntryValue = value;
                    PropertyHasChanged("EntryValue");
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

		public static JournalPost NewJournalPost()
		{
			return DataPortal.Create<JournalPost>();
		}

        protected JournalPost()
		{
			/* require use of factory methods */
		}

		#endregion
	
		#region Data Access

		[Serializable]
		protected class Criteria
		{
		
		}

		protected override void DataPortal_Create()
		{
            ValidationRules.CheckRules();
		}

		protected override void DataPortal_Insert()
		{
#if test
			using (SqlConnection connection = new SqlConnection(Database.TeklaConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO UDT_2097_JournalValues_V10 (" +
                                            @"ObjectNumber," +
                                            @"JournalDate," +
                                            @"EntryUnit," +
                                            @"EntryValue" +
                                            @") VALUES (" +
                                            @"@ObjectNumber," +
                                            @"@JournalDate," +
                                            @"@EntryUnit," +
                                            @"@EntryValue)";

					command.Parameters.AddWithValue("@ObjectNumber", m_MachineId);
                    command.Parameters.AddWithValue("@JournalDate", m_JournalDate.DBValue);
                    command.Parameters.AddWithValue("@EntryUnit", (int)m_EntryUnit);
                    command.Parameters.AddWithValue("@EntryValue", m_EntryValue);

					command.ExecuteNonQuery();			
				}
			}

#else
            using (OleDbConnection connection = new OleDbConnection(Database.TeklaConnectionString))
			{
				connection.Open();
				using (OleDbCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO UDT_2097_JournalValues_V10 (" +
                                            @"ObjectNumber," +
                                            @"JournalDate," +
                                            @"EntryUnit," +
                                            @"EntryValue" +
                                            @") VALUES (" +
                                            @"?," +
                                            @"?," +
                                            @"?," +
                                            @"?)";

					command.Parameters.AddWithValue("ObjectNumber", m_MachineId);
                    command.Parameters.AddWithValue("JournalDate", m_JournalDate.DBValue);
                    command.Parameters.AddWithValue("EntryUnit", (int)m_EntryUnit);
                    command.Parameters.AddWithValue("EntryValue", m_EntryValue);

					command.ExecuteNonQuery();			
				}
			}
#endif
		}
		
		#endregion

	}
}