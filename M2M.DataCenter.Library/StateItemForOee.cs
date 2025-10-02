using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class StateItemForOee : ReadOnlyBase<StateItemForOee>
	{
		#region Business Methods

		private Guid m_StateId = Guid.NewGuid();
		private string m_MachineId = String.Empty;
		private string m_ArticleNumber = String.Empty;
		private StateType m_StateType = StateType.NotApplicable;
		private SmartDate m_TimeStampOnSet = new SmartDate();
		private SmartDate m_TimeStampOnReset = new SmartDate();
		private int m_NumberOfItemsOnSet = 0;
		private int m_NumberOfItemsOnReset = 0;
        private int m_NumberOfRejectedOnSet = 0;
        private int m_NumberOfRejectedOnReset = 0;
		

		public Guid StateId
		{
			get
			{
				return m_StateId;
			}
		}

		public string MachineId
		{
			get
			{
				return m_MachineId;
			}
		}

		public string ArticleNumber
		{
			get
			{
				return m_ArticleNumber;
			}
		}

		public StateType StateType
		{
			get
			{
				return m_StateType;
			}
		}

		public SmartDate TimeStampOnSet
		{
			get
			{
				return m_TimeStampOnSet;
			}
		}

		public SmartDate TimeStampOnReset
		{
			get
			{
				return m_TimeStampOnReset;
			}
		}

		public double ElapsedTime
		{
			get
			{
				TimeSpan ElapsedTime = m_TimeStampOnReset.Subtract(m_TimeStampOnSet.Date);

				return ElapsedTime.TotalSeconds;
			}
		}

        public int NumberOfItemsOnSet
        {
            get
            {
                return m_NumberOfItemsOnSet;
            }
        }

        public int NumberOfItemsOnReset
        {
            get
            {
                return m_NumberOfItemsOnReset;
            }
        }

		public int NumberOfItems
		{
			get
			{
				return m_NumberOfItemsOnReset - m_NumberOfItemsOnSet;
			}
		}

        public int NumberOfRejectedOnSet
        {
            get
            {
                return m_NumberOfRejectedOnSet;
            }
        }

        public int NumberOfRejectedOnReset
        {
            get
            {
                return m_NumberOfRejectedOnReset;
            }
        }

        public int NumberOfRejected
        {
            get
            {
                return m_NumberOfRejectedOnReset - m_NumberOfRejectedOnSet;
            }
        }

		protected override object GetIdValue()
		{
			return m_StateId;
		}

		#endregion

		#region Factory Methods

		internal static StateItemForOee GetStateItem(SafeDataReader dr)
		{
			return new StateItemForOee(dr);
		}

		private StateItemForOee()
		{
			/* require use of factory methods */
		}

		private StateItemForOee(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dr)
		{
			m_StateId = dr.GetGuid("StateId");
			m_MachineId = dr.GetString("MachineId");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_StateType = (StateType)dr.GetInt32("StateType");
			m_TimeStampOnSet = dr.GetSmartDate("TimeStampOnSet");
			m_TimeStampOnReset = dr.GetSmartDate("TimeStampOnReset");
			m_NumberOfItemsOnSet = dr.GetInt32("NumberOfItemsOnSet");
			m_NumberOfItemsOnReset = dr.GetInt32("NumberOfItemsOnReset");
            m_NumberOfRejectedOnSet = dr.GetInt32("NumberOfRejectedOnSet");
            m_NumberOfRejectedOnReset = dr.GetInt32("NumberOfRejectedOnReset");
		}

		#endregion
	}
}