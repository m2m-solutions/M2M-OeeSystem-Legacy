using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using NLog;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public class SystemDatabase
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        internal static string m_ConnectionString = "";
        public static bool IsConnected = false;
        public static bool LogException = true;

        public static string ConnectionString
        {
            get
            {
                if (m_ConnectionString == "")
                {
                    m_ConnectionString = ApplicationSettings.SystemConnectionString;
                }
                return m_ConnectionString;
            }
            set
            {
                m_ConnectionString = value;
            }
        }

        public static List<TagInfo> GetSubscriptionTags(string divisionId, string machineId, string machineType)
        {
            List<TagInfo> tags = new List<TagInfo>();

            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        switch (machineType)
                        {
                            case "SingleMachine":
                                cmd.CommandText = String.Format("SELECT TagId, DisplayName, DivisionId, MachineId, CategoryId FROM dbo.[TagInfo] WHERE MachineId='{0}' AND SendPanelRequest=1", machineId);
                                break;
                            case "Line":
                                cmd.CommandText = String.Format("SELECT TagId, DisplayName, DivisionId, MachineId, CategoryId FROM dbo.[TagInfo] WHERE DivisionId='{0}' AND SendPanelRequest=1", divisionId);
                                break;
                            default:
                                throw new ArgumentException("{0} is not a valid MachineType value");
                        }

                        cn.Open();

                        IsConnected = true;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                tags.Add(new TagInfo(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4)));


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }

            return tags;
        }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT CategoryId, DisplayName, ChangeOver, NoProduction FROM dbo.[EventCategories]");

                        cn.Open();

                        IsConnected = true;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                categories.Add(new Category(dr.GetInt32(0), dr.GetString(1), dr.GetBoolean(2), dr.GetBoolean(3)));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }

            return categories;
        }

        public static bool UpdateEvent(Guid eventId, ButtonData buttonData)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    cn.Open();
                    IsConnected = true;
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE [Events] SET [ReasonCode]=@p1 WHERE [EventId]=@p2";
                        cmd.Parameters.AddWithValue("@p1", buttonData.ReasonId);
                        cmd.Parameters.AddWithValue("@p2", eventId);

                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM [PendingPanelRequests] WHERE [EventId]=@p1";
                        cmd.Parameters.AddWithValue("@p1", eventId);

                        cmd.ExecuteNonQuery();
                    }

                    result = true;
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }

            return result;

        }

        public static List<Reason> GetReasonCodes(string divisionId, string machineId, string machineType)
        {
            List<Reason> reasonCodes = new List<Reason>();

            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        switch (machineType)
                        {
                            case "SingleMachine":
                                cmd.CommandText = String.Format("SELECT TagId, ReasonCode, DisplayName, DivisionId, MachineId, CategoryId FROM dbo.[ReasonCodes] WHERE MachineId='{0}'", machineId);
                                break;
                            case "Line":
                                cmd.CommandText = String.Format("SELECT TagId, ReasonCode, DisplayName, DivisionId, MachineId, CategoryId FROM dbo.[ReasonCodes] WHERE DivisionId='{0}'", divisionId);
                                break;
                            default:
                                throw new ArgumentException("{0} is not a valid MachineType value");
                        }

                        cn.Open();
                        IsConnected = true;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                reasonCodes.Add(new Reason(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetInt32(5)));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }

            return reasonCodes;
        }

        public static int? GetNextReasonCodeSequences(string tagId)
        {
            int? next = null;
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    cn.Open();
                    IsConnected = true;
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = String.Format("UPDATE dbo.[ReasonCodeSequences] SET LastSequence=LastSequence+1 WHERE TagId='{0}'", tagId);

                        result = cmd.ExecuteNonQuery();
                    }

                    if (result == 0)
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = String.Format("INSERT INTO dbo.[ReasonCodeSequences] (TagId, LastSequence) VALUES ('{0}', 1)", tagId);

                            cmd.ExecuteNonQuery();

                            next = 1;
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {


                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = String.Format("SELECT LastSequence from dbo.[ReasonCodeSequences] WHERE TagId='{0}'", tagId);

                            next = (int?)cmd.ExecuteScalar();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }

            return next;
        }

        public static void AddReason(Reason reason)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [ReasonCodes] ([TagId], [ReasonCode], [DisplayName], [DivisionId], [MachineId], [CategoryId]) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                        cmd.Parameters.AddWithValue("@p1", reason.TagId);
                        cmd.Parameters.AddWithValue("@p2", reason.ReasonCode);
                        cmd.Parameters.AddWithValue("@p3", reason.DisplayName);
                        cmd.Parameters.AddWithValue("@p4", reason.DivisionId);
                        cmd.Parameters.AddWithValue("@p5", reason.MachineId);
                        cmd.Parameters.AddWithValue("@p6", reason.CategoryId);
                        cn.Open();
                        IsConnected = true;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }
        }

        public static void UpdateReason(Reason reason)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE [ReasonCodes] SET [DisplayName]=@p1, [CategoryId]=@p2 WHERE ([TagId]=@p3 AND [ReasonCode]=@p4)";
                        cmd.Parameters.AddWithValue("@p1", reason.DisplayName);
                        cmd.Parameters.AddWithValue("@p2", reason.CategoryId);
                        cmd.Parameters.AddWithValue("@p3", reason.TagId);
                        cmd.Parameters.AddWithValue("@p4", reason.ReasonCode);
                        cn.Open();
                        IsConnected = true;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }
        }

        public static void DeleteReason(Reason reason)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM [ReasonCodes] WHERE ([TagId] = @p1 AND [ReasonCode]=@p2)";
                        cmd.Parameters.AddWithValue("@p1", reason.TagId);
                        cmd.Parameters.AddWithValue("@p2", reason.ReasonCode);
                        cn.Open();
                        IsConnected = true;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }
        }

        public static void AddChangeOverRequest(EventInfo pendingEvent)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [ChangeOverCalculateRequests] ([Timestamp], [EventId], [MachineId]) VALUES (@p1, @p2, @p3);UPDATE [RealTimeValues] SET [ChangeOverActive]=1 WHERE [MachineId]=@p4 AND ValidAuto=0";
                        cmd.Parameters.AddWithValue("@p1", pendingEvent.EventRaised);
                        cmd.Parameters.AddWithValue("@p2", pendingEvent.EventId);
                        cmd.Parameters.AddWithValue("@p3", pendingEvent.MachineId);
                        cmd.Parameters.AddWithValue("@p4", pendingEvent.MachineId);
                        cn.Open();
                        IsConnected = true;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }
        }

        public static void ClearPending(string divisionId, string machineId, string machineType)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        switch (machineType)
                        {
                            case "SingleMachine":
                                cmd.CommandText = String.Format("DELETE FROM dbo.[PendingPanelRequests] WHERE MachineId='{0}'", machineId);
                                break;
                            case "Line":
                                cmd.CommandText = String.Format("DELETE FROM dbo.[PendingPanelRequests] WHERE MachineId IN (SELECT MachineId FROM Machines WHERE DivisionId='{0}')", divisionId);
                                break;
                            default:
                                throw new ArgumentException("{0} is not a valid MachineType value");
                        }

                        cn.Open();
                        IsConnected = true;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }
        }


        public static Dictionary<string, List<ButtonData>> GetButtonDataList(List<TagInfo> tags)
        {
            Dictionary<string, List<ButtonData>> dictionary = new Dictionary<string, List<ButtonData>>();

            foreach (TagInfo tag in tags)
            {
                dictionary.Add(tag.TagId, GetButtonDataList(tag.TagId));
            }

            return dictionary;
        }

        public static List<ButtonData> GetButtonDataList(string tagId)
        {
            List<ButtonData> buttons = new List<ButtonData>();

            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT [TagId], [ReasonCode], [DisplayName], [PosX], [PosY] FROM [PanelButtons] WHERE [TagId]=@p1";
                        cmd.Parameters.AddWithValue("@p1", tagId);
                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                buttons.Add(new ButtonData(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetInt32(3), dr.GetInt32(4)));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }

            return buttons;
        }

        public static void AddButtonData(ButtonData button)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [PanelButtons] ([TagId],[ReasonCode], [DisplayName],[PosY], [PosX]) VALUES (@p1, @p2, @p3, @p4, @p5)";
                        cmd.Parameters.AddWithValue("@p1", button.TagId);
                        cmd.Parameters.AddWithValue("@p2", button.ReasonId);
                        cmd.Parameters.AddWithValue("@p3", button.DisplayName);
                        cmd.Parameters.AddWithValue("@p4", button.Row);
                        cmd.Parameters.AddWithValue("@p5", button.Column);
                        cn.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }
        }

        public static void DeleteButtonData(ButtonData button)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM [PanelButtons] WHERE ([TagId] = @p1 AND [ReasonCode]=@p2)";
                        cmd.Parameters.AddWithValue("@p1", button.TagId);
                        cmd.Parameters.AddWithValue("@p2", button.ReasonId);
                        cn.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                if (LogException)
                    logger.ErrorException("Failed to connect to server", ex);
                else
                    logger.Error("Failed to reconnect");
            }
        }
    }
}
