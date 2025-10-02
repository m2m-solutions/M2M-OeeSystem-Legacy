using System;

namespace M2M.OeeCalculator.Library
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
		/// Company Name
		/// </summary>
		public static int CalculateInterval
		{
            get { return Convert.ToInt32(GetConfigValue("CalculateInterval")); }
		}
	}
}
