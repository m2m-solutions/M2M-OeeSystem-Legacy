using System;
using System.Collections.Generic;
using M2M.DataCenter;

namespace M2M.Integrator.Lexit.Library
{
    public class LexitSettings : ApplicationSettingsBase
    {
        /// <summary>
        /// System connect string
        /// </summary>
        public static string SystemConnectionString
        {
            get { return GetConnectionString("M2M.DataCenter.System"); }
        }

        public static string PollPath
        {
            get { return GetConfigValue("PollPath", @"C:\Temp"); }
        }

        public static List<string> OpcTags
        {
            get
            {
                string config = GetConfigValue("OpcTags", "");

                List<string> tags = new List<string>();

                string[] split = config.Split(';');

                foreach (string part in split)
                {
                    if(part != "")
                        tags.Add(part);
                }
             
                return tags;
            }
        }

        public static bool DeleteFile
        {
            get { return GetConfigValue("DeleteFile", false); }
        }
    }
}
