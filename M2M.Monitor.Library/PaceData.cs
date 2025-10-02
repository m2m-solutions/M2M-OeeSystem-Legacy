using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    public class PaceData
    {
        private string m_DivisionId = String.Empty;
        private string m_MachineId = String.Empty;
        private int m_Shift = -1;
        private string m_ArticleNumber = String.Empty;
        private SmartDate m_StartTime = new SmartDate();
        private SmartDate m_EndTime = new SmartDate();
        private double m_AutoTime = 0.0;
        private double m_NoProductionTime = 0.0;
        private int m_ProducedItems = 0;
      
        public string DivisionId
        {
            get
            {
                return m_DivisionId;
            }
            set
            {
                if (m_DivisionId != value)
                {
                    m_DivisionId = value;
                }
            }
        }

        public string MachineId
        {
            get
            {
                return m_MachineId;
            }
            set
            {
                if (m_MachineId != value)
                {
                    m_MachineId = value;
                }
            }
        }

        public int Shift
        {
            get
            {
                return m_Shift;
            }
            set
            {
                if (m_Shift != value)
                {
                    m_Shift = value;
                }
            }
        }

        public string ArticleNumber
        {
            get
            {
                return m_ArticleNumber;
            }
            set
            {
                if (m_ArticleNumber != value)
                {
                    m_ArticleNumber = value;
                }
            }
        }

        public SmartDate StartTime
        {
            get
            {
                return m_StartTime;
            }
            set
            {
                if (m_StartTime != value)
                {
                    m_StartTime = value;
                }
            }
        }

        public SmartDate EndTime
        {
            get
            {
                return m_EndTime;
            }
            set
            {
                if (m_EndTime != value)
                {
                    m_EndTime = value;
                }
            }
        }

        public double AutoTime
        {
            get
            {
                return m_AutoTime;
            }
            set
            {
                if (m_AutoTime != value)
                {
                    m_AutoTime = value;
                }
            }
        }

        public double NoProductionTime
        {
            get
            {
                return m_NoProductionTime;
            }
            set
            {
                if (m_NoProductionTime != value)
                {
                    m_NoProductionTime = value;
                }
            }
        }

        public int ProducedItems
        {
            get
            {
                return m_ProducedItems;
            }
            set
            {
                if (m_ProducedItems != value)
                {
                    m_ProducedItems = value;
                }
            }
        }

        public bool AggregateAvailability
        {
            get
            {
                return M2MDataCenter.GetMachine(m_DivisionId, m_MachineId).AggregateAvailability;
            }
       }

        public bool AggregatePerformance
        {
            get
            {
                return M2MDataCenter.GetMachine(m_DivisionId, m_MachineId).AggregatePerformance;
            }
        }

        public bool AggregateCounter
        {
            get
            {
                return M2MDataCenter.GetMachine(m_DivisionId, m_MachineId).AggregateCounter;
            }
        }

        public double TotalTime
		{
			get
			{
				TimeSpan totalTime = m_EndTime.Subtract(m_StartTime.Date);
				return totalTime.TotalSeconds;
			}
		}

        public double ProductionTime
        {
            get
            {
                return TotalTime - m_NoProductionTime;
            }
        }

        public double RunRate
        {
            get
            {
                double runRate = 0;

                if (AutoTime != 0 && ProducedItems != 0)
                {
                    runRate = 1000 * (AutoTime / (double)ProducedItems);
                }

                return runRate;
            }
        }
    }
}