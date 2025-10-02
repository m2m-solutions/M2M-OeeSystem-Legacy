using System;
using System.Collections.Generic;
using System.Linq;

using Telerik.Web.UI;

using System.Data.SqlClient;
using System.Collections.Specialized;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
    public class ProductionSchemeProvider : SchedulerProviderBase
    {
        private IDictionary<int, Resource> shifts;
        private IDictionary<string, Resource> deviceUnits;

        private IDictionary<int, Resource> Shifts
        {
            get
            {
                if (this.shifts == null)
                {
                    this.shifts = new Dictionary<int, Resource>();
                    foreach (Resource shift in LoadShifts())
                    {
                        this.shifts.Add((int)shift.Key, shift);
                    }
                }

                return this.shifts;
            }
        }

        private IDictionary<string, Resource> DeviceUnits
        {
            get
            {
                if (this.deviceUnits == null)
                {
                    this.deviceUnits = new Dictionary<string, Resource>();

                    foreach (Resource deviceUnit in LoadDeviceUnits())
                    {
                        this.deviceUnits.Add((string)deviceUnit.Key, deviceUnit);
                    }

                    if (this.deviceUnits.Count == 0)
                    {
                        CreateDefaultDeviceUnit();

                        foreach (Resource deviceUnit in LoadDeviceUnits())
                        {
                            this.deviceUnits.Add((string)deviceUnit.Key, deviceUnit);
                        }
                    }
                }
                
                return this.deviceUnits;
            }
        }

        public override IEnumerable<Appointment> GetAppointments(RadScheduler owner)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [SchemeId], [Subject], [Start], [End], [RecurrenceRule], [RecurrenceParentId] FROM [Schemes]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment apt = new Appointment();
                            apt.Owner = owner;
                            apt.ID = reader["SchemeId"];
                            apt.Subject = Convert.ToString(reader["Subject"]);
                            apt.Start = DateTime.SpecifyKind(Convert.ToDateTime(reader["Start"]), DateTimeKind.Utc);
                            apt.End = DateTime.SpecifyKind(Convert.ToDateTime(reader["End"]), DateTimeKind.Utc);
                            apt.RecurrenceRule = Convert.ToString(reader["RecurrenceRule"]);
                            apt.RecurrenceParentID = reader["RecurrenceParentId"] == DBNull.Value ? null : reader["RecurrenceParentId"];

                            if (apt.RecurrenceParentID != null)
                            {
                                apt.RecurrenceState = RecurrenceState.Exception;
                            }
                            else if (apt.RecurrenceRule != string.Empty)
                            {
                                apt.RecurrenceState = RecurrenceState.Master;
                            }

                            LoadResources(apt);
                            appointments.Add(apt);
                        }
                    }
                }
            }

            return appointments;
        }

        public override void Insert(RadScheduler owner, Appointment appointmentToInsert)
        {
            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;

                        PopulateAppointmentParameters(cmd, appointmentToInsert);

                        cmd.CommandText =
                            @"	INSERT	INTO [Schemes]
									([Subject], [Start], [End], [ShiftId],
                                    [Level], [SchemeDeviceUnitId],
									[RecurrenceRule], [RecurrenceParentId])
							VALUES	(@Subject, @Start, @End, @ShiftId,
                                    @Level, @SchemeDeviceUnitId,
									@RecurrenceRule, @RecurrenceParentId)";


                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
            }
        }

        public override void Update(RadScheduler owner, Appointment appointmentToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;

                        PopulateAppointmentParameters(cmd, appointmentToUpdate);

                        cmd.Parameters.AddWithValue("@SchemeId", appointmentToUpdate.ID);
                        cmd.CommandText = "UPDATE [Schemes] SET [Subject] = @Subject, [Start] = @Start, [End] = @End, [ShiftId] = @ShiftId, [Level] = @Level, [SchemeDeviceUnitId] = @SchemeDeviceUnitId, [RecurrenceRule] = @RecurrenceRule, [RecurrenceParentId] = @RecurrenceParentId WHERE [SchemeId] = @SchemeId";
                        cmd.ExecuteNonQuery();
                       
                    }
                    tran.Commit();
                }
            }
        }

        public override void Delete(RadScheduler owner, Appointment appointmentToDelete)
        {
            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SchemeId", appointmentToDelete.ID);
                        cmd.CommandText = "DELETE FROM [Schemes] WHERE [SchemeId] = @SchemeId";
                        cmd.ExecuteNonQuery();

                        
                    }
                    tran.Commit();
                }
            }
        }

        public override IEnumerable<ResourceType> GetResourceTypes(RadScheduler owner)
        {
            ResourceType[] resourceTypes = new ResourceType[2];
            resourceTypes[0] = new ResourceType("Shift", false);
            resourceTypes[1] = new ResourceType("DeviceUnit", false);

            return resourceTypes;
        }

        public override IEnumerable<Resource> GetResourcesByType(RadScheduler owner, string resourceType)
        {
            switch (resourceType)
            {
                case "Shift":
                    return Shifts.Values;

                case "DeviceUnit":
                    return DeviceUnits.Values;

                default:
                    throw new InvalidOperationException("Unknown resource type: " + resourceType);
            }
        }

        private void LoadResources(Appointment apt)
        {
            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@SchemeId", apt.ID);
                    cmd.CommandText = "SELECT [ShiftId],[SchemeDeviceUnitId] FROM [Schemes] WHERE [SchemeId] = @SchemeId";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Resource shift = Shifts[Convert.ToInt32(reader["ShiftId"])];
                            apt.Resources.Add(shift);

                            Resource deviceUnit = DeviceUnits[(string)reader["SchemeDeviceUnitId"]];
                            apt.Resources.Add(deviceUnit);
                        }
                    }
                }
            }
        }

        private IEnumerable<Resource> LoadShifts()
        {
            List<Resource> resources = new List<Resource>();

            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [ShiftId], [DisplayName] FROM [Shifts]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Resource res = new Resource();
                            res.Type = "Shift";
                            res.Key = reader["ShiftId"];
                            res.Text = Convert.ToString(reader["DisplayName"]);
                            resources.Add(res);
                        }
                    }
                }
            }

            return resources;
        }

        private void CreateDefaultDeviceUnit()
        {
            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [SchemeDeviceUnits] ([SchemeDeviceUnitId], [Level]) SELECT [DeviceUnitId], [Level] FROM [DeviceUnits] WHERE [Level]=@Level";
                    cmd.Parameters.AddWithValue("@Level", 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private IEnumerable<Resource> LoadDeviceUnits()
        {
            List<Resource> resources = new List<Resource>();

            using (SqlConnection conn = new SqlConnection(Database.SystemConnectionStringWithMultipleActiveResultSets))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [SchemeDeviceUnitId], [Level] FROM [SchemeDeviceUnits] WHERE [Level]=@Level";
                    cmd.Parameters.AddWithValue("@Level", 0);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Resource res = new Resource();
                            res.Type = "DeviceUnit";
                            res.Key = reader["SchemeDeviceUnitId"];
                            res.Text = String.Format(ResourceStrings.GetString("DeviceUnitLevel."), Convert.ToString(reader["Level"]));
                            res.Attributes["Level"] = Convert.ToString(reader["Level"]);
                            resources.Add(res);

                            resources.AddRange(LoadDeviceUnits(conn, (string)res.Key));
                        }
                    }
                }
            }

            return resources;
        }

        private IEnumerable<Resource> LoadDeviceUnits(SqlConnection conn, string parentId)
        {
            List<Resource> resources = new List<Resource>();

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT [SchemeDeviceUnitId], [Level], [ParentId] FROM [SchemeDeviceUnits] WHERE ParentId=@ParentId ORDER BY [Level],SchemeDeviceUnitId]";
                cmd.Parameters.AddWithValue("@ParentId", parentId);
                    
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Resource res = new Resource();
                        res.Type = "DeviceUnit";
                        res.Key = reader["SchemeDeviceUnitId"];
                        res.Text = String.Format(ResourceStrings.GetString("DeviceUnitLevel."), Convert.ToString(reader["Level"]));
                        res.Attributes["Level"] = Convert.ToString(reader["Level"]);
                        res.Attributes["ParentId"] = reader["ParentId"] != DBNull.Value ? (string)reader["ParentId"] : null;
                        resources.Add(res);

                        resources.AddRange(LoadDeviceUnits(conn, (string)res.Key));
                    }
                }
            }
       
            return resources;
        }

        
        private void PopulateAppointmentParameters(SqlCommand cmd, Appointment apt)
        {
            cmd.Parameters.AddWithValue("@Subject", apt.Subject);
            cmd.Parameters.AddWithValue("@Start", apt.Start);
            cmd.Parameters.AddWithValue("@End", apt.End);

            Resource shift = apt.Resources.GetResourceByType("Shift");
            cmd.Parameters.AddWithValue("@ShiftId", shift.Key);

            Resource deviceUnit = apt.Resources.GetResourceByType("DeviceUnit");
            cmd.Parameters.AddWithValue("@SchemeDeviceUnitId", deviceUnit.Key);
            cmd.Parameters.AddWithValue("@Level", Convert.ToInt32(deviceUnit.Attributes["Level"]));

            cmd.Parameters.AddWithValue("@RecurrenceRule", apt.RecurrenceRule);

            object parentId = DBNull.Value;
            if (apt.RecurrenceParentID != null)
            {
                parentId = apt.RecurrenceParentID;
            }
            cmd.Parameters.AddWithValue("@RecurrenceParentId", parentId);
        }

        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (string.IsNullOrEmpty(name))
            {
                name = "ProductionSchemeProvider";
            }

            base.Initialize(name, config);
        }
    }       
}