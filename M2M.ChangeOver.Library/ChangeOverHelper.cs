using System;
using System.Linq;
using NLog;
using System.Data.SqlClient;
using M2M.DataCenter;
using System.Data;
using System.Collections.Generic;

namespace M2M.ChangeOver.Library
{
    public class ChangeOverHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static bool AddData(EventItem autoItem, DateTime changeOverStartTime, DateTime startTime, DateTime endTime, string prevArticle, bool countThis)
        {
            bool result = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();
                    long id = 0;
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT TOP 1 Id FROM [ChangeOvers] WHERE MachineId=@MachineId AND EndTime=@Timestamp";
                        cmd.Parameters.AddWithValue("@MachineId", autoItem.MachineId);
                        cmd.Parameters.AddWithValue("@Timestamp", endTime);

                        object ret = cmd.ExecuteScalar();
                        id = ret != null ? (long)ret : 0;
                    }

                    if (id > 0)
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE [ChangeOvers] SET [StartTime]=@StartTime WHERE [Id]=@Id";
                            cmd.Parameters.AddWithValue("@StartTime", startTime);
                            cmd.Parameters.AddWithValue("@Id", id);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO [ChangeOvers] (StartTime, EndTime, MachineId, Article, PreviousArticle, CountThis,ChangeOverStart,ChangeOverEnd) VALUES (@StartTime,@EndTime,@MachineId,@Article,@PreviousArticle,@CountThis,@ChangeOverStart,@ChangeOverEnd)";
                            cmd.Parameters.AddWithValue("@StartTime", startTime);
                            cmd.Parameters.AddWithValue("@EndTime", endTime);
                            cmd.Parameters.AddWithValue("@MachineId", autoItem.MachineId);
                            cmd.Parameters.AddWithValue("@Article", autoItem.Article);
                            cmd.Parameters.AddWithValue("@PreviousArticle", prevArticle);
                            cmd.Parameters.AddWithValue("@CountThis", countThis);
                            cmd.Parameters.AddWithValue("@ChangeOverStart", changeOverStartTime);
                            cmd.Parameters.AddWithValue("@ChangeOverEnd", autoItem.EventRaised);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    

                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to connect to server", ex);
            }

            return result;

        }

        public static bool OverrideEvent(Guid eventId)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE [Events] SET [Overridden]=1 WHERE [EventId]=@EventId";
                        cmd.Parameters.AddWithValue("@EventId", eventId);

                        cmd.ExecuteNonQuery();
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to connect to server", ex);
            }

            return result;
        }

        public static bool InsertEvent(EventItem changeOverItem, Guid originalEventId)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText += @"INSERT INTO Events " +
                                           @"(EventId,DivisionId,MachineId,ArticleNumber,TagId,ReasonCode,RunRate,EventRaised,TimeForNextEvent,CurrentNumberOfItems,Overridden)" +
                                           @" SELECT @EventId,DivisionId,MachineId,@ArticleNumber,TagId,ReasonCode,RunRate,@EventRaised,@TimeForNextEvent,CurrentNumberOfItems,0 FROM Events WHERE EventId=@OriginalEventId;";
                        cmd.Parameters.AddWithValue("@EventId", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@ArticleNumber", changeOverItem.Article);
                        cmd.Parameters.AddWithValue("@EventRaised", changeOverItem.EventRaised);
                        cmd.Parameters.AddWithValue("@TimeForNextEvent", changeOverItem.TimeForNextEvent);
                        cmd.Parameters.AddWithValue("@OriginalEventId", originalEventId);

                        result = cmd.ExecuteNonQuery() > 0;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to connect to server", ex);
            }

            return result;
        }

        public static EventItem GetValidAuto(string machineId, DateTime startTime)
        {
            EventItem result = null;

            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 e.EventId, e.EventRaised, e.ArticleNumber" +
                                          @" FROM Events e JOIN TagInfo t ON e.TagId=t.TagId WHERE e.MachineId=@MachineId AND e.EventRaised>@EventRaised AND t.TagType=@TagType AND e.RunRate > 0 AND Overridden=0"+
                                          @" ORDER BY EventRaised";
                    command.Parameters.AddWithValue(@"@MachineId", machineId);
                    command.Parameters.AddWithValue(@"@EventRaised", startTime);
                    command.Parameters.AddWithValue(@"@TagType", (int)TagType.Auto);


                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new EventItem();
                            result.EventId = dr.GetGuid(0);
                            result.EventRaised = dr.GetDateTime(1);
                            result.Article = dr.GetString(2);
                            result.TagType = TagType.Auto;
                            result.MachineId = machineId;
                        }
                    }
                }
            }
            return result;
        }

        public static bool IsValidRequest(Guid eventId)
        {
            bool valid = false;
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT t.TagType FROM TagInfo t JOIN Events e ON t.TagId=e.TagId WHERE e.EventId=@EventId";
                                         
                    command.Parameters.AddWithValue(@"@EventId", eventId);

                    int tagType = (int)command.ExecuteScalar();
                    valid = (tagType == (int)TagType.Stop || tagType == (int)TagType.UnidentifiedStop || tagType == (int)TagType.MainAlarm);
                }
            }
            return valid;
        }

        public static List<EventItem> GetInvolvedEvents(ChangeOverCalculateRequest request, EventItem autoItem)
        {
            List<EventItem> result = new List<EventItem>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT e.EventId,e.EventRaised,e.TimeForNextEvent,t.TagType FROM [Events] e JOIN [TagInfo] t ON e.TagId=t.TagId WHERE e.[MachineId]=@MachineId AND e.[EventRaised]>=@StartTime AND e.[EventRaised]<@EndTime AND e.TimeForNextEvent IS NOT NULL AND Overridden=0 ORDER BY e.EventRaised,e.TimeForNextEvent";
                        cmd.Parameters.AddWithValue("@MachineId", request.MachineId);
                        cmd.Parameters.AddWithValue("@StartTime", request.Timestamp.DBValue);
                        cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EventItem item = new EventItem();
                                item.EventId = dr.GetGuid(0);
                                item.EventRaised = dr.GetDateTime(1);
                                item.TimeForNextEvent = dr.GetDateTime(2);
                                item.TagType = (TagType)dr.GetInt32(3);
                                item.MachineId = request.MachineId;
                                item.Article = autoItem.Article;
                                result.Add(item);
                            }
                        } cmd.ExecuteNonQuery();
                    }

                    
                    
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to connect to server", ex);
            }

            return result;

        }

        public static bool OverrideStates(EventItem changeOverItem)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE [States] SET [Overridden]=1 WHERE [MachineId]=@MachineId AND [TimeStampOnSet]>=@StartTime AND [TimeStampOnSet]<@EndTime and StateType<>2";
                        cmd.Parameters.AddWithValue("@Overridden", true);
                        cmd.Parameters.AddWithValue("@MachineId", changeOverItem.MachineId);
                        cmd.Parameters.AddWithValue("@StartTime", changeOverItem.EventRaised);
                        cmd.Parameters.AddWithValue("@EndTime", changeOverItem.TimeForNextEvent);
                  
                        int count = cmd.ExecuteNonQuery();
                        logger.Trace("{0} states overriden", count);
                    }
                }

                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [States] (StateId, DivisionId,MachineId,ArticleNumber,StateType,TimeStampOnSet,TimeStampOnReset,NumberOfItemsOnSet,NumberOfItemsOnReset,NumberOfRejectedOnSet,NumberOfRejectedOnReset,Overridden)" +
                                                       " VALUES (@StateId,@DivisionId,@MachineId,@ArticleNumber,@StateType,@TimeStampOnSet,@TimeStampOnReset,0,0,0,0,0)";

                        cmd.Parameters.AddWithValue("@StateId", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@DivisionId", M2MDataCenter.GetMachine(changeOverItem.MachineId).DivisionId);
                        cmd.Parameters.AddWithValue("@MachineId", changeOverItem.MachineId);
                        cmd.Parameters.AddWithValue("@ArticleNumber", changeOverItem.Article);
                        cmd.Parameters.AddWithValue("@StateType", (int)StateType.ChangeOver);
                        cmd.Parameters.AddWithValue("@TimeStampOnSet", changeOverItem.EventRaised);
                        cmd.Parameters.AddWithValue("@TimeStampOnReset", changeOverItem.TimeForNextEvent);

                        result = cmd.ExecuteNonQuery() > 0;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to connect to server", ex);
            }

            return result;

        }

        public static string GetPreviousArticle(ChangeOverCalculateRequest request)
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 ArticleNumber From Events e  JOIN TagInfo t ON e.TagId=t.TagId" +
                                    " WHERE e.MachineId=@MachineId AND e.EventRaised<@EventRaised AND t.TagType=@TagType AND e.RunRate > 0 AND Overridden=0" +
                                          @" ORDER BY EventRaised DESC";
                    command.Parameters.AddWithValue("@MachineId", request.MachineId);
                    command.Parameters.AddWithValue("@EventRaised", request.Timestamp.DBValue);
                    command.Parameters.AddWithValue("@TagType", (int)TagType.Auto);
                    
                    result = (string)command.ExecuteScalar();
                    if (result == null)
                    {
                        result = "";
                    }
                }
            }
            return result;
        }

        public static bool UpdateArticleNumber(ChangeOverCalculateRequest request, EventItem autoItem)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();
                    int retVal = 0;
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        // Move previous article change to changeover start if there has been an article during the changeover
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE States" +
                                                @" SET TimeStampOnReset=@TimeStampOnReset" +
                                                @" WHERE StateId=(SELECT TOP 1 StateId FROM States WHERE [MachineId]=@MachineId AND StateType=2 AND [TimeStampOnSet]< @StartTime AND TimeStampOnReset IS NOT NULL AND TimeStampOnReset<@EndTime AND TimeStampOnReset > @StartTime2 ORDER BY TimeStampOnSet DESC)";

                        cmd.Parameters.AddWithValue("@TimeStampOnReset", request.Timestamp.DBValue);
                        cmd.Parameters.AddWithValue("@MachineId", request.MachineId);
                        cmd.Parameters.AddWithValue("@StartTime", request.Timestamp.DBValue);
                        cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);
                        cmd.Parameters.AddWithValue("@StartTime2", request.Timestamp.DBValue);
                        retVal = cmd.ExecuteNonQuery();
                    }

                    if (retVal > 0)
                    {
                        logger.Trace("Article change during changeover deteceted. Previous article TimeStamponReset has been updated to {0}", request.Timestamp);
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            // If there were an article change during the change over move the new article start to changeover start
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE States" +
                                                    @" SET TimeStampOnSet=@TimeStampOnSet" +
                                                    @" WHERE StateId=(SELECT TOP 1 StateId FROM States WHERE [MachineId]=@MachineId AND StateType=2 AND [TimeStampOnSet]> @StartTime  AND [TimeStampOnSet]< @EndTime AND (TimeStampOnReset IS NULL OR TimeStampOnReset>@EndTime2) ORDER BY TimeStampOnSet)";

                            cmd.Parameters.AddWithValue("@TimeStampOnSet", request.Timestamp.DBValue);
                            cmd.Parameters.AddWithValue("@MachineId", request.MachineId);
                            cmd.Parameters.AddWithValue("@StartTime", request.Timestamp.DBValue);
                            cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);
                            cmd.Parameters.AddWithValue("@EndTime2", autoItem.EventRaised);
                            if (cmd.ExecuteNonQuery() > 0)
                                logger.Trace("New article Timestamponset has been updated to {0}", request.Timestamp);
                        }
                    }

                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        // Override any article states that has been totally inside the changeover
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE [States] SET [Overridden]=1 WHERE [MachineId]=@MachineId AND [TimeStampOnSet]>@StartTime AND [TimeStampOnSet]<@EndTime and StateType=2";
                        cmd.Parameters.AddWithValue("@MachineId", request.MachineId);
                        cmd.Parameters.AddWithValue("@StartTime", request.Timestamp.DBValue);
                        cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);

                        int count = cmd.ExecuteNonQuery();

                        logger.Trace("{0} article changes overriden", count);
                    }

                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        // Update articlenumber on all not overriden states
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE States" +
                                                @" SET ArticleNumber=@ArticleNumber" +
                                                @" WHERE  [MachineId]=@MachineId AND StateType<>2  AND Overridden=0 AND [TimeStampOnSet] >= @StartTime AND TimeStampOnReset <= @EndTime";

                        cmd.Parameters.AddWithValue("@ArticleNumber", autoItem.Article);
                        cmd.Parameters.AddWithValue("@MachineId", request.MachineId);
                        cmd.Parameters.AddWithValue("@StartTime", request.Timestamp.DBValue);
                        cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);
                        int count = cmd.ExecuteNonQuery();

                        logger.Trace("{0} article number changed in states", count);
                    }

                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        // Update articlenumber on all not overriden events
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Events" +
                                                @" SET ArticleNumber=@ArticleNumber" +
                                                @" WHERE  [MachineId]=@MachineId AND Overridden=0 AND [EventRaised] >= @StartTime AND [TimeForNextEvent] <= @EndTime";

                        cmd.Parameters.AddWithValue("@ArticleNumber", autoItem.Article);
                        cmd.Parameters.AddWithValue("@MachineId", request.MachineId);
                        cmd.Parameters.AddWithValue("@StartTime", request.Timestamp.DBValue);
                        cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);
                        int count = cmd.ExecuteNonQuery();

                        logger.Trace("{0} article number changed in events", count);
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to connect to server", ex);
            }

            return result;

        }

        public static bool InsertCalculateRequest(string divisionId, string machineId, DateTime start, DateTime stop)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO StoppageCalculateRequests (" +
                                                "DivisionId," +
                                                "MachineId," +
                                                "StartDate," +
                                                "EndDate" +
                                                ") VALUES (" +
                                                "@DivisionId," +
                                                "@MachineId," +
                                                "@StartDate," +
                                                "@EndDate)";

                        cmd.Parameters.AddWithValue(@"@DivisionId", divisionId);
                        cmd.Parameters.AddWithValue(@"@MachineId", machineId);
                        cmd.Parameters.AddWithValue(@"@StartDate", start);
                        cmd.Parameters.AddWithValue(@"@EndDate", stop);

                        result = cmd.ExecuteNonQuery() > 0;
                    }


                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO OeeCalculateRequests (" +
                                                "DivisionId," +
                                                "MachineId," +
                                                "StartDate," +
                                                "EndDate" +
                                                ") VALUES (" +
                                                "@DivisionId," +
                                                "@MachineId," +
                                                "@StartDate," +
                                                "@EndDate)";

                        cmd.Parameters.AddWithValue(@"@DivisionId", divisionId);
                        cmd.Parameters.AddWithValue(@"@MachineId", machineId);
                        cmd.Parameters.AddWithValue(@"@StartDate", start);
                        cmd.Parameters.AddWithValue(@"@EndDate", stop);

                        result = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to connect to server", ex);
            }

            return result;
        }
    }
}
