using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class ShiftListItem : ReadOnlyBase<ShiftListItem>
    {
        #region Business Methods

        private int m_ShiftId = 0;
        private string m_DisplayName = String.Empty;

        public int ShiftId
        {
            get
            {
                return m_ShiftId;
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
            return m_ShiftId;
        }

        #endregion

        #region Factory Methods

        internal static ShiftListItem GetShiftListItem(SafeDataReader dr)
        {
            return new ShiftListItem(dr);
        }

        private ShiftListItem()
        {
            /* require use of factory methods */
        }

        private ShiftListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_ShiftId = dr.GetInt32("ShiftId");
            m_DisplayName = dr.GetString("DisplayName");
        }

        #endregion
    }
}