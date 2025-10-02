using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter;

namespace M2M.Integrator.Tekla.Library
{
	[Serializable()]
	public partial class TeklaSetting : BusinessBase<TeklaSetting>
	{

		#region Business Methods
		protected string m_Name = "";
		protected string m_Value = "";

		/// <summary>
		/// Name
		/// </summary> 
		[System.ComponentModel.DataObjectField(true, true)]
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


		protected override object GetIdValue()
		{
			return m_Name;
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

		internal static TeklaSetting NewSetting()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add TeklaSetting objects");
			return new TeklaSetting();
		}

		internal static TeklaSetting NewSetting(string name)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add TeklaSetting objects");
			return new TeklaSetting(name);
		}

		internal static TeklaSetting GetSetting(SafeDataReader dr)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view TeklaSetting objects");
			return new TeklaSetting(dr);
		}

		protected TeklaSetting()
			: base()
		{
			MarkAsChild();
		}


		protected TeklaSetting(string name)
			: this()
		{
			m_Name = name;

			ValidationRules.CheckRules();
		}

		protected TeklaSetting(SafeDataReader dr)
			: this()
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dataReader)
		{
			m_Name = dataReader.GetString("Name");
			m_Value = dataReader.GetString("Value");

			MarkOld();
			ValidationRules.CheckRules();
		}

		internal void Insert()
		{
			if (!this.IsDirty)
				return;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"INSERT INTO TeklaSettings " +
										  @"(Name,Value)" +
										  @" VALUES " +
										  @"(@Name,@Value)";

					command.Parameters.AddWithValue(@"@Name", m_Name);
					command.Parameters.AddWithValue(@"@Value", m_Value);

					command.ExecuteNonQuery();
				}
			}

			MarkOld();
		}

		internal void Update()
		{
			if (!this.IsDirty)
				return;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"UPDATE TeklaSettings" +
										  @" SET Value=@Value" +
										  @" WHERE Name=@Name";

					command.Parameters.AddWithValue(@"@Value", m_Value);
					command.Parameters.AddWithValue(@"@Name", m_Name);

					command.ExecuteNonQuery();
				}
			}

			MarkOld();
		}

		internal void DeleteSelf()
		{
			if (!this.IsDirty)
				return;

			if (this.IsNew)
				return;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"DELETE TeklaSettings" +
										  @" WHERE " +
										  @"Name=@Name";

					command.Parameters.AddWithValue(@"@Name", m_Name);

					command.ExecuteNonQuery();
					MarkNew();
				}
			}
		}

		#endregion
	}
}