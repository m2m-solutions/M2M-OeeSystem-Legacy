using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class PlainMachineListItem : ReadOnlyBase<PlainMachineListItem>
	{
		#region Business Methods 
		private string m_MachineId = String.Empty;
		private string m_DisplayName = String.Empty;
        private string m_ShortName = String.Empty;
		private string m_Notes = String.Empty;
		private string m_DivisionId = String.Empty;
        private string m_DivisionName = String.Empty;
	
		private MachineSettingList m_Settings = null;
		private ArticleList m_Articles = null;

		public string MachineId
		{
			get
			{
				return m_MachineId;
			}
		}

		public string DisplayName
		{
			get
			{
				return m_DisplayName;
			}
		}

        public string ShortName
        {
            get
            {
                return m_ShortName;
            }
        }

		public string Notes
		{
			get
			{
				return m_Notes;
			}
		}

		public string DivisionId
		{
			get
			{
				return m_DivisionId;
			}
		}

        public string DivisionName
        {
            get
            {
                return m_DivisionName;
            }
        }

		public int? IdealRunRate
		{
			get
			{
				if (m_Settings == null)
					return null;

				return (int?)m_Settings.IdealRunRate;
			}
		}

		public RunRateUnit RunRateUnit
		{
			get
			{
				if (m_Settings == null)
					return RunRateUnit.CycleTimeInMilliSeconds;

				return m_Settings.RunRateUnit;
			}
		}

		public double? CycleTimeInMilliSeconds
		{
			get
			{
				if (m_Settings == null || !m_Settings.IdealRunRate.HasValue)
					return null;

				int idealRunRate = (int)m_Settings.IdealRunRate.Value;
				RunRateUnit unit = m_Settings.RunRateUnit;

				double cycleTimeInMilliSeconds;

				switch (unit)
				{
					case RunRateUnit.CyclesPerHour:
						cycleTimeInMilliSeconds = 60.0 * 60.0 * 1000.0 / (double)idealRunRate;
						break;
					case RunRateUnit.CyclesPerMinute:
						cycleTimeInMilliSeconds = 60.0 * 1000.0 / (double)idealRunRate;
						break;
					case RunRateUnit.CycleTimeInMilliSeconds:
					default:
						cycleTimeInMilliSeconds = idealRunRate;
						break;

				}
				return (double?)cycleTimeInMilliSeconds;
			}
		}

		public double? GetIdealCycleTime(string articleNumber)
		{
			double? idealCycleTime = CycleTimeInMilliSeconds;

			ArticleListItem article = m_Articles.GetItem(articleNumber);

			if (article != null && article.CycleTimeInMilliSeconds != null)
				idealCycleTime = article.CycleTimeInMilliSeconds;

			return idealCycleTime;
		}

        public MomentUnit MomentUnit
        {
            get
            {
                if (m_Settings == null)
                    return MomentUnit.Cycles;

                return m_Settings.MomentUnit;
            }
        }

        public bool AggregateCounter
        {
            get
            {
                if (m_Settings == null)
                    return true;

                return m_Settings.AggregateCounter;
            }
        }

        
        public bool AggregateAvailability
        {
            get
            {
                if (m_Settings == null)
                    return true;

                return m_Settings.AggregateAvailability;
            }
        }

        public bool AggregatePerformance
        {
            get
            {
                if (m_Settings == null)
                    return true;

                return m_Settings.AggregatePerformance;
            }
        }

        public bool AllowNegativeScrap
        {
            get
            {
                if (m_Settings == null)
                    return false;

                return m_Settings.AllowNegativeScrap;
            }
        }

        public int AllowedCycleDiff
        {
            get
            {
                if (m_Settings == null)
                    return 5;

                return m_Settings.AllowedCycleDiff;
            }
        }

        public MachineSettingList Settings
		{
			get
			{
				return m_Settings;
			}
		}

        public string ConcatenatedDisplayName
        {
            get
            {
                return m_DivisionName + ": " + m_DisplayName;
            }
        }

        public string ConcatenatedId
        {
            get
            {
                return m_DivisionId + ":" + m_MachineId;
            }
        }

		protected override object GetIdValue()
		{
			return m_MachineId;
		}

		#endregion
	
		#region Factory Methods

		internal static PlainMachineListItem GetMachineListItem(SafeDataReader dr)
		{
			return new PlainMachineListItem(dr);
		}

		protected PlainMachineListItem(): base()
		{
			/* require use of factory methods */
		}

		protected PlainMachineListItem(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion
	
		#region Data Access

		private void Fetch(SafeDataReader dataReader)
		{	
			m_MachineId = dataReader.GetString("MachineId");
			m_DisplayName = dataReader.GetString("DisplayName");
            m_ShortName = dataReader.GetString("ShortName");
			m_Notes = dataReader.GetString("Notes");
			m_DivisionId = dataReader.GetString("DivisionId");
            m_DivisionName = dataReader.GetString("DivisionName");

			m_Settings = MachineSettingList.GetMachineSettingList(m_MachineId);
			m_Articles = ArticleList.GetArticleList(m_MachineId);
		}

		#endregion
	
	}
}