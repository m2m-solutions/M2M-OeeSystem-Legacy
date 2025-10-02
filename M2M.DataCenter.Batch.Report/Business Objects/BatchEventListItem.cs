using System;
using Csla;
using Csla.Data;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Batch.Report
{
    [Serializable()]
    public class BatchEventListItem : ReadOnlyBase<BatchEventListItem>
    {
        #region Business Methods

        private Guid m_EventId = Guid.NewGuid();
        private string m_BatchNumber = String.Empty;
        private SmartDate m_EventRaised = new SmartDate();
        private SmartDate m_TimeForNextEvent = new SmartDate();
        private string m_EventName = String.Empty;
        private string m_EventType = String.Empty;
        private string m_MachineId = String.Empty;

        public Guid EventId
        {
            get
            {
                return m_EventId;
            }
        }

        public string BatchNumber
        {
            get
            {
                return m_BatchNumber;
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
                if (m_TimeForNextEvent.IsEmpty)
                    return m_EventRaised.Date;

                return m_TimeForNextEvent.Date;
            }
        }

        public string EventName
        {
            get
            {
                return m_EventName;
            }
        }

        public string EventType
        {
            get
            {
                return m_EventType;
            }
        }

        public string MachineId
        {
            get
            {
                return m_MachineId;
            }
        }

        protected override object GetIdValue()
        {
            return m_EventId;
        }
        #endregion

        #region Factory Methods

        internal static BatchEventListItem GetEventListItem(SafeDataReader dr)
        {
            return new BatchEventListItem(dr);
        }

        private BatchEventListItem()
        {
            /* require use of factory methods */
        }

        private BatchEventListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_EventId = dr.GetGuid("EventId");
            m_MachineId = dr.GetString("MachineId");
            m_BatchNumber = dr.GetString("ArticleNumber");
            m_EventName = dr.GetString("TagInfoDisplayName");
            m_EventRaised = dr.GetSmartDate("EventRaised");
            m_TimeForNextEvent = dr.GetSmartDate("TimeForNextEvent");
            m_EventType = GetEventType((TagType)dr.GetInt32("TagType"));
        }

        private string GetEventType(TagType tagType)
        {
            switch (tagType)
            {
                case TagType.Stop:
                case TagType.MainAlarm:
                case TagType.Informational:
                    return ResourceStrings.GetString(tagType);
                default:
                    return ResourceStrings.GetString(TagType.Informational);
            }
        }

        #endregion
    }
}