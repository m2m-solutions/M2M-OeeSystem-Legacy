using System;
using System.Collections;
using System.Linq;
using Csla;

namespace M2M.DataCenter
{
    public class AggregatedOrderData : CollectionBase
    {
        public AggregatedOrderData()
        {
            // default constructor
        }

        public int Add(OrderItem item)
        {
            return List.Add(item);
        }

        public void Remove(OrderItem item)
        {
            List.Remove(item);
        }

        public OrderItem this[int index]
        {
            get
            {
                return ((OrderItem)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        //public void Sort()
        //{
        //    IComparer DateSorter = new AscendingDateSorter();
        //    InnerList.Sort(DateSorter);
        //}

        public class OrderItem
        {
            private SmartDate m_OrderStart = new SmartDate();
            private SmartDate m_FirstAuto = new SmartDate();
            private SmartDate m_OrderStop = new SmartDate();
            private TimeSpan m_NoProductionTime = new TimeSpan(0);
            private TimeSpan m_AutoTime = new TimeSpan(0);
            private TimeSpan m_TotalTime = new TimeSpan(0);
            private TimeSpan m_AssembleTime = new TimeSpan(0);
            private string m_Article = "";
            private int m_ProducedItems = 0;
            
            public OrderItem()
            {
                
            }

            public SmartDate OrderStart
            {
                get
                {
                    return m_OrderStart;
                }
                set
                {
                    m_OrderStart = value;
                }
            }

            public SmartDate FirstAuto
            {
                get
                {
                    return m_FirstAuto;
                }
                set
                {
                    m_FirstAuto = value;
                }
            }

            public SmartDate OrderStop
            {
                get
                {
                    return m_OrderStop;
                }
                set
                {
                    m_OrderStop = value;
                }
            }

            public TimeSpan NoProductionTime
            {
                get
                {
                    return m_NoProductionTime;
                }
                set
                {
                    m_NoProductionTime = value;
                }
            }

            public TimeSpan AutoTime
            {
                get
                {
                    return m_AutoTime;
                }
                set
                {
                    m_AutoTime = value;
                }
            }

            public TimeSpan TotalTime
            {
                get
                {
                    return m_TotalTime;
                }
                set
                {
                    m_TotalTime = value;
                }
            }

            public TimeSpan AssembleTime
            {
                get
                {
                    return m_AssembleTime;
                }
                set
                {
                    m_AssembleTime = value;
                }
            }

            public string Article
            {
                get
                {
                    return m_Article;
                }
                set
                {
                    m_Article = value;
                }
            }

            public int ProducedItems
            {
                get
                {
                    return m_ProducedItems;
                }
                set
                {
                    m_ProducedItems = value;
                }
            }

            public TimeSpan ProducingTime
            {
                get
                {
                    return m_TotalTime - m_NoProductionTime - m_AssembleTime;
                }
            }

            public double RunRate
            {
                get
                {
                    double producingTime = ProducingTime.TotalHours;
                    if(producingTime > 0)
                        return (double)m_ProducedItems/producingTime;

                    return 0;
                }
            }

            public double CycleTime
            {
                get
                {
                    double runRate = RunRate;
                    if (runRate > 0)
                        return (double)3600000 / runRate;

                    return 0;
                }
            }

            public double Availability
            {
                get
                {
                    double producingTime = m_TotalTime.TotalHours - m_NoProductionTime.TotalHours - m_AssembleTime.TotalHours;
                    if (producingTime > 0)
                        return m_AutoTime.TotalHours / producingTime;

                    return 0;
                }
            }
        }
    }
}
