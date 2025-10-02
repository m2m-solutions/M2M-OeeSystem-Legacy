using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class StoppageReasonListItem : ReadOnlyBase<StoppageReasonListItem>
    {
        #region Business Methods

        private string m_DivisionId = String.Empty;
        private int m_CategoryId = 0;
        private string m_DisplayName = String.Empty;

        public string DivisionId
        {
            get
            {
                return m_DivisionId;
            }
        }

        public int CategoryId
        {
            get
            {
                return m_CategoryId;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
            }
        }

        protected override object GetIdValue()
        {
            return String.Format("{0}|{1}|{2}", m_DivisionId, m_CategoryId, m_DisplayName);
        }

        #endregion

        #region Factory Methods

        internal static StoppageReasonListItem GetStoppageReasonListItem(SafeDataReader dr)
        {
            return new StoppageReasonListItem(dr);
        }

        private StoppageReasonListItem()
        {
            /* require use of factory methods */
        }

        private StoppageReasonListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_DivisionId = dr.GetString("DivisionId");
            m_CategoryId = dr.GetInt32("CategoryId");
            m_DisplayName = dr.GetString("DisplayName");
        }

        #endregion
    }
}