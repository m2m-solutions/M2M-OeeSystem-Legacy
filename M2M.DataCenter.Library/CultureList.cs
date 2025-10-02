using System;
using System.Collections.Generic;

namespace M2M.DataCenter
{
	/// <summary>
	/// CultureList list item
	/// </summary>
	public struct CultureListItem
	{
		string m_Name;
		string m_Culture;
        string m_UICulture;

		/// <summary>
		/// Name of culture
		/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// String value of culture
		/// </summary>
		public string Culture
		{
            get { return m_Culture; }
            set { m_Culture = value; }
		}

        /// <summary>
        /// String value of uiculture
        /// </summary>
        public string UICulture
        {
            get { return m_UICulture; }
            set { m_UICulture = value; }
        }

		/// <summary>
		/// Creates a CultureListItem
		/// </summary>
		/// <param name="name">Name of culture</param>
		/// <param name="culture">String value of culture</param>
        /// <param name="uiculture">String value of culture</param>
        public CultureListItem(string name, string culture, string uiculture)
		{
			m_Name = name;
			m_Culture = culture;
            m_UICulture = uiculture;
		}

        public static Predicate<CultureListItem> ByName(string name)
        {
            return delegate(CultureListItem item) { return item.Name == name; };
        }
	}

	/// <summary>
	/// Encapsulates a list of application supported cultures
	/// </summary>
	public class CultureList: List<CultureListItem>
	{
		private static CultureList m_CultureList = null;

		private CultureList()
		{
            this.Add(new CultureListItem("Auto", "", ""));
            this.Add(new CultureListItem("English (United States)", "en-US", "en"));
            this.Add(new CultureListItem("English (Europe)", "en-GB", "en"));
            this.Add(new CultureListItem("Deutsch (Deutschland)", "de-DE", "de"));
			this.Add(new CultureListItem("Svenska (Sverige)", "sv-SE", "sv"));
		}

		/// <summary>
		/// Static function that returns the list of supported cultures for use in a GUI list
		/// </summary>
		/// <returns>A List&lt;CultureListItem> with supported cultures</returns>
		public static CultureList GetCultureList()
		{
			if (m_CultureList == null)
				m_CultureList = new CultureList();
			return m_CultureList;
		}

        /// <summary>
        /// Static function that returns the Culture of given culturename
        /// </summary>
        /// <returns>A string with culture</returns>
        /// <param name="cultureName">String value of culturename</param>
        public static string GetCulture(string cultureName)
        {
            if (m_CultureList == null)
                m_CultureList = new CultureList();

            if(m_CultureList.Exists(CultureListItem.ByName(cultureName)))
                return m_CultureList.Find(CultureListItem.ByName(cultureName)).Culture;

            return "";
        }

        /// <summary>
        /// Static function that returns the UICulture of given culturename
        /// </summary>
        /// <returns>A string with uiculture</returns>
        /// <param name="cultureName">String value of culturename</param>
        public static string GetUICulture(string cultureName)
        {
            if (m_CultureList == null)
                m_CultureList = new CultureList();

            if (m_CultureList.Exists(CultureListItem.ByName(cultureName)))
                return m_CultureList.Find(CultureListItem.ByName(cultureName)).UICulture;

            return "";
        }
	}
}
