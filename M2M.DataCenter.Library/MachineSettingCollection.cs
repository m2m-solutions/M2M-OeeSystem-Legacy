using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public partial class MachineSettingCollection : BusinessListBase<MachineSettingCollection, MachineSetting>
	{

		#region Business Methods

		

		// Parent Id member variables 

		protected string m_MachineId;

		/// <summary>
		/// Returns the MachineSetting object matching the id given.
		/// </summary>		
		public MachineSetting GetItem(string name)
		{
			foreach(MachineSetting item in this)
			{
				if (item.Name == name)
				{
					return item;
				}
			}
			return null;
			
		}

		/// <summary>
		/// Adds a new MachineSetting object to the collection
		/// </summary>
		public MachineSetting Add(string name)
		{
			MachineSetting item = MachineSetting.NewMachineSetting(m_MachineId, name);
			Add(item);
			return item;
		}
		/// <summary>
		/// Removes the MachineSetting object matching the id given.
		/// </summary>
		public void Remove(string name)
		{
			Remove(GetItem(name));			
		}

		/// <summary>
		/// Returns true if a MachineSetting object matching the id exists.
		/// </summary>
		public bool Contains(string name)
		{
			return (GetItem(name) != null);
		}

		/// <summary>
		/// Returns true if a deleted MachineSetting object matching the id exists.
		/// </summary>
		public bool ContainsDeleted(string name)
		{
			foreach(MachineSetting item in DeletedList)
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

		internal static MachineSettingCollection NewMachineSettingCollection(string machineId)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add MachineSettingCollection objects");
			return new MachineSettingCollection(machineId, false);
		}

		internal static MachineSettingCollection GetMachineSettingCollection(string machineId)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view MachineSettingCollection objects");
				return new MachineSettingCollection(machineId, true);
		}

		protected MachineSettingCollection()
		{
		
			MarkAsChild();
		
		}

		
		protected MachineSettingCollection(string machineId, bool fetch) : this()
		{	
			m_MachineId = machineId;

			if (fetch)
				Fetch();
		}
		
		#endregion
	
		#region Data Access

		
		private void Fetch()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT MachineId,Setting,Value,LastModified" +
	                                      @" FROM MachineSettings" + 
	                                      @" WHERE MachineId=@MachineId";

					command.Parameters.AddWithValue(@"@MachineId", m_MachineId);

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(MachineSetting.GetMachineSetting(dataReader));
						}
					}
				}
			}		
			
			RaiseListChangedEvents = true;
		}

		internal void Update()
		{
			RaiseListChangedEvents = false;
			SqlConnection connection;
			bool createdConnection = false;
			if (ApplicationContext.LocalContext["cn"] != null)
			{
				connection = (SqlConnection)ApplicationContext.LocalContext["cn"];
			}
			else
			{
				createdConnection = true;
				connection = new SqlConnection(Database.SystemConnectionString);
				connection.Open();
				ApplicationContext.LocalContext["cn"] = connection;
			}
			foreach (MachineSetting item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();
			
			foreach (MachineSetting item in this)
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
			if (createdConnection && (ApplicationContext.ExecutionLocation==ApplicationContext.ExecutionLocations.Client))
			{
				ApplicationContext.LocalContext.Remove("cn");
				connection.Dispose();
			}

			RaiseListChangedEvents = true;
		}

		#endregion
	}
}