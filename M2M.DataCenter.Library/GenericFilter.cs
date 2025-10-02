using System;

using Csla;
using System.Collections.Generic;

namespace M2M.DataCenter
{
	[Serializable]
	public class GenericFilter
	{
		public GenericFilter()
		{
			
		}

		private SmartDate m_StartDate = new SmartDate();
		private SmartDate m_EndDate = new SmartDate();
		private string m_DivisionId = String.Empty;
		private string m_MachineId = String.Empty;
		private string m_TagId = String.Empty;
		private string m_ArticleNumber = String.Empty;
		private bool m_ShowInformation = false;
        private bool m_ShowAuto = false;
        private bool m_ShowProductionSwitch = false;
        private bool m_ShowSecondaryFailures = false;
        private bool m_ExcludeNoProductionTime = true;
        private List<int> m_Categories = new List<int>();
        private bool m_ShowSystemErrors = true;
        private int m_Shift = -1;
		
		public SmartDate StartDate
		{
			get 
			{ return m_StartDate; }
			set { m_StartDate = value; }
		}

		public SmartDate EndDate
		{
			get { return m_EndDate; }
			set { m_EndDate = value; }
		}

		public string DivisionId
		{
			get { return m_DivisionId; }
			set { m_DivisionId = value; }
		}
		
		public string MachineId
		{
			get { return m_MachineId; }
			set { m_MachineId = value; }
		}

		public string TagId
		{
			get { return m_TagId; }
			set { m_TagId = value; }
		}
		
		public string ArticleNumber
		{
			get { return m_ArticleNumber; }
			set { m_ArticleNumber = value; }
		}
		
		public bool ShowInformation
		{
			get { return m_ShowInformation; }
			set { m_ShowInformation = value; }
		}

        public bool ShowAuto
        {
            get { return m_ShowAuto; }
            set { m_ShowAuto= value; }
        }

        public bool ShowProductionSwitch
        {
            get { return m_ShowProductionSwitch; }
            set { m_ShowProductionSwitch = value; }
        }

        public bool ShowSecondaryFailures
        {
            get { return m_ShowSecondaryFailures; }
            set { m_ShowSecondaryFailures = value; }
        }

		public List<int> Categories
		{
			get { return m_Categories; }
			set { m_Categories = value; }
		}

        public bool ShowSystemErrors
		{
            get { return m_ShowSystemErrors; }
            set { m_ShowSystemErrors = value; }
		}

        public bool ExcludeNoProductionTime
        {
            get { return m_ExcludeNoProductionTime; }
            set { m_ExcludeNoProductionTime = value; }
        }

        public int Shift
		{
			get { return m_Shift; }
			set { m_Shift = value; }
		}

		public EventList.Criteria GetEventListCriteria()
		{
			EventList.Criteria criteria = new EventList.Criteria();

            if (!String.IsNullOrEmpty(m_DivisionId))
                criteria.DivisionId = m_DivisionId;

			if (!String.IsNullOrEmpty(m_MachineId))
				criteria.MachineId = m_MachineId;

			if (!String.IsNullOrEmpty(m_ArticleNumber))
				criteria.ArticleNumber = m_ArticleNumber;

			if (!String.IsNullOrEmpty(m_TagId))
				criteria.TagId = m_TagId;

            criteria.StartDate = m_StartDate;
			
			if (m_EndDate.IsEmpty)
				criteria.EndDate = new SmartDate(DateTime.Now);
			else
				criteria.EndDate = m_EndDate;

			criteria.Shift = m_Shift;
			criteria.ShowInformation = m_ShowInformation;
            criteria.ShowAuto = m_ShowAuto;
            criteria.ShowProductionSwitch = m_ShowProductionSwitch;
            criteria.ShowSystemErrors = m_ShowSystemErrors;
            criteria.ShowSecondaryFailures = m_ShowSecondaryFailures;
			criteria.Categories = m_Categories;

			return criteria;
		}

