using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    [Serializable()]
    public class EventList : ReadOnlyListBase<EventList, EventListItem>
    {
        public int TotalRowCount { get; set; }

        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        #endregion

        #region Factory Methods

        public static EventList GetEventList()
        {
            return DataPortal.Fetch<EventList>(new Criteria());
        }

        public static EventList GetEventList(Criteria criteria)
        {
            return DataPortal.Fetch<EventList>(criteria);
        }

        private EventList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region Data Access

        [Serializable()]
        public class Criteria
        {
            private string m_DivisionId = null;
            private string m_MachineId = null;
            private string m_TagId = null;
            private string m_ArticleNumber = null;
            private SmartDate m_StartDate = new SmartDate();
            private SmartDate m_EndDate = new SmartDate();
            private int m_Shift = -1;
            private bool m_ShowInformation = true;
            private bool m_ShowAuto = true;
            private bool m_ShowProductionSwitch = true;
            private bool m_ShowSystemErrors = true;
            private bool m_ShowSecondaryFailures = true;
            private List<int> m_Categories = new List<int>();
            private bool m_FetchPagedData = false;
            private bool m_ChangeOverData = false;
            private int m_PageIndex = 1;
            private int m_PageSize = 20;

            public Criteria()
            {
            }

            public string ArticleNumber
            {
                get { return m_ArticleNumber; }
                set { m_ArticleNumber = value; }
            }

            public string DivisionId
            {
                get { return m_DivisionId; }
                set { m_DivisionId = value; }
            }

            public string MachineId
            {
                get { return m_MachineId; }
                set { m_MachineId = value; }
            }

            public string TagId
            {
                get { return m_TagId; }
                set { m_TagId = value; }
            }

            public SmartDate StartDate
            {
                get { return m_StartDate; }
                set { m_StartDate = value; }
            }

            public SmartDate EndDate
            {
                get { return m_EndDate; }
                set { m_EndDate = value; }
            }

            public int Shift
            {
                get { return m_Shift; }
                set { m_Shift = value; }
            }

            public int PageIndex
            {
                get { return m_PageIndex; }
                set { m_PageIndex = value; }
            }

            public int PageSize
            {
                get { return m_PageSize; }
                set { m_PageSize = value; }
            }

            public int StartIndex
            {
                get { return m_PageIndex * m_PageSize + 1; }
            }

            public int EndIndex
            {
                get { return StartIndex + m_PageSize - 1; }
            }

            public bool ShowInformation
            {
                get { return m_ShowInformation; }
                set { m_ShowInformation = value; }
            }

            public bool ShowAuto
            {
                get { return m_ShowAuto; }
                set { m_ShowAuto = value; }
            }

            public bool ShowProductionSwitch
            {
                get { return m_ShowProductionSwitch; }
                set { m_ShowProductionSwitch = value; }
            }

            public bool ShowSystemErrors
            {
                get { return m_ShowSystemErrors; }
                set { m_ShowSystemErrors = value; }
            }

            public bool ShowSecondaryFailures
            {
                get { return m_ShowSecondaryFailures; }
                set { m_ShowSecondaryFailures = value; }
            }

            public bool FetchPagedData
            {
                get { return m_FetchPagedData; }
                set { m_FetchPagedData = value; }
            }

            public bool ChangeOverData
            {
                get { return m_ChangeOverData; }
                set { m_ChangeOverData = value; }
            }

            public List<int> Categories
            {
                get { return m_Categories; }
                set { m_Categories = value; }
            }

            public bool ShowAll
            {
                get
                {
                    return (m_Categories.Count == M2MDataCenter.GetAvailableCategories().Count && m_ShowInformation && m_ShowSystemErrors && m_ShowAuto && m_ShowProductionSwitch);
                }
            }

            public bool ShowNone
            {
                get
                {
                    return (m_Categories.Count == 0 && M2MDataCenter.GetAvailableCategories().Count > 0 && !m_ShowInformation && !m_ShowSystemErrors && !m_ShowAuto && !m_ShowProductionSwitch);
                }
            }
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            if (criteria.FetchPagedData)
                FetchPagedData(criteria);
            else if (criteria.ChangeOverData)
                FetchChangeOverData(criteria);
            else
                FetchEventData(criteria);
            //if (!criteria.ShowNone)
            //{
            //    using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            //    {

            //        connection.Open();

            //        using (SqlCommand command = connection.CreateCommand())
            //        {
            //            string whereClause = "";

            //            if (!String.IsNullOrEmpty(criteria.DivisionId))
            //            {
            //                if (whereClause != "")
            //                    whereClause += " AND ";

            //                whereClause += "e.DivisionId=@DivisionId";
            //                command.Parameters.AddWithValue("@DivisionId", criteria.DivisionId);
            //            }

            //            if (!String.IsNullOrEmpty(criteria.MachineId))
            //            {
            //                if (whereClause != "")
            //                    whereClause += " AND ";

            //                whereClause += "e.MachineId=@MachineId";
            //                command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
            //            }

            //            if (!String.IsNullOrEmpty(criteria.ArticleNumber))
            //            {
            //                if (whereClause != "")
            //                    whereClause += " AND ";

            //                whereClause += "e.ArticleNumber=@ArticleNumber";
            //                command.Parameters.AddWithValue("@ArticleNumber", criteria.ArticleNumber);
            //            }

            //            if (!String.IsNullOrEmpty(criteria.TagId))
            //            {
            //                if (whereClause != "")
            //                    whereClause += " AND ";

            //                whereClause += "e.TagId=@TagId";
            //                command.Parameters.AddWithValue("@TagId", criteria.TagId);
            //            }

            //            if (!criteria.ShowAll)
            //            {
            //                string innerClause = "";
            //                if (criteria.ShowSystemErrors)
            //                {
            //                    if (innerClause != "")
            //                        innerClause += " OR ";

            //                    innerClause += "t.TagType>@TagType0";
            //                    command.Parameters.AddWithValue("@TagType0", (int)TagType.UnidentifiedStop);
            //                }

            //                if (criteria.ShowInformation)
            //                {
            //                    if (innerClause != "")
            //                        innerClause += " OR ";

            //                    innerClause += "t.TagType=@TagType1";
            //                    command.Parameters.AddWithValue("@TagType1", (int)TagType.Informational);
            //                }

            //                if (criteria.ShowAuto)
            //                {
            //                    if (innerClause != "")
            //                        innerClause += " OR ";

            //                    innerClause += "t.TagType=@TagType2";
            //                    command.Parameters.AddWithValue("@TagType2", (int)TagType.Auto);
            //                }

            //                if (criteria.ShowProductionSwitch)
            //                {
            //                    if (innerClause != "")
            //                        innerClause += " OR ";

            //                    innerClause += "t.TagType=@TagType3";
            //                    command.Parameters.AddWithValue("@TagType3", (int)TagType.ProductionSwitch);
            //                }

            //                if (criteria.Categories.Count == M2MDataCenter.GetAvailableCategories().Count)
            //                {
            //                    if (innerClause != "")
            //                        innerClause += " OR ";

            //                    innerClause += "t.TagType=@TagType4 OR t.TagType=@TagType5 OR TagType=@TagType6";
            //                    command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
            //                    command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);
            //                    command.Parameters.AddWithValue("@TagType6", (int)TagType.UnidentifiedStop);
            //                }
            //                else if (criteria.Categories.Count > 0)
            //                {
            //                    if (innerClause != "")
            //                        innerClause += " OR ";

            //                    innerClause += "((t.TagType=@TagType4 OR t.TagType=@TagType5 OR TagType=@TagType6) AND (";
            //                    command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
            //                    command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);
            //                    command.Parameters.AddWithValue("@TagType6", (int)TagType.UnidentifiedStop);

            //                    string innerInnerClause = "";

            //                    foreach (int categoryId in criteria.Categories)
            //                    {
            //                        if (innerInnerClause != "")
            //                            innerInnerClause += " OR ";

            //                        innerInnerClause += "(e.ReasonCode=0 AND t.CategoryId=@CategoryIdA" + categoryId.ToString() + " OR r.CategoryId=@CategoryIdB" + categoryId.ToString() + ") ";
            //                        command.Parameters.AddWithValue("@CategoryIdA" + categoryId.ToString(), categoryId);
            //                        command.Parameters.AddWithValue("@CategoryIdB" + categoryId.ToString(), categoryId);
            //                    }
            //                    innerInnerClause += "))";
            //                    innerClause += innerInnerClause;
            //                }

            //                if (innerClause != "")
            //                {
            //                    if (whereClause != "")
            //                        whereClause += " AND ";

            //                    whereClause += "(" + innerClause + ")";
            //                }
            //            }

            //            if (!criteria.StartDate.IsEmpty)
            //            {
            //                if (whereClause != "")
            //                    whereClause += " AND ";

            //                whereClause += "(e.TimeForNextEvent IS NULL OR e.TimeForNextEvent>@StartDate)";
            //                command.Parameters.AddWithValue("@StartDate", criteria.StartDate.DBValue);
            //            }

            //            if (!criteria.EndDate.IsEmpty)
            //            {
            //                if (whereClause != "")
            //                    whereClause += " AND ";

            //                whereClause += "e.EventRaised<@EndDate";
            //                command.Parameters.AddWithValue("@EndDate", criteria.EndDate.DBValue);
            //            }

            //            if (whereClause != "")
            //                whereClause += " AND ";

            //            whereClause = " WHERE " + whereClause + "e.Overridden=0";

            //            command.CommandType = CommandType.Text;

            //            if (criteria.FetchPagedData)
            //            {
            //                command.CommandText = @";WITH CTE AS (" +
            //                                      @"SELECT e.EventId," +
            //                                      @"e.DivisionId as DivisionId," +
            //                                      @"e.MachineId as MachineId," +
            //                                      @"(ROW_NUMBER() OVER (ORDER BY e.EventRaised DESC)) as Row," +
            //                                      @"e.ArticleNumber as ArticleNumber," +
            //                                      @"e.EventRaised as EventRaised," +
            //                                      @"e.TimeForNextEvent as TimeForNextEvent," +
            //                                      @"e.CurrentNumberOfItems as CurrentNumberOfItems," +
            //                                      @"e.RunRate as RunRate," +
            //                                      @"t.TagType as TagType," +
            //                                      @"t.CategoryId as TagInfoCategoryId," +
            //                                      @"r.CategoryId as ReasonCategoryId," +
            //                                      @"t.DisplayName AS TagInfoDisplayName," +
            //                                      @"r.DisplayName AS ReasonDisplayName" +
            //                                      @" FROM Events e WITH (NOLOCK)" +
            //                                      @" INNER JOIN" +
            //                                      @" TagInfo t WITH (NOLOCK) ON e.TagId = t.TagId" +
            //                                      @" LEFT OUTER JOIN" +
            //                                      @" ReasonCodes r WITH (NOLOCK) ON e.TagId = r.TagId" +
            //                                      @" AND e.ReasonCode = r.ReasonCode" +
            //                                      whereClause +
            //                                      @" )" +
            //                                      @", CTE2 AS (SELECT Count(*) CNT FROM CTE)" +
            //                                      @"SELECT EventId," +
            //                                      @"CNT," +
            //                                      @"DivisionId," +
            //                                      @"MachineId," +
            //                                      @"ArticleNumber," +
            //                                      @"EventRaised," +
            //                                      @"TimeForNextEvent," +
            //                                      @"CurrentNumberOfItems," +
            //                                      @"RunRate," +
            //                                      @"TagType," +
            //                                      @"TagInfoCategoryId," +
            //                                      @"ReasonCategoryId," +
            //                                      @"TagInfoDisplayName," +
            //                                      @"ReasonDisplayName" +
            //                                      @" FROM CTE,CTE2" +
            //                                      @" WHERE Row BETWEEN(@StartIndex)" +
            //                                      @" AND (@EndIndex);";

            //                command.Parameters.AddWithValue("@StartIndex", criteria.StartIndex);
            //                command.Parameters.AddWithValue("@EndIndex", criteria.EndIndex);
            //            }
            //            else
            //            {
            //                command.CommandText = @"SELECT e.EventId," +
            //                                      @"e.DivisionId as DivisionId," +
            //                                      @"e.MachineId as MachineId," +
            //                                      @"e.ArticleNumber as ArticleNumber," +
            //                                      @"e.EventRaised as EventRaised," +
            //                                      @"e.TimeForNextEvent as TimeForNextEvent," +
            //                                      @"e.CurrentNumberOfItems as CurrentNumberOfItems," +
            //                                      @"e.RunRate as RunRate," +
            //                                      @"t.TagType as TagType," +
            //                                      @"t.CategoryId as TagInfoCategoryId," +
            //                                      @"r.CategoryId as ReasonCategoryId," +
            //                                      @"t.DisplayName AS TagInfoDisplayName," +
            //                                      @"r.DisplayName AS ReasonDisplayName" +
            //                                      @" FROM Events e WITH (NOLOCK)" +
            //                                      @" INNER JOIN" +
            //                                      @" TagInfo t WITH (NOLOCK) ON e.TagId = t.TagId" +
            //                                      @" LEFT OUTER JOIN" +
            //                                      @" ReasonCodes r WITH (NOLOCK) ON e.TagId = r.TagId" +
            //                                      @" AND e.ReasonCode = r.ReasonCode" +
            //                                      whereClause +
            //                                      @" ORDER BY e.EventRaised ASC, (CASE WHEN e.TimeForNextEvent IS NULL THEN 1 ELSE 0 END), e.TimeForNextEvent";
            //            }


            //            using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
            //            {
            //                while (dr.Read())
            //                {
            //                    EventListItem listItem = EventListItem.GetEventListItem(dr);

            //                    //if(!criteria.ShowSecondaryFailures && listItem.TagType == TagType.Stop && listItem.ElapsedTime.TotalSeconds == 0)
            //                    //    continue;

            //                    Add(listItem);

            //                    if (criteria.FetchPagedData)
            //                        TotalRowCount = dr.GetInt32("CNT");
            //                }
            //            }

            //        }
            //    }

            //}
            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void FetchPagedData(Criteria criteria)
        {
            if (!criteria.ShowNone)
            {
                using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        string whereClause = "";

                        if (!String.IsNullOrEmpty(criteria.DivisionId))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            if (criteria.DivisionId.Contains(","))
                            {
                                var divisions = criteria.DivisionId.Split(',');
                                var parameters = new string[divisions.Length];
                                for (int i = 0; i < divisions.Length; i++)
                                {
                                    parameters[i] = string.Format("@DivisionId{0}", i);
                                    command.Parameters.AddWithValue(parameters[i], divisions[i]);
                                }
                                whereClause += string.Format("e.DivisionId IN ({0})", string.Join(",", parameters));
                                //command.AddArrayParameters(new int[] { (int)TagType.Stop, (int)TagType.MainAlarm, (int)TagType.UnidentifiedStop }, "TagType");
                            }
                            else
                            {
                                whereClause += "e.DivisionId=@DivisionId";
                                command.Parameters.AddWithValue("@DivisionId", criteria.DivisionId);
                            }
                        }

                        if (!String.IsNullOrEmpty(criteria.MachineId))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.MachineId=@MachineId";
                            command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
                        }

                        if (!String.IsNullOrEmpty(criteria.ArticleNumber))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.ArticleNumber=@ArticleNumber";
                            command.Parameters.AddWithValue("@ArticleNumber", criteria.ArticleNumber);
                        }

                        if (!String.IsNullOrEmpty(criteria.TagId))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.TagId=@TagId";
                            command.Parameters.AddWithValue("@TagId", criteria.TagId);
                        }

                        if (!criteria.ShowAll)
                        {
                            string innerClause = "";
                            if (criteria.ShowSystemErrors)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType>@TagType0";
                                command.Parameters.AddWithValue("@TagType0", (int)TagType.UnidentifiedStop);
                            }

                            if (criteria.ShowInformation)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType1";
                                command.Parameters.AddWithValue("@TagType1", (int)TagType.Informational);
                            }

                            if (criteria.ShowAuto)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType2";
                                command.Parameters.AddWithValue("@TagType2", (int)TagType.Auto);
                            }

                            if (criteria.ShowProductionSwitch)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType3";
                                command.Parameters.AddWithValue("@TagType3", (int)TagType.ProductionSwitch);
                            }

                            if (criteria.Categories.Count == M2MDataCenter.GetAvailableCategories().Count)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType4 OR t.TagType=@TagType5 OR t.TagType=@TagType6";
                                command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
                                command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);
                                command.Parameters.AddWithValue("@TagType6", (int)TagType.UnidentifiedStop);
                            }
                            else if (criteria.Categories.Count > 0)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "((t.TagType=@TagType4 OR t.TagType=@TagType5 OR t.TagType=@TagType6) AND (";
                                command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
                                command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);
                                command.Parameters.AddWithValue("@TagType6", (int)TagType.UnidentifiedStop);

                                string innerInnerClause = "";

                                foreach (int categoryId in criteria.Categories)
                                {
                                    if (innerInnerClause != "")
                                        innerInnerClause += " OR ";

                                    innerInnerClause += "(e.ReasonCode=0 AND t.CategoryId=@CategoryIdA" + categoryId.ToString() + " OR r.CategoryId=@CategoryIdB" + categoryId.ToString() + ") ";
                                    command.Parameters.AddWithValue("@CategoryIdA" + categoryId.ToString(), categoryId);
                                    command.Parameters.AddWithValue("@CategoryIdB" + categoryId.ToString(), categoryId);
                                }
                                innerInnerClause += "))";
                                innerClause += innerInnerClause;
                            }

                            if (innerClause != "")
                            {
                                if (whereClause != "")
                                    whereClause += " AND ";

                                whereClause += "(" + innerClause + ")";
                            }
                        }

                        if (!criteria.StartDate.IsEmpty)
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "(e.TimeForNextEvent IS NULL OR e.TimeForNextEvent>@StartDate)";
                            command.Parameters.AddWithValue("@StartDate", criteria.StartDate.DBValue);
                        }

                        if (!criteria.EndDate.IsEmpty)
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.EventRaised<@EndDate";
                            command.Parameters.AddWithValue("@EndDate", criteria.EndDate.DBValue);
                        }

                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause = " WHERE " + whereClause + "e.Overridden=0";

                        command.CommandType = CommandType.Text;

                        command.CommandText = @";WITH CTE AS (" +
                                                @"SELECT e.EventId," +
                                                @"e.DivisionId as DivisionId," +
                                                @"e.MachineId as MachineId," +
                                                @"(ROW_NUMBER() OVER (ORDER BY e.EventRaised DESC)) as Row," +
                                                @"e.ArticleNumber as ArticleNumber," +
                                                @"e.EventRaised as EventRaised," +
                                                @"e.TimeForNextEvent as TimeForNextEvent," +
                                                @"e.CurrentNumberOfItems as CurrentNumberOfItems," +
                                                @"e.RunRate as RunRate," +
                                                @"t.TagType as TagType," +
                                                @"t.CategoryId as TagInfoCategoryId," +
                                                @"r.CategoryId as ReasonCategoryId," +
                                                @"t.DisplayName AS TagInfoDisplayName," +
                                                @"r.DisplayName AS ReasonDisplayName" +
                                                @" FROM Events e WITH (NOLOCK)" +
                                                @" INNER JOIN" +
                                                @" TagInfo t WITH (NOLOCK) ON e.TagId = t.TagId" +
                                                @" LEFT OUTER JOIN" +
                                                @" ReasonCodes r WITH (NOLOCK) ON e.TagId = r.TagId" +
                                                @" AND e.ReasonCode = r.ReasonCode" +
                                                whereClause +
                                                @" )" +
                                                @", CTE2 AS (SELECT Count(*) CNT FROM CTE)" +
                                                @"SELECT EventId," +
                                                @"CNT," +
                                                @"DivisionId," +
                                                @"MachineId," +
                                                @"ArticleNumber," +
                                                @"EventRaised," +
                                                @"TimeForNextEvent," +
                                                @"CurrentNumberOfItems," +
                                                @"RunRate," +
                                                @"TagType," +
                                                @"TagInfoCategoryId," +
                                                @"ReasonCategoryId," +
                                                @"TagInfoDisplayName," +
                                                @"ReasonDisplayName" +
                                                @" FROM CTE,CTE2" +
                                                @" WHERE Row BETWEEN(@StartIndex)" +
                                                @" AND (@EndIndex);";

                        command.Parameters.AddWithValue("@StartIndex", criteria.StartIndex);
                        command.Parameters.AddWithValue("@EndIndex", criteria.EndIndex);
             
                        using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                EventListItem listItem = EventListItem.GetEventListItem(dr);

                                //if(!criteria.ShowSecondaryFailures && listItem.TagType == TagType.Stop && listItem.ElapsedTime.TotalSeconds == 0)
                                //    continue;

                                Add(listItem);
                                TotalRowCount = dr.GetInt32("CNT");
                            }
                        }

                    }
                }

            }
        }

        private void FetchEventData(Criteria criteria)
        {
            if (!criteria.ShowNone)
            {
                using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        string whereClause = "";

                        if (!String.IsNullOrEmpty(criteria.DivisionId))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.DivisionId=@DivisionId";
                            command.Parameters.AddWithValue("@DivisionId", criteria.DivisionId);
                        }

                        if (!String.IsNullOrEmpty(criteria.MachineId))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.MachineId=@MachineId";
                            command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
                        }

                        if (!String.IsNullOrEmpty(criteria.ArticleNumber))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.ArticleNumber=@ArticleNumber";
                            command.Parameters.AddWithValue("@ArticleNumber", criteria.ArticleNumber);
                        }

                        if (!String.IsNullOrEmpty(criteria.TagId))
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.TagId=@TagId";
                            command.Parameters.AddWithValue("@TagId", criteria.TagId);
                        }

                        if (!criteria.ShowAll)
                        {
                            string innerClause = "";
                            if (criteria.ShowSystemErrors)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType>@TagType0";
                                command.Parameters.AddWithValue("@TagType0", (int)TagType.UnidentifiedStop);
                            }

                            if (criteria.ShowInformation)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType1";
                                command.Parameters.AddWithValue("@TagType1", (int)TagType.Informational);
                            }

                            if (criteria.ShowAuto)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType2";
                                command.Parameters.AddWithValue("@TagType2", (int)TagType.Auto);
                            }

                            if (criteria.ShowProductionSwitch)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType3";
                                command.Parameters.AddWithValue("@TagType3", (int)TagType.ProductionSwitch);
                            }

                            if (criteria.Categories.Count == M2MDataCenter.GetAvailableCategories().Count)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "t.TagType=@TagType4 OR t.TagType=@TagType5 OR t.TagType=@TagType6";
                                command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
                                command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);
                                command.Parameters.AddWithValue("@TagType6", (int)TagType.UnidentifiedStop);
                            }
                            else if (criteria.Categories.Count > 0)
                            {
                                if (innerClause != "")
                                    innerClause += " OR ";

                                innerClause += "((t.TagType=@TagType4 OR t.TagType=@TagType5 OR t.TagType=@TagType6) AND (";
                                command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
                                command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);
                                command.Parameters.AddWithValue("@TagType6", (int)TagType.UnidentifiedStop);

                                string innerInnerClause = "";

                                foreach (int categoryId in criteria.Categories)
                                {
                                    if (innerInnerClause != "")
                                        innerInnerClause += " OR ";

                                    innerInnerClause += "(e.ReasonCode=0 AND t.CategoryId=@CategoryIdA" + categoryId.ToString() + " OR r.CategoryId=@CategoryIdB" + categoryId.ToString() + ") ";
                                    command.Parameters.AddWithValue("@CategoryIdA" + categoryId.ToString(), categoryId);
                                    command.Parameters.AddWithValue("@CategoryIdB" + categoryId.ToString(), categoryId);
                                }
                                innerInnerClause += "))";
                                innerClause += innerInnerClause;
                            }

                            if (innerClause != "")
                            {
                                if (whereClause != "")
                                    whereClause += " AND ";

                                whereClause += "(" + innerClause + ")";
                            }
                        }

                        if (!criteria.StartDate.IsEmpty)
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "(e.TimeForNextEvent IS NULL OR e.TimeForNextEvent>@StartDate)";
                            command.Parameters.AddWithValue("@StartDate", criteria.StartDate.DBValue);
                        }

                        if (!criteria.EndDate.IsEmpty)
                        {
                            if (whereClause != "")
                                whereClause += " AND ";

                            whereClause += "e.EventRaised<@EndDate";
                            command.Parameters.AddWithValue("@EndDate", criteria.EndDate.DBValue);
                        }

                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause = " WHERE " + whereClause + "e.Overridden=0";

                        command.CommandType = CommandType.Text;

                        command.CommandText = @"SELECT e.EventId," +
                                                  @"e.DivisionId as DivisionId," +
                                                  @"e.MachineId as MachineId," +
                                                  @"e.ArticleNumber as ArticleNumber," +
                                                  @"e.EventRaised as EventRaised," +
                                                  @"e.TimeForNextEvent as TimeForNextEvent," +
                                                  @"e.CurrentNumberOfItems as CurrentNumberOfItems," +
                                                  @"e.RunRate as RunRate," +
                                                  @"t.TagType as TagType," +
                                                  @"t.CategoryId as TagInfoCategoryId," +
                                                  @"r.CategoryId as ReasonCategoryId," +
                                                  @"t.DisplayName AS TagInfoDisplayName," +
                                                  @"r.DisplayName AS ReasonDisplayName" +
                                                  @" FROM Events e WITH (NOLOCK)" +
                                                  @" INNER JOIN" +
                                                  @" TagInfo t WITH (NOLOCK) ON e.TagId = t.TagId" +
                                                  @" LEFT OUTER JOIN" +
                                                  @" ReasonCodes r WITH (NOLOCK) ON e.TagId = r.TagId" +
                                                  @" AND e.ReasonCode = r.ReasonCode" +
                                                  whereClause +
                                                  @" ORDER BY e.EventRaised ASC, (CASE WHEN e.TimeForNextEvent IS NULL THEN 1 ELSE 0 END), e.TimeForNextEvent";
                        
                        using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                EventListItem listItem = EventListItem.GetEventListItem(dr);

                                //if(!criteria.ShowSecondaryFailures && listItem.TagType == TagType.Stop && listItem.ElapsedTime.TotalSeconds == 0)
                                //    continue;

                                Add(listItem);
                                
                            }
                        }

                    }
                }

            }
        }

        private void FetchChangeOverData(Criteria criteria)
        {
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {

                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    string whereClause = "";

                    if (!String.IsNullOrEmpty(criteria.DivisionId))
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "e.DivisionId=@DivisionId";
                        command.Parameters.AddWithValue("@DivisionId", criteria.DivisionId);
                    }

                    if (!String.IsNullOrEmpty(criteria.MachineId))
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "e.MachineId=@MachineId";
                        command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
                    }

                    if (!String.IsNullOrEmpty(criteria.ArticleNumber))
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "e.ArticleNumber=@ArticleNumber";
                        command.Parameters.AddWithValue("@ArticleNumber", criteria.ArticleNumber);
                    }

                    if (whereClause != "")
                        whereClause += " AND ";

                    whereClause += "(t.TagType=@TagType4 OR t.TagType=@TagType5 OR t.TagType=@TagType6)";
                    command.Parameters.AddWithValue("@TagType4", (int)TagType.Stop);
                    command.Parameters.AddWithValue("@TagType5", (int)TagType.MainAlarm);
                    command.Parameters.AddWithValue("@TagType6", (int)TagType.UnidentifiedStop);

                    string innerInnerClause = "";

                    foreach (int categoryId in M2MDataCenter.GetAvailableChangeOverCategories())
                    {
                        if (innerInnerClause != "")
                            innerInnerClause += " OR ";

                        innerInnerClause += "(e.ReasonCode=0 AND t.CategoryId=@CategoryIdA" + categoryId.ToString() + " OR r.CategoryId=@CategoryIdB" + categoryId.ToString() + ") ";
                        command.Parameters.AddWithValue("@CategoryIdA" + categoryId.ToString(), categoryId);
                        command.Parameters.AddWithValue("@CategoryIdB" + categoryId.ToString(), categoryId);
                    }

                    if (innerInnerClause != "")
                    {
                        whereClause += " AND (" + innerInnerClause + ")";
                    }

                    if (!criteria.StartDate.IsEmpty)
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "(e.TimeForNextEvent IS NULL OR e.TimeForNextEvent>@StartDate)";
                        command.Parameters.AddWithValue("@StartDate", criteria.StartDate.DBValue);
                    }

                    if (!criteria.EndDate.IsEmpty)
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "e.EventRaised<@EndDate";
                        command.Parameters.AddWithValue("@EndDate", criteria.EndDate.DBValue);
                    }

                    if (whereClause != "")
                        whereClause += " AND ";

                    whereClause = " WHERE " + whereClause + "e.Overridden=0";

                    command.CommandType = CommandType.Text;

                    command.CommandText = @"SELECT e.EventId," +
                                                @"e.DivisionId as DivisionId," +
                                                @"e.MachineId as MachineId," +
                                                @"e.ArticleNumber as ArticleNumber," +
                                                @"e.EventRaised as EventRaised," +
                                                @"e.TimeForNextEvent as TimeForNextEvent," +
                                                @"e.CurrentNumberOfItems as CurrentNumberOfItems," +
                                                @"e.RunRate as RunRate," +
                                                @"t.TagType as TagType," +
                                                @"t.CategoryId as TagInfoCategoryId," +
                                                @"r.CategoryId as ReasonCategoryId," +
                                                @"t.DisplayName AS TagInfoDisplayName," +
                                                @"r.DisplayName AS ReasonDisplayName" +
                                                @" FROM Events e WITH (NOLOCK)" +
                                                @" INNER JOIN" +
                                                @" TagInfo t WITH (NOLOCK) ON e.TagId = t.TagId" +
                                                @" LEFT OUTER JOIN" +
                                                @" ReasonCodes r WITH (NOLOCK) ON e.TagId = r.TagId" +
                                                @" AND e.ReasonCode = r.ReasonCode" +
                                                whereClause +
                                                @" ORDER BY e.EventRaised ASC, (CASE WHEN e.TimeForNextEvent IS NULL THEN 1 ELSE 0 END), e.TimeForNextEvent";

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            EventListItem listItem = EventListItem.GetEventListItem(dr);

                            //if(!criteria.ShowSecondaryFailures && listItem.TagType == TagType.Stop && listItem.ElapsedTime.TotalSeconds == 0)
                            //    continue;

                            Add(listItem);

                        }
                    }

                }

            }
        }
        
        #endregion
    }
}

