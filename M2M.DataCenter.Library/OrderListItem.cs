using System;
using Csla;

namespace M2M.DataCenter
{
    [Serializable()]
    public class OrderListItem : ReadOnlyBase<OrderListItem>
    {
        #region Business Methods

        private Guid m_OrderId = Guid.NewGuid();
        private string m_ArticleNumber = String.Empty;
        private int m_ProducedItems = 0;
        private SmartDate m_OrderStart = new SmartDate();
        private SmartDate m_OrderStop = new SmartDate();
        private SmartDate m_FirstAuto = new SmartDate();
        private double m_AutoTime = 0;
        private double m_NoProductionTime = 0;
        private double m_TotalTime = 0;
        private double m_AssembleTime = 0;
        
        public Guid OrderId
        {
            get
            {
                return m_OrderId;
            }
        }

        public string ArticleNumber
        {
            get
            {
                return m_ArticleNumber;
            }
        }

        public int ProducedItems
        {
            get
            {
                return m_ProducedItems;
            }
        }

        public SmartDate OrderStart
        {
            get
            {
                return m_OrderStart;
            }
        }

        public SmartDate OrderStop
        {
            get
            {
                return m_OrderStop;
            }
        }

        public SmartDate FirstAuto
        {
            get
            {
                return m_FirstAuto;
            }
        }

        public double AutoTime
        {
            get
            {
                return m_AutoTime;
            }
        }

        public double NoProductionTime
        {
            get
            {
                return m_NoProductionTime;
            }
        }

        public double TotalTime
        {
            get
            {
                return m_TotalTime;
            }
        }

        public double AssembleTime
        {
            get
            {
                return m_AssembleTime;
            }
        }

        public bool IsValid
        {
            get
            {
                if (TotalTime <= 0)
                    return false;

                if (m_OrderStart.IsEmpty || m_FirstAuto.IsEmpty || m_OrderStop.IsEmpty)
                    return false;

                if (m_OrderStart > m_FirstAuto)
                    return false;

                if (m_FirstAuto > m_OrderStop)
                    return false;

                if (ProducedItems < 100)
                    return false;

                if (m_AssembleTime < 0)
                    return false;

                if (m_AutoTime <= 0)
                    return false;

                if (m_ArticleNumber == "")
                    return false;

                return true;
            }
        }


       protected override object GetIdValue()
        {
            return m_OrderId;
        }
        #endregion

        #region Factory Methods

        internal static OrderListItem GetOrderListItem(string divisionId, StateListItem stateItem)
        {
            return new OrderListItem(divisionId, stateItem);
        }

        private OrderListItem()
        {
            /* require use of factory methods */
        }

        private OrderListItem(string divisionId, StateListItem stateItem)
        {
            Fetch(divisionId, stateItem);
        }

        #endregion

        #region Data Access

