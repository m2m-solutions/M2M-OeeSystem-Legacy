using System;
using System.Linq;
using Csla;

namespace M2M.DataCenter.Batch.Report
{


    [Serializable()]
    public class BatchData : ReadOnlyBase<BatchData>
    {
        #region Business methods

        private string m_Division = "";
        private string m_Machine = "";
        private string m_BatchNumber = "";
        private DateTime m_PeriodStart;
        private BatchEventList m_EventList = null;

        public string Division
        {
            get { return m_Division; }
        }

        public string Machine
        {
            get { return m_Machine; }
        }

        public string BatchNumber
        {
            get { return m_BatchNumber; }
        }

        public DateTime PeriodStart
        {
            get { return m_PeriodStart; }
        }

        public BatchEventList Events
        {
            get { return m_EventList; }
        }

        public AggregatedBatchData GetEventList()
        {
            AggregatedBatchData batchData = new AggregatedBatchData();

            if (m_EventList.Count > 0)
            {
                foreach (BatchEventListItem eventListItem in m_EventList)
                {
                    AggregatedBatchData.BatchItem batchItem = new AggregatedBatchData.BatchItem();

                    batchItem.BatchNumber = eventListItem.BatchNumber;
                    batchItem.EventRaised = eventListItem.EventRaised;
                    batchItem.EventName = eventListItem.EventName;
                    batchItem.EventType = eventListItem.EventType;
                    
                    batchData.Add(batchItem);
                }
            }

            return batchData;
        }

        

        protected override object GetIdValue()
        {
            return m_BatchNumber;
        }

        #endregion

        #region Constructors

        public BatchData(string batchNumber, int prevCount)
        {
            BatchEventList.Criteria criteria = new BatchEventList.Criteria();
            criteria.BatchNumber = batchNumber;
            criteria.PrevCount = prevCount;
            
            m_EventList = BatchEventList.GetEventList(criteria);

            m_BatchNumber = batchNumber;

            int count = m_EventList.Count;

            if (count > 0)
            {
                m_Machine = m_EventList[count-1].MachineId;
                m_PeriodStart = m_EventList[0].EventRaisedAsDateTime;
            }
        }

        #endregion
    }
}
