using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class GroupingList : ReadOnlyListBase<GroupingList, GroupingListItem>
    {
        #region Business Methods

        public GroupingListItem GetGrouping(int grouping)
        {
            foreach (GroupingListItem item in this)
            {
                if (item.GroupingId == grouping)
                    return item;
            }

            return null;
        }

        public bool Contains(int grouping)
        {
            return GetGrouping(grouping) != null;
        }

        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        #endregion

        #region Factory Methods

        public static GroupingList GetGroupingList()
        {
            return DataPortal.Fetch<GroupingList>(new Criteria());
        }

        public static GroupingList GetGroupingList(GroupingType groupingType)
        {
            return DataPortal.Fetch<GroupingList>(new Criteria(groupingType));
        }

        protected GroupingList()
        {
            /* require use of factory methods */
        }

        #endregion


        #region Data Access

        [Serializable()]
        private class Criteria
        {
            private GroupingType m_GroupingType = GroupingType.NotSet;

            public GroupingType GroupingType
            {
                get { return m_GroupingType; }
                set { m_GroupingType = value; }
            }

            public Criteria()
            {
            }

            public Criteria(GroupingType groupingType)
            {
                m_GroupingType = groupingType;
            }


        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT " +
                                            @"GroupingId," +
                                            @"DisplayName," +
                                            @"GroupingType" +
                                            @" FROM Groupings";

                    if (criteria.GroupingType != GroupingType.NotSet)
                    {
                        command.CommandText += " WHERE GroupingType=@GroupingType";
                        command.Parameters.AddWithValue("@GroupingType", (int)criteria.GroupingType);
                    }

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(GroupingListItem.GetGroupingListItem(dataReader));
                        }
                    }
                }
            }

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        #endregion
    }
}