using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class UserRole : BusinessBase<UserRole>
    {

        #region Business Methods
        protected Guid m_UserRoleId = Guid.NewGuid();
        protected string m_UserId = String.Empty;
        protected string m_Role = String.Empty;
        protected string m_DisplayName = String.Empty;
        protected int m_AccessLevel = 0;

        // Id properties
        /// <summary>
        /// User role id
        /// </summary> 
        [System.ComponentModel.DataObjectField(true, true)]
        public Guid UserRoleId
        {
            get
            {
                CanReadProperty("UserRoleId", true);
                return m_UserRoleId;
            }
        }

        /// <summary>
        /// User id
        /// </summary> 
        public string UserId
        {
            get
            {
                CanReadProperty("UserId", true);
                return m_UserId;
            }
            set
            {
                CanWriteProperty("UserId", true);
                if (m_UserId != value)
                {
                    m_UserId = value;
                }
            }
        }

        /// <summary>
        /// Role name
        /// </summary> 
        public string Role
        {
            get
            {
                CanReadProperty("Role", true);
                return m_Role;
            }
            set
            {
                CanWriteProperty("Role", true);
                if (m_Role != value)
                {
                    m_Role = value;
                }
            }
        }

        /// <summary>
        /// Display name
        /// </summary> 
        public string DisplayName
        {
            get
            {
                CanReadProperty("DisplayName", true);
                return m_DisplayName;
            }
            set
            {
                CanWriteProperty("DisplayName", true);
                if (m_DisplayName != value)
                {
                    m_DisplayName = value;
                }
            }
        }

        /// <summary>
        /// Access level
        /// </summary> 
        public int AccessLevel
        {
            get
            {
                CanReadProperty("AccessLevel", true);
                return m_AccessLevel;
            }
            set
            {
                CanWriteProperty("AccessLevel", true);
                if (m_AccessLevel != value)
                {
                    m_AccessLevel = value;
                }
            }
        }

        /// <summary>
        /// User role Id
        /// </summary>
        public string UserRoleIdAsString
        {
            get
            {
                CanReadProperty("UserRoleId", true);
                return m_UserRoleId.ToString("d");
            }
        }

        // == Public collection properties ==
        protected override object GetIdValue()
        {
            return m_UserRoleId.ToString();
        }

        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
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

        internal static UserRole NewUserRole(string userId)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add UserRole objects");
            return new UserRole(userId);
        }

        internal static UserRole GetUserRole(SafeDataReader dr)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view UserRole objects");
            return new UserRole(dr);
        }

        protected UserRole()
            : base()
        {
            MarkAsChild();
        }

        protected UserRole(string userId)
            : this()
        {
            m_UserId = userId;

            ValidationRules.CheckRules();
        }

        protected UserRole(SafeDataReader dr)
            : this()
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dataReader)
        {
            m_UserRoleId = dataReader.GetGuid("UserRoleId");
            m_UserId = dataReader.GetString("UserId");
            m_Role = dataReader.GetString("Role");
            m_DisplayName = dataReader.GetString("DisplayName");
            m_AccessLevel = dataReader.GetInt32("AccessLevel");

            MarkOld();
            ValidationRules.CheckRules();
        }

        internal void Insert()
        {
            if (!this.IsDirty)
                return;

            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized");

            SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO UserRoles (" +
                                                @"[UserRoleId]," +
                                                @"[UserId]," +
                                                @"[Role]" +
                                                @") VALUES (" +
                                                @"@UserRoleId," +
                                                @"@UserId," +
                                                @"@Role)";

                command.Parameters.AddWithValue(@"@UserRoleId", m_UserRoleId);
                command.Parameters.AddWithValue(@"@UserId", m_UserId);
                command.Parameters.AddWithValue(@"@Role", m_Role);

                command.ExecuteNonQuery();
            }


            MarkOld();
        }

        internal void Update()
        {
            if (!this.IsDirty)
                return;

            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized");

            SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"UPDATE UserRoles SET " +
                                            @"[UserId]=@UserId," +
                                            @"[Role]=@Role" +
                                            @" WHERE " +
                                            @"[UserRoleId]=@UserRoleId";

                command.Parameters.AddWithValue(@"@UserRoleId", m_UserRoleId);
                command.Parameters.AddWithValue(@"@UserId", m_UserId);
                command.Parameters.AddWithValue(@"@Role", m_Role);

                command.ExecuteNonQuery();
            }

            MarkOld();
        }

        internal void DeleteSelf()
        {
            if (!this.IsDirty)
                return;

            if (this.IsNew)
                return;

            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized");

            SqlConnection connection = (SqlConnection)ApplicationContext.LocalContext["cn"];

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"DELETE FROM UserRoles WHERE " +
                                        @"[UserRoleId]=@UserRoleId";

                command.Parameters.AddWithValue(@"@UserRoleId", m_UserRoleId);
                command.ExecuteNonQuery();
                MarkNew();
            }
        }

        #endregion
    }
}