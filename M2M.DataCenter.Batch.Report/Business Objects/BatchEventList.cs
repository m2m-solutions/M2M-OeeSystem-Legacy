using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using Csla.Data;

namespace M2M.DataCenter.Batch.Report
{
    [Serializable()]
    public class BatchEventList : ReadOnlyListBase<BatchEventList, BatchEventListItem>
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

        public static BatchEventList GetEventList(Criteria criteria)
        {
            return DataPortal.Fetch<BatchEventList>(criteria);
        }

        private BatchEventList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region Data Access

        [Serializable()]
        public class Criteria
        {
            private string m_BatchNumber = "";
            private int m_PrevCount = 0;
            
            public Criteria()
            {
            }

            public string BatchNumber
            {
                get { return m_BatchNumber; }
                set { m_BatchNumber = value; }
            }

            public int PrevCount
            {
                get { return m_PrevCount; }
                set { m_PrevCount = value; }
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
                    command.CommandText = @"SELECT e.EventId," +
                                          @"e.MachineId," +
                                          @"e.ArticleNumber," +
                                          @"e.EventRaised," +
                                          @"e.TimeForNextEvent," +
                                          @"t.TagType," +
                                          @"t.CategoryId," +  
                                          @"t.DisplayName AS TagInfoDisplayName" +
                                          @" FROM Events e" +
                                          @" INNER JOIN" +
                                          @" TagInfo t ON e.TagId = t.TagId" +
                                          @" WHERE e.ArticleNumber=@ArticleNumber AND (e.MachineId='650' OR e.MachineId='651')" +
                                          @" ORDER BY e.EventRaised ASC";

                    command.Parameters.AddWithValue("@ArticleNumber", criteria.BatchNumber);

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					{
						while (dr.Read())
						{
							Add(BatchEventListItem.GetEventListItem(dr));
                 		}
					}
				}

                if(this.Count > 0 && criteria.PrevCount > 0)
                {
                    using (SqlCommand command = connection.CreateCommand())
				    {
					    command.CommandType = CommandType.Text;
                        command.CommandText = String.Format(@"SELECT TOP ({0}) e.EventId,", criteria.PrevCount) +
                                              @"e.MachineId," +
                                              @"e.ArticleNumber," +
                                              @"e.EventRaised," +
                                              @"e.TimeForNextEvent," +
                                              @"t.TagType," +
                                              @"t.CategoryId," +  
                                              @"t.DisplayName AS TagInfoDisplayName" +
                                              @" FROM Events e" +
                                              @" INNER JOIN" +
                                              @" TagInfo t ON e.TagId = t.TagId" +
                                              @" WHERE e.EventRaised<=@EventRaised AND e.MachineId=@MachineId AND e.ArticleNumber<>@ArticleNumber" +
                                              @" ORDER BY e.EventRaised DESC";

                        command.Parameters.AddWithValue("@EventRaised", this[0].EventRaised.DBValue);
                        command.Parameters.AddWithValue("@MachineId", this[0].MachineId);
                        command.Parameters.AddWithValue("@ArticleNumber", criteria.BatchNumber);
                   
                        using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					    {
						    while (dr.Read())
						    {
							    Insert(0, BatchEventListItem.GetEventListItem(dr));
                 		    }
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

