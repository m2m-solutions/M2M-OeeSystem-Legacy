using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class ModuleList : ReadOnlyListBase<ModuleList, ModuleListItem>
    {
        #region Business Methods

        public ModuleListItem GetModule(string module)
        {
            foreach (ModuleListItem item in this)
            {
                if (item.Module == module)
                    return item;
            }

            return null;
        }

        public bool Contains(string module)
        {
            return GetModule(module) != null;
        }

        #endregion
        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        #endregion

        #region Factory Methods

        public static ModuleList GetModuleList()
        {
            return DataPortal.Fetch<ModuleList>(new Criteria(false));
        }

        public static ModuleList GetModuleList(bool ignoreSystemOnly)
        {
            return DataPortal.Fetch<ModuleList>(new Criteria(ignoreSystemOnly));
        }

        protected ModuleList()
        {
            /* require use of factory methods */
        }

        #endregion


        #region Data Access

        [Serializable()]
        private class Criteria
        {
            private bool m_IgnoreSystemOnly = false;

            public bool IgnoreSystemOnly
            {
                get { return m_IgnoreSystemOnly; }
                set { m_IgnoreSystemOnly = value; }
            }
            
            public Criteria(bool ignoreSystemOnly)
            {
                m_IgnoreSystemOnly = ignoreSystemOnly;
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
                                            @"Module," +
                                            @"DisplayName," +
                                            @"SystemOnly" +
                                            @" FROM Modules";

                    if (criteria.IgnoreSystemOnly)
                    {
                        command.CommandText += " WHERE SystemOnly=0";
                    }

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(ModuleListItem.GetModuleListItem(dataReader));
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