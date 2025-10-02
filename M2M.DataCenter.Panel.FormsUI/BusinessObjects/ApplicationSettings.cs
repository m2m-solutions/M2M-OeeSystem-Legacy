using System;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
	public class ApplicationSettings : ApplicationSettingsBase
	{
        public static bool IsDeveloperEnvironment { get; set; }
		/// <summary>
		/// System connect string
		/// </summary>
		public static string SystemConnectionString
		{
			get 
            {
                if (IsDeveloperEnvironment)
                    return "Data Source=SQL2017;Initial Catalog=OeeSystem;uid=DataCenter;pwd=pdQ7718-t;";
                
                return GetConnectionString("M2M.DataCenter.System");
            }
		}

        /// <summary>
		/// Local connect string
		/// </summary>
		public static string LocalConnectionString
		{
            get { return GetConnectionString("M2M.DataCenter.Panel.FormsUI.Properties.Settings.SettingsConnectionString"); }
		}

        /// <summary>
        /// Kiosk mode (always on top, otherwise started in system tray)
        /// </summary>
        public static bool KioskMode
        {
            get
            {
                if (IsDeveloperEnvironment)
                    return false;
 
                return GetConfigValue("KioskMode", true);
            }
        }

        /// <summary>
        /// Ignore minimize to tray when no alerts (development only)
        /// Manually change when needed
        /// </summary>
        public static bool DeveloperIgnoreMinimize
        {
            get
            {
                if (IsDeveloperEnvironment)
                {
                    // Uncomment line below when needed
                    //return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Language
        /// </summary>
        public static string Language
        {
            get
            {
                //if (IsDeveloperEnvironment)
                //    return "sv";

                return GetConfigValue("Language", "sv-se");
            }
        }

        /// <summary>
        /// Address for OeeSystem 
        /// </summary>
        public static string OeeSystemAddress
        {
            get 
            {
                if (IsDeveloperEnvironment)
                    return "http://localhost/M2M.DataCenter.WebUI/Production/MachinePage.aspx?DivisionId={0}";

                return GetConfigValue("OeeSystemAddress"); 
            }
        }

        /// <summary>
        /// Type of Machine (SingleMachine or Station)
        /// </summary>
        public static string MachineType
        {
            get 
            {
                if (IsDeveloperEnvironment)
                    return "SingleMachine";

                return GetConfigValue("MachineType"); 
            }
        }

        /// <summary>
        /// DivisionId 
        /// </summary>
        public static string DivisionId
        {
            get 
            {
                if (IsDeveloperEnvironment)
                    return "Automat_press";

                return GetConfigValue("DivisionId"); 
            }
        }

        /// <summary>
        /// MachineId 
        /// </summary>
        public static string MachineId
        {
            get 
            {
                if (IsDeveloperEnvironment)
                    return "31201";

                return GetConfigValue("MachineId"); 
            }
        }
	}
}
