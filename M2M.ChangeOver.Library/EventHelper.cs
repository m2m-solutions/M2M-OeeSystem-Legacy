using System;
using System.Linq;
using NLog;
using System.Data.SqlClient;
using M2M.DataCenter;
using System.Data;

namespace M2M.ChangeOver.Library
{
    public class EventHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static bool OverrideEvents(EventItem changeOverItem, EventItem autoItem)
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
                        cmd.CommandText = "UPDATE [Events] SET [Overridden]=@Overridden WHERE [MachineId]=@MachineId AND [EventRaised]>=@StartTime AND [EventRaised]<=@EndTime AND [EventId]<>@ChangeOverId AND [EventId]<>@AutoId";
                        cmd.Parameters.AddWithValue("@Overridden", true);
                        cmd.Parameters.AddWithValue("@MachineId", changeOverItem.MachineId);
                        cmd.Parameters.AddWithValue("@StartTime", changeOverItem.EventRaised);
                        cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);
                        cmd.Parameters.AddWithValue("@ChangeOverId", changeOverItem.EventId);
                        cmd.Parameters.AddWithValue("@AutoId", autoItem.EventId);

                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE [Events] SET [TimeForNextEvent]=@EventRaised, [ArticleNumber]=@ArticleNumber  WHERE [EventId]=@EventId";
                        cmd.Parameters.AddWithValue("@EventRaised", autoItem.EventRaised);
                        cmd.Parameters.AddWithValue("@ArticleNumber", autoItem.Article);
                        cmd.Parameters.AddWithValue("@EventId", changeOverItem.EventId);

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

        
    }
}
