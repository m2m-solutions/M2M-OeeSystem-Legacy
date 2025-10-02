using System;
using System.Linq;
using Csla;

namespace M2M.DataCenter
{
    [Serializable()]
    public class OrderList : ReadOnlyListBase<OrderList, OrderListItem>
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

        public static OrderList GetOrderList(Criteria criteria)
        {
            return DataPortal.Fetch<OrderList>(criteria);
        }

        private OrderList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region Data Access

        [Serializable()]
        public class Criteria
        {
            private string m_DivisionId = "";
            private string m_MachineId = "";
            private SmartDate m_StartTime = new SmartDate(new DateTime(2000, 1, 1));
            private SmartDate m_EndTime = new SmartDate(DateTime.Today);

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


        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            
            StateList.Criteria stateCriteria = new StateList.Criteria();
            stateCriteria.MachineId = criteria.MachineId;
            stateCriteria.StartDate = criteria.StartTime;
            stateCriteria.EndDate = criteria.EndTime;
            stateCriteria.StateType = StateType.ArticleSwitch;


            StateList stateList = StateList.GetStateList(stateCriteria);

            m_TotalTime = 0; 
   
            foreach(StateListItem stateItem in stateList)
            {
                OrderListItem listItem = OrderListItem.GetOrderListItem(criteria.DivisionId, stateItem);

                if(listItem.IsValid)
                    this.Add(listItem);
            }

            
            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        #endregion
    }
}

