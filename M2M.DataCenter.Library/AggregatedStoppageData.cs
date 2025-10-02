//using System;
//using System.Collections;
//using System.Linq;

//namespace M2M.DataCenter
//{
//    public class AggregatedStoppageData : CollectionBase
//    {
//        public AggregatedStoppageData()
//        {
//            // default constructor
//        }

//        public int Add(StoppageItem item)
//        {
//            return List.Add(item);
//        }

//        public void Remove(StoppageItem item)
//        {
//            List.Remove(item);
//        }

//        public StoppageItem this[int index]
//        {
//            get
//            {
//                return ((StoppageItem)List[index]);
//            }
//            set
//            {
//                List[index] = value;
//            }
//        }

//        public double MaxNumberOfStops
//        {
//            get
//            {
//                double maxValue = 0;
//                foreach (StoppageItem item in this)
//                {
//                    if (item.StopCount > maxValue)
//                        maxValue = item.StopCount;
//                }

//                return maxValue;
//            }
//        }

//        public double MaxStopTime
//        {
//            get
//            {
//                double maxValue = 0;
//                foreach (StoppageItem item in this)
//                {
//                    if (item.IdentifiedStopTimeInSeconds > maxValue)
//                        maxValue = item.IdentifiedStopTimeInSeconds;
//                }

//                return maxValue;
//            }
//        }

//        public double TotalNumberOfStops
//        {
//            get
//            {
//                double total = 0;
//                foreach (StoppageItem item in this)
//                {
//                    total += item.StopCount;
//                }

//                return total;
//            }
//        }

//        public double TotalStopTime
//        {
//            get
//            {
//                double total = 0;
//                foreach (StoppageItem item in this)
//                {
//                    total += item.IdentifiedStopTimeInSeconds;
//                }

//                return total;
//            }
//        }

//        //public void Sort()
//        //{
//        //    IComparer DateSorter = new AscendingDateSorter();
//        //    InnerList.Sort(DateSorter);
//        //}

//        public class StoppageItem
//        {
//            private TimeSpan m_StopTime = new TimeSpan(0);
//            private TimeSpan m_NoProductionTime = new TimeSpan(0);
//            private TimeSpan m_AutoTime = new TimeSpan(0);
//            private TimeSpan m_ScheduledTime = new TimeSpan(0);
//            private double m_StopTimePart = 0;
//            private int m_StopCount = 0;
//            private string m_ReasonText = "";
//            private string m_Category = "";
            
//            public StoppageItem()
//            {

//            }

//            public TimeSpan StopTime
//            {
//                get
//                {
//                    return TotalTime - AutoTime;
//                }
//            }

//            public double StopTimeInMinutes
//            {
//                get { return StopTime.TotalMinutes; }
//            }

//            public double StopTimeInHours
//            {
//                get { return StopTime.TotalHours; }
//            }

//            public double StopTimeInSeconds
//            {
//                get { return StopTime.TotalSeconds; }
//            }

//            public TimeSpan IdentifiedStopTime
//            {
//                get
//                {
//                    return m_StopTime;
//                }
//                set
//                {
//                    m_StopTime = value;
//                }
//            }

//            public double IdentifiedStopTimeInMinutes
//            {
//                get { return IdentifiedStopTime.TotalMinutes; }
//            }

//            public double IdentifiedStopTimeInHours
//            {
//                get { return IdentifiedStopTime.TotalHours; }
//            }

//            public double IdentifiedStopTimeInSeconds
//            {
//                get { return IdentifiedStopTime.TotalSeconds; }
//            }

//            public TimeSpan UnIdentifiedStopTime
//            {
//                get
//                {
//                    return StopTime - IdentifiedStopTime;
//                }
//            }

//            public double UnIdentifiedStopTimeInMinutes
//            {
//                get { return UnIdentifiedStopTime.TotalMinutes; }
//            }

//            public double UnIdentifiedStopTimeInHours
//            {
//                get { return UnIdentifiedStopTime.TotalHours; }
//            }

