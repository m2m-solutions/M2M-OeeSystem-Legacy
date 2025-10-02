using System;
using System.Collections.Generic;
using System.Linq;

using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;
using Csla;

namespace M2M.DataCenter
{
    public class AggregatedDataContainer : ReadOnlyBase<AggregatedDataContainer>
    {
        #region Business methods

        private readonly int m_GroupingId = 0;
        private readonly string m_DivisionId = "";
        private readonly string m_MachineId = "";
        private readonly string m_Shift = "";
        private readonly DateTime m_PeriodStart;
        private readonly DateTime m_PeriodEnd;
        private readonly MachineOee m_OeeData = null;
        private readonly MachineStoppage m_StoppageData = null;
        private readonly List<int> m_Categories = null;
        
        public MachineOee OeeData
        {
            get
            {
                return m_OeeData;
            }
        }

        public MachineStoppage StoppageData
        {
            get
            {
                return m_StoppageData;
            }
        }

        public int GroupingId
        {
            get { return m_GroupingId; }
        }

        public string Grouping
        {
            get
            {
                int groupingId = 0;
                if(m_GroupingId > 0)
                {
                    groupingId = m_GroupingId;
                }
                else if (m_DivisionId != null)
                {
                    PlainDivisionListItem division = M2MDataCenter.GetDivision(m_DivisionId);
                    if (division != null)
                        groupingId = division.GroupingId;
                }
                

                if (groupingId > 0)
                {
                    GroupingListItem grouping = M2MDataCenter.GetGrouping(groupingId);
                    if (grouping != null)
                        return grouping.DisplayName;
                }

                return "";
            }
        }

        public List<string> DivisionIdList
        {
            get
            {
                if (m_GroupingId == 0)
                    return new List<string> {m_DivisionId};
                
                return M2MDataCenter.GetDivisionList(m_GroupingId).Select( a => a.DivisionId).ToList();
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
                PlainDivisionListItem division = M2MDataCenter.GetDivision(m_DivisionId);
                if (division == null)
                    return "";
                return division.DisplayName;
            }
        }

        public string Machine
        {
            get
            {
                PlainMachineListItem machine = M2MDataCenter.GetMachine(m_DivisionId, m_MachineId);
                if (machine == null)
                    return "";
                return machine.DisplayName;
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

        public string Range
        {
            get { return string.Format("{0} {1} - {2} {3}", m_PeriodStart.ToShortDateString(), m_PeriodStart.ToShortTimeString(), m_PeriodEnd.ToShortDateString(), m_PeriodEnd.ToShortTimeString()); }
        }

        public string Categories
        {
            get { return m_Categories.Count == M2MDataCenter.GetAvailableCategories().Count ? ResourceStrings.GetString("All") : ResourceStrings.GetString("Selected"); }
        }

        public string Week
        {
            get { return String.Format("{0}. {1}", ResourceStrings.GetString("#-Week.Abbr"), m_PeriodStart.GetWeek()); }
        }

        public List<AggregatedCombinedDataItem> GetTotalData()
        {
            List<AggregatedCombinedDataItem> totalData = new List<AggregatedCombinedDataItem>();
            AggregatedCombinedDataItem totalDataItem = new AggregatedCombinedDataItem(m_StoppageData.Stoppages.GetTotalSums(), m_OeeData.GetTotalData()[0]);
            totalData.Add(totalDataItem);
            return totalData;
        }

        public List<AggregatedCombinedDataItem> GetDataForAllMachines()
        {
            List<AggregatedCombinedDataItem> combinedData = new List<AggregatedCombinedDataItem>();
            List<AggregatedOeeDataItem> oeeDataList = m_OeeData.GetDataForAllMachines();
            foreach(AggregatedOeeDataItem oeeData in oeeDataList)
            {
                AggregatedCombinedDataItem combinedDataItem = new AggregatedCombinedDataItem(m_StoppageData.Stoppages.GetMachineSums(oeeData.MachineId), oeeData);
                combinedData.Add(combinedDataItem);
            }
            return combinedData;
        }

        public List<AggregatedCombinedDataItem> GetDataForAllDivisions()
        {
            List<AggregatedCombinedDataItem> combinedData = new List<AggregatedCombinedDataItem>();
            List<AggregatedOeeDataItem> oeeDataList = m_OeeData.GetDataForAllDivisions();
            foreach (AggregatedOeeDataItem oeeData in oeeDataList)
            {
                AggregatedCombinedDataItem combinedDataItem = new AggregatedCombinedDataItem(m_StoppageData.Stoppages.GetDivisionSums(oeeData.DivisionId), oeeData);
                combinedData.Add(combinedDataItem);
            }
            return combinedData;
        }

        public List<AggregatedStoppageDataListItem> GetTopStopTimes(int groupCount, bool showOther)
        {
            return m_StoppageData.Stoppages.GetTopTimes(groupCount, showOther);
        }

        public List<AggregatedStoppageDataListItem> GetTopStopTimesNpbSpecial(int groupCount, bool showOther)
        {
            double totalScheduledTime = GetTotalData()[0].ScheduledTimeAverageInHours;
            return m_StoppageData.Stoppages.GetTopTimes(groupCount, showOther, totalScheduledTime);
        }

        public List<AggregatedStoppageDataListItem> GetTopStopCounts(int groupCount, bool showOther)
        {
            return m_StoppageData.Stoppages.GetTopCount(groupCount, showOther);
        }

        public List<AggregatedStoppageDataListItem> GetTopStopTimes(string divisionId, int groupCount, bool showOther)
        {
            return m_StoppageData.Stoppages.GetTopTimes(divisionId, groupCount, showOther);
        }


        public List<AggregatedStoppageDataListItem> GetTopStopCounts(string divisionId, int groupCount, bool showOther)
        {

            return m_StoppageData.Stoppages.GetTopCount(divisionId, groupCount, showOther);
        }

        protected override object GetIdValue()
        {
            return m_DivisionId + " " + m_MachineId;
        }

        #endregion

        #region Constructors

        public AggregatedDataContainer(int groupingId, string divisionId, string machineId, int shift, DateTime startDate, DateTime endDate, List<int> categories)
        {
            m_GroupingId = groupingId;
            m_DivisionId = divisionId;
            m_MachineId = machineId;
            m_PeriodStart = startDate;
            m_PeriodEnd = endDate;
            m_Shift = M2MDataCenter.GetShiftName(shift);
            m_Categories = categories;

            m_OeeData = new MachineOee(groupingId, divisionId, machineId, shift, startDate, endDate, categories);
            m_StoppageData = new MachineStoppage(groupingId, divisionId, machineId, shift, startDate, endDate, categories);          
        }
        
        #endregion
    }
}