using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ServiceProcess;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
	public class M2MDataCenter
	{
		private static PlainDivisionList m_DivisionList = null;
        private static ReasonCodeList m_ReasonCodeList = null;
        private static SystemSettingCollection m_SystemSettings = null;
        private static RoleList m_Roles = null;
        private static ModuleList m_Modules = null;
        private static GroupingList m_Groupings = null;
        private static CategoryList m_Categories = null;
        private static Dictionary<int, string> m_Shifts = null;
        private static Dictionary<string, DeviceUnit> m_DeviceUnits = null;
        private static List<string> m_SchemeDeviceUnits = null;
        private static StoppageReasonList m_StopReasons = null;
        
		/// <summary>
		/// Gets the logged on user
		/// </summary>
		/// <returns>Returns a logged on M2MMembershipUser, or null if user is not logged on.</returns>
		public static M2MPrincipal User
		{
			get
			{
				M2MPrincipal result = null;
				IIdentity identity = Csla.ApplicationContext.User.Identity;

				if (identity.IsAuthenticated)
				{
					if (identity.GetType() == typeof(M2MIdentity))
					{
						result = (M2MPrincipal)Csla.ApplicationContext.User;
					}
					else
					{
						result = M2MPrincipal.GetM2MPrincipal(identity.Name);
						Csla.ApplicationContext.User = result;
					}
				}
				return result;
			}
		}

		public static IM2MPrincipal Principal
		{
			get { return (IM2MPrincipal)Csla.ApplicationContext.User; }
		}

		/// <summary>
		/// Validates and logs on user.
		/// A M2MMembershipUser is created, and placed in the Csl.ApplicationContext.ClientContext["User"] slot.
		/// </summary>
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		/// <returns>True if the user logon was successful.</returns>
		public static bool ValidateUser(string userName, string password)
		{
			m_DivisionList = null;
            m_ReasonCodeList = null;
            m_SystemSettings = null;
            m_Roles = null;
            m_Modules = null;
            m_Groupings = null;
            m_Categories = null;
            m_Shifts = null;
            m_DeviceUnits = null;
            m_SchemeDeviceUnits = null;
            m_StopReasons = null;
    		return M2MPrincipal.Login(userName, password);
		}
    
		public static void Logout()
		{
			M2MPrincipal.Logout();
		}

        static public RoleList GetAvailableRoles()
        {
            if (m_Roles == null)
                ReloadRoles();

            return m_Roles;
        }

        //static public RoleList GetUserRoles()
        //{
        //    RoleList roles = GetAvailableRoles();

        //    foreach(RoleListItem role in roles

        //    return m_Roles;
        //}

        static public ModuleList GetAvailableModules()
        {
            if (m_Modules == null)
                ReloadModules();

            return m_Modules;
        }

        static public List<ModuleListItem> GetUserModuleList()
        {
            if (m_Modules == null)
                ReloadModules();

            return m_Modules.Where(a => a.SystemOnly == false).ToList();
        }

        static public List<ModuleListItem> GetSystemModuleList()
        {
            if (m_Modules == null)
                ReloadModules();

            return m_Modules.Where(a => a.SystemOnly == true).ToList();
        }

		public static PlainDivisionList GetDivisionList()
		{
            if (m_DivisionList == null)
                ReloadConfiguration();

			return m_DivisionList;
		}

        public static List<PlainDivisionListItem> GetDivisionsAccessibleForUser()
        {
            PlainDivisionList divisions = GetDivisionList();
            if(M2MDataCenter.User.CanAccessAllDivisions())
                return divisions.ToList();

            List<PlainDivisionListItem> accessibleDivisions = new List<PlainDivisionListItem>();

            foreach (PlainDivisionListItem division in divisions)
            {
                if (M2MDataCenter.User.CanAccessDivision(division.DivisionId))
                    accessibleDivisions.Add(division);
            }

            return accessibleDivisions;
        }

        public static List<PlainDivisionListItem> GetDivisionList(int groupingId)
        {
            if (m_DivisionList == null)
                ReloadConfiguration();

            return m_DivisionList.Where(a => a.GroupingId == groupingId).ToList();
        }

		public static PlainDivisionListItem GetDivision(string divisionId)
		{
			PlainDivisionList divisions = GetDivisionList();

			if (divisions != null)
			{
				foreach (PlainDivisionListItem division in divisions)
				{
					if (division.DivisionId == divisionId)
						return division;
				}
			}

			return null;
		}

        public static void ReloadConfiguration()
        {
            m_DivisionList = PlainDivisionList.GetDivisionList();
        }

        public static void ReloadModules()
        {
            m_Modules = ModuleList.GetModuleList();
        }

        public static void ReloadRoles()
        {
            m_Roles = RoleList.GetRoleList();
        }

        public static void ReloadShifts()
        {
            ShiftList shifts = ShiftList.GetShiftList();
            m_Shifts = new Dictionary<int, string>();

            foreach (ShiftListItem shift in shifts)
            {
                m_Shifts.Add(shift.ShiftId, shift.DisplayName);
            }
        }

        public static void ReloadDeviceUnits()
        {
            m_DeviceUnits = new Dictionary<string, DeviceUnit>();
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT DeviceUnitId, Level, ParentId FROM DeviceUnits";
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        DeviceUnit deviceUnit = new DeviceUnit();
                        deviceUnit.DeviceUnitId = (string)dataReader["DeviceUnitId"];
                        deviceUnit.Level = (int)dataReader["Level"];
                        deviceUnit.DisplayName = String.Format(ResourceStrings.GetString("DeviceUnitLevel."), deviceUnit.Level);
                        deviceUnit.ParentId = dataReader["ParentId"] != DBNull.Value ? (string)dataReader["ParentId"] : null;
                        m_DeviceUnits.Add(deviceUnit.DeviceUnitId, deviceUnit);
                    }
                }
            }

            m_SchemeDeviceUnits = new List<string>();
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT SchemeDeviceUnitId FROM SchemeDeviceUnits";
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        m_SchemeDeviceUnits.Add((string)dataReader["SchemeDeviceUnitId"]);
                    }
                }
            }


        }

        public static void ReloadAll()
        {
            ReloadShifts();
            ReloadCategories();
            ReloadConfiguration();
            ReloadModules();
            ReloadGroupings();
            ReloadReasonCodes();
            ReloadRoles();
            ReloadSystemSettings();
            ReloadDeviceUnits();
            ReloadStopReasons();
        }

        static public void ReloadStopReasons()
        {
            m_StopReasons = StoppageReasonList.GetStoppageReasonList();
        }

        static public void ReloadCategories()
        {
            m_Categories = CategoryList.GetCategoryList();
        }

        static public void ReloadReasonCodes()
        {
            m_ReasonCodeList = ReasonCodeList.GetReasonCodeList();
        }

        static public void ReloadGroupings()
        {
            m_Groupings = GroupingList.GetGroupingList();
        }

        public static GroupingList GetGroupings()
        {
            if (m_Groupings == null)
                ReloadGroupings();

            return m_Groupings;
        }

        public static List<GroupingListItem> GetGroupings(GroupingType type)
        {
            if (m_Groupings == null)
                ReloadGroupings();

            return m_Groupings.Where(a => a.GroupingType == type).ToList();
        }

        public static GroupingListItem GetGrouping(int groupingId)
        {
            GroupingList groupings = GetGroupings();

            foreach (GroupingListItem grouping in groupings)
            {
                if (grouping.GroupingId == groupingId)
                    return grouping;
            }

            return null;
        }

		public static PlainMachineList GetMachineList(string divisionId)
		{
			PlainDivisionListItem division = GetDivision(divisionId);

			if(division != null)
				return division.Machines;

			return null;
        }

        public static Dictionary<int, string> GetShiftList()
        {
            if (m_Shifts == null)
                ReloadShifts();

            return m_Shifts;
        }

        public static Dictionary<int, string> GetShiftSelectList(bool allowAll)
        {
            if (m_Shifts == null)
                ReloadShifts();

            Dictionary<int, string> shifts = new Dictionary<int,string>();

            shifts.Add(-1, allowAll ? ResourceStrings.GetString("AllShifts") : ResourceStrings.GetString("SelectShift"));

            foreach (KeyValuePair<int, string> shift in m_Shifts)
            {
                shifts.Add(shift.Key, shift.Value);
            }

            return shifts;
        }

        private static List<DeviceUnit> GetChildDeviceUnits(string parentId)
        {
            List<DeviceUnit> deviceUnits = new List<DeviceUnit>();

            var filteredList = (from item in m_DeviceUnits.Values
                                where item.ParentId == parentId
                                select item);

            foreach (var deviceUnit in filteredList)
            {
                if (!m_SchemeDeviceUnits.Contains(deviceUnit.DeviceUnitId))
                    deviceUnits.Add(deviceUnit);

                deviceUnits.AddRange(GetChildDeviceUnits(deviceUnit.DeviceUnitId));
            }

            return deviceUnits;
        }

        public static List<DeviceUnit> GetDeviceUnitSortedList()
        {
            if (m_DeviceUnits == null)
                ReloadDeviceUnits();

            List<DeviceUnit> deviceUnits = new List<DeviceUnit>();

            DeviceUnit rootDeviceUnit = (from item in m_DeviceUnits.Values
                                 where item.Level == 0
                                 select item).SingleOrDefault();
            
            deviceUnits.AddRange(GetChildDeviceUnits(rootDeviceUnit.DeviceUnitId));
            
            return deviceUnits;
        }

        public static string GetShiftName(int shiftId)
        {
            if (m_Shifts == null)
                ReloadShifts();

            foreach (KeyValuePair<int, string> shift in m_Shifts)
            {
                if (shift.Key == shiftId)
                    return shift.Value;
            }

            return ResourceStrings.GetString("AllShifts");
        }

        public static int GetShiftId(string displayName)
        {
            if (m_Shifts == null)
                ReloadShifts();

            foreach(KeyValuePair<int, string> shift in m_Shifts)
            {
                if(shift.Value == displayName)
                    return shift.Key;
            }

            return -1;
        }

        public static List<PlainMachineListItem> GetMachineList()
        {
            List<PlainMachineListItem> machines = new List<PlainMachineListItem>();
            PlainDivisionList divisions = GetDivisionList();
           
            foreach (PlainDivisionListItem division in divisions)
                machines.AddRange(division.Machines);

            return machines;
        }

		public static PlainMachineListItem GetMachine(string divisionId, string machineId)
		{
			PlainMachineList machines = GetMachineList(divisionId);

			if (machines != null)
			{
				foreach (PlainMachineListItem machine in machines)
				{
					if (machine.MachineId == machineId)
						return machine;
				}
			}

			return null;
		}

        public static PlainMachineListItem GetMachine(string machineId)
        {
            List<PlainMachineListItem> machines = GetMachineList();

             foreach (PlainMachineListItem machine in machines)
            {
                if (machine.MachineId == machineId)
                    return machine;
            }
       
            return null;
        }

		public static double? GetIdealCycleTime(string divisionId, string machineId, string articleNumber)
		{
			
			PlainMachineListItem machine = GetMachine(divisionId, machineId);

			if (machine != null)
				return machine.GetIdealCycleTime(articleNumber);

			return null;
		}

        public static ReasonCodeList GetReasonCodeList()
        {
            if (m_ReasonCodeList == null)
                m_ReasonCodeList = ReasonCodeList.GetReasonCodeList();
            return m_ReasonCodeList;
        }

        public static string GetReasonText(string tagId, int reasonCode)
        {
            ReasonCodeList reasonCodes = GetReasonCodeList();

            if (reasonCodes != null)
            {
                if (reasonCode >= 0)
                {
                    ReasonCodeListItem listItem = reasonCodes.GetItem(tagId, reasonCode);

                    if (listItem != null)
                        return listItem.DisplayName;
                }
                else
                    return "Övriga stopp";
            }

            return string.Format("Ogiltig orsakskod ({0})", reasonCode);
        }

        public static CategoryList GetCategoriesSelectList()
        {
            if (m_Categories == null)
            {
                ReloadCategories();
            }
            
            return m_Categories;
        }

        public static List<int> GetAvailableCategories()
        {
            List<int> categories = new List<int>();
            if (m_Categories == null)
            {
                ReloadCategories();
            }

            foreach (CategoryListItem category in m_Categories)
            {
                categories.Add(category.CategoryId);
            }

            return categories;
        }

        public static List<int> GetAvailableChangeOverCategories()
        {
            List<int> categories = new List<int>();
            if (m_Categories == null)
            {
                ReloadCategories();
            }

            foreach (CategoryListItem category in m_Categories)
            {
                if(category.ChangeOver)
                    categories.Add(category.CategoryId);
            }

            return categories;
        }

        public static CategoryListItem GetCategoryItem(int categoryId)
        {
            if (m_Categories == null)
            {
                ReloadCategories();
            }

            return m_Categories.GetItem(categoryId);
        }

        // Obsolete
        public static string GetCategory(int categoryId)
        {
            return GetCategoryDisplayName(categoryId);
        }

        public static string GetCategoryDisplayName(int categoryId)
        {
            if (m_Categories == null)
            {
                ReloadCategories();
            }

            return m_Categories.GetItem(categoryId).DisplayName;
        }

        public static StoppageReasonList GetStoppageReasonList()
        {
            if(m_StopReasons == null)
            {
                ReloadStopReasons();
            }
            
            return m_StopReasons;
        }

        public static List<StoppageReasonListItem> GetStoppageReasonList(string divisionId, int categoryId)
        {
            if(m_StopReasons == null)
            {
                ReloadStopReasons();
            }
            
            return m_StopReasons.Where( a => a.DivisionId == divisionId).Where( b => b.CategoryId == categoryId).ToList() ;
        }

        static public SystemSettingCollection SystemSettings
        {
            get
            {
                if (m_SystemSettings == null)
                    ReloadSystemSettings();

                return m_SystemSettings;
            }
        }

        static public void ReloadSystemSettings()
        {
            m_SystemSettings = SystemSettingCollection.GetSettingCollection();
        }

        

        static public bool StartService(string serviceName)
        {
            if (ServiceExists(serviceName))
            {
                ServiceController Controller = new ServiceController(serviceName);
                if (Controller.Status == ServiceControllerStatus.Stopped)
                {
                    Controller.Start();
                    return true;
                }
            }

            return false;
        }

        static public bool StopService(string serviceName)
        {
            if (ServiceExists(serviceName))
            {
                ServiceController Controller = new ServiceController(serviceName);
                if (Controller.Status == ServiceControllerStatus.Running)
                {
                    Controller.Stop();
                    return true;
                }
            }

            return false;
        }

        private static bool ServiceExists(string serviceName)
        {
            ServiceController[] services;
            services = ServiceController.GetServices();
            bool found = false;
            foreach (ServiceController sc in services)
                if (string.Compare(serviceName, sc.ServiceName, true) == 0)
                    found = true;
            
            return found;
        }

        static public bool IsServiceStarted(string serviceName)
        {
            if (ServiceExists(serviceName))
            {
                ServiceController Controller = new ServiceController(serviceName);
                return (Controller.Status == ServiceControllerStatus.Running);
            }

            return false;
        }

             
	}
}
