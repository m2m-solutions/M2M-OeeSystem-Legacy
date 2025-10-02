using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class ArticleList : ReadOnlyListBase<ArticleList, ArticleListItem>
	{

		#region Business Methods

		public ArticleListItem GetItem(string articleNumber)
		{
			foreach(ArticleListItem item in this)
			{
				if ((item.ArticleNumber == articleNumber))
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

		internal static ArticleList GetArticleList(string machineId)
		{
			return DataPortal.Fetch<ArticleList>(new Criteria(machineId));
		}

		internal ArticleList()
		{
			/* require use of factory methods */
		}

		#endregion
	

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_MachineId = "";

			public Criteria()
			{

			}

			public Criteria(string machineId)
			{
				m_MachineId = machineId;
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
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
					command.CommandText = @"SELECT DISTINCT " +
											@"[MachineId]," +
											@"[ArticleNumber]" +
											@" FROM ArticleSettings" +
											@" WHERE MachineId=@MachineId";

					command.Parameters.AddWithValue("@MachineId", criteria.MachineId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(ArticleListItem.GetArticleListItem(dataReader));
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