using System;

namespace M2M.DataCenter
{
	public class Database
	{
		internal static string m_SystemConnectionString = "";
        internal static string m_TeklaConnectionString = "";
        public static bool ShowOld = false;

        public static string SystemConnectionString
        {
            get
            {
                if (ShowOld)
                    return @"Data Source=SSEHILOPC\SQLEXPRESS;Initial Catalog=M2M.DataCenter;uid=DataCenter;pwd=pdQ7718-t;";

                if (m_SystemConnectionString == "")
                {
                    m_SystemConnectionString = ApplicationSettings.SystemConnectionString;
                }
                return m_SystemConnectionString;
            }
            set
            {
                m_SystemConnectionString = value;
            }
        }

		public static string SystemConnectionStringWithMultipleActiveResultSets
        {
            get
            {
                if (ShowOld)
                    return @"Data Source=SSEHILOPC\SQLEXPRESS;Initial Catalog=M2M.DataCenter;uid=DataCenter;pwd=pdQ7718-t;MultipleActiveResultSets=true;";

                if (m_SystemConnectionString == "")
                {
                    m_SystemConnectionString = ApplicationSettings.SystemConnectionString;
                }

                return m_SystemConnectionString + "MultipleActiveResultSets=true;";
            }
        }
	}
}
