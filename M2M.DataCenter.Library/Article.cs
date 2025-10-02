using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class Article : BusinessBase<Article>
	{
		#region Business Methods 
		protected string m_MachineId = String.Empty;
        protected string m_ArticleNumber = String.Empty;
		protected ArticleSettingCollection m_Settings = null;
		
		public string MachineId
		{
			get
			{
				CanReadProperty("MachineId", true);
				return m_MachineId;
			}
			set
			{
				CanWriteProperty("MachineId", true);
				if (m_MachineId != value)
				{
					m_MachineId = value;
					PropertyHasChanged("MachineId");
				}
			}
		}

		public string ArticleNumber
		{
			get
			{
				CanReadProperty("ArticleNumber", true);
				return m_ArticleNumber;
			}
			set
			{
				CanWriteProperty("ArticleNumber", true);
				if (m_ArticleNumber != value)
				{
					m_ArticleNumber = value;
					PropertyHasChanged("ArticleNumber");
				}
			}
		}

        public string ToolNumber
        {
            get
            {
                CanReadProperty("ToolNumber", true);
                if (m_Settings == null || m_Settings.GetItem("ToolNumber") == null)
                    return "";

                return m_Settings.GetItem("ToolNumber").Value;
            }
            set
            {
                CanWriteProperty("ToolNumber", true);
                if (!String.IsNullOrEmpty(m_MachineId) && !String.IsNullOrEmpty(m_ArticleNumber))
                {
                    if (m_Settings == null)
                        m_Settings = ArticleSettingCollection.NewArticleSettingCollection(m_MachineId, m_ArticleNumber);

                    if (m_Settings.GetItem("ToolNumber") == null)
                        m_Settings.Add("ToolNumber");

                    m_Settings.GetItem("ToolNumber").Value = value.ToString();
                    PropertyHasChanged("ToolNumber");
                }
            }
        }

        public int? IdealRunRate
		{
			get
			{
				CanReadProperty("IdealRunRate", true);
				if (m_Settings == null || m_Settings.GetItem("IdealRunRate") == null)
					return null;

				return (int?)Convert.ToInt32(m_Settings.GetItem("IdealRunRate").Value);
			}
			set
			{
				CanWriteProperty("IdealRunRate", true);
				if(!String.IsNullOrEmpty(m_MachineId) && !String.IsNullOrEmpty(m_ArticleNumber))
				{
					if (m_Settings == null)
						m_Settings = ArticleSettingCollection.NewArticleSettingCollection(m_MachineId, m_ArticleNumber);

					if (m_Settings.GetItem("IdealRunRate") == null)
						m_Settings.Add("IdealRunRate");
				
					m_Settings.GetItem("IdealRunRate").Value = value.ToString();
					PropertyHasChanged("IdealRunRate");
				}
			}
		}

        public double WeightPerCycle
        {
            get
            {
                CanReadProperty("WeightPerCycle", true);
                if (m_Settings == null || m_Settings.GetItem("WeightPerCycle") == null)
                    return 1.0;

                return Convert.ToDouble(m_Settings.GetItem("WeightPerCycle").Value);
            }
            set
            {
                CanWriteProperty("WeightPerCycle", true);
                if (!String.IsNullOrEmpty(m_MachineId) && !String.IsNullOrEmpty(m_ArticleNumber))
                {
                    if (m_Settings == null)
                        m_Settings = ArticleSettingCollection.NewArticleSettingCollection(m_MachineId, m_ArticleNumber);

                    if (m_Settings.GetItem("WeightPerCycle") == null)
                        m_Settings.Add("WeightPerCycle");

                    m_Settings.GetItem("WeightPerCycle").Value = value.ToString();
                    PropertyHasChanged("WeightPerCycle");
                }
            }
        }

		public SmartDate LastModified(string key)
		{
			if (m_Settings != null && m_Settings.GetItem(key) != null)
			{
				return m_Settings.GetItem(key).LastModified;
			}

			return new SmartDate();
		}

        public SmartDate LastModifiedIdealRunRate
        {
            get { return LastModified("IdealRunRate"); }
        }

		public RunRateUnit RunRateUnit
		{
			get
			{
				CanReadProperty("RunRateUnit", true);
				if (m_Settings == null || m_Settings.GetItem("RunRateUnit") == null)
					return RunRateUnit.CycleTimeInMilliSeconds;

				return (RunRateUnit)Convert.ToInt32(m_Settings.GetItem("RunRateUnit").Value);
			}
			set
			{
				CanWriteProperty("RunRateUnit", true);
				if (!String.IsNullOrEmpty(m_MachineId) && !String.IsNullOrEmpty(m_ArticleNumber))
				{
					if (m_Settings == null)
						m_Settings = ArticleSettingCollection.NewArticleSettingCollection(m_MachineId, m_ArticleNumber);

					if (m_Settings.GetItem("RunRateUnit") == null)
						m_Settings.Add("RunRateUnit");

					m_Settings.GetItem("RunRateUnit").Value = ((int)value).ToString();
					PropertyHasChanged("RunRateUnit");
				}
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
						cycleTimeInMilliSeconds = (double)idealRunRate;
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

		public override bool IsValid
		{
			get
			{
				return m_Settings == null || m_Settings.IsValid;
			}
		}

		public override bool IsDirty
		{
			get
			{
				return m_Settings != null && m_Settings.IsDirty;
			}
		}

		#endregion
	
		#region Validation Rules

		protected override void AddBusinessRules()
		{

		}

		#endregion
	
		#region Authorization Rules

		public static bool CanAddObject()
		{
			return CanEditObject();
		}

		public static bool CanEditObject()
		{
			return true;
		}

		public static bool CanDeleteObject()
		{
			return CanEditObject();
		}

		public static bool CanGetObject()
		{
			
			return true;
		}


		#endregion

		#region Factory Methods

		internal static Article NewArticle(string machineId, string articleNumber)
		{
			return new Article(machineId, articleNumber);
		}

		internal static Article GetArticle(SafeDataReader dr)
		{
			return new Article(dr);
		}

		protected Article()
		{
			MarkAsChild();
		}

		private Article(string machineId, string articleNumber)
			: this()
		{
			m_MachineId = machineId;
			m_ArticleNumber = articleNumber;

			m_Settings = ArticleSettingCollection.NewArticleSettingCollection(machineId, articleNumber);
		}

		private Article(SafeDataReader dr)
			: this()
		{
			Fetch(dr);
		}

		#endregion
	
		#region Data Access

		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
		}

		private void Fetch(SafeDataReader dr)
		{
			m_MachineId = dr.GetString("MachineId");
			m_ArticleNumber = dr.GetString("ArticleNumber");
			m_Settings = ArticleSettingCollection.GetArticleSettingCollection(m_MachineId, m_ArticleNumber);
			MarkOld();
		}

		internal void Update()
		{
			m_Settings.Update();
			MarkOld();
		}

		internal void DeleteSelf()
		{
			if (this.IsNew)
				return;

			m_Settings.Clear();
			m_Settings.Update();

			MarkNew();
		}
		#endregion
	}
}