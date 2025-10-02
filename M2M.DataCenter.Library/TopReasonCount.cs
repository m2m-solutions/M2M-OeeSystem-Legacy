//using System;
//using System.Linq;
//using M2M.DataCenter.Localization;

//namespace M2M.DataCenter
//{
//    public class TopReasonCount
//    {
//        private StoppageList m_StoppageList = null;

//        public TopReasonCount(StoppageList.Criteria stoppageCriteria)
//        {
//            m_StoppageList = StoppageList.GetStoppageList(stoppageCriteria);
//        }

//        public AggregatedStoppageData GetTopStopTimes(int groupCount)
//        {
//            AggregatedStoppageData stoppageData = new AggregatedStoppageData();

//            var grouped = m_StoppageList.GroupBy(a => new { a.MachineId, a.DisplayName });

//            var orderedGroup = grouped.OrderByDescending(g => g.Sum(a => a.ElapsedTime.TotalSeconds)).Take(groupCount);

//            int totalStopCount = 0;
//            double totalStopTime = 0;

//            foreach (var group in orderedGroup)
//            {
//                AggregatedStoppageData.StoppageItem item = new AggregatedStoppageData.StoppageItem();
//                item.ReasonText = group.First().DisplayName;
//                double stopTime = group.Sum(a => a.ElapsedTime.TotalSeconds);
//                item.IdentifiedStopTime = new TimeSpan(0, 0, (int)stopTime);
//                item.StopCount = group.Count();
//                totalStopCount += (int)item.StopCount;
//                totalStopTime += stopTime;

//                stoppageData.Add(item);
//            }

//            double otherStopTime = m_StoppageList.Sum(t => t.ElapsedTime.TotalSeconds) - totalStopTime;
//            int otherStopCount = m_StoppageList.Count() - totalStopCount;

//            if ((int)otherStopTime > 0)
//            {
//                AggregatedStoppageData.StoppageItem item = new AggregatedStoppageData.StoppageItem();
//                item.ReasonText = ResourceStrings.GetString("Other");
//                item.IdentifiedStopTime = new TimeSpan(0, 0, (int)otherStopTime);
//                item.StopCount = otherStopCount;
//                stoppageData.Add(item);
//            }

//            return stoppageData;
//        }

//        public AggregatedStoppageData GetTopStopCounts(int groupCount)
//        {
//            AggregatedStoppageData stoppageData = new AggregatedStoppageData();

//            var grouped = m_StoppageList.GroupBy(a => new { a.MachineId, a.DisplayName });

//            var orderedGroup = grouped.OrderByDescending(g => g.Count()).Take(groupCount);

//            int totalStopCount = 0;
//            double totalStopTime = 0;

//            foreach (var group in orderedGroup)
//            {
//                AggregatedStoppageData.StoppageItem item = new AggregatedStoppageData.StoppageItem();
//                item.ReasonText = group.First().DisplayName;
//                double stopTime = group.Sum(a => a.ElapsedTime.TotalSeconds);
//                item.IdentifiedStopTime = new TimeSpan(0, 0, (int)stopTime);
//                item.StopCount = group.Count();
//                totalStopCount += (int)item.StopCount;
//                totalStopTime += stopTime;

//                stoppageData.Add(item);
//            }

//            int otherStopCount = m_StoppageList.Count() - totalStopCount;
//            double otherStopTime = m_StoppageList.Sum(t => t.ElapsedTime.TotalSeconds) - totalStopTime;

//            if (otherStopCount > 0)
//            {
//                AggregatedStoppageData.StoppageItem item = new AggregatedStoppageData.StoppageItem();
//                item.ReasonText = "Övriga";
//                item.IdentifiedStopTime = new TimeSpan(0, 0, (int)otherStopTime);
//                item.StopCount = otherStopCount;
//                stoppageData.Add(item);
//            }

//            return stoppageData;
//        }
//    }
//}
