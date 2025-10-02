using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class ArticleSettingListItem : ReadOnlyBase<ArticleSettingListItem>
	{
		#region Business Methods

		private string m_MachineId = String.Empty;
		private string m_ArticleNumber = String.Empty;
		private string m_Setting = String.Empty;
		private string m_Value = String.Empty;
		private SmartDate m_LastModified = new SmartDate();

		public string MachineId
		{
			get
			{
				return m_MachineId;
			}
		}

		public string ArticleNumber
		{
			get
			{
				return m_ArticleNumber;
			}
		}

		public string Setting
		{
			get
			{
				return m_Setting;
			}
		}

		public string Value
		{
			get
			{
				return m_Value;
			}
		}

		public SmartDate LastModified
		{
			get
			{
				return m_LastModified;
			}
		}

		protected override object GetIdValue()
		{
			return String.Format("{0}|{1}", m_MachineId, m_Setting);
		}

		//public string MachineDescription
		//{
		//    get
		//    {
		//        CanReadProperty("MachineDescription", true);
		//        return MachineList.GetMachineDescription(m_MachineId);
		//    }
		//}

		#endregion

		#region Factory Methods

		internal static ArticleSettingListItem GetArticleSettingListItem(SafeDataReader dr)
		{
			return new ArticleSettingListItem(dr);
		}

		private ArticleSettingListItem()
		{
			/* require use of factory methods */
		}

		private ArticleSettingListItem(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dr)
		{
			m_MachineId = dr.GetString("MachineId");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_Setting = dr.GetString("Setting");
			m_Value = dr.GetString("Value");
			m_LastModified = dr.GetSmartDate("LastModified");
		}

		#endregion
	}
}