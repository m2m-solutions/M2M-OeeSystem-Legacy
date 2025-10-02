using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class UserCollection : BusinessListBase<UserCollection, User>
	{

		#region Business Methods

		/// <summary>
		/// Returns the User object matching the name given.
		/// </summary>		
		public User GetItem(string userId)
		{
			foreach(User item in this)
			{
				if ((item.UserId == userId))
				{
					return item;
				}
			}
			return null;
			
		}

		/// <summary>
		/// Adds a new User object to the collection
		/// </summary>
		public User Add(string userId)
		{
			User item = User.NewUser(userId);
			Add(item);
			return item;
		}
		/// <summary>
		/// Removes the User object matching the id given.
		/// </summary>
		public void Remove(string userId)
		{
			Remove(GetItem(userId));			
		}

		/// <summary>
		/// Returns true if a User object matching the id exists.
		/// </summary>
		public bool Contains(string userId)
		{
			return (GetItem(userId) != null);
		}

		/// <summary>
		/// Returns true if a deleted User object matching the id exists.
		/// </summary>
		public bool ContainsDeleted(string userId)
		{
			foreach(User item in DeletedList)
			{
				if (item.UserId == userId)
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

		public static UserCollection GetUserCollection()
		{
			return GetUserCollection(true);
		}

        public static UserCollection GetUserCollection(bool ignoreUser)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view UserCollection objects");

            return DataPortal.Fetch<UserCollection>(new Criteria(ignoreUser));
        }

		protected UserCollection()
		{
			
		}
	
		#endregion
	

		#region Data Access

        public class Criteria
        {
            private bool m_IgnoreUser = true;

            public bool IgnoreUser
            {
                get { return m_IgnoreUser; }
                set { m_IgnoreUser = value; }
            }

            public Criteria(bool ignoreUser)
            {
                m_IgnoreUser = ignoreUser;
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
											@"[UserId]," +
											@"[DisplayName]," +
											@"[Password]," +
											@"[Notes]" +
											@" FROM Users";

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
                            User user = User.GetUser(dataReader);

                            if (criteria.IgnoreUser || M2MDataCenter.User.CanAdminstrateUser(user)) 
                            {
                                Add(User.GetUser(dataReader));
                            }
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
			foreach (User item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();
			
			foreach (User item in this)
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