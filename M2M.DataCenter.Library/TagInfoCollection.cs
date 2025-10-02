using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class TagInfoCollection : BusinessListBase<TagInfoCollection, TagInfo>
	{

		#region Business Methods

		public TagInfo Add(string machineId, string accessPath, string tagName)
		{
			TagInfo item = TagInfo.NewTagInfo(machineId, accessPath, tagName);
			Add(item);
			return item;
		}

		public TagInfo GetItem(string tagId)
		{
			foreach (TagInfo item in this)
			{
				if (item.TagId == tagId)
				{
					return item;
				}
			}
			return null;

		}

        public bool Contains(string machineId, string tagName)
        {
            foreach (TagInfo item in this)
            {
                if (item.MachineId == machineId && item.TagName == tagName)
                {
                    return true;
                }
            }
            return false;
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

		public static TagInfoCollection NewTagInfoCollection()
		{
			return new TagInfoCollection();
		}

		public static TagInfoCollection GetTagInfoCollection()
		{
			return DataPortal.Fetch<TagInfoCollection>();
		}

		public static TagInfoCollection GetTagInfoCollection(string machineId)
		{
			return DataPortal.Fetch<TagInfoCollection>(new Criteria(machineId));
		}

		protected TagInfoCollection()
		{
		}

		#endregion
	

		#region Data Access

		[Serializable()]
		private class Criteria
		{
			private string m_MachineId = String.Empty;
			
			public string MachineId
			{
				get { return m_MachineId; }
			}

			public Criteria(string machineId)
			{
				m_MachineId = machineId;
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
		
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
                                            @"ReasonCode," +
											@"Description," +
											@"TagType," +
											@"Inverted," +
											@"Address," +
											@"DataType," +
											@"SendPanelRequest," +
                                            @"RequestDelay" +
											@" FROM TagInfo";

					if (criteria.MachineId != String.Empty)
					{
						command.CommandText += @" WHERE MachineId=@MachineId";
						command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);
					}
				
					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(TagInfo.GetTagInfo(dataReader));
						}
					}
				}
			}

			RaiseListChangedEvents = true;
		}
		
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;
			SqlConnection connection;
			bool createdConnection = false;
			if (ApplicationContext.LocalContext["cn"] != null)
			{
				connection = (SqlConnection)ApplicationContext.LocalContext["cn"];
			}
			else
			{
				createdConnection = true;
				connection = new SqlConnection(Database.SystemConnectionString);
				connection.Open();
				ApplicationContext.LocalContext["cn"] = connection;
			}
			
			foreach (TagInfo item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();

			foreach (TagInfo item in this)
			{
				if (item.IsNew)
				{
					item.Insert();
				}
				else
				{
					item.Update();
				}
			}

			if (createdConnection && (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client))
			{
				ApplicationContext.LocalContext.Remove("cn");
				connection.Dispose();
			}

			RaiseListChangedEvents = true;
		}

		#endregion
	}
}