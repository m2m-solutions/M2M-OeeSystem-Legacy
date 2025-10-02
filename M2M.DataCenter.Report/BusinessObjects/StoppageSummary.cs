using System;
using System.Collections.Generic;
using System.Linq;
using Csla;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    [Serializable()]
    public class StoppageSummary : ReadOnlyBase<StoppageSummary>
    {
        #region Business methods

        private readonly string m_DivisionId = "";
        private readonly string m_MachineId = "";
        private readonly string m_Article = "";
        private readonly string m_Shift = "";
        private readonly DateTime m_PeriodStart;
        private readonly DateTime m_PeriodEnd;
        private readonly StoppageDataList m_StoppageDataList = null;
        private readonly OeeDataList m_OeeList = null;
        private readonly int m_Category = 0;
        private readonly string m_StopReason = "";
        private double m_MaxValue = 0;
        private readonly AnalyzeShowType m_ShowType = AnalyzeShowType.WeightedNumberOfStops;
        
        public string DivisionId
        {
            get { return m_DivisionId; }
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

        public string MachineId
        {
            get { return m_DivisionId; }
        }

        public string Machine
        {
            get
            {
                PlainMachineListItem machine = M2MDataCenter.GetMachine(m_MachineId);
                if (machine == null)
                    return "";
                return machine.DisplayName;
            }
        }

        public string Article
        {
            get { return m_Article; }
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

        public string Category
        {
            get { return M2MDataCenter.GetCategoryDisplayName(m_Category); }
        }

        public string StopReason
        {
            get { return m_StopReason == null ? ResourceStrings.GetString("All") : m_StopReason; }
        }

        public string ShowType
        {
            get { return ResourceStrings.GetString(m_ShowType); }
        }

        public string Week
        {   // Subtracting one day to get the week number from the last full week in range. 
            get { return String.Format("{0}. {1}", ResourceStrings.GetString("#-Week.Abbr"), m_PeriodEnd.GetWeek()); }
        }

        public StoppageDataList Stoppages
        {
            get { return m_StoppageDataList; }
        }

        public double MaxValue 
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
            }
        }

        public double GetMaxValue(Intervals interval)
        {
            double result = 0;
            List<AggregatedStoppageDataListItem> stoppages = m_StoppageDataList.GetPeriodicStops(interval);

            switch (this.m_ShowType)
            {
                case AnalyzeShowType.WeightedNumberOfStops:
                    {
                        List<AggregatedOeeDataItem> oeeList = m_OeeList.GetPeriodicDataForWeightedStoppages(interval);

                        if (stoppages != null)
                        {
                            foreach (AggregatedStoppageDataListItem stoppageData in stoppages)
                            {
                                AggregatedStoppageDataListItem stoppage = stoppageData;
                                AggregatedOeeDataItem oee = oeeList.Where(o => o.Date == stoppage.XDate).FirstOrDefault();
                                double weightedNumberOfStops = (oee != null && oee.ActualProductionTimeInHours > 0) ? stoppage.NumberOfStops / oee.ActualProductionTimeInHours : 0;
                                if (weightedNumberOfStops > result)
                                    result = weightedNumberOfStops;
                            }

                        }
                    }
                    break;
                case AnalyzeShowType.NumberOfStops:
                    {
                        result = stoppages != null ? stoppages.Max(s => s.NumberOfStops) : 0;
                    }
                    break;
                case AnalyzeShowType.WeightedElapsedTime:
                    {
                        List<AggregatedOeeDataItem> oeeList = m_OeeList.GetPeriodicDataForWeightedStoppages(interval);

                        if (stoppages != null)
                        {
                            foreach (AggregatedStoppageDataListItem stoppageData in stoppages)
                            {
                                AggregatedStoppageDataListItem stoppage = stoppageData;
                                AggregatedOeeDataItem oee = oeeList.Where(o => o.Date == stoppage.XDate).FirstOrDefault();
                                double weightedElapsedTime = (oee != null && oee.ActualProductionTimeInHours > 0) ? stoppage.ElapsedTimeInHours / oee.ActualProductionTimeInHours : 0;
                                if (weightedElapsedTime > result)
                                    result = weightedElapsedTime;
                            }

                        }
                    }
                    break;
                case AnalyzeShowType.ElapsedTime:
                    {
                        result = stoppages != null ? stoppages.Max(s => s.ElapsedTimeInHours) : 0;
                    }
                    break;
            }
            return result;
        }

        public List<AggregatedStoppageDataListItem> GetPeriodicStops(Intervals interval)
        {
            List<AggregatedStoppageDataListItem> stoppages = m_StoppageDataList.GetPeriodicStops(interval);
            if (stoppages == null)
                return null;

            double totalValue = 0;

            switch (this.m_ShowType)
            {
                case AnalyzeShowType.WeightedNumberOfStops:
                    {
                        List<AggregatedOeeDataItem> oeeList = m_OeeList.GetPeriodicDataForWeightedStoppages(interval);

                        foreach (AggregatedStoppageDataListItem stoppageData in stoppages)
                        {
                            // To avoid using a iteration variable in lambda expression
                            AggregatedStoppageDataListItem stoppage = stoppageData;

                            AggregatedOeeDataItem oee = oeeList.Where(o => o.Date == stoppage.XDate).FirstOrDefault();
                            double weightedNumberOfStops = (oee != null && oee.ActualProductionTimeInHours > 0) ? stoppage.NumberOfStops / oee.ActualProductionTimeInHours : 0;
                            stoppage.WeightedNumberOfStops = weightedNumberOfStops;
                            totalValue += stoppage.WeightedNumberOfStops;
                            if (this.m_MaxValue > 0)
                                stoppage.MaxValue = this.m_MaxValue;
                        }
                    }
                    break;
                case AnalyzeShowType.NumberOfStops:
                    {
                        foreach (AggregatedStoppageDataListItem stoppageData in stoppages)
                        {
                            // To avoid using a iteration variable in lambda expression
                            AggregatedStoppageDataListItem stoppage = stoppageData;

                            stoppage.WeightedNumberOfStops = stoppage.NumberOfStops;
                            totalValue += stoppage.WeightedNumberOfStops;
                            if (this.m_MaxValue > 0)
                                stoppage.MaxValue = this.m_MaxValue;
                        }
                    }
                    break;
                case AnalyzeShowType.WeightedElapsedTime:
                    {
                        List<AggregatedOeeDataItem> oeeList = m_OeeList.GetPeriodicDataForWeightedStoppages(interval);

                        foreach (AggregatedStoppageDataListItem stoppageData in stoppages)
                        {
                            // To avoid using a iteration variable in lambda expression
                            AggregatedStoppageDataListItem stoppage = stoppageData;

                            AggregatedOeeDataItem oee = oeeList.Where(o => o.Date == stoppage.XDate).FirstOrDefault();
                            double weightedElapsedTime = (oee != null && oee.ActualProductionTimeInHours > 0) ? stoppage.ElapsedTimeInHours / oee.ActualProductionTimeInHours : 0;
                            stoppage.WeightedNumberOfStops = weightedElapsedTime;
                            totalValue += stoppage.WeightedNumberOfStops;
                            if (this.m_MaxValue > 0)
                                stoppage.MaxValue = this.m_MaxValue;
                        }
                    }
                    break;
                case AnalyzeShowType.ElapsedTime:
                    {
                        foreach (AggregatedStoppageDataListItem stoppageData in stoppages)
                        {
                            // To avoid using a iteration variable in lambda expression
                            AggregatedStoppageDataListItem stoppage = stoppageData;

                            stoppage.WeightedNumberOfStops = stoppage.ElapsedTimeInHours;
                            totalValue += stoppage.WeightedNumberOfStops;
                            if (this.m_MaxValue > 0)
                                stoppage.MaxValue = this.m_MaxValue;
                        }
                    }
                    break;
            }
            
            return totalValue > 0 ? stoppages : null;
        }

        protected override object GetIdValue()
        {
            return m_DivisionId;
        }

        #endregion

        #region Constructors

        public StoppageSummary(string divisionId, string machineId, string article, int shift, DateTime startDate, DateTime endDate, int category, string stopReason, AnalyzeShowType showType)
        {
            m_DivisionId = divisionId;
            m_MachineId = machineId;
            m_Article = article;
            m_PeriodStart = startDate;
            // Subtracting one day for display purposes
            m_PeriodEnd = endDate.AddDays(-1);
            m_Shift = M2MDataCenter.GetShiftName(shift);
            m_Category = category;
            m_StopReason = stopReason;
            m_ShowType = showType;

            StoppageDataList.Criteria criteria = new StoppageDataList.Criteria();
            criteria.MachineId = machineId;
            criteria.ArticleNumber = article;
            criteria.Shift = shift;
            criteria.StartTime = startDate;
            criteria.EndTime = endDate;
            criteria.SystemError = false;
            criteria.Categories.Add(category);
            criteria.StopReason = stopReason;

            m_StoppageDataList = StoppageDataList.GetStoppageDataList(criteria);

            OeeDataList.Criteria criteria2 = new OeeDataList.Criteria();
            criteria2.DivisionId = divisionId;
            criteria2.MachineId = machineId;
            criteria2.ArticleNumber = article;
            criteria2.Shift = shift;
            criteria2.StartTime = startDate;
            criteria2.EndTime = endDate;
            criteria2.CalculateSums = false;
            m_OeeList = OeeDataList.GetOeeDataList(criteria2);
        }
        

        #endregion
    }
}
