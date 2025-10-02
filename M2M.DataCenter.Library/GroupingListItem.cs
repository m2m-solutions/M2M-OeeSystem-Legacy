using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class GroupingListItem : ReadOnlyBase<GroupingListItem>
    {
        #region Business Methods

        private int m_GroupingId;
        private string m_DisplayName = String.Empty;
        private GroupingType m_GroupingType = GroupingType.NotSet;

        public int GroupingId
        {
            get
            {
                return m_GroupingId;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
            }
        }

        public GroupingType GroupingType
        {
            get
            {
                return m_GroupingType;
            }
        }

        protected override object GetIdValue()
        {
            return m_GroupingId;
        }

        #endregion

        #region Factory Methods

        internal static GroupingListItem GetGroupingListItem(SafeDataReader dr)
        {
            return new GroupingListItem(dr);
        }

        private GroupingListItem()
        {
            /* require use of factory methods */
        }

        private GroupingListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_GroupingId = dr.GetInt32("GroupingId");
            m_DisplayName = dr.GetString("DisplayName");
            m_GroupingType = (GroupingType)dr.GetInt32("GroupingType");
        }

        #endregion
    }
}
