using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class TagInfo : BusinessBase<TagInfo>
	{
		#region Business Methods

		private string m_TagId = String.Empty;
		private string m_MachineId = String.Empty;
		private string m_DisplayName = String.Empty;
		private string m_Description = String.Empty;
		private string m_Address = String.Empty;
		private int m_DataType = 0;
		private TagType m_TagType = TagType.NotApplicable;
		private bool m_Inverted = false;
        private bool m_SendPanelRequest = false;
        private int m_RequestDelay = 0;
		private int m_ReasonCode = 0;

		public string TagId
		{
			get
			{
				CanReadProperty("TagId");
				return m_TagId;
			}
		}

        public string TagName
		{
			get
			{
				CanReadProperty("TagName");

				return m_TagId.Substring(m_TagId.LastIndexOf('.')+1);
			}
		}

		public string MachineId
		{
			get
			{
				CanReadProperty("MachineId");
				return m_MachineId;
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

		public string Description
		{
			get
			{
				CanReadProperty("Description");
				return m_Description;
			}
			set
			{
				CanWriteProperty("Description");
				if (m_Description != value)
				{
					m_Description = value;
					PropertyHasChanged("Description");
				}
			}
		}

		public string Address
		{
			get
			{
				CanReadProperty("Address");
				return m_Address;
			}
			set
			{
				CanWriteProperty("Address");
				if (m_Address != value)
				{
					m_Address = value;
					PropertyHasChanged("Address");
				}
			}
		}

		public int DataType
		{
			get
			{
				CanReadProperty("DataType");
				return m_DataType;
			}
			set
			{
				CanWriteProperty("DataType");
				if (m_DataType != value)
				{
					m_DataType = value;
					PropertyHasChanged("DataType");
				}
			}
		}

		public TagType TagType
		{
			get
			{
				CanReadProperty("TagType");
				return m_TagType;
			}
			set
			{
				CanWriteProperty("TagType");
				if (m_TagType != value)
				{
					m_TagType = value;
					PropertyHasChanged("TagType");
				}
			}
		}

		public bool Inverted
		{
			get
			{
				CanReadProperty("Inverted");
				return m_Inverted;
			}
			set
			{
				CanWriteProperty("Inverted");
				if (m_Inverted != value)
				{
					m_Inverted = value;
					PropertyHasChanged("Inverted");
				}
			}
		}

        public bool SendPanelRequest
        {
            get
            {
                CanReadProperty("SendPanelRequest");
                return m_SendPanelRequest;
            }
            set
            {
                CanWriteProperty("SendPanelRequest");
                if (m_SendPanelRequest != value)
                {
                    m_SendPanelRequest = value;
                    PropertyHasChanged("SendPanelRequest");
                }
            }
        }

        public int RequestDelay
        {
            get
            {
                CanReadProperty("RequestDelay");
                return m_RequestDelay;
            }
            set
            {
                CanWriteProperty("RequestDelay");
                if (m_RequestDelay != value)
                {
                    m_RequestDelay = value;
                    PropertyHasChanged("RequestDelay");
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

		protected override object GetIdValue()
		{
			return m_TagId;
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

		internal static TagInfo NewTagInfo(string machineId, string accessPath, string tagName)
		{
			return new TagInfo(machineId, accessPath, tagName);
		}

		internal static TagInfo GetTagInfo(SafeDataReader dr)
		{
			return new TagInfo(dr);
		}

		public static TagInfo GetTagInfo(string tagId)
		{
			return new TagInfo(tagId);
		}

        public static TagInfo GetTagInfo(string machineId, TagType tagType)
        {
            return new TagInfo(machineId, tagType);
        }

		private TagInfo()
		{
			
		}

        private TagInfo(string machineId, string accessPath, string tagName)
			: this()
		{
			m_TagId = String.Format("{0}.{1}", accessPath, tagName);

			m_MachineId = machineId;

			MarkAsChild();
		}

		private TagInfo(SafeDataReader dr) : this()
		{
            MarkAsChild();
			Fetch(dr);
		}

		private TagInfo(string tagId)
			: this()
		{
			Fetch(tagId);
		}

        private TagInfo(string machineId, TagType tagType)
            : this()
        {
            Fetch(machineId, tagType);
        }

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dr)
		{
			m_TagId = dr.GetString("TagId");
			m_MachineId = dr.GetString("MachineId");
			m_DisplayName = dr.GetString("DisplayName");
			m_Description = dr.GetString("Description");
			m_TagType = (TagType)dr.GetInt32("TagType");
			m_Inverted = dr.GetBoolean("Inverted");
			m_Address = dr.GetString("Address");
			m_DataType = dr.GetInt32("DataType");
			m_SendPanelRequest = dr.GetBoolean("SendPanelRequest");
            m_RequestDelay = dr.GetInt32("RequestDelay");
			m_ReasonCode = dr.GetInt32("ReasonCode");

			MarkOld();
		}

		private void Fetch(string tagId)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT " +
											@"TagId," +
											@"MachineId," +
											@"DisplayName," +
											@"Description," +
											@"TagType," +
											@"Inverted," +
											@"Address," +
											@"DataType," +
											@"SendPanelRequest," +
                                            @"RequestDelay," +
											@"ReasonCode" +
											@" FROM TagInfo" +
											" WHERE TagId=@TagId";

					command.Parameters.AddWithValue(@"@TagId", tagId);
				
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

        private void Fetch(string machineId, TagType tagType)
        {
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT " +
                                            @"TagId" +
                                            @" FROM TagInfo" +
                                            @" WHERE MachineId=@MachineId AND TagType=@TagType";

                    command.Parameters.AddWithValue(@"@MachineId", machineId);
                    command.Parameters.AddWithValue(@"@TagType", tagType);

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            m_TagId = dataReader.GetString("TagId");
                        }
                    }
                }
            }
        }

		internal void Insert()
		{
			if (!this.IsDirty)
				return;

			SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];

			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandType = CommandType.Text;
				command.CommandText = "INSERT INTO TagInfo (" +
										"TagId," +
										"MachineId," +
										"DisplayName," +
										"Description," +
										"TagType," +
										"Inverted," +
										"Address," +
										"DataType," +
										"SendPanelRequest," +
                                        "RequestDelay," +
										"ReasonCode" +
										") VALUES (" +
										"@TagId," +
										"@MachineId," +
										"@DisplayName," +
										"@Description," +
										"@TagType," +
										"@Inverted," +
										"@Address," +
										"@DataType," +
										"@SendPanelRequest," +
                                        "@RequestDelay," +
										"@ReasonCode)";

				command.Parameters.AddWithValue("@TagId", m_TagId);
				command.Parameters.AddWithValue("@MachineId", m_MachineId);
				command.Parameters.AddWithValue("@DisplayName", m_DisplayName);
				command.Parameters.AddWithValue("@Description", m_Description);
				command.Parameters.AddWithValue("@TagType", (int)m_TagType);
				command.Parameters.AddWithValue("@Inverted", m_Inverted);
				command.Parameters.AddWithValue("@Address", m_Address);
				command.Parameters.AddWithValue("@DataType", m_DataType);
				command.Parameters.AddWithValue("@SendPanelRequest", m_SendPanelRequest);
                command.Parameters.AddWithValue("@RequestDelay", m_RequestDelay);
				command.Parameters.AddWithValue("@ReasonCode", m_ReasonCode);

				command.ExecuteNonQuery();
			}

			MarkOld();
		}

		internal void Update()
		{
			if (!this.IsDirty)
				return;

			SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];

			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandType = CommandType.Text;
				command.CommandText = "UPDATE TagInfo SET " +
										"DisplayName=@DisplayName," +
										"TagType=@TagType," +
										"Inverted=@Inverted" +
										" WHERE " +
										"TagId=@TagId";

				command.Parameters.AddWithValue("@DisplayName", m_DisplayName);
				command.Parameters.AddWithValue("@TagType", (int)m_TagType);
				command.Parameters.AddWithValue("@Inverted", m_Inverted);
				command.Parameters.AddWithValue("@TagId", m_TagId);
				
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

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
 
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = "DELETE FROM TagInfo WHERE " +
					                        "TagId=@TagId";
					
					command.Parameters.AddWithValue("@TagId", m_TagId);
			
					command.ExecuteNonQuery();
				}
			}

			MarkNew();
		}

		#endregion


	}
}
