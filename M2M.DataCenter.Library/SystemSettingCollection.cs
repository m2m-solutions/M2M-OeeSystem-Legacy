using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public partial class SystemSettingCollection : BusinessListBase<SystemSettingCollection, SystemSetting>
    {

        #region Business Methods

        public string Customer
        {
            get
            {
                SystemSetting item = GetItem("Customer");

                if (item == null)
                {
                    item = Add("Customer");
                    item.Value = "";
                }

                return item.Value;
            }
            set
            {
                SystemSetting item = GetItem("Customer");

                if (item == null)
                    item = Add("Customer");

                item.Value = value;
            }
        }

        public string Culture
        {
            get
            {
                SystemSetting item = GetItem("Culture");
                
                if (item == null)
                {
                    item = Add("Culture");
                    item.Value = "Auto";
                }

                return item.Value;
            }
            set
            {
                SystemSetting item = GetItem("Culture");

                if (item == null)
                    item = Add("Culture");

                item.Value = value;
            }
        }

        public bool LogSecondaryAlerts
        {
            get
            {
                SystemSetting item = GetItem("LogSecondaryAlerts");

                if (item == null)
                {
                    item = Add("LogSecondaryAlerts");
                    item.Value = Boolean.FalseString;
                }

                return Convert.ToBoolean(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("LogSecondaryAlerts");

                if (item == null)
                    item = Add("LogSecondaryAlerts");

                item.Value = value.ToString();
            }
        }

        public bool PurplepointMode
        {
            get
            {
                SystemSetting item = GetItem("PurplepointMode");

                if (item == null)
                {
                    item = Add("PurplepointMode");
                    item.Value = Boolean.FalseString;
                }

                return Convert.ToBoolean(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("PurplepointMode");

                if (item == null)
                    item = Add("PurplepointMode");

                item.Value = value.ToString();
            }
        }

        public string OpcServerName
        {
            get
            {
                SystemSetting item = GetItem("OpcServerName");

                if (item == null)
                {
                    item = Add("OpcServerName");
                    item.Value = "Beijer.ElectronicsOPCServer.1";
                }

                return item.Value;
            }
            set
            {
                SystemSetting item = GetItem("OpcServerName");

                if (item == null)
                    item = Add("Beijer.ElectronicsOPCServer.1");

                item.Value = value;
            }
        }

        public int CalculateInterval
        {
            get
            {
                SystemSetting item = GetItem("CalculateInterval");

                if (item == null)
                {
                    item = Add("CalculateInterval");
                    item.Value = (10).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("CalculateInterval");

                if (item == null)
                    item = Add("CalculateInterval");

                item.Value = value.ToString();
            }
        }

        public int ChangeCalculateInterval
        {
            get
            {
                SystemSetting item = GetItem("ChangeCalculateInterval");

                if (item == null)
                {
                    item = Add("ChangeCalculateInterval");
                    item.Value = (1).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("ChangeCalculateInterval");

                if (item == null)
                    item = Add("ChangeCalculateInterval");

                item.Value = value.ToString();
            }
        }

        public int MonitorRefreshInterval
        {
            get
            {
                SystemSetting item = GetItem("MonitorRefreshInterval");

                if (item == null)
                {
                    item = Add("MonitorRefreshInterval");
                    item.Value = (5).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("MonitorRefreshInterval");

                if (item == null)
                    item = Add("MonitorRefreshInterval");

                item.Value = value.ToString();
            }
        }

        public int LoadOpcItemsRetryInterval
        {
            get
            {
                SystemSetting item = GetItem("LoadOpcItemsRetryInterval");

                if (item == null)
                {
                    item = Add("LoadOpcItemsRetryInterval");
                    item.Value = (5000).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("LoadOpcItemsRetryInterval");

                if (item == null)
                    item = Add("LoadOpcItemsRetryInterval");

                item.Value = value.ToString();
            }
        }

        public int LoadOpcItemsRetryAttempts
        {
            get
            {
                SystemSetting item = GetItem("LoadOpcItemsRetryAttempts");

                if (item == null)
                {
                    item = Add("LoadOpcItemsRetryAttempts");
                    item.Value = (5).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("LoadOpcItemsRetryAttempts");

                if (item == null)
                    item = Add("LoadOpcItemsRetryAttempts");

                item.Value = value.ToString();
            }
        }

        public int StoppageGraphGroupCount
        {
            get
            {
                SystemSetting item = GetItem("StoppageGraphGroupCount");

                if (item == null)
                {
                    item = Add("StoppageGraphGroupCount");
                    item.Value = (5).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("StoppageGraphGroupCount");

                if (item == null)
                    item = Add("StoppageGraphGroupCount");

                item.Value = value.ToString();
            }
        }

        public int StoppageListReasonMax
        {
            get
            {
                SystemSetting item = GetItem("StoppageListReasonMax");

                if (item == null)
                {
                    item = Add("StoppageListReasonMax");
                    item.Value = (65).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("StoppageListReasonMax");

                if (item == null)
                    item = Add("StoppageListReasonMax");

                item.Value = value.ToString();
            }
        }

        public int StoppageGraphLegendMax
        {
            get
            {
                SystemSetting item = GetItem("StoppageGraphLegendMax");

                if (item == null)
                {
                    item = Add("StoppageGraphLegendMax");
                    item.Value = (36).ToString();
                }

                return Convert.ToInt32(item.Value);
            }
            set
            {
                SystemSetting item = GetItem("StoppageGraphLegendMax");

                if (item == null)
                    item = Add("StoppageGraphLegendMax");

                item.Value = value.ToString();
            }
        }

		public int StartDateOffset
		{
			get
			{
                SystemSetting item = GetItem("StartDateOffset");

				if (item == null)
				{
					item = Add("StartDateOffset");
					item.Value = (3).ToString();
				}

				return Convert.ToInt32(item.Value);
			}
			set
			{
				SystemSetting item = GetItem("StartDateOffset");

				if (item == null)
					item = Add("StartDateOffset");

				item.Value = value.ToString();
			}
		}

        /// <summary>
        /// Returns the SystemSetting object matching the id given.
        /// </summary>		
        public SystemSetting GetItem(string name)
        {
            foreach (SystemSetting item in this)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;

        }

        /// <summary>
        /// Adds a new SystemSetting object to the collection
        /// </summary>
        public SystemSetting Add(string name)
        {
            SystemSetting item = SystemSetting.NewSetting(name);
            this.Add(item);
            return item;
        }
        /// <summary>
        /// Removes the SystemSetting object matching the id given.
        /// </summary>
        public void Remove(string name)
        {
            Remove(GetItem(name));
        }

        /// <summary>
        /// Returns true if a SystemSetting object matching the id exists.
        /// </summary>
        public bool Contains(string name)
        {
            return (GetItem(name) != null);
        }

        /// <summary>
        /// Returns true if a deleted SystemSetting object matching the id exists.
        /// </summary>
        public bool ContainsDeleted(string name)
        {
            foreach (SystemSetting item in DeletedList)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
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

        public static SystemSettingCollection GetSettingCollection()
        {

            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view SystemSettingCollection objects");
            return DataPortal.Fetch<SystemSettingCollection>();
        }


        protected SystemSettingCollection()
        {

        }

        #endregion

        #region Data Access


        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;


            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Name,Value" +
                                          @" FROM SystemSettings";

                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dataReader.Read())
                        {
                            Add(SystemSetting.GetSetting(dataReader));
                        }
                    }
                }
            }

            RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            foreach (SystemSetting item in DeletedList)
            {
                item.DeleteSelf();
            }
            DeletedList.Clear();

            foreach (SystemSetting item in this)
            {
                if (item.IsNew)
                {
                    item.Insert();
                }
                else
                {
                    item.Update();
                }
            }

            RaiseListChangedEvents = true;
        }

        #endregion
    }
}