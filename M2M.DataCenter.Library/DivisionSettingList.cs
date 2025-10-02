using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Drawing;

namespace M2M.DataCenter
{
	[Serializable()]
	public class DivisionSettingList : ReadOnlyListBase<DivisionSettingList, DivisionSettingListItem>
	{
		#region Business Methods

        public string OverviewImageFile
        {
            get
            {
                DivisionSettingListItem item = GetItem("OverviewImageFile");

                if (item != null)
                    return item.Value;

                return "";
            }
        }

        public bool IsLine
        {
            get
            {
                DivisionSettingListItem item = GetItem("IsLine");

                if (item != null)
                    return Convert.ToBoolean(item.Value);

                return false;
            }
        }

        public string MonitorImageFile
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorImageFile");

                if (item != null)
                    return item.Value;

                return "";
            }
        }

        public MonitorObject MonitorPace
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorPace");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public MonitorObject MonitorPaceIdeal
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorPaceIdeal");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public MonitorObject MonitorPaceIdeal2
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorPaceIdeal2");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public MonitorObject MonitorChangeOverCount
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorChangeOverCount");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public MonitorObject MonitorChangeOverLatest
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorChangeOverLatest");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public MonitorObject MonitorChangeOverAverage
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorChangeOverAverage");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public MonitorObject MonitorChangeOverIdeal
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorChangeOverIdeal");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public MonitorObject MonitorOee
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorOee");
                MonitorObject result = new MonitorObject();
                if (item != null)
                {
                    result.Deserialize(item.Value);
                }
                return result;
            }
        }

        public decimal PaceUpperLimit
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorPaceUpperLimit");
                if (item != null)
                {
                    return Convert.ToDecimal(item.Value) / 100;
                }
                return 90/100;
            }
        }

        public decimal PaceLowerLimit
        {
            get
            {
                DivisionSettingListItem item = GetItem("MonitorPaceLowerLimit");
                if (item != null)
                {
                    return Convert.ToDecimal(item.Value) / 100;
                }
                return 80 / 100;
            }
        }

        public int ChangeOverIdeal
        {
            get
            {
                DivisionSettingListItem item = GetItem("ChangeOverIdeal");
                if (item != null)
                {
                    return Convert.ToInt32(item.Value);
                }
                return 10;
            }
        }

        public int UpperLimitCount
        {
            get
            {
                DivisionSettingListItem item = GetItem("UpperLimitCount");
                if (item != null)
                {
                    return Convert.ToInt32(item.Value);
                }
                return 1;
            }
        }

        public int LowerLimitCount
        {
            get
            {
                DivisionSettingListItem item = GetItem("LowerLimitCount");
                if (item != null)
                {
                    return Convert.ToInt32(item.Value);
                }
                return 2;
            }
        }

		/// <summary>
		/// Returns the DivisionSetting object matching the id given.
		/// </summary>		
		private DivisionSettingListItem GetItem(string setting)
		{
			foreach (DivisionSettingListItem item in this)
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

		public static DivisionSettingList GetDivisionSettingList()
		{
			return DataPortal.Fetch<DivisionSettingList>(new Criteria());
		}

		public static DivisionSettingList GetDivisionSettingList(string DivisionId)
		{
			return DataPortal.Fetch<DivisionSettingList>(new Criteria(DivisionId));
		}

		public static DivisionSettingList GetDivisionSettingList(Criteria criteria)
		{
			return DataPortal.Fetch<DivisionSettingList>(criteria);
		}

		private DivisionSettingList()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_DivisionId = null;

			public Criteria()
			{
			}

			public Criteria(string DivisionId)
			{
				m_DivisionId = DivisionId;
			}

			public string DivisionId
			{
				get { return m_DivisionId; }
				set { m_DivisionId = value; }
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
                    if (!String.IsNullOrEmpty(criteria.DivisionId))
                    {
                        whereClause = " WHERE DivisionId=@DivisionId";
                        command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);
                    }

                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT DivisionId,Setting,Value,LastModified" +
                                          @" FROM DivisionSettings" +
                                          whereClause;
					

					using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					{
						while (dr.Read())
						{
							Add(DivisionSettingListItem.GetDivisionSettingListItem(dr));
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