//            public double UnIdentifiedStopTimeInSeconds
//            {
//                get { return UnIdentifiedStopTime.TotalSeconds; }
//            }

//            public double StopTimePart
//            {
//                get
//                {
//                    return m_StopTimePart;
//                }
//                set
//                {
//                    m_StopTimePart = value;
//                }
//            }

//            public TimeSpan NoProductionTime
//            {
//                get
//                {
//                    return m_NoProductionTime;
//                }
//                set
//                {
//                    m_NoProductionTime = value;
//                }
//            }

//            public double NoProductionTimeInMinutes
//            {
//                get { return NoProductionTime.TotalMinutes; }
//            }

//            public double NoProductionTimeInHours
//            {
//                get { return NoProductionTime.TotalHours; }
//            }

//            public double NoProductionTimeInSeconds
//            {
//                get { return NoProductionTime.TotalSeconds; }
//            }

//            public TimeSpan ScheduledTime
//            {
//                get
//                {
//                    return m_ScheduledTime;
//                }
//                set
//                {
//                    m_ScheduledTime = value;
//                }
//            }

//            public double ScheduledTimeInMinutes
//            {
//                get { return ScheduledTime.TotalMinutes; }
//                }

//            public double ScheduledTimeInHours
//            {
//                get { return ScheduledTime.TotalHours; }
//            }

//            public double ScheduledTimeInSeconds
//            {
//                get { return ScheduledTime.TotalSeconds; }
//            }

//            public TimeSpan TotalTime
//            {
//                get
//                {
//                    return m_ScheduledTime - m_NoProductionTime;
//                }
//            }

//            public double TotalTimeInMinutes
//            {
//                get { return TotalTime.TotalMinutes; }
//            }

//            public double TotalTimeInHours
//                {
//                get { return TotalTime.TotalHours; }
//                }

//            public double TotalTimeInSeconds
//            {
//                get { return TotalTime.TotalSeconds; }
//            }

//            public TimeSpan AutoTime
//            {
//                get
//                {
//                    return m_AutoTime;
//                }
//                set
//                {
//                    m_AutoTime = value;
//                }
//            }

//            public double AutoTimeInMinutes
//            {
//                get { return AutoTime.TotalMinutes; }
//            }

//            public double AutoTimeInHours
//                {
//                get { return AutoTime.TotalHours; }
//            }

//            public double AutoTimeInSeconds
//            {
//                get { return AutoTime.TotalSeconds; }
//            }

//            public double AverageStopTimeInMinutes
//                    {
//                get { return IdentifiedStopTimeInMinutes / StopCount; }
//                    }

//            public double AverageStopTimeInHours
//            {
//                get { return IdentifiedStopTimeInHours / StopCount; }
//                }

//            public double AverageStopTimeInSeconds
//            {
//                get { return IdentifiedStopTimeInSeconds / StopCount; }
//            }

//            public double StopCount
//            {
//                get
//                {
//                    return (double)m_StopCount;
//                }
//                set
//                {
//                    m_StopCount = (int)value;
//                }
//            }

//            public string ReasonText
//            {
//                get
//                {
//                    return m_ReasonText;
//                }
//                set
//                {
//                    m_ReasonText = value;
//                }
//            }

//            public string Category
//            {
//                get
//                {
//                    return m_Category;
//                }
//                set
//                {
//                    m_Category = value;
//                }
//            }

//            public string XLabel
//            {
//                get
//                {
//                    return m_ReasonText;
//                }
//            }
//        }

//        //private class AscendingDateSorter : IComparer
//        //{
//        //    public int Compare(Object x, Object y)
//        //    {
//        //        AggregatedStoppageData.StoppageItem item1 = (AggregatedStoppageData.StoppageItem)x;
//        //        IComparable ic1 = (IComparable)item1.Date;

//        //        AggregatedStoppageData.StoppageItem item2 = (AggregatedStoppageData.StoppageItem)y;
//        //        IComparable ic2 = (IComparable)item2.Date;

//        //        return ic1.CompareTo(ic2);
//        //    }
//        //}
//    }
//}
