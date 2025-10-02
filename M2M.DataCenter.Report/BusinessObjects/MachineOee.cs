using System;
using System.Collections.Generic;
using System.Linq;
using Csla;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    [Serializable()]
    public class MachineOee : ReadOnlyBase<MachineOee>
    {
        #region Business methods

        private readonly int m_GroupingId = 0;
        private readonly string m_DivisionId = "";
        private readonly string m_MachineId = "";
        private readonly string m_Shift = "";
        private readonly DateTime m_PeriodStart;
        private readonly DateTime m_PeriodEnd;
        private readonly OeeDataList m_OeeList = null;
        private readonly List<int> m_Categories = null;
        
        private readonly bool m_AggregateData = false;
        
        public int GroupingId
        {
            get { return m_GroupingId; }
        }

        public string GroupingName
        {
            get
            {
                GroupingListItem grouping = M2MDataCenter.GetGrouping(m_GroupingId);
                if (grouping == null)
                    return "";
                return grouping.DisplayName;
            }
        }

        public string DivisionId
        {
            get { return m_DivisionId; }
        }

        public string MachineId
        {
            get { return m_MachineId; }
        }

        public string Division
        {
            get
            {
                if (DivisionId == null)
                    return "";
                return M2MDataCenter.GetDivision(DivisionId).DisplayName;
            }
        }

        public string Machine
        {
            get
            {
                if (DivisionId == null || MachineId == null)
                    return "";
                return M2MDataCenter.GetMachine(DivisionId, MachineId).DisplayName;
            }
        }

        public string Shift
        {
            get { return m_Shift; }
        }

        public DateTime PeriodStart
        {
            get { return m_PeriodStart; }
        }

        public DateTime PeriodEnd
        {
            get { return m_PeriodEnd; }
        }

        private TimeSpan Period
        {
            get { return m_PeriodEnd.Subtract(m_PeriodStart); }
        }

        public string Week
        {
            get { return String.Format("{0}. {1}", ResourceStrings.GetString("#-Week.Abbr"), m_PeriodStart.GetWeek()); }
        }

        public string Categories
        {
            get { return m_Categories.Count == M2MDataCenter.GetAvailableCategories().Count ? ResourceStrings.GetString("All") : ResourceStrings.GetString("Selected"); }
        }

        public List<AggregatedOeeDataItem> GetTotalData()
        {
            List<AggregatedOeeDataItem> oeeData = m_OeeList.GetTotalData(m_AggregateData);

            return oeeData;
        }

        public List<AggregatedOeeDataItem> GetPeriodicData(Intervals interval)
        {
            return m_OeeList.GetPeriodicData(interval, m_AggregateData);
        }

        public AggregatedOeeDataItem GetMachineData(string machineId)
        {
            AggregatedOeeDataItem oeeData = m_OeeList.GetMachineData(machineId);
           
            return oeeData;
        }

        public List<AggregatedOeeDataItem> GetDataForAllMachines()
        {
            List<AggregatedOeeDataItem> oeeData = new List<AggregatedOeeDataItem>();

            // If this function is called when no division is given, just return empty data list
            if(m_DivisionId == null)
                return oeeData;

            PlainMachineList machines = M2MDataCenter.GetMachineList(m_DivisionId);

            foreach (PlainMachineListItem machine in machines)
            {
                AggregatedOeeDataItem machineData = GetMachineData(machine.MachineId);
                machineData.NotScheduledTime = this.Period.Subtract(machineData.ScheduledTime);
                machineData.MachineShortName = machine.ShortName;
                oeeData.Add(machineData);
            }

            return oeeData;
        }

        public AggregatedOeeDataItem GetDivisionData(string divisionId)
        {
            AggregatedOeeDataItem oeeData = m_OeeList.GetDivisionData(divisionId, m_AggregateData);

            return oeeData;
        }

        public List<AggregatedOeeDataItem> GetDataForAllDivisions()
        {
            List<AggregatedOeeDataItem> oeeData = new List<AggregatedOeeDataItem>();

            PlainDivisionList divisions = M2MDataCenter.GetDivisionList();

            foreach (PlainDivisionListItem division in divisions)
            {
                if (m_GroupingId > 0 && m_GroupingId != division.GroupingId)
                    continue;

                double numberOfMachines = division.Machines.Where(a => a.AggregateAvailability == true).Count();
                AggregatedOeeDataItem divisionData = GetDivisionData(division.DivisionId);
                divisionData.ScheduledTime = TimeSpan.FromSeconds(divisionData.ScheduledTime.TotalSeconds / numberOfMachines);
                divisionData.AutoTime = TimeSpan.FromSeconds(divisionData.AutoTime.TotalSeconds / numberOfMachines);
                divisionData.NoProductionTime = TimeSpan.FromSeconds(divisionData.NoProductionTime.TotalSeconds / numberOfMachines);
                divisionData.NotConnectedTime = TimeSpan.FromSeconds(divisionData.NotConnectedTime.TotalSeconds / numberOfMachines);
                divisionData.NotScheduledTime = this.Period.Subtract(divisionData.ScheduledTime);
                oeeData.Add(divisionData);
            }

            return oeeData;
        }

        public List<AggregatedOeeDataItem> GetArticleData(string machineId)
        {
            return m_OeeList.GetArticleData(machineId);
        }

        #region Obsolete
        //public List<AggregatedOeeDataItem> GetMachineData()
        //{
        //    List<AggregatedOeeDataItem> oeeData = new List<AggregatedOeeDataItem>();

        //    var grouped = m_OeeList.OrderBy(a => a.MachineId).GroupBy(a => a.MachineId);

        //    foreach (var group in grouped)
        //    {
        //        double totalAutoTime = group.Sum(a => a.AutoTime);
        //        double totalScheduledTime = group.Sum(a => a.TotalTime);

        //        double totalNoProductionTime = group.Sum(a => a.NoProductionTime);
        //        double totalNotConnectedTime = group.Sum(a => a.NotConnectedTime);
        //        int totalProducedItems = group.Sum(a => a.ProducedItems);
        //        int totalDiscardedItems = group.Sum(a => a.DiscardedItems);
        //        double totalStopTime = group.Sum(a => a.StopTime);
        //        double totalActualStopTime = group.Sum(a => a.ActualStopTime);
        //        double totalFlowErrorTime = group.Sum(a => a.FlowErrorTime);
        //        double totalProductionTime = group.Sum(a => a.ProductionTime);

        //        AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
        //        timePart.XType = XTypes.Machine;
        //        timePart.MachineId = group.Key;
        //        timePart.Machine = M2MDataCenter.GetMachine(group.Key).DisplayName;
        //        timePart.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
        //        timePart.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
        //        timePart.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
        //        timePart.NotConnectedTime = TimeSpan.FromSeconds(totalNotConnectedTime);
        //        timePart.FlowErrorTime = TimeSpan.FromSeconds(totalFlowErrorTime);
        //        timePart.Produced = totalProducedItems;
        //        timePart.Discarded = totalDiscardedItems;

        //        if (totalProductionTime > 0)
        //        {
        //            timePart.Availability = totalAutoTime / totalProductionTime;
        //            timePart.AvailabilityLoss = totalStopTime / totalProductionTime;
        //            timePart.AvailabilityLossBasedOnActualStops = totalActualStopTime / totalProductionTime;
        //            timePart.AvailabilityLossBasedOnFlowErrors = totalFlowErrorTime / totalProductionTime;
        //        }

        //        if (totalProducedItems > 0)
        //            timePart.Quality = 1.0 - (double)totalDiscardedItems / (double)totalProducedItems;

        //        if (totalAutoTime > 0)
        //        {
        //            timePart.Performance = 0;

        //            foreach (var item in group)
        //            {
        //                double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

        //                if (idealRunRate != null && item.RunRate != 0)
        //                {
        //                    timePart.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTime);
        //                }
        //            }
        //        }

        //        if (m_PreviousOee != null)
        //        {
        //            AggregatedOeeDataItem prevOeeData = m_PreviousOee.GetMachineData(group.Key);

        //            timePart.PreviousOeeData = prevOeeData;
        //        }

        //        oeeData.Add(timePart);
        //    }

        //    return oeeData;
        //}

        //public List<AggregatedOeeDataItem> GetDivisionData()
        //{
        //    List<AggregatedOeeDataItem> oeeData = new List<AggregatedOeeDataItem>();

        //    var grouped = m_OeeList.OrderBy(a => a.DivisionId).GroupBy(a => a.DivisionId);

        //    foreach (var group in grouped)
        //    {
        //        string divisionId = group.Key;
        //        double totalAutoTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.AutoTime) : group.Sum(a => a.AutoTime);
        //        double totalAutoTimeForPerformance = m_AggregateData ? group.Where(a => a.AggregatePerformance).Sum(a => a.AutoTime) : group.Sum(a => a.AutoTime);
        //        double totalScheduledTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.TotalTime) : group.Sum(a => a.TotalTime);
        //        //double totalNotScheduledTime = (double)numberOfMachines * this.Period;
        //        double totalNoProductionTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.NoProductionTime) : group.Sum(a => a.NoProductionTime);
        //        double totalNotConnectedTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.NotConnectedTime) : group.Sum(a => a.NotConnectedTime);
        //        int totalProducedItems = m_AggregateData ? group.Where(a => a.AggregateCounter).Sum(a => a.ProducedItems) : group.Sum(a => a.ProducedItems);
        //        int totalDiscardedItems = group.Sum(a => a.DiscardedItems);
        //        double totalStopTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.StopTime) : group.Sum(a => a.StopTime);
        //        double totalActualStopTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.ActualStopTime) : group.Sum(a => a.ActualStopTime);
        //        double totalFlowErrorTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.FlowErrorTime) : group.Sum(a => a.FlowErrorTime);
        //        double totalProductionTime = m_AggregateData ? group.Where(a => a.AggregateAvailability).Sum(a => a.ProductionTime) : group.Sum(a => a.ProductionTime);
                

        //        AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
        //        timePart.XType = XTypes.Division;
        //        timePart.DivisionId = divisionId;
        //        timePart.Division = M2MDataCenter.GetDivision(divisionId).DisplayName;
        //        timePart.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
        //        timePart.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
        //        //timePart.NotScheduledTime = TimeSpan.FromSeconds(totalNotScheduledTime);
        //        timePart.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
        //        timePart.NotConnectedTime = TimeSpan.FromSeconds(totalNotConnectedTime);
        //        timePart.FlowErrorTime = TimeSpan.FromSeconds(totalFlowErrorTime);
        //        timePart.Produced = totalProducedItems;
        //        timePart.Discarded = totalDiscardedItems;

        //        if (totalProductionTime > 0)
        //        {
        //            timePart.Availability = totalAutoTime / totalProductionTime;
        //            timePart.AvailabilityLoss = totalStopTime / totalProductionTime;
        //            timePart.AvailabilityLossBasedOnActualStops = totalActualStopTime / totalProductionTime;
        //            timePart.AvailabilityLossBasedOnFlowErrors = totalFlowErrorTime / totalProductionTime;
        //        }

        //        if (totalProducedItems > 0)
        //            timePart.Quality = 1.0 - (double)totalDiscardedItems / (double)totalProducedItems;

        //        if (totalAutoTimeForPerformance > 0)
        //        {
        //            timePart.Performance = 0;

        //            foreach (var item in group)
        //            {
        //                if (m_AggregateData && !item.AggregatePerformance)
        //                    continue;

        //                double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

        //                if (idealRunRate != null && item.RunRate != 0)
        //                {
        //                    timePart.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTimeForPerformance);
        //                }
        //            }
        //        }

        //        if (m_PreviousOee != null)
        //        {
        //            AggregatedOeeDataItem prevOeeData = m_PreviousOee.GetDivisionData(group.Key);

        //            timePart.PreviousOeeData = prevOeeData;
        //        }

        //        oeeData.Add(timePart);
        //    }

        //    return oeeData;
        //}
        #endregion

        protected override object GetIdValue()
        {
            return m_GroupingId.ToString() + " " + m_DivisionId + " " + m_MachineId;
        }

        #endregion

        #region Constructors


        public MachineOee(int groupingId, string divisionId, string machineId, int shift, DateTime startDate, DateTime endDate, List<int> categories)
        {
            m_GroupingId = groupingId;
            m_DivisionId = divisionId;
            m_MachineId = machineId;
            m_PeriodStart = startDate;
            m_PeriodEnd = endDate;
            m_Shift = M2MDataCenter.GetShiftName(shift);
            m_Categories = categories;
            
            m_AggregateData = (machineId == null);
            
            OeeDataList.Criteria criteria = new OeeDataList.Criteria();
            criteria.GroupingId = groupingId;
            criteria.DivisionId = divisionId;
            criteria.MachineId = machineId;
            criteria.Shift = shift;
            criteria.StartTime = startDate;
            criteria.EndTime = endDate;
            criteria.CalculateSums = false;

            m_OeeList = OeeDataList.GetOeeDataList(criteria);
        }

        #endregion
    }
}
