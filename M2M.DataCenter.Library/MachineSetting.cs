using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class MachineSetting : BusinessBase<MachineSetting>
	{

		#region Business Methods 
		protected string m_MachineId = String.Empty;
		protected string m_Name = String.Empty;
        protected string m_Value = String.Empty;
		protected SmartDate m_LastModified = new SmartDate();
		
		// Id properties
		/// <summary>
		/// Machine Id
		/// </summary> 
		[System.ComponentModel.DataObjectField(true, false)]
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

		/// <summary>
		/// Name
		/// </summary> 
		[System.ComponentModel.DataObjectField(true, false)]
		public string Name
		{
			get
			{
				CanReadProperty("Name", true);
				return m_Name;
			}
			set
			{
				CanWriteProperty("Name", true);
				if (m_Name != value)
				{
					m_Name = value;
					PropertyHasChanged("Name");
				}
			}
		}

		// Public properties
		/// <summary>
		/// Value
		/// </summary> 
		public string Value
		{
			get
			{
				CanReadProperty("Value", true);
				return m_Value;
			}
			set
			{
				CanWriteProperty("Value", true);
				if (m_Value != value)
				{
					m_Value = value;
					PropertyHasChanged("Value");
				}
			}
		}
		// Public properties
		/// <summary>
		/// LastModified
		/// </summary> 
		public SmartDate LastModified
		{
			get
			{
				CanReadProperty("LastModified", true);
				return m_LastModified;
			}
		}

		protected override object GetIdValue()
		{
			return m_MachineId + "|" + 
					m_Name;
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

		internal static MachineSetting NewMachineSetting()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add MachineSetting objects");
			return new MachineSetting();
		}

		internal static MachineSetting NewMachineSetting(string machineId, string name)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add MachineSetting objects");
			return new MachineSetting(machineId, name);
		}

		internal static MachineSetting GetMachineSetting(SafeDataReader dr)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view MachineSetting objects");
			return new MachineSetting(dr);
		}

		protected MachineSetting(): base()
		{
			MarkAsChild();
		}

		
		protected MachineSetting(string machineId, string name) : this()
		{
			m_MachineId = machineId;
			m_Name = name;

			ValidationRules.CheckRules();
		}

		protected MachineSetting(SafeDataReader dr) : this()
		{
			Fetch(dr);
		}

		#endregion
	
		#region Data Access

		private void Fetch(SafeDataReader dataReader)
		{	
			m_MachineId = dataReader.GetString("MachineId");
			m_Name = dataReader.GetString("Setting");
			m_Value = dataReader.GetString("Value");
			m_LastModified = dataReader.GetSmartDate("LastModified");

			MarkOld();
			ValidationRules.CheckRules();
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
				command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO MachineSettings " + 
	                                  @"(MachineId,Setting,Value,LastModified)" + 
	                                  @" VALUES " +
	                                  @"(@MachineId,@Setting,@Value,@LastModified)";

				command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
				command.Parameters.AddWithValue(@"@Setting", m_Name);
				command.Parameters.AddWithValue(@"@Value", m_Value);
                command.Parameters.AddWithValue(@"@LastModified", DateTime.Now);

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
				command.CommandType = CommandType.Text;
                command.CommandText = @"UPDATE MachineSettings" +
	                                  @" SET Value=@Value,LastModified=@LastModified" +
	                                  @" WHERE MachineId=@MachineId" +
	                                  @" AND Setting=@Setting";

				command.Parameters.AddWithValue(@"@Value", m_Value);
                command.Parameters.AddWithValue(@"@LastModified", DateTime.Now);
				command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
				command.Parameters.AddWithValue(@"@Setting", m_Name);

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
				command.CommandType = CommandType.Text;
                command.CommandText = @"DELETE MachineSettings" + 
	                                  @" WHERE " +
	                                  @"MachineId=@MachineId" +
	                                  @" AND Setting=@Setting";
					
				command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
				command.Parameters.AddWithValue(@"@Setting", m_Name);
				
				command.ExecuteNonQuery();
				MarkNew();			
			}
		}

		#endregion
	}
}