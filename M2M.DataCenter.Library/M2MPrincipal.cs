using System;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Csla;
using Csla.Data;
using System.Security.Principal;

namespace M2M.DataCenter
{
	/// <summary>
	/// Encapsulation of a user
	/// </summary>
	[Serializable()]
	public partial class M2MPrincipal : BusinessBase<M2MPrincipal>, IPrincipal, IM2MPrincipal
	{

		#region Business Methods 

		private M2MIdentity m_Identity;
		protected string m_UserId = "";
		protected string m_Name = "";
		protected string m_Notes = "";
		protected string m_Password = "";
		protected UserSettingCollection m_UserSettings = null;
		protected UserRoleCollection m_UserRoles = null;
        protected UserModuleCollection m_UserModules = null;
        protected UserDivisionCollection m_UserDivisions = null;
		
		// Public properties
		/// <summary>
		/// User id
		/// </summary> 
		[System.ComponentModel.DataObjectField(true, true)]
		public string UserId
		{
			get
			{
				CanReadProperty("UserId", true);
				return m_UserId;
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
		/// Users full name
		/// </summary> 
		public string Name
		{
			get
			{
				CanReadProperty("Name", true);
				return m_Name;
			}
			set
			{
				CanWriteProperty("Name", true);
				if (m_Name != value)
				{
					m_Name = value;
					PropertyHasChanged("Name");
				}
			}
		}

		/// <summary>
		/// Users notes
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
		/// The user settings for the M2M application
		/// </summary>
		public UserSettingCollection Settings
		{
			get 
			{
				return m_UserSettings; 
			}
		}

		/// <summary>
		/// The user roles for the M2M application
		/// </summary>
		public UserRoleCollection Roles
		{
			get
			{
				return m_UserRoles;
			}
		}

        /// <summary>
        /// The user modules for the M2M application
        /// </summary>
        public UserModuleCollection Modules
        {
            get
            {
                return m_UserModules;
            }
        }

        /// <summary>
        /// The user divisions for the M2M application
        /// </summary>
        public UserDivisionCollection Divisions
        {
            get
            {
                return m_UserDivisions;
            }
        }

        public bool CanAdminstrateUser(User user)
        {
            // A user can administrate himself and all users with lower access level
            // whome has equal or less division accessibilty
            if(this.UserId == user.UserId)
                return true;

            int roleWithHighestAccess = 0;

            foreach(UserRole userRole in m_UserRoles)
            {
                if(userRole.AccessLevel > roleWithHighestAccess)
                    roleWithHighestAccess = userRole.AccessLevel;
            }

            if(roleWithHighestAccess >= user.RoleWithHighestAccess.AccessLevel)
            {
                if (this.CanAccessAllDivisions())
                    return true;
                else if (user.CanSeeAllDivisions)
                    return false;


                foreach (UserDivision division in user.Divisions)
                {
                    if (!this.m_UserDivisions.Contains(division.DivisionId))
                        return false;
                }

                return true;
            }

            return false;
        }

		// == Public collection properties ==

		protected override object GetIdValue()
		{
			return m_UserId;
		}

		#endregion

		#region Interface member implementations

		public IIdentity Identity
		{
			get { return m_Identity; }
		}

		public bool IsInRole(string role)
		{
			return m_UserRoles.Contains(role);
		}

        public bool CanAccessModule(string module)
        {
            return m_UserModules.Contains(module);
        }

        public bool CanAccessDivision(string divisionId)
        {
            if (m_UserDivisions.Count == 0)
                return true;

            return m_UserDivisions.Contains(divisionId);
        }

        public bool CanAccessMultipleDivisions()
        {
            return m_UserDivisions.Count != 1;
        }

        public bool CanAccessAllDivisions()
        {
            return m_UserDivisions.Count == 0;
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

		/// <summary>
		/// Main login function. 
		/// If user id and password matches, a M2MPrincipal is created and stored in the 
		/// Csla.ApplicationContext.User variable. 
		/// </summary>
		/// <param name="userid">User id</param>
		/// <param name="password">Password</param>
		/// <returns>True if the login succeeded</returns>
		public static bool Login(string userid, string password)
		{
			M2MPrincipal principal = M2MPrincipal.GetM2MPrincipal(userid, password);
			if (principal.Identity.IsAuthenticated)
				SetPrincipal(principal);

			return principal.Identity.IsAuthenticated;
		}

		/// <summary>
		/// Resets the type of Principal of Csla.ApplicationContext.User to a M2MPrincipal
		/// using the Principal.User.Identty.Name
		/// </summary>
		/// <param name="currentProduct"></param>
		public static void ResetPrincipal()
		{
			if (Csla.ApplicationContext.User.Identity.IsAuthenticated &&
				Csla.ApplicationContext.User.GetType() != typeof(M2MPrincipal))
			{
				M2MPrincipal principal = M2MPrincipal.GetM2MPrincipal(Csla.ApplicationContext.User.Identity.Name);
				SetPrincipal(principal);
			}			
		}

		/// <summary>
		/// Sets the following properties from the <paramref>principal</paramref> instance:
		/// <list type="bullet">
		/// <item>Csla.ApplicationContext.User</item>
		/// </list>
		/// </summary>
		/// <param name="principal">A M2MPrincipal instance</param>
		internal static void SetPrincipal(M2MPrincipal principal)
		{			
			Csla.ApplicationContext.User = principal;

            string culture = CultureList.GetCulture(principal.Settings.Culture);
            if (culture == "")
                culture = CultureList.GetCulture(M2MDataCenter.SystemSettings.Culture);

            if (culture != "")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            }

            string uiCulture = CultureList.GetUICulture(principal.Settings.Culture);
            if (uiCulture == "")
                uiCulture = CultureList.GetUICulture(M2MDataCenter.SystemSettings.Culture);

            if (uiCulture != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(uiCulture);
            }
        }

		public static void Logout()
		{
			M2MPrincipal principal = M2MPrincipal.NewM2MPrincipal("");
			Csla.ApplicationContext.User = principal;
		}

		public static M2MPrincipal NewM2MPrincipal(string userid)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("Not allowed to add new principal");
			return DataPortal.Create<M2MPrincipal>(new Criteria(userid));
		}

		public static M2MPrincipal GetM2MPrincipal(string userid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("Not allowed to get principal");
			return DataPortal.Fetch<M2MPrincipal>(new Criteria(userid));
		}

		public static M2MPrincipal GetM2MPrincipal(string userid, string password)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("Not allowed to get principal"); 

        
			return DataPortal.Fetch<M2MPrincipal>(new Criteria(userid, password));
		}

