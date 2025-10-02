using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class ArticleSettingCollection : BusinessListBase<ArticleSettingCollection, ArticleSetting>
	{

		#region Business Methods

		

		// Parent Id member variables 

		protected string m_MachineId;
		protected string m_ArticleNumber;

		/// <summary>
		/// Returns the ArticleSetting object matching the id given.
		/// </summary>		
		public ArticleSetting GetItem(string name)
		{
			foreach(ArticleSetting item in this)
			{
				if (item.Name == name)
				{
					return item;
				}
			}
			return null;
			
		}

		/// <summary>
		/// Adds a new ArticleSetting object to the collection
		/// </summary>
		public ArticleSetting Add(string name)
		{
			ArticleSetting item = ArticleSetting.NewArticleSetting(m_MachineId, m_ArticleNumber, name);
			Add(item);
			return item;
		}
		/// <summary>
		/// Removes the ArticleSetting object matching the id given.
		/// </summary>
		public void Remove(string name)
		{
			Remove(GetItem(name));			
		}

		/// <summary>
		/// Returns true if a ArticleSetting object matching the id exists.
		/// </summary>
		public bool Contains(string name)
		{
			return (GetItem(name) != null);
		}

		/// <summary>
		/// Returns true if a deleted ArticleSetting object matching the id exists.
		/// </summary>
		public bool ContainsDeleted(string name)
		{
			foreach(ArticleSetting item in DeletedList)
			{
				if (item.Name == name)
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

		internal static ArticleSettingCollection NewArticleSettingCollection(string machineId, string articleNumber)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add ArticleSettingCollection objects");
			return new ArticleSettingCollection(machineId, articleNumber, false);
		}

		internal static ArticleSettingCollection GetArticleSettingCollection(string machineId, string articleNumber)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view ArticleSettingCollection objects");
				return new ArticleSettingCollection(machineId, articleNumber, true);
		}

		protected ArticleSettingCollection()
		{
		
			MarkAsChild();
		
		}


		protected ArticleSettingCollection(string machineId, string articleNumber, bool fetch)
			: this()
		{	
			m_MachineId = machineId;
			m_ArticleNumber = articleNumber;

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
                    command.CommandText = @"SELECT MachineId,ArticleNumber,Setting,Value,LastModified" +
	                                      @" FROM ArticleSettings" + 
	                                      @" WHERE MachineId=@MachineId" +
                                          @" AND ArticleNumber=@ArticleNumber" +
	                                      @" ORDER BY MachineId,ArticleNumber";

					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@ArticleNumber", m_ArticleNumber);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(ArticleSetting.GetArticleSetting(dataReader));
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
			foreach (ArticleSetting item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();
			
			foreach (ArticleSetting item in this)
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