        private void Fetch(string divisionId, StateListItem stateItem)
        {
            m_ArticleNumber = stateItem.ArticleNumber;
            
            OeeDataList.Criteria oeeCriteria = new OeeDataList.Criteria();
            oeeCriteria.MachineId = stateItem.MachineId;
            oeeCriteria.StartTime = stateItem.TimeStampOnSet;
            oeeCriteria.EndTime = stateItem.TimeStampOnReset;

            OeeDataList oeeList = OeeDataList.GetOeeDataList(oeeCriteria);

            m_AutoTime = oeeList.TotalAutoTime;
            m_NoProductionTime = oeeList.TotalNoProductionTime;
            m_TotalTime = oeeList.TotalTime;
            m_ProducedItems = oeeList.ProducedItems;
            
            m_OrderStart = StateList.GetPreviousLastAuto(stateItem.MachineId, stateItem.TimeStampOnSet, m_ArticleNumber);
            m_FirstAuto = StateList.GetFirstAuto(stateItem.MachineId, stateItem.TimeStampOnSet, m_ArticleNumber);
            m_OrderStop = StateList.GetLastAuto(stateItem.MachineId, stateItem.TimeStampOnReset, m_ArticleNumber);

            if (!m_OrderStart.IsEmpty && !m_FirstAuto.IsEmpty && !m_OrderStop.IsEmpty && m_OrderStart <= m_FirstAuto && m_FirstAuto < m_OrderStop)
            {
#region Time from previous article's last auto (orderstart) to this article's start (articleswitch)
                ExpandedProductionScheme productionScheme = ExpandedProductionScheme.GetExpandedProductionScheme(divisionId, m_OrderStart, stateItem.TimeStampOnSet);

                foreach (ExpandedProductionSchemeItem schemeItem in productionScheme)
                {
                    StateList.Criteria stateCriteria = new StateList.Criteria();
                    stateCriteria.MachineId = stateItem.MachineId;
                    stateCriteria.StartDate = schemeItem.StartTime;
                    stateCriteria.EndDate = schemeItem.EndTime;

                    StateList stateList = StateList.GetStateList(stateCriteria);

                    foreach (StateListItem stateListItem in stateList)
                    {
                        double elapsedTime = CalculateElapsedTime(stateListItem.TimeStampOnSet, stateListItem.TimeStampOnReset, schemeItem.StartTime, schemeItem.EndTime);
                        switch (stateListItem.StateType)
                        {
                            case StateType.ArticleSwitch:
                                m_TotalTime += elapsedTime;
                                m_AssembleTime += elapsedTime;
                                break;
                            case StateType.NoProduction:
                                m_NoProductionTime += elapsedTime;
                                m_AssembleTime -= elapsedTime;
                                break;
                            case StateType.Auto:
                                break;
                        }
                    }
                }
#endregion

#region Time from this article's start (articleSwitch) to first auto
                productionScheme = ExpandedProductionScheme.GetExpandedProductionScheme(divisionId, stateItem.TimeStampOnSet, m_FirstAuto);

                foreach (ExpandedProductionSchemeItem schemeItem in productionScheme)
                {
                    StateList.Criteria stateCriteria = new StateList.Criteria();
                    stateCriteria.MachineId = stateItem.MachineId;
                    stateCriteria.StartDate = schemeItem.StartTime;
                    stateCriteria.EndDate = schemeItem.EndTime;

                    StateList stateList = StateList.GetStateList(stateCriteria);

                    foreach (StateListItem stateListItem in stateList)
                    {
                        double elapsedTime = CalculateElapsedTime(stateListItem.TimeStampOnSet, stateListItem.TimeStampOnReset, schemeItem.StartTime, schemeItem.EndTime);
                        switch (stateListItem.StateType)
                        {
                            case StateType.ArticleSwitch:
                                m_AssembleTime += elapsedTime;
                                break;
                            case StateType.NoProduction:
                                m_AssembleTime -= elapsedTime;
                                break;
                            case StateType.Auto:
                                m_AutoTime -= elapsedTime;
                                m_ProducedItems -= CalculateProducedItems(stateListItem.NumberOfItems, stateListItem.ElapsedTime, elapsedTime);
                                break;
                        }
                    }
                }

#endregion

#region Time from this article's last auto (orderstop) to this article's end (articleswitch)

                productionScheme = ExpandedProductionScheme.GetExpandedProductionScheme(divisionId, m_OrderStop, stateItem.TimeStampOnReset);
                
                foreach (ExpandedProductionSchemeItem schemeItem in productionScheme)
                {
                    StateList.Criteria stateCriteria = new StateList.Criteria();
                    stateCriteria.MachineId = stateItem.MachineId;
                    stateCriteria.StartDate = schemeItem.StartTime;
                    stateCriteria.EndDate = schemeItem.EndTime;

                    StateList stateList = StateList.GetStateList(stateCriteria);

                    foreach (StateListItem stateListItem in stateList)
                    {
                        double elapsedTime = CalculateElapsedTime(stateListItem.TimeStampOnSet, stateListItem.TimeStampOnReset, schemeItem.StartTime, schemeItem.EndTime);
                        switch (stateListItem.StateType)
                        {
                            case StateType.ArticleSwitch:
                                m_TotalTime -= elapsedTime;
                                break;
                            case StateType.NoProduction:
                                m_NoProductionTime -= elapsedTime;
                                break;
                        }
                    }

                    
                }
#endregion
            }
            else
            {
                m_AutoTime = 0;
                m_AssembleTime = m_TotalTime - m_NoProductionTime;
            }
        }

        private double CalculateElapsedTime(SmartDate stateStart, SmartDate stateEnd, SmartDate schemeStart, SmartDate schemeEnd)
		{
			SmartDate start = new SmartDate();
			SmartDate end = new SmartDate();

			if (schemeStart.CompareTo(stateStart) > 0)
				start = schemeStart;
			else
				start = stateStart;

			if (schemeEnd.CompareTo(stateEnd) > 0)
				end = stateEnd;
			else
				end = schemeEnd;

			TimeSpan elapsedTime = end.Subtract(start.Date);

			return elapsedTime.TotalSeconds;
		}

		private int CalculateProducedItems(int stateProducedItems, double stateTime, double actualTime)
		{
			return ((int)Math.Round((double)stateProducedItems * actualTime / stateTime));
		}
        #endregion
    }
}