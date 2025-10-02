using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class Machine : BusinessBase<Machine>
	{
		#region Business Methods 
		protected string m_MachineId = String.Empty;
		protected string m_DisplayName = String.Empty;
		protected string m_Notes = String.Empty;
		protected string m_DivisionId = String.Empty;
		protected MachineSettingCollection m_Settings = null;
		protected ArticleCollection m_Articles = null;
		
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

		public string DisplayName
		{
			get
			{
				CanReadProperty("DisplayName", true);
				return m_DisplayName;
			}
			set
			{
				CanWriteProperty("DisplayName", true);
				if (m_DisplayName != value)
				{
					m_DisplayName = value;
					PropertyHasChanged("DisplayName");
				}
			}
		}

		public string Notes
		{
			get
			{
				CanReadProperty("Notes", true);
				return m_Notes;
			}
			set
			{
				CanWriteProperty("Notes", true);
				if (m_Notes != value)
				{
					m_Notes = value;
					PropertyHasChanged("Notes");
				}
			}
		}

		public string DivisionId
		{
			get
			{
				CanReadProperty("DivisionId", true);
				return m_DivisionId;
			}
			set
			{
				CanWriteProperty("DivisionId", true);
				if (m_DivisionId != value)
				{
					m_DivisionId = value;
					PropertyHasChanged("DivisionId");
				}
			}
		}

		public ArticleCollection Articles
		{
			get
			{
				CanReadProperty("Articles", true);

				if (m_Articles == null && !String.IsNullOrEmpty(m_MachineId))
				{
					m_Articles = ArticleCollection.NewArticleCollection(m_MachineId);
					PropertyHasChanged("Articles");
				}

				return m_Articles;
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
				if(!String.IsNullOrEmpty(m_MachineId))
				{
					if (m_Settings == null)
						m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

					if (m_Settings.GetItem("IdealRunRate") == null)
						m_Settings.Add("IdealRunRate");
				
					m_Settings.GetItem("IdealRunRate").Value = value.ToString();
					PropertyHasChanged("IdealRunRate");
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
				if (!String.IsNullOrEmpty(m_MachineId))
				{
					if (m_Settings == null)
						m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

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
				CanReadProperty("IdealRunRate", true);
				CanReadProperty("RunRateUnit", true);
				if (m_Settings == null || m_Settings.GetItem("IdealRunRate") == null)
					return null;

				int idealRunRate = Convert.ToInt32(m_Settings.GetItem("IdealRunRate").Value);
				RunRateUnit unit = RunRateUnit.CycleTimeInMilliSeconds;

				if (m_Settings.GetItem("RunRateUnit") != null)
					unit = (RunRateUnit)Convert.ToInt32(m_Settings.GetItem("RunRateUnit").Value);

				double cycleTimeInMilliSeconds;

				switch (unit)
				{
					case RunRateUnit.CyclesPerHour:
						cycleTimeInMilliSeconds = 60.0*60.0*1000.0/(double)idealRunRate;
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

		public MomentUnit MomentUnit
        {
            get
            {
                CanReadProperty("MomentUnit", true);
                if (m_Settings == null || m_Settings.GetItem("MomentUnit") == null)
                    return MomentUnit.Cycles;

                return (MomentUnit)Convert.ToInt32(m_Settings.GetItem("MomentUnit").Value);
            }
            set
            {
                CanWriteProperty("MomentUnit", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("MomentUnit") == null)
                        m_Settings.Add("MomentUnit");

                    m_Settings.GetItem("MomentUnit").Value = ((int)value).ToString();
                    PropertyHasChanged("MomentUnit");
                }
            }
        }

        public bool AggregateCounter
        {
            get
            {
                CanReadProperty("AggregateCounter", true);
                if (m_Settings == null || m_Settings.GetItem("AggregateCounter") == null)
                    return true;

                return Convert.ToBoolean(m_Settings.GetItem("AggregateCounter").Value);
            }
            set
            {
                CanWriteProperty("AggregateCounter", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("AggregateCounter") == null)
                        m_Settings.Add("AggregateCounter");

                    m_Settings.GetItem("CounterForLine").Value = value.ToString();
                    PropertyHasChanged("CounterForLine");
                }
            }
        }

        public bool AggregateAvailability
        {
            get
            {
                CanReadProperty("AggregateAvailability", true);
                if (m_Settings == null || m_Settings.GetItem("AggregateAvailability") == null)
                    return true;

                return Convert.ToBoolean(m_Settings.GetItem("AggregateAvailability").Value);
            }
            set
            {
                CanWriteProperty("AggregateAvailability", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("AggregateAvailability") == null)
                        m_Settings.Add("AggregateAvailability");

                    m_Settings.GetItem("AggregateAvailability").Value = value.ToString();
                    PropertyHasChanged("AggregateAvailability");
                }
            }
        }

        public bool AggregatePerformance
        {
            get
            {
                CanReadProperty("AggregatePerformance", true);
                if (m_Settings == null || m_Settings.GetItem("AggregatePerformance") == null)
                    return true;

                return Convert.ToBoolean(m_Settings.GetItem("AggregatePerformance").Value);
            }
            set
            {
                CanWriteProperty("AggregatePerformance", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("AggregatePerformance") == null)
                        m_Settings.Add("AggregatePerformance");

                    m_Settings.GetItem("AggregatePerformance").Value = value.ToString();
                    PropertyHasChanged("AggregatePerformance");
                }
            }
        }

        public string PanelIpAddress
        {
            get
            {
                CanReadProperty("PanelIpAddress", true);
                if (m_Settings == null || m_Settings.GetItem("PanelIpAddress") == null)
                    return "";

                return m_Settings.GetItem("PanelIpAddress").Value;
            }
            set
            {
                CanWriteProperty("PanelIpAddress", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("PanelIpAddress") == null)
                        m_Settings.Add("PanelIpAddress");

                    m_Settings.GetItem("PanelIpAddress").Value = value;
                    PropertyHasChanged("PanelIpAddress");
                }
            }
        }

        public int AllowedCycleDiff
        {
            get
            {
                CanReadProperty("AllowedCycleDiff", true);
                if (m_Settings == null || m_Settings.GetItem("AllowedCycleDiff") == null)
                    return 5;

                return Convert.ToInt32(m_Settings.GetItem("AllowedCycleDiff").Value);
            }
            set
            {
                CanWriteProperty("AllowedCycleDiff", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("AllowedCycleDiff") == null)
                        m_Settings.Add("AllowedCycleDiff");

                    m_Settings.GetItem("AllowedCycleDiff").Value = value.ToString();
                    PropertyHasChanged("AllowedCycleDiff");
                }
            }
        }

        public bool AllowNegativeScrap
        {
            get
            {
                CanReadProperty("AllowNegativeScrap", true);
                if (m_Settings == null || m_Settings.GetItem("AllowNegativeScrap") == null)
                    return false;

                return Convert.ToBoolean(m_Settings.GetItem("AllowNegativeScrap").Value);
            }
            set
            {
                CanWriteProperty("AllowNegativeScrap", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("AllowNegativeScrap") == null)
                        m_Settings.Add("AllowNegativeScrap");

                    m_Settings.GetItem("AllowNegativeScrap").Value = value.ToString();
                    PropertyHasChanged("AllowNegativeScrap");
                }
            }
        }

        public int RunRateCalcLimit
        {
            get
            {
                CanReadProperty("RunRateCalcLimit", true);
                if (m_Settings == null || m_Settings.GetItem("RunRateCalcLimit") == null)
                    return 5;

                return Convert.ToInt32(m_Settings.GetItem("RunRateCalcLimit").Value);
            }
            set
            {
                CanWriteProperty("RunRateCalcLimit", true);
                if (!String.IsNullOrEmpty(m_MachineId))
                {
                    if (m_Settings == null)
                        m_Settings = MachineSettingCollection.NewMachineSettingCollection(m_MachineId);

                    if (m_Settings.GetItem("RunRateCalcLimit") == null)
                        m_Settings.Add("RunRateCalcLimit");

                    m_Settings.GetItem("RunRateCalcLimit").Value = value.ToString();
                    PropertyHasChanged("RunRateCalcLimit");
                }
            }
        }

		// == Public collection properties ==
		protected override object GetIdValue()
		{
			return m_MachineId;
		}

		public override bool IsValid
		{
			get
			{
				return base.IsValid && (m_Settings == null || m_Settings.IsValid) && (m_Articles == null || m_Articles.IsValid) ;
			}
		}

		public override bool IsDirty
		{
			get
			{
				return base.IsDirty || (m_Settings != null && m_Settings.IsDirty) || (m_Articles != null && m_Articles.IsDirty);
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

		public static Machine NewMachine()
		{
			return DataPortal.Create<Machine>();
		}

		public static Machine GetMachine(string machineId)
		{
			return DataPortal.Fetch<Machine>(new Criteria(machineId));
		}

		public static void DeleteMachine(string machineId)
		{
			DataPortal.Delete(new Criteria(machineId));
		}

		protected Machine()
		{
			/* require use of factory methods */
		}

		#endregion
	
		#region Data Access

		[Serializable]
		protected class Criteria
		{
			private string m_MachineId = String.Empty;

			public string MachineId
			{
				get { return m_MachineId; }
			}

			public Criteria(string machineId)
			{
				m_MachineId = machineId;
			}
		}

		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT MachineId,DisplayName,Notes,DivisionId" +
	                                      @" FROM Machines" +
	                                      @" WHERE MachineId=@MachineId";

					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						if(dataReader.Read())
						{
							m_MachineId = dataReader.GetString("MachineId");
							m_DisplayName = dataReader.GetString("DisplayName");
							m_Notes = dataReader.GetString("Notes");
							m_DivisionId = dataReader.GetString("DivisionId");
						}
					}
				}
			}

			m_Settings = MachineSettingCollection.GetMachineSettingCollection(m_MachineId);
			m_Articles = ArticleCollection.GetArticleCollection(m_MachineId);

			ValidationRules.CheckRules();
		}

		protected override void DataPortal_Insert()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Machines " +
	                                      @"(MachineId,DisplayName,Notes,DivisionId)" + 
	                                      @" VALUES " + 
	                                      @"(@MachineId,@DisplayName,@Notes,@DivisionId)";

					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@DisplayName", m_DisplayName);
					command.Parameters.AddWithValue(@"@Notes", m_Notes);
					command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);

					command.ExecuteNonQuery();			
				}
			}

			if(m_Settings != null)
				m_Settings.Update();
			if(m_Articles != null)
				m_Articles.Update();
		}

		protected override void DataPortal_Update()
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE Machines" +
	                                      @" SET DisplayName=@DisplayName,Notes=@Notes,DivisionId=@DivisionId" +
	                                      @" WHERE " +
	                                      @"MachineId=@MachineId";

					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);
					command.Parameters.AddWithValue(@"@DisplayName", m_DisplayName);
					command.Parameters.AddWithValue(@"@Notes", m_Notes);
					command.Parameters.AddWithValue(@"@DivisionId", m_DivisionId);

					command.ExecuteNonQuery();	
				}
			}

			if (m_Settings != null)
				m_Settings.Update();
			if (m_Articles != null)
				m_Articles.Update();
		}

		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(m_MachineId));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE MachineSettings" +
                                      @" WHERE " +
                                      @"MachineId=@MachineId";

					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);

					command.ExecuteNonQuery();
				}

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE Machines WHERE MachineId=@MachineId";

					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);

					command.ExecuteNonQuery();
					MarkNew();
				}
			}
		}
		#endregion

		#region Exists

		public static bool Exists(int machineId)
		{
			bool exists = false;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*)" +
                                          @" FROM Machines WHERE MachineId=@MachineId";
					command.Parameters.AddWithValue(@"@MachineId", machineId);

					int count = (int)command.ExecuteScalar();
					exists = (count > 0);
				}
			}
			return exists;
		}

		#endregion
	}
}