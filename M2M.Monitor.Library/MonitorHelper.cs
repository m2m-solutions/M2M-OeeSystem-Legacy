using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using NLog;
using M2M.DataCenter;
using Newtonsoft.Json;

namespace M2M.Monitor.Library
{
    public class MonitorHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static bool AddData(string divisionId, MonitorData data)
        {
            bool result = false;

            try
            {
                string json = JsonConvert.SerializeObject(data);

                logger.Trace(json);

                using (SqlConnection cn = new SqlConnection(ApplicationSettings.SystemConnectionString))
                {
                    cn.Open();
                    bool update = false;
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT TOP 1 DivisionId FROM [MonitorValues] WHERE DivisionId=@DivisionId";
                        cmd.Parameters.AddWithValue("@DivisionId", divisionId);
                   
                        object ret = cmd.ExecuteScalar();
                        update = ret != null;
                    }

                    if (update)
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE [MonitorValues] SET [Data]=@Data WHERE [DivisionId]=@DivisionId";
                            cmd.Parameters.AddWithValue("@Data", json);
                            cmd.Parameters.AddWithValue("@DivisionId", divisionId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO [MonitorValues] (DivisionId, [Data]) VALUES (@DivisionId,@Data)";
                            cmd.Parameters.AddWithValue("@DivisionId", divisionId);
                            cmd.Parameters.AddWithValue("@Data", json);
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

        public static MonitorData GetData(string divisionId)
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT [Data] From MonitorValues WHERE DivisionId=@DivisionId";
                    command.Parameters.AddWithValue("@DivisionId", divisionId);
                   
                    result = (string)command.ExecuteScalar();
                    if (result == null)
                    {
                        return null;
                    }
                }
            }
            return JsonConvert.DeserializeObject<MonitorData>(result);
        }
    }
}
