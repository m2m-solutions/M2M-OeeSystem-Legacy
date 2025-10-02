using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using M2M.DataCenter;
using M2M.DataCenter.Utilities;
using Csla;

namespace M2M.Integrator.Tekla.Library
{
	public class TeklaTransfer: IJob
	{
		public TeklaTransfer()
		{
		}

		private class ServiceData
		{
			private string m_ObjectId = "";
			private long m_Ticks = 0;
			private int m_ProducedItems = 0;

			public string ObjectId
			{
				get { return m_ObjectId; }
			}

			public long Ticks
			{
				get { return m_Ticks; }
				set { m_Ticks = value; }
			}

			public int ProducedItems
			{
				get { return m_ProducedItems; }
				set { m_ProducedItems = value; }
			}

			public ServiceData(string objectId)
			{
				m_ObjectId = objectId;
			}

			public static Predicate<ServiceData> ByObjectId(string objectId)
			{
				return delegate(ServiceData item) { return item.ObjectId == objectId; };
			}
		}
 
		public void Execute(JobExecutionContext context)
		{
			Console.WriteLine("Start transfer to Tekla");
			SmartDate transferTime = new SmartDate(DateTime.Now);
			SmartDate latestTransfer = new SmartDate();
			string error = "";
			try
			{
				
				latestTransfer = TransferLogEntry.LatestTransfer;

                // Add support for fetching states ignoring scheme
                //StateList.Criteria criteria = new StateList.Criteria();
                //criteria.StateType = StateType.Auto;
                //criteria.StartDate = latestTransfer;
                //StateList states = StateList.GetStateList(criteria);
                //Console.WriteLine("Processing " + states.Count + " rows");  
                //List<ServiceData> serviceDataList = new List<ServiceData>();
                //int cnt = 0;
                //foreach (StateListItem state in states)
                //{
                //    if (state.TimeStampOnReset != null
                //        && state.TimeStampOnReset >= state.TimeStampOnSet
                //        && state.NumberOfItems >= 0)
                //    {
                //        string objectId = ObjectIdHelper.GetObjectId(state);
                //        if (objectId != "")
                //        {
                //            ServiceData serviceData = serviceDataList.Find(ServiceData.ByObjectId(objectId));
                //            if (serviceData == null)
                //            {
                //                serviceData = new ServiceData(objectId);
                //                serviceDataList.Add(serviceData);
                //            }

                //            serviceData.Ticks += (state.TimeStampOnReset.Date.Ticks - state.TimeStampOnSet.Date.Ticks);
                //            serviceData.ProducedItems += state.NumberOfItems;
                //        }
                //    }
                //    cnt++;
                //    string s = string.Format("Reading progress: {0:F}%\r", 100.0f * ((float)cnt) / ((float)states.Count));
                //    Console.Write(s);
                //}

                //cnt = 0;
                //Console.WriteLine();
                //foreach (ServiceData serviceData in serviceDataList)
                //{
                //    JournalPost journalPost = JournalPost.NewJournalPost();
                //    journalPost.MachineId = serviceData.ObjectId;
                //    journalPost.EntryValue = Convert.ToDecimal(TimeSpan.FromTicks(serviceData.Ticks).TotalHours);
                //    journalPost.EntryUnit = EntryUnit.Hours;
                //    journalPost.JournalDate = transferTime;
                //    journalPost.Save();

                //    journalPost = JournalPost.NewJournalPost();
                //    journalPost.MachineId = serviceData.ObjectId;
                //    journalPost.EntryValue = Convert.ToDecimal(serviceData.ProducedItems);
                //    journalPost.EntryUnit = EntryUnit.ProducedItems;
                //    journalPost.JournalDate = transferTime;
                //    journalPost.Save();

                //    cnt++;
                //    string s = string.Format("Writing progress: {0:F}%\r", 100.0f * ((float)cnt) / ((float)serviceDataList.Count));
                //    Console.Write(s);
                //}

				Console.WriteLine();
				Console.WriteLine("Transfer to Tekla successful.");

				

			}
			catch (Exception ex)
			{
				Console.WriteLine("Transfer to Tekla failed");
				Console.WriteLine(ex.ToString());
				error = ex.Message.SafeSubstring(0, 100); 
			}
			finally
			{
				try
				{
					TransferLogEntry logEntry = TransferLogEntry.NewTransferLogEntry();
					logEntry.TransferDate = error == "" ? transferTime : latestTransfer;
					logEntry.TimeConsumed = DateTime.Now.Ticks - transferTime.Date.Ticks;
					logEntry.Error = error;
					logEntry.Save();
				}
				catch(Exception ex)
				{
					Console.WriteLine("Failed to log transfer");
					Console.WriteLine(ex.ToString());
				}
				Console.WriteLine("Press any key to exit program...");
			}
		}
	}


} 
