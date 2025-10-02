using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class UserDivision : BusinessBase<UserDivision>
    {

        #region Business Methods
        protected Guid m_UserDivisionId = Guid.NewGuid();
        protected string m_UserId = String.Empty;
        protected string m_DivisionId = String.Empty;
        protected string m_DisplayName = String.Empty;

        // Id properties
        /// <summary>
        /// User Division id
        /// </summary> 
        [System.ComponentModel.DataObjectField(true, true)]
        public Guid UserDivisionId
        {
            get
            {
                CanReadProperty("UserDivisionId", true);
                return m_UserDivisionId;
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
        /// Division name
        /// </summary> 
        public string DivisionId
        {
            get
            {
                CanReadProperty("DivisionId", true);
                return m_DivisionId;
            }
            set
            {
                CanWriteProperty("DivisionId", true);
                if (m_DivisionId != value)
                {
                    m_DivisionId = value;
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
        /// User Division Id
        /// </summary>
        public string UserDivisionIdAsString
        {
            get
            {
                CanReadProperty("UserDivisionId", true);
                return m_UserDivisionId.ToString("d");
            }
        }

        // == Public collection properties ==
        protected override object GetIdValue()
        {
            return m_UserDivisionId.ToString();
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

        internal static UserDivision NewUserDivision(string userId)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add UserDivision objects");
            return new UserDivision(userId);
        }

        internal static UserDivision GetUserDivision(SafeDataReader dr)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view UserDivision objects");
            return new UserDivision(dr);
        }

        protected UserDivision()
            : base()
        {
            MarkAsChild();
        }

        protected UserDivision(string userId)
            : this()
        {
            m_UserId = userId;

            ValidationRules.CheckRules();
        }

        protected UserDivision(SafeDataReader dr)
            : this()
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dataReader)
        {
            m_UserDivisionId = dataReader.GetGuid("UserDivisionId");
            m_UserId = dataReader.GetString("UserId");
            m_DivisionId = dataReader.GetString("DivisionId");
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
                command.CommandText = @"INSERT INTO UserDivisions (" +
                                                @"[UserDivisionId]," +
                                                @"[UserId]," +
                                                @"[DivisionId]" +
                                                @") VALUES (" +
                                                @"@UserDivisionId," +
                                                @"@UserId," +
                                                @"@DivisionId)";

                command.Parameters.AddWithValue(@"@UserDivisionId", m_UserDivisionId);
                command.Parameters.AddWithValue(@"@UserId", m_UserId);
                command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);

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
                command.CommandText = @"UPDATE UserDivisions SET " +
                                            @"[UserId]=@UserId," +
                                            @"[DivisionId]=@DivisionId" +
                                            @" WHERE " +
                                            @"[UserDivisionId]=@UserDivisionId";

                command.Parameters.AddWithValue(@"@UserDivisionId", m_UserDivisionId);
                command.Parameters.AddWithValue(@"@UserId", m_UserId);
                command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);

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
                command.CommandText = @"DELETE FROM UserDivisions WHERE " +
                                        @"[UserDivisionId]=@UserDivisionId";

                command.Parameters.AddWithValue(@"@UserDivisionId", m_UserDivisionId);
                command.ExecuteNonQuery();
                MarkNew();
            }
        }

        #endregion
    }
}