		public OeeDataList.Criteria GetOeeDataListCriteria()
		{
			OeeDataList.Criteria criteria = new OeeDataList.Criteria();

			criteria.MachineId = m_MachineId;
			criteria.DivisionId = m_DivisionId;

			if (!String.IsNullOrEmpty(m_ArticleNumber))
				criteria.ArticleNumber = m_ArticleNumber;

			criteria.StartTime = m_StartDate;

			if (m_EndDate.IsEmpty)
				criteria.EndTime = new SmartDate(DateTime.Now);
			else
				criteria.EndTime = m_EndDate;

			criteria.Shift = m_Shift;
            
			return criteria;
		}

		public ArticlesInProductionList.Criteria GetArticlesInProductionListCriteria()
		{
			ArticlesInProductionList.Criteria criteria = new ArticlesInProductionList.Criteria();

			if (!String.IsNullOrEmpty(m_MachineId))
				criteria.MachineId = m_MachineId;

			criteria.StartDate = m_StartDate;

			if (m_EndDate.IsEmpty)
				criteria.EndDate = new SmartDate(DateTime.Now);
			else
				criteria.EndDate = m_EndDate;

			criteria.Shift = m_Shift;
			criteria.ArticlesFilter = m_ArticleNumber;

			return criteria;
		}

		public DivisionList.Criteria GetDivisionListCriteria()
		{
			DivisionList.Criteria criteria = new DivisionList.Criteria();
			criteria.StartDate = m_StartDate;

			if (m_EndDate.IsEmpty)
				criteria.EndDate = new SmartDate(DateTime.Now);
			else
				criteria.EndDate = m_EndDate;
		
			if (!String.IsNullOrEmpty(m_ArticleNumber))
				criteria.ArticleNumber = m_ArticleNumber;
			
			criteria.Shift = m_Shift;
            
			return criteria;
		}

		public MachineList.Criteria GetMachineListCriteria()
		{
			MachineList.Criteria criteria = new MachineList.Criteria();

			criteria.DivisionId = m_DivisionId;
			criteria.StartDate = m_StartDate;

			if (m_EndDate.IsEmpty)
				criteria.EndDate = new SmartDate(DateTime.Now);
			else
				criteria.EndDate = m_EndDate;


			if (!String.IsNullOrEmpty(m_ArticleNumber))
				criteria.ArticleNumber = m_ArticleNumber;

			criteria.Shift = m_Shift;
            return criteria;
		}

        public StoppageDataList.Criteria GetStoppageDataListCriteria()
        {
            StoppageDataList.Criteria criteria = new StoppageDataList.Criteria();

            criteria.DivisionId = m_DivisionId;
            criteria.MachineId = m_MachineId;

            if (!String.IsNullOrEmpty(m_ArticleNumber))
                criteria.ArticleNumber = m_ArticleNumber;

            criteria.StartTime = m_StartDate;

            if (m_EndDate.IsEmpty)
                criteria.EndTime = new SmartDate(DateTime.Now);
            else
                criteria.EndTime = m_EndDate;

            criteria.Shift = m_Shift;

            criteria.SystemError = false;
            criteria.Categories = m_Categories;

            return criteria;
        }


		
		public OEEForMachine.Criteria GetOEEForMachineCriteria()
		{
			OEEForMachine.Criteria criteria = new OEEForMachine.Criteria();

			if (!String.IsNullOrEmpty(m_DivisionId))
				criteria.DivisionId = m_DivisionId;

			if (!String.IsNullOrEmpty(m_MachineId))
				criteria.MachineId = m_MachineId;

			if (!String.IsNullOrEmpty(m_ArticleNumber))
				criteria.ArticleNumber = m_ArticleNumber;

			criteria.StartDate = m_StartDate;
			
			if (m_EndDate.IsEmpty)
				criteria.EndDate = new SmartDate(DateTime.Now);
			else
				criteria.EndDate = m_EndDate;

			criteria.Shift = m_Shift;
			
			criteria.ChartSettings = new ChartSettings(criteria.StartDate.Date.Date, criteria.EndDate.Date.Date, (criteria.EndDate - criteria.StartDate).TotalDays > 40 ? Intervals.Weekly : Intervals.Daily);

			return criteria;
		}
	}
}
