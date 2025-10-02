using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class EventListItem : ReadOnlyBase<EventListItem>
    {
        #region Business Methods

        private Guid m_EventId = Guid.NewGuid();
        private string m_DivisionId = String.Empty;
        private string m_MachineId = String.Empty;
        private string m_ArticleNumber = String.Empty;
        private SmartDate m_EventRaised = new SmartDate();
        private SmartDate m_TimeForNextEvent = new SmartDate();
        private int m_CurrentNumberOfItems = 0;
        private int m_RunRate = 0;
        private string m_ReasonDisplayName = "";
        private string m_TagInfoDisplayName = "";
        private TagType m_TagType = TagType.NotApplicable;
        private int m_TagInfoCategoryId = -1;
        private int m_ReasonCategoryId = -1;

        public Guid EventId
        {
            get
            {
                return m_EventId;
            }
        }

        public string DivisionId
        {
            get
            {
                return m_DivisionId;
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

        public int RunRate
        {
            get
            {
                return m_RunRate;
            }
        }

        public string PaceAsString
        {
            get
            {
                string result = "";

                if (m_RunRate > 0)
                    result = String.Format("{0} / tim", 3600 * 1000 / m_RunRate);

                return result;
            }
        }

        public int CurrentNumberOfItems
        {
            get
            {
                return m_CurrentNumberOfItems;
            }
        }

        public SmartDate EventRaised
        {
            get
            {
                return m_EventRaised;
            }
        }

        public DateTime EventRaisedAsDateTime
        {
            get
            {
                return m_EventRaised.Date;
            }
        }

        public SmartDate TimeForNextEvent
        {
            get
            {
                return m_TimeForNextEvent;
            }
        }

        public DateTime TimeForNextEventAsDateTime
        {
            get
            {
                return m_TimeForNextEvent.Date;
            }
        }

        public string DisplayName
        {
            get
            {
                if (m_ReasonDisplayName != "")
                    return m_ReasonDisplayName;//return String.Format("{0} - {1}", m_TagInfoDisplayName, m_ReasonDisplayName);

                return m_TagInfoDisplayName;
            }
        }

        public string ReasonDisplayName
        {
            get
            {
                return m_ReasonDisplayName;
            }
        }

        public string TagInfoDisplayName
        {
            get
            {
                return m_TagInfoDisplayName;
            }
        }

        public TagType TagType
        {
            get
            {
                return m_TagType;
            }
        }

        public int CategoryId
        {
            get
            {
                if (m_ReasonCategoryId > 0)
                    return m_ReasonCategoryId;

                return m_TagInfoCategoryId;
            }
        }

        public string Category
        {
            get
            {
                if (m_TagType == TagType.Stop || m_TagType == TagType.MainAlarm || m_TagType == TagType.UnidentifiedStop)
                {
                    return M2MDataCenter.GetCategoryDisplayName(CategoryId);
                }
                return "";
            }
        }

        public bool Complete
        {
            get
            {
                return !m_TimeForNextEvent.IsEmpty;
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                if (!Complete)
                    return DateTime.Now.Subtract(m_EventRaised.Date);

                return m_TimeForNextEvent.Date.Subtract(m_EventRaised.Date);
            }
        }

        protected override object GetIdValue()
        {
            return m_EventId;
        }
        #endregion

        #region Factory Methods

        internal static EventListItem GetEventListItem(SafeDataReader dr)
        {
            return new EventListItem(dr);
        }

        private EventListItem()
        {
            /* require use of factory methods */
        }

        private EventListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_EventId = dr.GetGuid("EventId");
            m_DivisionId = dr.GetString("DivisionId");
            m_MachineId = dr.GetString("MachineId");
            m_ArticleNumber = dr.GetString("ArticleNumber");
            m_EventRaised = dr.GetSmartDate("EventRaised");
            m_TimeForNextEvent = dr.GetSmartDate("TimeForNextEvent");
            m_CurrentNumberOfItems = dr.GetInt32("CurrentNumberOfItems");
            m_RunRate = dr.GetInt32("RunRate");
            m_TagType = (TagType)dr.GetInt32("TagType");
            m_TagInfoCategoryId = dr.GetInt32("TagInfoCategoryId");
            m_ReasonCategoryId = dr.GetInt32("ReasonCategoryId");
            m_ReasonDisplayName = dr.GetString("ReasonDisplayName");
            m_TagInfoDisplayName = dr.GetString("TagInfoDisplayName");
        }

        #endregion
    }
}