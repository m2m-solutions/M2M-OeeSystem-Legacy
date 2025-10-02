using System;
using System.Collections.Generic;
using System.Linq;
using Csla;

namespace M2M.DataCenter
{
    [Serializable()]
    public class StoppageList : ReadOnlyListBase<StoppageList, StoppageListItem>
    {
        #region Business Methods

        private double m_TotalTime = 0;

        public double TotalTime
        {
            get
            {
                return m_TotalTime;
            }
        }



        #endregion
        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        #endregion

        #region Factory Methods

        public static StoppageList GetStoppageList(Criteria criteria)
        {
            return DataPortal.Fetch<StoppageList>(criteria);
        }

        private StoppageList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region Data Access

        [Serializable()]
        public class Criteria
        {
            private string m_DivisionId = null;
            private string m_MachineId = null;
            private int m_Shift = -1;
            private string m_ArticleNumber = null;
            private SmartDate m_StartTime = new SmartDate(new DateTime(2000, 1, 1));
            private SmartDate m_EndTime = new SmartDate(DateTime.Today);
            private List<int> m_Categories = new List<int>(); 

            public Criteria()
            {
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

            public int Shift
            {
                get { return m_Shift; }
                set { m_Shift = value; }
            }

            public string ArticleNumber
            {
                get { return m_ArticleNumber; }
                set { m_ArticleNumber = value; }
            }

            public SmartDate StartTime
            {
                get { return m_StartTime; }
                set { m_StartTime = value; }
            }

            public SmartDate EndTime
            {
                get { return m_EndTime; }
                set { m_EndTime = value; }
            }

            public List<int> Categories
            {
                get { return m_Categories; }
                set { m_Categories = value; }
            }
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            ExpandedProductionScheme productionScheme = ExpandedProductionScheme.GetExpandedProductionScheme(criteria.DivisionId, criteria.StartTime, criteria.EndTime);

            m_TotalTime = 0;

            foreach (ExpandedProductionSchemeItem schemeItem in productionScheme)
            {
                if (criteria.Shift < 0 || criteria.Shift == schemeItem.Shift)
                {
                    m_TotalTime += schemeItem.EndTime.Subtract(schemeItem.StartTime.Date).TotalSeconds;
                    AddStoppageData(schemeItem, criteria);
                }
            }
            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void AddStoppageData(ExpandedProductionSchemeItem schemeItem, Criteria criteria)
        {
            EventList.Criteria eventCriteria = new EventList.Criteria();
            eventCriteria.DivisionId = criteria.DivisionId;
            eventCriteria.MachineId = criteria.MachineId;
            eventCriteria.ArticleNumber = criteria.ArticleNumber;
            eventCriteria.Shift = criteria.Shift;
            eventCriteria.StartDate = schemeItem.StartTime;
            eventCriteria.EndDate = schemeItem.EndTime;
            eventCriteria.ShowInformation = false;
            eventCriteria.ShowAuto = false;
            eventCriteria.ShowProductionSwitch = false;
            eventCriteria.ShowSecondaryFailures = false;
            eventCriteria.ShowSystemErrors = false;
            eventCriteria.Categories = criteria.Categories;
            
            EventList events = EventList.GetEventList(eventCriteria);

            foreach (EventListItem eventItem in events)
            {
                this.Add(StoppageListItem.GetStoppageListItem(eventItem, schemeItem));
            }
        }

        #endregion
    }
}

