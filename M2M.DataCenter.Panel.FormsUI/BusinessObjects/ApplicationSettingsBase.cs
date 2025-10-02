using System;
using System.Configuration;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
	public abstract class ApplicationSettingsBase
	{
		protected static string GetConfigValue(string key)
		{
			string result = ConfigurationManager.AppSettings[key];
			if (result == null)
				throw new ConfigurationErrorsException(String.Format("Configuration key: {0} not set", key));
			return result;
		}

        protected static bool GetConfigValue(string key, bool defaultValue)
        {
            bool result = false; 
            string appSetting = ConfigurationManager.AppSettings[key];

            if (appSetting == null || !Boolean.TryParse(appSetting, out result))
                return defaultValue;

            return result;
        }

		protected static int GetConfigValue(string key, int defaultValue)
		{
			int result = 0;
			string appSetting = ConfigurationManager.AppSettings[key];

			if (appSetting == null || !Int32.TryParse(appSetting, out result))
				return defaultValue;

			return result;
		}

        protected static string GetConfigValue(string key, string defaultValue)
        {
            string result = ConfigurationManager.AppSettings[key];

            if (result == null)
                return defaultValue;

            return result;
        }

		protected static string GetConnectionString(string key)
		{
			ConnectionStringSettings result = ConfigurationManager.ConnectionStrings[key];
			if (result == null)
				throw new ConfigurationErrorsException(String.Format("Connection string: {0} not set", key));
			return result.ConnectionString;
		}
	}
}
