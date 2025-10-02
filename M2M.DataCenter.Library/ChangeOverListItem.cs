using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class ChangeOverListItem : ReadOnlyBase<ChangeOverListItem>
    {
        #region Business Methods

        private long m_Id = 0;
        private string m_MachineId = String.Empty;
        private string m_ArticleNumber = String.Empty;
        private string m_PreviousArticle = String.Empty;
        private SmartDate m_StartTime = new SmartDate();
        private SmartDate m_EndTime = new SmartDate();
        private SmartDate m_ChangeOverStartTime = new SmartDate();
        private SmartDate m_ChangeOverEndTime = new SmartDate();
        private TimeSpan m_ElapsedTime = new TimeSpan(0);
        private bool m_CountThis = false;
        
        public long Id
        {
            get
            {
                return m_Id;
            }
        }

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

        public string PreviousArticle
        {
            get
            {
                return m_PreviousArticle;
            }
        }

        public SmartDate StartTime
        {
            get
            {
                return m_StartTime;
            }
        }

        public SmartDate EndTime
        {
            get
            {
                return m_EndTime;
            }
        }

        public SmartDate ChangeOverStartTime
        {
            get
            {
                return m_ChangeOverStartTime;
            }
        }

        public SmartDate ChangeOverEndTime
        {
            get
            {
                return m_ChangeOverEndTime;
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                return m_ElapsedTime;
            }
        }

        public bool CountThis
        {
            get
            {
                return m_CountThis;
            }
        }

        public double ElapsedTimeInMinutes { get { return ElapsedTime.TotalMinutes; } }

        protected override object GetIdValue()
        {
            return m_Id;
        }
        #endregion

        #region Factory Methods

        internal static ChangeOverListItem GetChangeOverListItem(SafeDataReader dr, TimeSpan productionTime)
        {
            return new ChangeOverListItem(dr, productionTime);
        }

        private ChangeOverListItem()
        {
            /* require use of factory methods */
        }

        private ChangeOverListItem(SafeDataReader dr, TimeSpan productionTime)
        {
            Fetch(dr, productionTime);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr, TimeSpan productionTime)
        {
            m_Id = dr.GetInt64("Id");
            m_MachineId = dr.GetString("MachineId");
            m_ArticleNumber = dr.GetString("Article");
            m_PreviousArticle = dr.GetString("PreviousArticle");
            m_StartTime = dr.GetSmartDate("StartTime");
            m_EndTime = dr.GetSmartDate("EndTime");
            m_ChangeOverStartTime = dr.GetSmartDate("ChangeOverStart");
            m_ChangeOverEndTime = dr.GetSmartDate("ChangeOverEnd");
            m_ElapsedTime = productionTime;
            m_CountThis = dr.GetBoolean("CountThis");
        }

        
        #endregion
    }
}