using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class ReasonCodeList : ReadOnlyListBase<ReasonCodeList, ReasonCodeListItem>
    {
        #region Business Methods


        /// <summary>
        /// Returns the ReasonCode object matching the id given.
        /// </summary>		
        public ReasonCodeListItem GetItem(string tagId, int reasonCode)
        {
            foreach (ReasonCodeListItem item in this)
            {
                if (item.TagId == tagId && item.ReasonCode == reasonCode)
                {
                    return item;
                }
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

        public static ReasonCodeList GetReasonCodeList()
        {
            return DataPortal.Fetch<ReasonCodeList>();
        }

        private ReasonCodeList()
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
                    command.CommandText = @"SELECT TagId,ReasonCode,DivisionId,MachineId,DisplayName,CategoryId FROM ReasonCodes";

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            Add(ReasonCodeListItem.GetReasonCodeListItem(dr));
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

