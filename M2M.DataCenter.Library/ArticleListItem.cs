using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class ArticleListItem : ReadOnlyBase<ArticleListItem>
	{
		#region Business Methods 
		protected string m_MachineId = String.Empty;
		protected string m_ArticleNumber = String.Empty;
		protected ArticleSettingList m_Settings = null;
		
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

        public string ToolNumber
        {
            get
            {
                if (m_Settings == null || m_Settings.GetItem("ToolNumber") == null)
                    return "";

                return m_Settings.GetItem("ToolNumber").Value;
            }
        }

        public int? IdealRunRate
		{
			get
			{
				if (m_Settings == null || m_Settings.GetItem("IdealRunRate") == null)
					return null;

				return (int?)Convert.ToInt32(m_Settings.GetItem("IdealRunRate").Value);
			}
		}

        public double WeightPerCycle
        {
            get
            {
                if (m_Settings == null || m_Settings.GetItem("WeightPerCycle") == null)
                    return 1.0;

                return Convert.ToDouble(m_Settings.GetItem("WeightPerCycle").Value);
            }
        }

		public RunRateUnit RunRateUnit
		{
			get
			{
				if (m_Settings == null || m_Settings.GetItem("RunRateUnit") == null)
					return RunRateUnit.CycleTimeInMilliSeconds;

				return (RunRateUnit)Convert.ToInt32(m_Settings.GetItem("RunRateUnit").Value);
			}
		}

		public double? CycleTimeInMilliSeconds
		{
			get
			{
				int? idealRunRate = IdealRunRate;
				
				if (idealRunRate == null)
					return null;

				double cycleTimeInMilliSeconds;
				
				switch (this.RunRateUnit)
				{
					case RunRateUnit.CyclesPerHour:
						cycleTimeInMilliSeconds = 60.0 * 60.0 * 1000.0 / (double)idealRunRate;
						break;
					case RunRateUnit.CyclesPerMinute:
						cycleTimeInMilliSeconds = 60.0 * 1000.0 / (double)idealRunRate;
						break;
					case RunRateUnit.CycleTimeInMilliSeconds:
					default:
						cycleTimeInMilliSeconds = (double)IdealRunRate;
						break;

				}
				return (double?)cycleTimeInMilliSeconds;
			}
		}

		// == Public collection properties ==
		protected override object GetIdValue()
		{
			return m_MachineId + "|" + m_ArticleNumber;
		}

		#endregion

		#region Factory Methods

		internal static ArticleListItem GetArticleListItem(SafeDataReader dr)
		{
			return new ArticleListItem(dr);
		}

		protected ArticleListItem()
		{
			/* require use of factory methods */
		}

		
		private ArticleListItem(SafeDataReader dr)
			: this()
		{
			Fetch(dr);
		}

		#endregion
	
		#region Data Access


		private void Fetch(SafeDataReader dr)
		{
			m_MachineId = dr.GetString("MachineId");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_Settings = ArticleSettingList.GetArticleSettingList(m_MachineId, m_ArticleNumber);
		}

		#endregion
	}
}