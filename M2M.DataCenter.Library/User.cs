using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using Csla.Data;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
    [Serializable()]
    public class User : BusinessBase<User>
    {

        #region Business Methods
        protected string m_UserId = String.Empty;
        protected string m_DisplayName = String.Empty;
        protected string m_Password = String.Empty;
        protected string m_Notes = String.Empty;

        protected UserRoleCollection m_Roles = null;
        protected UserModuleCollection m_Modules = null;
        protected UserSettingCollection m_Settings = null;
        protected UserDivisionCollection m_Divisions = null;

        [System.ComponentModel.DataObjectField(true, false)]
        public string UserId
        {
            get
            {
                CanReadProperty("UserId", true);
                return m_UserId;
            }
        }


        // Public properties
        /// <summary>
        /// User name
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
                    PropertyHasChanged("DisplayName");
                }
            }
        }

        /// <summary>
        /// Password
        /// </summary> 
        public string Password
        {
            get
            {
                CanReadProperty("Password", true);
                return m_Password;
            }
            set
            {
                CanWriteProperty("Password", true);
                if (m_Password != value)
                {
                    m_Password = value;
                    PropertyHasChanged("Password");
                }
            }
        }


        /// <summary>
        /// Notes
        /// </summary> 
        public string Notes
        {
            get
            {
                CanReadProperty("Notes", true);
                return m_Notes;
            }
            set
            {
                CanWriteProperty("Notes", true);
                if (m_Notes != value)
                {
                    m_Notes = value;
                    PropertyHasChanged("Notes");
                }
            }
        }

        /// <summary>
        /// User roles
        /// </summary>		
        public UserRoleCollection Roles
        {
            get
            {
                return m_Roles;
            }
        }

        public UserRole RoleWithHighestAccess
        {
            get
            {
                return m_Roles[m_Roles.Count - 1];
            }
        }

        /// <summary>
        /// User modules
        /// </summary>		
        public UserModuleCollection Modules
        {
            get
            {
                return m_Modules;
            }
        }

        public string ModulesAsString
        {
            get
            {
                string modules = "";

                foreach (UserModule module in m_Modules)
                {
                    if (modules != "")
                        modules += ", ";
                    modules += ResourceStrings.GetString("Module." + module.Module);
                }

                return modules;
            }
        }


        /// <summary>
        /// User settings
        /// </summary>		
        public UserSettingCollection Settings
        {
            get
            {
                return m_Settings;
            }
        }

        /// <summary>
        /// User settings
        /// </summary>		
        public UserDivisionCollection Divisions
        {
            get
            {
                return m_Divisions;
            }
        }

        public string DivisionsAsString
        {
            get
            {
                if (CanSeeAllDivisions)
                    return ResourceStrings.GetString("AllDivisions");

                string divisions = "";
                foreach (UserDivision division in m_Divisions)
                {
                    if (divisions != "")
                        divisions += ", ";
                    divisions += division.DisplayName;
                }

                return divisions;
            }
        }

        public bool CanSeeAllDivisions
        {
            get { return m_Divisions.Count == 0; }
        }

        protected override object GetIdValue()
        {
            return m_UserId;
        }

        public override bool IsValid
        {
            get
            {
                return (base.IsValid &&
                        m_Roles.IsValid &&
                        m_Modules.IsValid &&
                        m_Settings.IsValid);
            }
        }

        public override bool IsDirty
        {
            get
            {
                return (base.IsDirty ||
                        m_Roles.IsDirty ||
                        m_Modules.IsDirty ||
                        m_Settings.IsDirty);
            }
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

        internal static User NewUser(string userId)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add User objects");
            return new User(userId);
        }

        internal static User GetUser(SafeDataReader dr)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view User objects");
            return new User(dr);
        }

        protected User()
            : base()
        {
            MarkAsChild();

        }


        protected User(string userId)
            : this()
        {
            m_UserId = userId;

            m_Roles = UserRoleCollection.NewUserRoleCollection(m_UserId);
            m_Modules = UserModuleCollection.NewUserModuleCollection(m_UserId);
            m_Settings = UserSettingCollection.NewUserSettingCollection(m_UserId);
            m_Divisions = UserDivisionCollection.NewUserDivisionCollection(m_UserId);
            ValidationRules.CheckRules();
        }

        protected User(SafeDataReader dr)
            : this()
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dataReader)
        {
            m_UserId = dataReader.GetString("UserId");
            m_DisplayName = dataReader.GetString("DisplayName");
            SimpleAES aes = new SimpleAES();
            m_Password = aes.DecryptString(dataReader.GetString("Password"));
            m_Notes = dataReader.GetString("Notes");

            m_Roles = UserRoleCollection.GetUserRoleCollection(m_UserId);
            m_Modules = UserModuleCollection.GetUserModuleCollection(m_UserId);
            m_Settings = UserSettingCollection.GetUserSettingCollection(m_UserId);
            m_Divisions = UserDivisionCollection.GetUserDivisionCollection(m_UserId);

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
                command.CommandText = @"INSERT INTO Users (" +
                                                @"[UserId]," +
                                                @"[DisplayName]," +
                                                @"[Password]," +
                                                @"[Notes]" +
                                                @") VALUES (" +
                                                @"@UserId," +
                                                @"@DisplayName," +
                                                @"@Password," +
                                                @"@Notes)";



                SimpleAES aes = new SimpleAES();
                command.Parameters.AddWithValue(@"@UserId", m_UserId);
                command.Parameters.AddWithValue(@"@DisplayName", m_DisplayName);
                command.Parameters.AddWithValue(@"@Password",  aes.EncryptToString(m_Password));
                command.Parameters.AddWithValue(@"@Notes", m_Notes);

                command.ExecuteNonQuery();
            }

            m_Roles.Update();
            m_Modules.Update();
            m_Settings.Update();
            m_Divisions.Update();

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
                command.CommandText = @"UPDATE Users SET " +
                                            @"[DisplayName]=@DisplayName," +
                                            @"[Password]=@Password," +
                                            @"[Notes]=@Notes" +
                                            @" WHERE " +
                                            @"[UserId]=@UserId";

                SimpleAES aes = new SimpleAES();
                command.Parameters.AddWithValue(@"@DisplayName", m_DisplayName);
                command.Parameters.AddWithValue(@"@Password", aes.EncryptToString(m_Password));
                command.Parameters.AddWithValue(@"@Notes", m_Notes);
                command.Parameters.AddWithValue(@"@UserId", m_UserId);

                command.ExecuteNonQuery();
            }

            m_Roles.Update();
            m_Modules.Update();
            m_Settings.Update();
            m_Divisions.Update();

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


            m_Roles.Clear();
            m_Roles.Update();
            m_Modules.Clear();
            m_Modules.Update();
            m_Settings.Clear();
            m_Settings.Update();
            m_Divisions.Clear();
            m_Divisions.Update();

            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE FROM Users WHERE " +
                                            @"[UserId]=@UserId";
                    command.Parameters.AddWithValue(@"@UserId", m_UserId);
                    command.ExecuteNonQuery();
                    MarkNew();
                }
            }
        }

        #endregion

    }
}