using System;
using System.Linq;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    public class ChangeOverData
    {
        private readonly string m_DivisionId = "";
        private readonly string m_MachineId = "";
        private readonly string m_Article = "";
        private readonly DateTime m_PeriodStart;
        private readonly DateTime m_PeriodEnd;
        private readonly string m_FilterArticle = "";
        
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

        public string FilterArticle
        {
            get { return m_FilterArticle; }
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

        public List<ChangeOverItem> Items { get; set; }

        public ChangeOverData(ChangeOverContainer parent, string article)
        {
            m_DivisionId = parent.DivisionId;
            m_MachineId = parent.MachineId;
            m_PeriodStart = parent.PeriodStart;
            m_PeriodEnd = parent.PeriodEnd;
            m_FilterArticle = parent.Article;
            m_Article = article;
            this.Items = new List<ChangeOverItem>();
        }
    }
}
