using System;
using System.Collections.Generic;
using System.Linq;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;
using Csla;

namespace M2M.DataCenter
{
    public class ChangeOverContainer
    {
        private readonly int m_GroupingId = 0;
        private readonly string m_DivisionId = "";
        private readonly string m_MachineId = "";
        private readonly string m_Article = "";
        private readonly DateTime m_PeriodStart;
        private readonly DateTime m_PeriodEnd;
        //private readonly List<StoppageListItem> m_StoppageList = new List<StoppageListItem>();
        private readonly List<ChangeOverListItem> m_ChangeOverList = new List<ChangeOverListItem>();
        
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

        public string Article
        {
            get { return m_Article; }
        }

        public DateTime PeriodStart
        {
            get { return m_PeriodStart; }
        }

        public DateTime PeriodEnd
        {
            get { return m_PeriodEnd; }
        }

        //public string Week
        //{
        //    get { return String.Format("{0}. {1}, {2}", ResourceStrings.GetString("#-Week.Abbr"), m_PeriodStart.GetWeek(), m_PeriodStart.Year); }
        //}

        public string Week
        {
            get { return String.Format("{0}. {1}", ResourceStrings.GetString("#-Week.Abbr"), m_PeriodStart.GetWeek()); }
        }
 
        public List<ChangeOverData> GetChangeOversPerArticle()
        {
            List<ChangeOverData> changeOvers = new List<ChangeOverData>();

            ChangeOverData currentData = null;
            ChangeOverItem currentItem = null;
            
            TimeSpan elapsedTime = new TimeSpan(0);

            foreach (ChangeOverListItem changeOver in m_ChangeOverList)
            {
                if (currentData == null || changeOver.ArticleNumber != currentData.Article)
                {
                    currentData = new ChangeOverData(this, changeOver.ArticleNumber);
                    changeOvers.Add(currentData);
                }

                elapsedTime += changeOver.ElapsedTime;

                if (changeOver.CountThis)
                {
                    currentItem = new ChangeOverItem(changeOver.PreviousArticle);
                    currentItem.StartTime = changeOver.ChangeOverStartTime;
                    currentItem.EndTime = changeOver.ChangeOverEndTime;
                    currentItem.ElapsedTime = elapsedTime;
                    currentData.Items.Add(currentItem);
                    elapsedTime = new TimeSpan(0);
                }
            }
            
            return changeOvers;
        }

        public ChangeOverContainer(int groupingId, string divisionId, string machineId, string article, DateTime startDate, DateTime endDate)
        {
            m_GroupingId = groupingId;
            m_DivisionId = divisionId;
            m_MachineId = machineId;
            m_Article = article;
            m_PeriodStart = startDate;
            m_PeriodEnd = endDate;

            ChangeOverList.Criteria criteria = new ChangeOverList.Criteria();
            criteria.MachineId = machineId;
            criteria.ArticleNumber = article;
            criteria.StartTime = new SmartDate(startDate);
            criteria.EndTime = new SmartDate(endDate);
            m_ChangeOverList = ChangeOverList.GetChangeOverList(criteria).ToList();
        }
    }
}
