using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class UserModule : BusinessBase<UserModule>
    {

        #region Business Methods
        protected Guid m_UserModuleId = Guid.NewGuid();
        protected string m_UserId = String.Empty;
        protected string m_Module = String.Empty;
        protected string m_DisplayName = String.Empty;

        // Id properties
        /// <summary>
        /// User module id
        /// </summary> 
        [System.ComponentModel.DataObjectField(true, true)]
        public Guid UserModuleId
        {
            get
            {
                CanReadProperty("UserModuleId", true);
                return m_UserModuleId;
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
        /// Module name
        /// </summary> 
        public string Module
        {
            get
            {
                CanReadProperty("Module", true);
                return m_Module;
            }
            set
            {
                CanWriteProperty("Module", true);
                if (m_Module != value)
                {
                    m_Module = value;
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
        /// User module Id
        /// </summary>
        public string UserModuleIdAsString
        {
            get
            {
                CanReadProperty("UserModuleId", true);
                return m_UserModuleId.ToString("d");
            }
        }

        // == Public collection properties ==
        protected override object GetIdValue()
        {
            return m_UserModuleId.ToString();
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

        internal static UserModule NewUserModule(string userId)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add UserModule objects");
            return new UserModule(userId);
        }

        internal static UserModule GetUserModule(SafeDataReader dr)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view UserModule objects");
            return new UserModule(dr);
        }

        protected UserModule()
            : base()
        {
            MarkAsChild();
        }

        protected UserModule(string userId)
            : this()
        {
            m_UserId = userId;

            ValidationRules.CheckRules();
        }

        protected UserModule(SafeDataReader dr)
            : this()
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dataReader)
        {
            m_UserModuleId = dataReader.GetGuid("UserModuleId");
            m_UserId = dataReader.GetString("UserId");
            m_Module = dataReader.GetString("Module");
            m_DisplayName = dataReader.GetString("DisplayName");

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
                command.CommandText = @"INSERT INTO UserModules (" +
                                                @"[UserModuleId]," +
                                                @"[UserId]," +
                                                @"[Module]" +
                                                @") VALUES (" +
                                                @"@UserModuleId," +
                                                @"@UserId," +
                                                @"@Module)";

                command.Parameters.AddWithValue(@"@UserModuleId", m_UserModuleId);
                command.Parameters.AddWithValue(@"@UserId", m_UserId);
                command.Parameters.AddWithValue(@"@Module", m_Module);

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
                command.CommandText = @"UPDATE UserModules SET " +
                                            @"[UserId]=@UserId," +
                                            @"[Module]=@Module" +
                                            @" WHERE " +
                                            @"[UserModuleId]=@UserModuleId";

                command.Parameters.AddWithValue(@"@UserModuleId", m_UserModuleId);
                command.Parameters.AddWithValue(@"@UserId", m_UserId);
                command.Parameters.AddWithValue(@"@Module", m_Module);

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
                command.CommandText = @"DELETE FROM UserModules WHERE " +
                                        @"[UserModuleId]=@UserModuleId";

                command.Parameters.AddWithValue(@"@UserModuleId", m_UserModuleId);
                command.ExecuteNonQuery();
                MarkNew();
            }
        }

        #endregion
    }
}