using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class PlainMachineList : ReadOnlyListBase<PlainMachineList, PlainMachineListItem>
	{
        public PlainMachineListItem GetMachine(string divisionId, string machineId)
        {
            foreach (PlainMachineListItem item in this.Items)
            {
                if (item.DivisionId == divisionId && item.MachineId == machineId)
                    return item;
            }

            return null;
        }

       
		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

        public static PlainMachineList GetMachineList()
        {
            return DataPortal.Fetch<PlainMachineList>(new Criteria());
        }

		public static PlainMachineList GetMachineList(string divisionId)
		{
			return DataPortal.Fetch<PlainMachineList>(new Criteria(divisionId));
		}

		protected PlainMachineList()
		{
			/* require use of factory methods */
		}
		
		#endregion

		#region Data Access

		[Serializable()]
		internal class Criteria
		{
            private readonly string m_DivisionId = null;
			
			public string DivisionId
			{
				get { return m_DivisionId; }
			}

            public Criteria()
            {
            }

			public Criteria(string divisionId)
			{
				m_DivisionId = divisionId;
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
                        whereClause = " WHERE d.DivisionId=@DivisionId";
                        command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);
                    }

                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT m.MachineId,m.DisplayName,m.ShortName,m.Notes,m.DivisionId,d.DisplayName as DivisionName" +
                                          @" FROM Machines m JOIN Divisions d ON m.DivisionId=d.DivisionId" + whereClause +
                                          @" ORDER BY DivisionName,MachineId ASC";
					
                    using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(PlainMachineListItem.GetMachineListItem(dataReader));
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