using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    [Serializable()]
    public class StoppageReasonList : ReadOnlyListBase<StoppageReasonList, StoppageReasonListItem>
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

        public static StoppageReasonList GetStoppageReasonList()
        {
            return DataPortal.Fetch<StoppageReasonList>();
        }

        private StoppageReasonList()
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
                    command.CommandText = @"SELECT DivisionId,CategoryId,DisplayName FROM TagInfo" +
                            @" WHERE TagType IN ({TagType})" +
                            @" UNION " +
                            @" SELECT DivisionId,CategoryId,DisplayName FROM ReasonCodes" +
                            @" GROUP BY DivisionId, CategoryId, DisplayName" +
                            @" ORDER BY DisplayName";

                    command.AddArrayParameters(new int[] { (int)TagType.Stop, (int)TagType.MainAlarm, (int)TagType.UnidentifiedStop }, "TagType");

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            Add(StoppageReasonListItem.GetStoppageReasonListItem(dr));
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

