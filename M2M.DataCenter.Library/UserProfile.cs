using System;

namespace M2M.DataCenter
{
    public static class UserProfile
    {
        /// <summary>
        /// Gets the stored profile value associated with the key from the logged on user profile
        /// </summary>
        /// <param name="key">Key value</param>
        /// <returns>Stored value</returns>
        internal static string GetValue(string key)
        {
            if (Csla.ApplicationContext.User.GetType() != typeof(M2MPrincipal))
                throw new UserIsNotLoggedOnException();

            M2MPrincipal user = (M2MPrincipal)Csla.ApplicationContext.User;
            UserSetting setting = user.Settings.GetItem(key);
            if (setting == null)
                return "";

            return setting.Value;
        }

        /// <summary>
        /// Sets the stored profile value associated with the key from the logged on user profile
        /// </summary>
        /// <param name="key">Key value</param>
        /// <param name="value">Stored</param>		
        internal static void SetValue(string key, string value)
        {
            if (Csla.ApplicationContext.User.GetType() != typeof(M2MPrincipal))
                throw new UserIsNotLoggedOnException();

            M2MPrincipal user = (M2MPrincipal)Csla.ApplicationContext.User;
            UserSetting setting = user.Settings.GetItem(key);
            if (setting == null)
                setting = user.Settings.Add(key);

            setting.Value = value;
        }

        /// <summary>
        /// Get/Set the users start page
        /// </summary>
        public static string StartPage
        {
            get { return GetValue("StartPage"); }
            set { SetValue("StartPage", value); }
        }

        public static void Save()
        {
            if (Csla.ApplicationContext.User is M2MPrincipal)
                Csla.ApplicationContext.User = ((M2MPrincipal)Csla.ApplicationContext.User).Save();
        }
    }
}
