using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class RoleList : ReadOnlyListBase<RoleList, RoleListItem>
    {
        #region Business Methods

        public RoleListItem GetRole(string role)
        {
            foreach (RoleListItem item in this)
            {
                if (item.Role == role)
                    return item;
            }

            return null;
        }

        #endregion
        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        #endregion

        #region Factory Methods

        public static RoleList GetRoleList()
        {
            return DataPortal.Fetch<RoleList>();
        }

        protected RoleList()
        {
            /* require use of factory methods */
        }

        #endregion


        #region Data Access

        
        private void DataPortal_Fetch()
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
                                            @"Role," +
                                            @"DisplayName," +
                                            @"AccessLevel" +
                                            @" FROM Roles" +
                                            @" ORDER BY AccessLevel" ;



                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(RoleListItem.GetRoleListItem(dataReader));
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