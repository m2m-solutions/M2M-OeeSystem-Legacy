using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class TagInfoList : ReadOnlyListBase<TagInfoList, TagInfoListItem>
	{
		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static TagInfoList GetTagInfoList()
		{
			return DataPortal.Fetch<TagInfoList>(new Criteria());
		}

		public static TagInfoList GetTagInfoList(string machineId)
		{
			return DataPortal.Fetch<TagInfoList>(new Criteria(machineId));
		}

		public static TagInfoList GetActiveTags()
		{
			return DataPortal.Fetch<TagInfoList>(new Criteria(true));
		}

		protected TagInfoList()
		{
			/* require use of factory methods */
		}

		#endregion
	

		#region Data Access

		[Serializable()]
		private class Criteria
		{
			private string m_MachineId = String.Empty;
			private bool m_ActiveOnly = false;

			public string MachineId
			{
				get { return m_MachineId; }
			}

			public bool ActiveOnly
			{
				get	{ return m_ActiveOnly; }
			}

			public Criteria()
			{
				
			}

			public Criteria(string machineId)
			{
				m_MachineId = machineId;
			}

			public Criteria(bool activeOnly)
			{
				m_ActiveOnly = activeOnly;
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					string whereClause = " WHERE OpcServer=@OpcServer";
                    command.Parameters.AddWithValue(@"@OpcServer", ApplicationSettings.OpcServerName == "Beijer.ElectronicsOPCServer.1" ? 1 : 2);
                    

					if (criteria.MachineId != String.Empty)
					{
						if (whereClause != String.Empty)
							whereClause += " AND ";

						whereClause += @"MachineId=@MachineId";
						command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);
					}

					if (criteria.ActiveOnly)
					{
						if (whereClause != String.Empty)
							whereClause += " AND ";

						whereClause += @"TagType>0 AND TagType<80";
					}
					
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
											@"Size," +
											@"ReadOnly," +
                                            @"SendPanelRequest," +
                                            @"RequestDelay," +
                                            @"CategoryId," +
											@"ScanRate" +
											@" FROM TagInfo" +
											whereClause;

					

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(TagInfoListItem.GetTagInfoListItem(dataReader));
						}
					}
				}
			}

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		#endregion
	}
}