		public static void DeleteM2MPrincipal(string userid)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("Not allowed to delete principal");
			DataPortal.Delete(new Criteria(userid));
		}

		public override M2MPrincipal Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("Not allowed to delete principal");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("Not allowed to add new principal");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("Not allowed to get principal");
			M2MPrincipal principal = base.Save();
			Csla.ApplicationContext.User = principal;
			return principal;
		}

		protected M2MPrincipal()
		{
		}

		#endregion
	
		#region Data Access

		
		[Serializable()]
		protected class Criteria
		{
			protected string m_Password = "";
			private string m_UserId = "";

			/// <summary>
			/// UserId, use email address
			/// </summary>
			public string UserId
			{
				get { return m_UserId; }
				set { m_UserId = value; }
			}
			/// <summary>
			/// Password
			/// </summary>
			public string Password
			{
				get	{ return m_Password; }
				set	{ m_Password=value;	}
			}

			public Criteria(string userid)
			{
				m_UserId = userid;
			}
				
			public Criteria(string userid, string password)
			{
				m_UserId = userid;
				m_Password = password;
			}
		}

		[RunLocal()]
		protected void DataPortal_Create(Criteria criteria)
		{
			m_UserId = criteria.UserId;
			if (m_UserId != "")
			{
				m_Identity = M2MIdentity.GetAuthenticatedIdentity(m_UserId);
				m_UserRoles = UserRoleCollection.NewUserRoleCollection(m_UserId);
				m_UserSettings = UserSettingCollection.NewUserSettingCollection(m_UserId);
                m_UserModules = UserModuleCollection.NewUserModuleCollection(m_UserId);
                m_UserDivisions = UserDivisionCollection.NewUserDivisionCollection(m_UserId);
			}
			else
			{
				m_Identity = M2MIdentity.GetUnAuthenticatedIdentity();
				m_UserRoles = null;
				m_UserSettings = null;
                m_UserModules = null;
                m_UserDivisions = null;
			}
		}

		protected void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					string whereClause =  "";
                    SimpleAES aes = new SimpleAES();
					if (criteria.UserId != "")
					{
						whereClause += "UserId=@UserId";
						command.Parameters.AddWithValue(@"@UserId", criteria.UserId);
					}										
					if (criteria.Password != "")
					{
                        
						whereClause += " AND Password=@Password";
						command.Parameters.AddWithValue(@"@Password", aes.EncryptToString(criteria.Password));
					}					


					command.CommandType = CommandType.Text;
					command.CommandText = @"SELECT " +
											@"UserId," +
											@"Password," +
											@"DisplayName," +
											@"Notes" +
											@" FROM Users";
					if (whereClause != "")
						command.CommandText += " WHERE " + whereClause;		

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if (dataReader.Read())
						{
							m_UserId = dataReader.GetString("UserId");
							m_Password = aes.DecryptString(dataReader.GetString("Password"));
							m_Name = dataReader.GetString("DisplayName");
							m_Notes = dataReader.GetString("Notes");
							m_Identity = M2MIdentity.GetAuthenticatedIdentity(m_UserId);
						}
						else
						{
							m_Identity = M2MIdentity.GetUnAuthenticatedIdentity();
						}
					}
					m_UserRoles = UserRoleCollection.GetUserRoleCollection(m_UserId);
					m_UserSettings = UserSettingCollection.GetUserSettingCollection(m_UserId);
                    m_UserModules = UserModuleCollection.GetUserModuleCollection(m_UserId);
                    m_UserDivisions = UserDivisionCollection.GetUserDivisionCollection(m_UserId);
				}
			}
		}

		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"INSERT INTO Users (" +
											@"UserId," +
											@"Password," +
											@"DisplayName," +
											@"Notes" +
											@") VALUES (" +
											@"@UserId," +
											@"@Password," +
											@"@DisplayName," +
											@"@Notes)";

                    SimpleAES aes = new SimpleAES();
					command.Parameters.AddWithValue(@"@UserId", m_UserId);
					command.Parameters.AddWithValue(@"@Password", aes.EncryptToString(m_Password));
					command.Parameters.AddWithValue(@"@DisplayName", m_Name);
					command.Parameters.AddWithValue(@"@Notes", m_Notes);
				
					command.ExecuteNonQuery();
				}
			}
			m_UserRoles.Update();
			m_UserSettings.Update();
            m_UserModules.Update();
            m_UserDivisions.Update();
		}

		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Update()
		{

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"UPDATE Users SET " +
											@"Password=@Password," +
											@"DisplayName=@DisplayName" +
											@"Notes=@Notes" +
											@" WHERE " +
											@"UserId=@UserId";

                    SimpleAES aes = new SimpleAES();
					command.Parameters.AddWithValue(@"@Password",aes.EncryptToString(m_Password));
					command.Parameters.AddWithValue(@"@DisplayName", m_Name);
					command.Parameters.AddWithValue(@"@Notes", m_Notes);
					command.Parameters.AddWithValue(@"@UserId", m_UserId);

					command.ExecuteNonQuery();
				}
			}
			m_UserRoles.Update();
			m_UserSettings.Update();
            m_UserModules.Update();
            m_UserDivisions.Update();
		}

		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_DeleteSelf()
		{

			DataPortal_Delete(new Criteria(m_UserId));
		}

		[Transactional(TransactionalTypes.TransactionScope)]
		protected void DataPortal_Delete(Criteria criteria)
		{
			m_UserRoles.Clear();
			m_UserRoles.Update();

			m_UserSettings.Clear();
			m_UserSettings.Update();

            m_UserModules.Clear();
            m_UserModules.Update();

            m_UserDivisions.Clear();
            m_UserDivisions.Update();

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = @"DELETE FROM Users WHERE " +
											@"UserId=@UserId";
					command.Parameters.AddWithValue(@"@UserId", criteria.UserId);

					command.ExecuteNonQuery();

					MarkNew();
				}
			}
		}

		#endregion
	
		#region Exists

		public static bool Exists()
		{
		ExistsCommand result;
		result = DataPortal.Execute<ExistsCommand>(new ExistsCommand());
		return result.Exists;
		}

		[Serializable()]
		private class ExistsCommand: CommandBase
		{
			private bool m_Exists = false;
			/// <summary>
			/// User id
			/// </summary>
			protected string m_UserId = "";

			public bool Exists
			{
				get { return m_Exists; }
			}

			public ExistsCommand()
			{
			}

			protected override void DataPortal_Execute()
			{

				using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
				{
					connection.Open();

					using (SqlCommand command = connection.CreateCommand())
					{
						command.CommandType = CommandType.Text;
						command.CommandText = @"SELECT COUNT(*) FROM Users WHERE " +
												@"UserId=@UserId";
						command.Parameters.AddWithValue(@"@UserId", m_UserId);

						int count = (int)command.ExecuteScalar();
						m_Exists = (count>0);
					}
				}
		
			}
		}
		#endregion
	
	}
}
	