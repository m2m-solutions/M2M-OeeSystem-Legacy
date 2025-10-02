using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace M2M.DataCenter
{
	[Serializable()]
	public partial class ArticleCollection : BusinessListBase<ArticleCollection, Article>
	{

		#region Business Methods

		protected string m_MachineId;

		/// <summary>
		/// Returns the Article object matching the name given.
		/// </summary>		
		public Article GetItem(string articleNumber)
		{
			foreach(Article item in this)
			{
				if ((item.ArticleNumber == articleNumber))
				{
					return item;
				}
			}
			return null;
			
		}

		/// <summary>
		/// Adds a new Article object to the collection
		/// </summary>
		public Article Add(string articleNumber)
		{
			Article item = Article.NewArticle(m_MachineId, articleNumber);
			Add(item);
			return item;
		}
		/// <summary>
		/// Removes the Article object matching the id given.
		/// </summary>
		public void Remove(string articleNumber)
		{
			Remove(GetItem(articleNumber));			
		}

		/// <summary>
		/// Returns true if a Article object matching the id exists.
		/// </summary>
		public bool Contains(string articleNumber)
		{
			return (GetItem(articleNumber) != null);
		}

		/// <summary>
		/// Returns true if a deleted Article object matching the id exists.
		/// </summary>
		public bool ContainsDeleted(string articleNumber)
		{
			foreach(Article item in DeletedList)
			{
				if (item.ArticleNumber == articleNumber)
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

		internal static ArticleCollection NewArticleCollection(string machineId)
		{
			return new ArticleCollection(machineId, false);
		}

		internal static ArticleCollection GetArticleCollection(string machineId)
		{
			return new ArticleCollection(machineId, true);
		}

		protected ArticleCollection()
		{
			MarkAsChild();
		}

		protected ArticleCollection(string machineId, bool fetch)
			: this()
		{
			m_MachineId = machineId;

			if (fetch)
				Fetch();
		}
		
		#endregion
	

		#region Data Access

		private void Fetch()
		{
			RaiseListChangedEvents = false;

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

					command.Parameters.AddWithValue("@MachineId", m_MachineId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(Article.GetArticle(dataReader));
						}
					}
				}
			}

			RaiseListChangedEvents = true;
		}



		internal void Update()
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
			foreach (Article item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();
			
			foreach (Article item in this)
			{
				item.Update();
			}
			if (createdConnection && (ApplicationContext.ExecutionLocation==ApplicationContext.ExecutionLocations.Client))
			{
				ApplicationContext.LocalContext.Remove("cn");
				connection.Dispose();
			}

			RaiseListChangedEvents = true;
		}

		#endregion
	}
}