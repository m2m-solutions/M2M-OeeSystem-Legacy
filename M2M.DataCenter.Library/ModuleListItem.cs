using System;
using Csla;
using Csla.Data;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
    [Serializable()]
    public class ModuleListItem : ReadOnlyBase<ModuleListItem>
    {
        #region Business Methods

        private string m_Module = String.Empty;
        private bool m_SystemOnly = false;

        public string Module
        {
            get
            {
                return m_Module;
            }
        }

        public string DisplayName
        {
            get
            {
                return ResourceStrings.GetString(m_Module);
            }
        }

        public bool SystemOnly
        {
            get
            {
                return m_SystemOnly;
            }
        }

        protected override object GetIdValue()
        {
            return m_Module;
        }

        #endregion

        #region Factory Methods

        internal static ModuleListItem GetModuleListItem(SafeDataReader dr)
        {
            return new ModuleListItem(dr);
        }

        private ModuleListItem()
        {
            /* require use of factory methods */
        }

        private ModuleListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_Module = dr.GetString("Module");
            m_SystemOnly = dr.GetBoolean("SystemOnly");
        }

        #endregion
    }
}
