using System;

namespace M2M.DataCenter
{
	public class ApplicationSettings : ApplicationSettingsBase
	{
		/// <summary>
		/// System connect string
		/// </summary>
		public static string SystemConnectionString
		{
			get { return GetConnectionString("M2M.DataCenter.System"); }
		}

        /// <summary>
        /// Show checkbos at logon. Used for Thule old data.
        /// </summary>
        public static bool ShowLogonCheckBox
        {
            get { return GetConfigValue("ShowLogonCheckBox", false); }
        }

        public static string OpcServerName
        {
            get { return GetConfigValue("OpcServerName", "Beijer.ElectronicsOPCServer.1"); }
        }
    }
}
