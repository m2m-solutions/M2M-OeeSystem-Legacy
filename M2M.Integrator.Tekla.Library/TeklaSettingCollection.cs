using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using M2M.DataCenter;

namespace M2M.Integrator.Tekla.Library
{
	[Serializable()]
	public partial class TeklaSettingCollection : BusinessListBase<TeklaSettingCollection, TeklaSetting>
	{

		#region Business Methods

        public double PollInterval
        {
            get
            {
                TeklaSetting item = GetItem("PollInterval");

                if (item == null)
                {
                    item = Add("PollInterval");
                    item.Value = "1440000";
                }

                return Convert.ToDouble(item.Value);
            }
            set
            {
                TeklaSetting item = GetItem("PollInterval");

                if (item == null)
                    item = Add("PollInterval");

                item.Value = value.ToString();
            }
        }

		public Intervals TransferInterval
		{
			get
			{
				TeklaSetting item = GetItem("TransferInterval");

				if (item == null)
				{
					item = Add("TransferInterval");
					item.Value = Intervals.Monthly.ToString();
				}

				return (Intervals)Enum.Parse(typeof(Intervals),	item.Value);
			}
			set
			{
				TeklaSetting item = GetItem("TransferInterval");

				if (item == null)
					item = Add("TransferInterval");

				item.Value = value.ToString();
			}
		}

		public DayOfWeek TransferDayOfWeek
		{
			get
			{
				TeklaSetting item = GetItem("TransferDayOfWeek");

				if (item == null)
				{
					item = Add("TransferDayOfWeek");

					item.Value = DayOfWeek.Monday.ToString();
					
				}

				return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), item.Value);
			}
			set
			{
				TeklaSetting item = GetItem("TransferDayOfWeek");

				if (item == null)
					item = Add("TransferDayOfWeek");

				item.Value = value.ToString();
			}
		}

		public int TransferDate
		{
			get
			{
				TeklaSetting item = GetItem("TransferDate");

				if (item == null)
				{
					item = Add("TransferDate");
					item.Value = "1";
				}

				return Convert.ToInt32(item.Value);
			}
			set
			{
				TeklaSetting item = GetItem("TransferDate");

				if (item == null)
					item = Add("TransferDate");

				item.Value = value.ToString();
			}
		}

		public DateTime TransferTime
		{
			get
			{
				TeklaSetting item = GetItem("TransferTime");

				if (item == null)
				{
					item = Add("TransferTime");
					DateTime temp = new DateTime(TimeSpan.FromHours(7).Ticks);
					item.Value = temp.ToString("HH:mm");
				}

				return DateTime.ParseExact(item.Value, "HH:mm", null);
			}
			set
			{
				TeklaSetting item = GetItem("TransferTime");

				if (item == null)
					item = Add("TransferTime");

				item.Value = value.ToString("HH:mm");
			}
		}

		/// <summary>
		/// Returns the TeklaSetting object matching the id given.
		/// </summary>		
		public TeklaSetting GetItem(string name)
		{
			foreach (TeklaSetting item in this)
			{
				if (item.Name == name)
				{
					return item;
				}
			}
			return null;

		}

		/// <summary>
		/// Adds a new TeklaSetting object to the collection
		/// </summary>
		public TeklaSetting Add(string name)
		{
			TeklaSetting item = TeklaSetting.NewSetting(name);
			Add(item);
			return item;
		}
		/// <summary>
		/// Removes the TeklaSetting object matching the id given.
		/// </summary>
		public void Remove(string name)
		{
			Remove(GetItem(name));
		}

		/// <summary>
		/// Returns true if a TeklaSetting object matching the id exists.
		/// </summary>
		public bool Contains(string name)
		{
			return (GetItem(name) != null);
		}

		/// <summary>
		/// Returns true if a deleted TeklaSetting object matching the id exists.
		/// </summary>
		public bool ContainsDeleted(string name)
		{
			foreach (TeklaSetting item in DeletedList)
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

		public static TeklaSettingCollection GetSettingCollection()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view TeklaSettingCollection objects");
			return DataPortal.Fetch<TeklaSettingCollection>();
		}


		protected TeklaSettingCollection()
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
										  @" FROM TeklaSettings";

					using (SafeDataReader dataReader = new SafeDataReader(command.ExecuteReader()))
					{
						while (dataReader.Read())
						{
							Add(TeklaSetting.GetSetting(dataReader));
						}
					}
				}
			}

			RaiseListChangedEvents = true;
		}

		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			foreach (TeklaSetting item in DeletedList)
			{
				item.DeleteSelf();
			}
			DeletedList.Clear();

			foreach (TeklaSetting item in this)
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