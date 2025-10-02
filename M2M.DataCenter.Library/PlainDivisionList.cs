using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class PlainDivisionList : ReadOnlyListBase<PlainDivisionList, PlainDivisionListItem>
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

        public static PlainDivisionList GetDivisionList()
        {
            return DataPortal.Fetch<PlainDivisionList>();
        }

        protected PlainDivisionList()
		{
			/* require use of factory methods */
		}
		
		#endregion

		#region Data Access

        [Serializable()]
        public class Criteria
        {
            public Criteria()
            {

            }

            
        }

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
                    command.CommandText = @"SELECT DivisionId,DisplayName,ShortName,GroupingId,Notes" +
                                          @" FROM Divisions" +
                                          @" ORDER BY DivisionId ASC";

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(PlainDivisionListItem.GetDivisionListItem(dataReader));
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