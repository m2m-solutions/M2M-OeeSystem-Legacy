using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class UserSettingCollection : BusinessListBase<UserSettingCollection, UserSetting>
	{

		#region Business Methods

		

		// Parent Id member variables 

		protected string m_UserId;


        public string Culture
        {
            get
            {
                UserSetting item = GetItem("Culture");

                if (item == null)
                {
                    item = Add("Culture");
                    item.Value = "Auto";
                }

                return item.Value;
            }
            set
            {
                UserSetting item = GetItem("Culture");

                if (item == null)
                    item = Add("Culture");

                item.Value = value;
            }
        }

        /// <summary>
		/// Returns the UserSetting object matching the id given.
		/// </summary>		
		public UserSetting GetItem(string name)
		{
			foreach(UserSetting item in this)
			{
				if (item.Name == name)
				{
					return item;
				}
			}
			return null;
			
		}

		/// <summary>
		/// Adds a new UserSetting object to the collection
		/// </summary>
		public UserSetting Add(string name)
		{
			UserSetting item = UserSetting.NewUserSetting(m_UserId, name);
			Add(item);
			return item;
		}
		/// <summary>
		/// Removes the UserSetting object matching the id given.
		/// </summary>
		public void Remove(string name)
		{
			Remove(GetItem(name));			
		}

		/// <summary>
		/// Returns true if a UserSetting object matching the id exists.
		/// </summary>
		public bool Contains(string name)
		{
			return (GetItem(name) != null);
		}

		/// <summary>
		/// Returns true if a deleted UserSetting object matching the id exists.
		/// </summary>
		public bool ContainsDeleted(string name)
		{
			foreach(UserSetting item in DeletedList)
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

		internal static UserSettingCollection NewUserSettingCollection(string userId)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add UserSettingCollection objects");
			return new UserSettingCollection(userId, false);
		}

		internal static UserSettingCollection GetUserSettingCollection(string userId)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view UserSettingCollection objects");
				return new UserSettingCollection(userId, true);
		}

		protected UserSettingCollection()
		{
		
			MarkAsChild();
		
		}

		
		protected UserSettingCollection(string userId, bool fetch) : this()
		{	
			m_UserId = userId;

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
					command.CommandText = @"SELECT " +
											@"[UserId]," +
											@"[Name]," +
											@"[Value]" +
											@" FROM UserSettings WHERE " +
											@"[UserId]=@UserId";

					command.Parameters.AddWithValue(@"@UserId", m_UserId);
					
					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(UserSetting.GetUserSetting(dataReader));
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
			foreach (UserSetting item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();
			
			foreach (UserSetting item in this)
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