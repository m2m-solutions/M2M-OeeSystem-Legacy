using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class ReasonCodeListItem : ReadOnlyBase<ReasonCodeListItem>
    {
        #region Business Methods

        private string m_TagId = "";
        private int m_ReasonCode = 0;
        private string m_DivisionId = "";
        private string m_MachineId = "";
        private int m_CategoryId = -1;
        private string m_DisplayName = String.Empty;

        public string TagId
        {
            get
            {
                return m_TagId;
            }
        }

        public int ReasonCode
        {
            get
            {
                return m_ReasonCode;
            }
        }

        public string DivisionId
        {
            get
            {
                return m_DivisionId;
            }
        }

        public string MachineId
        {
            get
            {
                return m_MachineId;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
            }
        }

        public int CategoryId
        {
            get
            {
                return m_CategoryId;
            }
        }

        protected override object GetIdValue()
        {
            return m_TagId + "|" + m_ReasonCode;
        }

        #endregion

        #region Factory Methods

        internal static ReasonCodeListItem GetReasonCodeListItem(SafeDataReader dr)
        {
            return new ReasonCodeListItem(dr);
        }

        private ReasonCodeListItem()
        {
            /* require use of factory methods */
        }

        private ReasonCodeListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_TagId = dr.GetString("TagId");
            m_ReasonCode = dr.GetInt32("ReasonCode");
            m_DivisionId = dr.GetString("DivisionId");
            m_MachineId = dr.GetString("MachineId");
            m_DisplayName = dr.GetString("DisplayName");
            m_CategoryId = dr.GetInt32("CategoryId");
        }

        #endregion
    }
}