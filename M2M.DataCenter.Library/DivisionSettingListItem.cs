using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class DivisionSettingListItem : ReadOnlyBase<DivisionSettingListItem>
    {
        #region Business Methods

        private string m_DivisionId = String.Empty;
        private string m_Setting = String.Empty;
        private string m_Value = String.Empty;
		private SmartDate m_LastModified = new SmartDate();
	
        public string DivisionId
        {
            get
            {
                return m_DivisionId;
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
            return String.Format("{0}|{1}", m_DivisionId,m_Setting);
        }

        //public string DivisionDescription
        //{
        //    get
        //    {
        //        CanReadProperty("DivisionDescription", true);
        //        return DivisionList.GetDivisionDescription(m_DivisionId);
        //    }
        //}

        #endregion

        #region Factory Methods

        internal static DivisionSettingListItem GetDivisionSettingListItem(SafeDataReader dr)
        {
            return new DivisionSettingListItem(dr);
        }

        private DivisionSettingListItem()
        {
            /* require use of factory methods */
        }

        private DivisionSettingListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_DivisionId = dr.GetString("DivisionId");
            m_Setting = dr.GetString("Setting");
            m_Value = dr.GetString("Value");
			m_LastModified = dr.GetSmartDate("LastModified");
        }

        #endregion
    }
}