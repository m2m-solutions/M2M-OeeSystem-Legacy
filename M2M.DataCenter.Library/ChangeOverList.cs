using System;
using System.Collections.Generic;
using System.Linq;
using Csla;
using System.Data.SqlClient;
using System.Data;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class ChangeOverList : ReadOnlyListBase<ChangeOverList, ChangeOverListItem>
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

        public static ChangeOverList GetChangeOverList(Criteria criteria)
        {
            return DataPortal.Fetch<ChangeOverList>(criteria);
        }

        private ChangeOverList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region Data Access

        [Serializable()]
        public class Criteria
        {
            private string m_MachineId = null;
            private string m_ArticleNumber = null;
            private SmartDate m_StartTime = new SmartDate(new DateTime(2000, 1, 1));
            private SmartDate m_EndTime = new SmartDate(DateTime.Today);

            public Criteria()
            {
            }

            public string MachineId
            {
                get { return m_MachineId; }
                set { m_MachineId = value; }
            }

            public string ArticleNumber
            {
                get { return m_ArticleNumber; }
                set { m_ArticleNumber = value; }
            }

            public SmartDate StartTime
            {
                get { return m_StartTime; }
                set { m_StartTime = value; }
            }

            public SmartDate EndTime
            {
                get { return m_EndTime; }
                set { m_EndTime = value; }
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
                    command.CommandText = @"SELECT Id,MachineId,Article,PreviousArticle,StartTime,EndTime,ChangeOverStart,ChangeOverEnd,CountThis FROM ChangeOvers" +
                        @" WHERE MachineId=@MachineId AND ChangeOverStart<@EndTime AND ChangeOverEnd>@StartTime";

                    command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
                    command.Parameters.AddWithValue("@StartTime", criteria.StartTime.DBValue);
                    command.Parameters.AddWithValue("@EndTime", criteria.EndTime.DBValue);

                    if (!String.IsNullOrEmpty(criteria.ArticleNumber))
                    {
                        command.CommandText += @" AND Article=@Article";
                        command.Parameters.AddWithValue("@Article", criteria.ArticleNumber);
                    }

                    command.CommandText += " ORDER BY Article,StartTime";

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SmartDate startDate = dr.GetSmartDate("StartTime");
                            SmartDate endDate = dr.GetSmartDate("EndTime");
                            TimeSpan elapsedTime = new TimeSpan(0);
                            ExpandedProductionScheme productionScheme = ExpandedProductionScheme.GetExpandedProductionScheme(M2MDataCenter.GetMachine(dr.GetString("MachineId")).DivisionId, startDate, endDate);
                            
                            foreach (ExpandedProductionSchemeItem schemeItem in productionScheme)
                            {
                                SmartDate start = startDate > schemeItem.StartTime ? startDate : schemeItem.StartTime;
                                SmartDate end = endDate < schemeItem.EndTime ? endDate : schemeItem.EndTime;
                                elapsedTime +=  end.Subtract(start.Date);
                            }
                            
                            Add(ChangeOverListItem.GetChangeOverListItem(dr, elapsedTime));
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

