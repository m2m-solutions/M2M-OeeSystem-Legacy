using System;
using System.Configuration;

namespace M2M.OeeCalculator.Library
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

		protected static string GetConnectionString(string key)
		{
			ConnectionStringSettings result = ConfigurationManager.ConnectionStrings[key];
			if (result == null)
				throw new ConfigurationErrorsException(String.Format("Connection string: {0} not set", key));
			return result.ConnectionString;
		}
	}
}
