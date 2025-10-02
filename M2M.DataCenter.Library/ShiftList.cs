using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class ShiftList : ReadOnlyListBase<ShiftList, ShiftListItem>
    {
        #region Business Methods

        
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        #endregion

        #region Factory Methods

        public static ShiftList GetShiftList()
        {
            return DataPortal.Fetch<ShiftList>();
        }

        private ShiftList()
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
                    command.CommandText = @"SELECT ShiftId,DisplayName FROM Shifts";

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            Add(ShiftListItem.GetShiftListItem(dr));
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

