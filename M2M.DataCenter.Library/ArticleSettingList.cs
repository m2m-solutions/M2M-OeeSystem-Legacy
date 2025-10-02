using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class ArticleSettingList : ReadOnlyListBase<ArticleSettingList, ArticleSettingListItem>
	{
		#region Business Methods

		/// <summary>
		/// Returns the ArticleSettingListItem object matching the id given.
		/// </summary>		
		public ArticleSettingListItem GetItem(string name)
		{
			foreach (ArticleSettingListItem item in this)
			{
				if (item.Setting == name)
				{
					return item;
				}
			}
			return null;

		}
		#endregion

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static ArticleSettingList GetArticleSettingList()
		{
			return DataPortal.Fetch<ArticleSettingList>(new Criteria());
		}

		public static ArticleSettingList GetArticleSettingList(string machineId)
		{
			return DataPortal.Fetch<ArticleSettingList>(new Criteria(machineId));
		}

		public static ArticleSettingList GetArticleSettingList(string machineId, string articleNumber)
		{
			return DataPortal.Fetch<ArticleSettingList>(new Criteria(machineId, articleNumber));
		}

		public static ArticleSettingList GetArticleSettingList(Criteria criteria)
		{
			return DataPortal.Fetch<ArticleSettingList>(criteria);
		}

		private ArticleSettingList()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_MachineId = null;
			private string m_ArticleNumber = null;

			public Criteria()
			{
			}

			public Criteria(string machineId)
			{
				m_MachineId = machineId;
			}

			public Criteria(string machineId, string articleNumber)
			{
				m_MachineId = machineId;
				m_ArticleNumber = articleNumber;
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
			}

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
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
					command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT MachineId,ArticleNumber,Setting,Value,LastModified" +
	                                      @" FROM ArticleSettings" + 
	                                      @" WHERE MachineId=@MachineId" +
                                          @" AND ArticleNumber=@ArticleNumber" +
                                          @" ORDER BY MachineId,ArticleNumber";
					command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
					command.Parameters.AddWithValue("@ArticleNumber", criteria.ArticleNumber);

					using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					{
						while (dr.Read())
						{
							Add(ArticleSettingListItem.GetArticleSettingListItem(dr));
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

