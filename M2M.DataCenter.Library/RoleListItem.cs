using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class RoleListItem : ReadOnlyBase<RoleListItem>
    {
        #region Business Methods

        private string m_Role = String.Empty;
        private string m_DisplayName = String.Empty;
        private int m_AccessLevel = 0;

        public string Role
        {
            get
            {
                return m_Role;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
            }
        }

        public int AccessLevel
        {
            get
            {
                return m_AccessLevel;
            }
        }

        protected override object GetIdValue()
        {
            return m_Role;
        }

        #endregion

        #region Factory Methods

        internal static RoleListItem GetRoleListItem(SafeDataReader dr)
        {
            return new RoleListItem(dr);
        }

        private RoleListItem()
        {
            /* require use of factory methods */
        }

        private RoleListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_Role = dr.GetString("Role");
            m_DisplayName = dr.GetString("DisplayName");
            m_AccessLevel = dr.GetInt32("AccessLevel");
        }

        #endregion
    }
}
