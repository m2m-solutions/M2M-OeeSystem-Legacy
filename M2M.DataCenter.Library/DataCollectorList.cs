using System;
using System.Collections.Generic;

namespace M2M.DataCenter
{
	/// <summary>
	/// DataCollectorList list item
	/// </summary>
	public struct DataCollectorListItem
	{
		string m_Name;
		string m_Value;

		/// <summary>
		/// Name of data collector
		/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// Service name for DataCollector
		/// </summary>
		public string Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}

		/// <summary>
		/// Creates a DataCollectorListItem
		/// </summary>
		/// <param name="name">Name of DataCollector</param>
		/// <param name="value">String value of DataCollector</param>
		public DataCollectorListItem(string name, string value)
		{
			m_Name = name;
			m_Value = value;
		}
	}

	/// <summary>
	/// Encapsulates a list of application supported data collectors
	/// </summary>
	public class DataCollectorList: List<DataCollectorListItem>
	{
		private static DataCollectorList m_DataCollectorList = null;

		private DataCollectorList()
		{
            this.Add(new DataCollectorListItem("M2M DataCollector", "M2M.DataCollector"));
   		}

		/// <summary>
		/// Static function that returns the list of supported data dollectors for use in a GUI list
		/// </summary>
		/// <returns>A List&lt;DataCollectorListItem> with supported data collectors</returns>
		public static DataCollectorList GetDataCollectorList()
		{
			if (m_DataCollectorList == null)
				m_DataCollectorList = new DataCollectorList();
			return m_DataCollectorList;
		}
			
	}
}
