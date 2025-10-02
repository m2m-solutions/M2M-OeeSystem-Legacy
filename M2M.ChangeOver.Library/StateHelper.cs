using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using NLog;
using M2M.DataCenter;

namespace M2M.ChangeOver.Library
{
    public class StateHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static bool OverrideStates(EventItem changeOverItem, EventItem autoItem)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();

                    Guid autoStateId = Guid.Empty;

                    using (SqlCommand command = cn.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT TOP 1 StateId" +
                                              @" FROM States WHERE MachineId=@MachineId AND TimeStampOnSet=@EventRaised AND StateType=@StateType AND TimeStampOnSet<>TimeStampOnReset AND Overridden=0" +
                                              @" ORDER BY TimeStampOnSet";
                        command.Parameters.AddWithValue(@"@MachineId", autoItem.MachineId);
                        command.Parameters.AddWithValue(@"@EventRaised", autoItem.EventRaised);
                        command.Parameters.AddWithValue(@"@StateType", (int)StateType.Auto);

                        object ret = command.ExecuteScalar();

                        if (ret != null)
                            autoStateId = new Guid(ret.ToString());
                    }

                    if (autoStateId != Guid.Empty)
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE [States] SET [Overridden]=@Overridden WHERE [MachineId]=@MachineId AND [TimeStampOnSet]>=@StartTime AND [TimeStampOnSet]<=@EndTime AND [StateId]<>@StateId";
                            cmd.Parameters.AddWithValue("@Overridden", true);
                            cmd.Parameters.AddWithValue("@MachineId", changeOverItem.MachineId);
                            cmd.Parameters.AddWithValue("@StartTime", changeOverItem.EventRaised);
                            cmd.Parameters.AddWithValue("@EndTime", autoItem.EventRaised);
                            cmd.Parameters.AddWithValue("@StateId", autoStateId);

                            cmd.ExecuteNonQuery();
                        }

                        Guid articleStateId = Guid.Empty;

                        using (SqlCommand command = cn.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = @"SELECT TOP 1 StateId" +
                                                  @" FROM States WHERE MachineId=@MachineId AND StateType=@StateType AND [TimeStampOnSet]>=@StartTime AND [TimeStampOnSet]<=@EndTime" +
                                                  @" ORDER BY TimeStampOnSet DESC";
                            command.Parameters.AddWithValue(@"@MachineId", autoItem.MachineId);
                            command.Parameters.AddWithValue(@"@StateType", (int)StateType.ArticleSwitch);
                            command.Parameters.AddWithValue(@"@StartTime", changeOverItem.EventRaised);
                            command.Parameters.AddWithValue(@"@EndTime", autoItem.EventRaised);

                            object ret = command.ExecuteScalar();

                            if (ret != null)
                                articleStateId = new Guid(ret.ToString());
                        }

                        if (articleStateId != Guid.Empty)
                        {
                            using (SqlCommand cmd = cn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "UPDATE [States] SET [Overridden]=@Overridden, [TimeStampOnSet]=@EventRaised WHERE [StateId]=@StateId";
                                cmd.Parameters.AddWithValue("@Overridden", false);
                                cmd.Parameters.AddWithValue("@EventRaised", changeOverItem.EventRaised);
                                cmd.Parameters.AddWithValue("@StateId", articleStateId);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        result = true;
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
