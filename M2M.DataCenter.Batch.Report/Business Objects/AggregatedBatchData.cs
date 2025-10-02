using System;
using System.Collections;
using System.Linq;
using Csla;

namespace M2M.DataCenter.Batch.Report
{
    public class AggregatedBatchData : CollectionBase
    {
        public AggregatedBatchData()
        {
            // default constructor
        }

        public int Add(BatchItem item)
        {
            return List.Add(item);
        }

        public void Remove(BatchItem item)
        {
            List.Remove(item);
        }

        public BatchItem this[int index]
        {
            get
            {
                return ((BatchItem)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public class BatchItem
        {
            private string m_BatchNumber = "";
            private SmartDate m_EventRaised = new SmartDate();
            private string m_EventName = "";
            private string m_EventType = "";

            public BatchItem()
            {
                
            }

            public SmartDate EventRaised
            {
                get
                {
                    return m_EventRaised;
                }
                set
                {
                    m_EventRaised = value;
                }
            }

            public string BatchNumber
            {
                get
                {
                    return m_BatchNumber;
                }
                set
                {
                    m_BatchNumber = value;
                }
            }

            public string EventName
            {
                get
                {
                    return m_EventName;
                }
                set
                {
                    m_EventName = value;
                }
            }

            public string EventType
            {
                get
                {
                    return m_EventType;
                }
                set
                {
                    m_EventType = value;
                }
            }
        }
    }
}
