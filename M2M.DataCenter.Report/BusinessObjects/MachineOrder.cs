using System;
using System.Linq;
using Csla;

namespace M2M.DataCenter
{
    

    [Serializable()]
    public class MachineOrder : ReadOnlyBase<MachineOrder>
    {
        #region Business methods

        private string m_DivisionId = "";
        private string m_MachineId = "";
        private DateTime m_PeriodStart;
        private DateTime m_PeriodEnd;
        private OrderList m_OrderList = null;

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
                PlainMachineListItem machine = PlainMachineList.GetMachineList().GetMachine(m_DivisionId, m_MachineId);
                return machine.DivisionName; 
            }
        }

        public string Machine
        {
            get 
            {
                PlainMachineListItem machine = PlainMachineList.GetMachineList().GetMachine(m_DivisionId, m_MachineId);
                return machine.DisplayName; 
            }
        }

        public DateTime PeriodStart
        {
            get { return m_PeriodStart; }
        }

        public DateTime PeriodEnd
        {
            get { return m_PeriodEnd; }
        }

        public AggregatedOrderData GetOrders()
        {
            AggregatedOrderData orderData = new AggregatedOrderData();

            if (m_OrderList.Count > 0)
            {
                

                foreach (OrderListItem orderListItem in m_OrderList)
                {
                    AggregatedOrderData.OrderItem orderItem = new AggregatedOrderData.OrderItem();

                    orderItem.Article = orderListItem.ArticleNumber;
                    orderItem.ProducedItems = orderListItem.ProducedItems;
                    orderItem.FirstAuto = orderListItem.FirstAuto;
                    orderItem.AutoTime = new TimeSpan(0, 0, (int)orderListItem.AutoTime);
                    orderItem.NoProductionTime = new TimeSpan(0, 0, (int)orderListItem.NoProductionTime);
                    orderItem.TotalTime = new TimeSpan(0, 0, (int)orderListItem.TotalTime);
                    orderItem.AssembleTime = new TimeSpan(0, 0, (int)orderListItem.AssembleTime);
                    orderItem.OrderStart = orderListItem.OrderStart;
                    orderItem.OrderStop = orderListItem.OrderStop;
                    
                    orderData.Add(orderItem);
                }
            }
         
            return orderData;
        }

      
        protected override object GetIdValue()
        {
            return m_DivisionId + " " + m_MachineId;
        }

        #endregion

        #region Constructors

        public MachineOrder(string divisionId, string machineId, DateTime startDate, DateTime endDate)
        {
            m_DivisionId = divisionId;
            m_MachineId = machineId;
            m_PeriodStart = startDate;
            m_PeriodEnd = endDate;

            OrderList.Criteria criteria = new OrderList.Criteria();
            criteria.DivisionId = divisionId;
            criteria.MachineId = machineId;
            criteria.StartTime = startDate;
            criteria.EndTime = endDate;

            m_OrderList = OrderList.GetOrderList(criteria);
        }

        #endregion
    }
}
