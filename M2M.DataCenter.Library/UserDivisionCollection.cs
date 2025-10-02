using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class UserDivisionCollection : BusinessListBase<UserDivisionCollection, UserDivision>
    {

        #region Business Methods

        // Parent Id member variables 

        protected string m_UserId;

        /// <summary>
        /// Returns the UserDivision object matching the given id.
        /// </summary>	
        public UserDivision GetItem(Guid userDivisionId)
        {
            foreach (UserDivision item in this)
            {
                if (item.UserDivisionId == userDivisionId)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the UserDivision object matching the given parameters.
        /// </summary>		
        public UserDivision GetItem(string userDivision)
        {
            foreach (UserDivision item in this)
            {
                if (item.DivisionId == userDivision)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds a new UserDivision object to the collection
        /// </summary>
        public UserDivision Add()
        {
            UserDivision item = UserDivision.NewUserDivision(m_UserId);
            Add(item);
            return item;
        }
        /// <summary>
        /// Removes the UserDivision object matching the id given.
        /// </summary>
        public void Remove(Guid userDivisionId)
        {
            Remove(GetItem(userDivisionId));
        }

        /// <summary>
        /// Returns true if a UserDivision object matching the id exists.
        /// </summary>
        public bool Contains(string userDivision)
        {
            return (GetItem(userDivision) != null);
        }


        /// <summary>
        /// Returns true if a deleted UserDivision object matching the id exists.
        /// </summary>
        public bool ContainsDeleted(Guid userDivisionId)
        {
            foreach (UserDivision item in DeletedList)
            {
                if (item.UserDivisionId == userDivisionId)
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

        internal static UserDivisionCollection NewUserDivisionCollection(string userId)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add UserDivisionCollection objects");
            return new UserDivisionCollection(userId, false);
        }

        internal static UserDivisionCollection GetUserDivisionCollection(string userId)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view UserDivisionCollection objects");

            return new UserDivisionCollection(userId, true);
        }

        protected UserDivisionCollection()
        {
            MarkAsChild();
        }


        protected UserDivisionCollection(string userId, bool fetch)
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
                                            @"u.UserDivisionId," +
                                            @"u.UserId," +
                                            @"u.DivisionId," +
                                            @"d.DisplayName" +
                                            @" FROM UserDivisions u JOIN Divisions d ON u.DivisionId=d.DivisionId WHERE " +
                                            @"u.UserId=@UserId";

                    command.Parameters.AddWithValue(@"@UserId", m_UserId);

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(UserDivision.GetUserDivision(dataReader));
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
            foreach (UserDivision item in DeletedList)
            {
                item.DeleteSelf();
            }
            DeletedList.Clear();

            foreach (UserDivision item in this)
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