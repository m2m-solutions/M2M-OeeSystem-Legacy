using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class UserSetting : BusinessBase<UserSetting>
	{

		#region Business Methods 
		protected string m_UserId = String.Empty;
		protected string m_Name = String.Empty;
		protected string m_Value = String.Empty;
		
		// Id properties
		/// <summary>
		/// User Id
		/// </summary> 
		[System.ComponentModel.DataObjectField(true, false)]
		public string UserId
		{
			get
			{
				CanReadProperty("UserId", true);
				return m_UserId;
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

		protected override object GetIdValue()
		{
			return m_UserId.ToString() + "|" + 
					m_Name.ToString();
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

		internal static UserSetting NewUserSetting(string userId, string name)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add UserSetting objects");
			return new UserSetting(userId, name);
		}

		internal static UserSetting GetUserSetting(SafeDataReader dr)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view UserSetting objects");
			return new UserSetting(dr);
		}

		protected UserSetting(): base()
		{
			MarkAsChild();
		}

		
		protected UserSetting(string userId, string name) : this()
		{
			m_UserId = userId;
			m_Name = name;

			ValidationRules.CheckRules();
		}

		protected UserSetting(SafeDataReader dr) : this()
		{
			Fetch(dr);
		}

		#endregion
	
		#region Data Access

		private void Fetch(SafeDataReader dataReader)
		{	
			m_UserId = dataReader.GetString("UserId");
			m_Name = dataReader.GetString("Name");
			m_Value = dataReader.GetString("Value");

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
				command.CommandText = @"INSERT INTO UserSettings (" +
												@"[UserId]," +
												@"[Name]," +
												@"[Value]" +
												@") VALUES (" +
												@"@UserId," + 
												@"@Name," + 
												@"@Value)";
				
				command.Parameters.AddWithValue(@"@UserId", m_UserId);
				command.Parameters.AddWithValue(@"@Name", m_Name);
				command.Parameters.AddWithValue(@"@Value", m_Value);

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
				command.CommandText = @"UPDATE UserSettings SET " +
											@"[Value]=@Value" +
											@" WHERE " +
											@"[UserId]=@UserId AND " +
											@"[Name]=@Name";

				command.Parameters.AddWithValue(@"@Value", m_Value);
				command.Parameters.AddWithValue(@"@UserId", m_UserId);
				command.Parameters.AddWithValue(@"@Name", m_Name);

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
				command.CommandText = @"DELETE FROM UserSettings WHERE " +
										@"[UserId]=@UserId AND " +
										@"[Name]=@Name";
					
				command.Parameters.AddWithValue(@"@UserId", m_UserId);
				command.Parameters.AddWithValue(@"@Name", m_Name);
				
				command.ExecuteNonQuery();
				MarkNew();			
			}
		}

		#endregion
	}
}