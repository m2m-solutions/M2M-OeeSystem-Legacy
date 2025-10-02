using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class UserModuleCollection : BusinessListBase<UserModuleCollection, UserModule>
    {

        #region Business Methods

        // Parent Id member variables 

        protected string m_UserId;

        /// <summary>
        /// Returns the UserModule object matching the given id.
        /// </summary>	
        public UserModule GetItem(Guid userModuleId)
        {
            foreach (UserModule item in this)
            {
                if (item.UserModuleId == userModuleId)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the UserModule object matching the given parameters.
        /// </summary>		
        public UserModule GetItem(string userModule)
        {
            foreach (UserModule item in this)
            {
                if (item.Module == userModule)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds a new UserModule object to the collection
        /// </summary>
        public UserModule Add()
        {
            UserModule item = UserModule.NewUserModule(m_UserId);
            Add(item);
            return item;
        }
        /// <summary>
        /// Removes the UserModule object matching the id given.
        /// </summary>
        public void Remove(Guid userModuleId)
        {
            Remove(GetItem(userModuleId));
        }

        /// <summary>
        /// Returns true if a UserModule object matching the id exists.
        /// </summary>
        public bool Contains(string userModule)
        {
            return (GetItem(userModule) != null);
        }


        /// <summary>
        /// Returns true if a deleted UserModule object matching the id exists.
        /// </summary>
        public bool ContainsDeleted(Guid userModuleId)
        {
            foreach (UserModule item in DeletedList)
            {
                if (item.UserModuleId == userModuleId)
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

        internal static UserModuleCollection NewUserModuleCollection(string userId)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add UserModuleCollection objects");
            return new UserModuleCollection(userId, false);
        }

        internal static UserModuleCollection GetUserModuleCollection(string userId)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view UserModuleCollection objects");

            return new UserModuleCollection(userId, true);
        }

        protected UserModuleCollection()
        {
            MarkAsChild();
        }


        protected UserModuleCollection(string userId, bool fetch)
            : this()
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
                                            @"u.UserModuleId," +
                                            @"u.UserId," +
                                            @"u.Module," +
                                            @"m.DisplayName" +
                                            @" FROM UserModules u JOIN Modules m ON u.Module=m.Module WHERE " +
                                            @"u.UserId=@UserId AND m.SystemOnly=0";

                    command.Parameters.AddWithValue(@"@UserId", m_UserId);

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(UserModule.GetUserModule(dataReader));
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
            foreach (UserModule item in DeletedList)
            {
                item.DeleteSelf();
            }
            DeletedList.Clear();

            foreach (UserModule item in this)
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