using System;
using System.Collections.Generic;
using System.Linq;
using Csla;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    [Serializable()]
    public class MachineStoppage : ReadOnlyBase<MachineStoppage>
    {
        #region Business methods

        private readonly int m_GroupingId = 0;
        private readonly string m_DivisionId = "";
        private readonly string m_MachineId = "";
        private readonly string m_Shift = "";
        private readonly DateTime m_PeriodStart;
        private readonly DateTime m_PeriodEnd;
        private readonly StoppageDataList m_StoppageDataList = null;
        private readonly List<int> m_Categories = null;

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

        public string Categories
        {
            get { return m_Categories.Count == M2MDataCenter.GetAvailableCategories().Count ? ResourceStrings.GetString("All") : ResourceStrings.GetString("Selected"); }
        }

        public string Week
        {
            get { return String.Format("{0}. {1}, {2}", ResourceStrings.GetString("#-Week.Abbr"), m_PeriodStart.GetWeek(), m_PeriodStart.Year); }
        }

        public StoppageDataList Stoppages
        {
            get { return m_StoppageDataList; }
        }

        public List<AggregatedStoppageDataListItem> GetMachineTopStopTimes(int groupCount, bool showOther)
        {
            return m_StoppageDataList.GetTopTimes(groupCount, showOther);
        }


        public List<AggregatedStoppageDataListItem> GetMachineTopStopCounts(int groupCount, bool showOther)
        {
            return m_StoppageDataList.GetTopCount(groupCount, showOther);
        }

        protected override object GetIdValue()
        {
            return m_GroupingId.ToString() + " " + m_DivisionId + " " + m_MachineId;
        }

        #endregion

        #region Constructors

        public MachineStoppage(int groupingId, string divisionId, string machineId, int shift, DateTime startDate, DateTime endDate, List<int> categories)
        {
            m_GroupingId = groupingId;
            m_DivisionId = divisionId;
            m_MachineId = machineId;
            m_PeriodStart = startDate;
            m_PeriodEnd = endDate;
            m_Shift = M2MDataCenter.GetShiftName(shift);
            m_Categories = categories;

            StoppageDataList.Criteria criteria = new StoppageDataList.Criteria();
            criteria.GroupingId = groupingId;
            criteria.DivisionId = divisionId;
            criteria.MachineId = machineId;
            criteria.Shift = shift;
            criteria.StartTime = startDate;
            criteria.EndTime = endDate;
            criteria.SystemError = false;
            criteria.Categories = categories;
            m_StoppageDataList = StoppageDataList.GetStoppageDataList(criteria);
        }
        

        #endregion
    }
}
