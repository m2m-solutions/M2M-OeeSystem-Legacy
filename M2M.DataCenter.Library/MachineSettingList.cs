using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Drawing;

namespace M2M.DataCenter
{
	[Serializable()]
	public class MachineSettingList : ReadOnlyListBase<MachineSettingList, MachineSettingListItem>
	{
		#region Business Methods

        public double? IdealRunRate
        {
            get
            {
                MachineSettingListItem item  = GetItem("IdealRunRate");

                if (item != null)
                    return Convert.ToDouble(item.Value);

                return null;
            }
        }

        public RunRateUnit RunRateUnit
        {
            get
            {
                MachineSettingListItem item = GetItem("RunRateUnit");

                if (item != null)
                    return (RunRateUnit)Convert.ToInt32(item.Value);

                return RunRateUnit.CycleTimeInMilliSeconds;
            }
        }

        public bool IgnoreArticleStateChange
        {
            get
            {
                MachineSettingListItem item = GetItem("IgnoreArticleStateChange");

                if (item != null)
                    return Convert.ToBoolean(item.Value);

                return false;
            }
        }

        public bool DisableCollection
        {
            get
            {
                MachineSettingListItem item = GetItem("DisableCollection");

                if (item != null)
                    return Convert.ToBoolean(item.Value);

                return false;
            }
        }

        public bool AggregateCounter
        {
            get
            {
                MachineSettingListItem item = GetItem("AggregateCounter");

                if (item != null)
                    return Convert.ToBoolean(item.Value);

                return true;
            }
        }

        public bool AggregateAvailability
        {
            get
            {
                MachineSettingListItem item = GetItem("AggregateAvailability");

                if (item != null)
                    return Convert.ToBoolean(item.Value);

                return true;
            }
        }
        public bool AggregatePerformance
        {
            get
            {
                MachineSettingListItem item = GetItem("AggregatePerformance");

                if (item != null)
                    return Convert.ToBoolean(item.Value);

                return true;
            }
        }

        public int AllowedCycleDiff
        {
            get
            {
                MachineSettingListItem item = GetItem("AllowedCycleDiff");

                if (item != null)
                    return Convert.ToInt32(item.Value);

                return 5;
           }
        }

        // Ta bort
        public bool AllowNegativeScrap
        {
            get
            {
                MachineSettingListItem item = GetItem("AllowNegativeScrap");

                if (item != null)
                    return Convert.ToBoolean(item.Value);

                return false;
            }
        }

        public int MinValidAutoTime
        {
            get
            {
                MachineSettingListItem item = GetItem("MinValidAutoTime");

                if (item != null)
                    return Convert.ToInt32(item.Value);

                return 0;
            }
        }

        public MomentUnit MomentUnit
        {
            get
            {
                MachineSettingListItem item = GetItem("MomentUnit");

                if (item != null)
                    return (MomentUnit)Convert.ToInt32(item.Value);

                return MomentUnit.Cycles;
            }
        }

        public string PanelIpAddress
        {
            get
            {
                MachineSettingListItem item = GetItem("PanelIpAddress");

                if (item != null)
                    return item.Value;

                return "";
            }
        }

        public int PanelTcpPort
        {
            get
            {
                MachineSettingListItem item = GetItem("PanelTcpPort");

                if (item != null)
                    return Convert.ToInt32(item.Value);

                return 34345;
            }
        }

        public Point UIPos
        {
            get
            {
                MachineSettingListItem item = GetItem("UIPosLeftTop");

                if (item != null)
                {
                    string[] splitValues = item.Value.Split(new char[]{';'});
                    if (splitValues.Length == 2)
                        return new Point(Convert.ToInt32(splitValues[0]), Convert.ToInt32(splitValues[1]));
                    else
                        return Point.Empty;
                }
                return Point.Empty;
            }  
        }

        public MonitorObject MonitorData
        {
            get
            {
                MachineSettingListItem item = GetItem("MonitorData");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public string AccessPath
        {
            get
            {
                MachineSettingListItem item = GetItem("AccessPath");

                if (item != null)
                    return item.Value;

                return "";
            }
        }

       /// <summary>
		/// Returns the MachineSetting object matching the id given.
		/// </summary>		
		private MachineSettingListItem GetItem(string setting)
		{
			foreach (MachineSettingListItem item in this)
			{
				if (item.Setting == setting)
				{
					return item;
				}
			}
			return null;

		}
		#endregion

		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static MachineSettingList GetMachineSettingList()
		{
			return DataPortal.Fetch<MachineSettingList>(new Criteria());
		}

		public static MachineSettingList GetMachineSettingList(string machineId)
		{
			return DataPortal.Fetch<MachineSettingList>(new Criteria(machineId));
		}

		public static MachineSettingList GetMachineSettingList(Criteria criteria)
		{
			return DataPortal.Fetch<MachineSettingList>(criteria);
		}

		private MachineSettingList()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_MachineId = null;

			public Criteria()
			{
			}

			public Criteria(string machineId)
			{
				m_MachineId = machineId;
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
                    string whereClause = "";
                    if (!String.IsNullOrEmpty(criteria.MachineId))
                    {
                        whereClause = " WHERE MachineId=@MachineId";
                        command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);
                    }

                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT MachineId,Setting,Value,LastModified" +
                                          @" FROM MachineSettings" +
                                          whereClause;
					

					using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					{
						while (dr.Read())
						{
							Add(MachineSettingListItem.GetMachineSettingListItem(dr));
						}
					}
				}
			}

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		#endregion
	}
}

