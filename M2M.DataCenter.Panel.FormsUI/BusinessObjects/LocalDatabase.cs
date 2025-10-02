//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Data.SqlServerCe;
//using NLog;
//using Telerik.WinControls;
//using M2M.DataCenter.Localization;

//namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
//{
//	public class LocalDatabase
//	{
//        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
//        internal static string m_ConnectionString = "";
        
//        public static string ConnectionString
//        {
//            get
//            {
//                if (m_ConnectionString == "")
//                {
//                    //string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
//                    //string path = (System.IO.Path.GetDirectoryName(executable));
//                    //m_ConnectionString = ApplicationSettings.LocalConnectionString.Replace("|DataDirectory|", path);
//                    m_ConnectionString = ApplicationSettings.LocalConnectionString;
//                }
//                return m_ConnectionString;
//            }
//            set
//            {
//                m_ConnectionString = value;
//            }
//        }

//        public static Dictionary<string, List<ButtonData>> GetButtonDataList(List<TagInfo> tags)
//        {
//            Dictionary<string, List<ButtonData>> dictionary = new Dictionary<string, List<ButtonData>>();

//            foreach(TagInfo tag in tags)
//            {
//                dictionary.Add(tag.TagId, GetButtonDataList(tag.TagId));
//            }

//            return dictionary;
//        }

//        public static List<ButtonData> GetButtonDataList(string tagId)
//        {
//            List<ButtonData> buttons = new List<ButtonData>();

//            try
//            {
//                using (SqlCeConnection cn = new SqlCeConnection(LocalDatabase.ConnectionString))
//                {
//                    using (SqlCeCommand cmd = cn.CreateCommand())
//                    {
//                        cmd.CommandType = CommandType.Text;
//                        cmd.CommandText = "SELECT [TagId], [ReasonCode], [DisplayName], [PosX], [PosY] FROM [ButtonData] WHERE [TagId]=@p1";
//                        cmd.Parameters.AddWithValue("@p1", tagId);
//                        cn.Open();

//                        using (SqlCeDataReader dr = cmd.ExecuteReader())
//                        {
//                            while (dr.Read())
//                            {
//                                buttons.Add(new ButtonData(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetInt32(3), dr.GetInt32(4)));
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                logger.ErrorException("Failed to connect to local database", ex);
//                RadMessageBox.Show(ResourceStrings.GetString("Panel.FailedToConnect.Local"), ResourceStrings.GetString("Panel.ErrorTitle"), System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
//            }

//            return buttons;
//        }

//        public static void AddButtonData(ButtonData button)
//        {
//            try
//            {
//                using (SqlCeConnection cn = new SqlCeConnection(LocalDatabase.ConnectionString))
//                {
//                    using (SqlCeCommand cmd = cn.CreateCommand())
//                    {
//                        cmd.CommandType = CommandType.Text;
//                        cmd.CommandText = "INSERT INTO [ButtonData] ([TagId],[ReasonCode], [DisplayName],[PosY], [PosX]) VALUES (@p1, @p2, @p3, @p4, @p5)";
//                        cmd.Parameters.AddWithValue("@p1", button.TagId);
//                        cmd.Parameters.AddWithValue("@p2", button.ReasonId);
//                        cmd.Parameters.AddWithValue("@p3", button.DisplayName);
//                        cmd.Parameters.AddWithValue("@p4", button.Row);
//                        cmd.Parameters.AddWithValue("@p5", button.Column);
//                        cn.Open();

//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                logger.ErrorException("Failed to connect to local database", ex);
//                RadMessageBox.Show(ResourceStrings.GetString("Panel.FailedToConnect.Local"), ResourceStrings.GetString("Panel.ErrorTitle"), System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
//            }
//        }

//        public static void DeleteButtonData(ButtonData button)
//        {
//            try
//            {
//                using (SqlCeConnection cn = new SqlCeConnection(LocalDatabase.ConnectionString))
//                {
//                    using (SqlCeCommand cmd = cn.CreateCommand())
//                    {
//                        cmd.CommandType = CommandType.Text;
//                        cmd.CommandText = "DELETE FROM [ButtonData] WHERE ([TagId] = @p1 AND [ReasonCode]=@p2)";
//                        cmd.Parameters.AddWithValue("@p1", button.TagId);
//                        cmd.Parameters.AddWithValue("@p2", button.ReasonId);
//                        cn.Open();

//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                logger.ErrorException("Failed to connect to local database", ex);
//                RadMessageBox.Show(ResourceStrings.GetString("Panel.FailedToConnect.Local"), ResourceStrings.GetString("Panel.ErrorTitle"), System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
//            }
//        }
//	}
//}
