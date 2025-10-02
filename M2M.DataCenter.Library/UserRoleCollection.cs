using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class UserRoleCollection : BusinessListBase<UserRoleCollection, UserRole>
    {

        #region Business Methods

        // Parent Id member variables 

        protected string m_UserId;

        /// <summary>
        /// Returns the UserRole object matching the given id.
        /// </summary>	
        public UserRole GetItem(Guid userRoleId)
        {
            foreach (UserRole item in this)
            {
                if (item.UserRoleId == userRoleId)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the UserRole object matching the given parameters.
        /// </summary>		
        public UserRole GetItem(string userRole)
        {
            foreach (UserRole item in this)
            {
                if (item.Role == userRole)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds a new UserRole object to the collection
        /// </summary>
        public UserRole Add()
        {
            UserRole item = UserRole.NewUserRole(m_UserId);
            Add(item);
            return item;
        }
        /// <summary>
        /// Removes the UserRole object matching the id given.
        /// </summary>
        public void Remove(Guid userRoleId)
        {
            Remove(GetItem(userRoleId));
        }

        /// <summary>
        /// Returns true if a UserRole object matching the id exists.
        /// </summary>
        public bool Contains(string userRole)
        {
            return (GetItem(userRole) != null);
        }


        /// <summary>
        /// Returns true if a deleted UserRole object matching the id exists.
        /// </summary>
        public bool ContainsDeleted(Guid userRoleId)
        {
            foreach (UserRole item in DeletedList)
            {
                if (item.UserRoleId == userRoleId)
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

        internal static UserRoleCollection NewUserRoleCollection(string userId)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add UserRoleCollection objects");
            return new UserRoleCollection(userId, false);
        }

        internal static UserRoleCollection GetUserRoleCollection(string userId)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view UserRoleCollection objects");

            return new UserRoleCollection(userId, true);
        }

        protected UserRoleCollection()
        {
            MarkAsChild();
        }


        protected UserRoleCollection(string userId, bool fetch)
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
                                            @"u.UserRoleId," +
                                            @"u.UserId," +
                                            @"u.Role," +
                                            @"r.DisplayName," +
                                            @"r.AccessLevel" +
                                            @" FROM UserRoles u JOIN Roles r ON u.Role=r.Role WHERE " +
                                            @"u.UserId=@UserId ORDER BY r.AccessLevel";

                    command.Parameters.AddWithValue(@"@UserId", m_UserId);

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(UserRole.GetUserRole(dataReader));
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
            foreach (UserRole item in DeletedList)
            {
                item.DeleteSelf();
            }
            DeletedList.Clear();

            foreach (UserRole item in this)
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