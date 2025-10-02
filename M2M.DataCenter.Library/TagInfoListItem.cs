using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class TagInfoListItem : ReadOnlyBase<TagInfoListItem>
	{
		#region Business Methods

		private string m_TagId = String.Empty;
		private string m_MachineId = String.Empty;
        private string m_DisplayName = String.Empty;
        private int m_ReasonCode = 0;
		private string m_Description = String.Empty;
		private string m_Address = String.Empty;
		private int m_DataType = 0;
		private TagType m_TagType = TagType.NotApplicable;
        private bool m_Inverted = false;
        private bool m_SendPanelRequest = false;
        private int m_RequestDelay = 0;
        private int m_CategoryId = 0;
		
		public string TagId
		{
			get
			{
				return m_TagId;
			}
		}

		public string TagName
		{
			get
			{
				return m_TagId.Substring(m_TagId.LastIndexOf('.') + 1);
			}
		}

		public string MachineId
		{
			get
			{
				return m_MachineId;
			}
		}

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
            }
        }

		public int ReasonCode
		{
			get
			{
				return m_ReasonCode;
			}
		}

        public int CategoryId
        {
            get
            {
                return m_CategoryId;
            }
        }

		public string Description
		{
			get
			{
				return m_Description;
			}
		}

		public string Address
		{
			get
			{
				return m_Address;
			}
		}

		public int DataType
		{
			get
			{
				return m_DataType;
			}
		}

		public TagType TagType
		{
			get
			{
				return m_TagType;
			}
		}

		public bool Inverted
		{
			get
			{
				return m_Inverted;
			}
		}

        public bool SendPanelRequest
        {
            get
            {
                return m_SendPanelRequest;
            }
        }

        public int RequestDelay
        {
            get
            {
                return m_RequestDelay;
            }
        }

		protected override object GetIdValue()
		{
			return m_TagId;
		}

		#endregion

		#region Factory Methods

		internal static TagInfoListItem GetTagInfoListItem(SafeDataReader dr)
		{
			return new TagInfoListItem(dr);
		}

		private TagInfoListItem()
		{
			/* require use of factory methods */
		}

		private TagInfoListItem(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dr)
		{
			m_TagId = dr.GetString("TagId");
			m_MachineId = dr.GetString("MachineId");
			m_DisplayName = dr.GetString("DisplayName");
            m_ReasonCode = dr.GetInt32("ReasonCode");
			m_Description = dr.GetString("Description");
			m_TagType = (TagType)dr.GetInt32("TagType");
			m_Inverted = dr.GetBoolean("Inverted");
			m_Address = dr.GetString("Address");
			m_DataType = dr.GetInt32("DataType");
			m_CategoryId = dr.GetInt32("CategoryId");
            m_SendPanelRequest = dr.GetBoolean("SendPanelRequest");
            m_RequestDelay = dr.GetInt32("RequestDelay");
		}

		#endregion
	}
}
