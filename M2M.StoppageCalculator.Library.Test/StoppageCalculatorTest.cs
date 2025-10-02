using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using M2M.DataCenter;
using Csla;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

namespace M2M.StoppageCalculator.Library.Test
{
    [TestFixture]
    public class StoppageCalculatorTest
    {
        private readonly string divisionId = "DivisionForTest";
        private readonly string machineId1 = "MTest1";
        private readonly string machineId2 = "MTest2";
        private readonly string stop1 = "Stop1";
        private readonly string stop2 = "Stop2";
        private readonly string stop3 = "Stop3";
        
        
        [TestFixtureSetUp]
        public void Setup()
        {
            Database.SystemConnectionString = @"Data Source=SQL2008;Initial Catalog=M2M.DataCenter;uid=DataCenter;pwd=pdQ7718-t;";
            TearDown();
            Division division = Division.NewDivision();
            division.DivisionId = this.divisionId;
            division.Save();

            Machine machine = Machine.NewMachine();
            machine.MachineId = this.machineId1;
            machine.DivisionId = this.divisionId;
            machine.Save();

            machine = Machine.NewMachine();
            machine.MachineId = this.machineId2;
            machine.DivisionId = this.divisionId;
            machine.Save();

            TagInfoCollection tags = TagInfoCollection.NewTagInfoCollection();
            TagInfo tag = tags.Add(this.machineId1, String.Format("{0}.{1}", this.divisionId, this.machineId1), stop1);
            tag.DisplayName = "Stopp 1";
            tag = tags.Add(this.machineId1, String.Format("{0}.{1}", this.divisionId, this.machineId1), stop2);
            tag.DisplayName = "Stopp 2";
            tag = tags.Add(this.machineId1, String.Format("{0}.{1}", this.divisionId, this.machineId1), stop3);
            tag.DisplayName = "Stopp 3";
            tag = tags.Add(this.machineId2, String.Format("{0}.{1}", this.divisionId, this.machineId2), stop1);
            tag.DisplayName = "Stopp 1";
            tag = tags.Add(this.machineId2, String.Format("{0}.{1}", this.divisionId, this.machineId2), stop2);
            tag.DisplayName = "Stopp 2";
            tag = tags.Add(this.machineId2, String.Format("{0}.{1}", this.divisionId, this.machineId2), stop3);
            tag.DisplayName = "Stopp 3";
            tags.Save();

            Appointment apt = new Appointment();
            apt.Start = DateTime.Today.AddDays(-2).AddHours(2);
            apt.End = DateTime.Today.AddDays(-2).AddHours(6);
            RecurrenceRange rrange = new RecurrenceRange();
            rrange.Start = apt.Start;
            rrange.EventDuration = apt.End - apt.Start;
            rrange.MaxOccurrences = 3;
            RecurrenceRule rrule = new DailyRecurrenceRule(1, rrange);
            apt.RecurrenceRule = rrule.ToString();

            ProductionSchemeItem item = ProductionSchemeItem.NewProductionSchemeItem();
            item.Shift = 0;
            item.StartTime = apt.Start;
            item.EndTime = apt.End;
            item.RecurrenceRule = apt.RecurrenceRule;
            item.DivisionId = this.divisionId;
            item.Save();

            apt = new Appointment();
            apt.Start = DateTime.Today.AddDays(-2).AddHours(9);
            apt.End = DateTime.Today.AddDays(-2).AddHours(13);
            rrange = new RecurrenceRange();
            rrange.Start = apt.Start;
            rrange.EventDuration = apt.End - apt.Start;
            rrange.MaxOccurrences = 3;
            rrule = new DailyRecurrenceRule(1, rrange);
            apt.RecurrenceRule = rrule.ToString();

            item = ProductionSchemeItem.NewProductionSchemeItem();
            item.Shift = 0;
            item.StartTime = apt.Start;
            item.EndTime = apt.End;
            item.RecurrenceRule = apt.RecurrenceRule;
            item.DivisionId = this.divisionId;
            item.Save();

            apt = new Appointment();
            apt.Start = DateTime.Today.AddDays(-2).AddHours(16);
            apt.End = DateTime.Today.AddDays(-2).AddHours(21);
            rrange = new RecurrenceRange();
            rrange.Start = apt.Start;
            rrange.EventDuration = apt.End - apt.Start;
            rrange.MaxOccurrences = 3;
            rrule = new DailyRecurrenceRule(1, rrange);
            apt.RecurrenceRule = rrule.ToString();

            item = ProductionSchemeItem.NewProductionSchemeItem();
            item.Shift = 0;
            item.StartTime = apt.Start;
            item.EndTime = apt.End;
            item.RecurrenceRule = apt.RecurrenceRule;
            item.DivisionId = this.divisionId;
            item.Save();


            Event stop;// = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddDays(-1).AddHours(3));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddDays(-1).AddHours(5));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId1;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId1, this.stop1);
            //stop.Save();

            stop = Event.NewEvent();
            stop.EventRaised = new SmartDate(DateTime.Today.AddHours(3));
            stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(5));
            stop.DivisionId = this.divisionId;
            stop.MachineId = this.machineId1;
            stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId1, this.stop1);
            stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(3));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(5));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId1;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId1, this.stop1);
            //stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(3));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(5));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId1;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId1, this.stop2);
            //stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(12));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(15));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId1;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId1, this.stop2);
            //stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(1));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(23));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId1;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId1, this.stop3);
            //stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(1));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(3));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId2;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId2, this.stop1);
            //stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(5));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(12));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId2;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId2, this.stop1);
            //stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(9));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(13));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId2;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId2, this.stop2);
            //stop.Save();

            //stop = Event.NewEvent();
            //stop.EventRaised = new SmartDate(DateTime.Today.AddHours(5));
            //stop.TimeForNextEvent = new SmartDate(DateTime.Today.AddHours(20));
            //stop.DivisionId = this.divisionId;
            //stop.MachineId = this.machineId2;
            //stop.TagId = String.Format("{0}.{1}.{2}", this.divisionId, this.machineId2, this.stop3);
            //stop.Save();

            StoppageCalculateRequest request = StoppageCalculateRequest.NewStoppageCalculateRequest();
            request.DivisionId = this.divisionId;
            request.StartDate = new SmartDate(DateTime.Today);
            request.EndDate = new SmartDate(DateTime.Now);
            request.Save();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            StoppageDataCollection stoppages = StoppageDataCollection.GetStoppageDataCollection(this.divisionId, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(1));
            stoppages.Clear();
            stoppages.Save();

            StoppageCalculateRequestCollection requests = StoppageCalculateRequestCollection.GetStoppageCalculateRequestCollection(this.divisionId);
            requests.Clear();
            requests.Save();

            ProductionSchemeItemCollection collection = ProductionSchemeItemCollection.GetProductionSchemeItemCollection(this.divisionId);
            collection.Clear();
            collection.Save();

            ClearEvents();

            TagInfoCollection tags = TagInfoCollection.GetTagInfoCollection(this.machineId1);
            tags.Clear();
            tags.Save();

            tags = TagInfoCollection.GetTagInfoCollection(this.machineId2);
            tags.Clear();
            tags.Save();

            Machine machine = Machine.GetMachine(this.machineId1);
            machine.Delete();
            machine.Save();

            machine = Machine.GetMachine(this.machineId2);
            machine.Delete();
            machine.Save();

            Division division = Division.GetDivision(this.divisionId);
            division.Delete();
            division.Save();
        }

        private void ClearEvents()
        {
            using(SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM Events WHERE MachineId=@MachineId1 OR MachineId=@MachineId2";
                    command.Parameters.AddWithValue("@MachineId1", this.machineId1);
                    command.Parameters.AddWithValue("@MachineId2", this.machineId2);
                    command.ExecuteNonQuery();
                }
            }
        }

        [Test]
        public void TestStoppageCalculateRequest()
        {
            StoppageCalculateRequestCollection collection = StoppageCalculateRequestCollection.GetStoppageCalculateRequestCollection(this.divisionId);

            Assert.AreEqual(1, collection.Count);

            StoppageCalculateRequest item = collection[0];

            Assert.AreEqual(this.divisionId, item.DivisionId);
            Assert.AreEqual(new SmartDate(DateTime.Today).Date, item.StartDate.Date);
            Assert.AreEqual(new SmartDate(DateTime.Today.AddHours(20)).Date, item.EndDate.Date);
        }

        [Test]
        public void TestStoppageCalculation()
        {
            int groupCount = 10;
            DateTime start = DateTime.Now;
            StoppageCalculator.CalculateStoppageData(this.divisionId, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-1));
            StoppageCalculator.CalculateStoppageData(this.divisionId, DateTime.Today.AddDays(-1), DateTime.Today);
            StoppageCalculator.CalculateStoppageData(this.divisionId, DateTime.Today, DateTime.Today.AddDays(1));
            Console.WriteLine(DateTime.Now.Subtract(start).TotalMilliseconds);
            start = DateTime.Now; 
            StoppageDataList.Criteria criteria = new StoppageDataList.Criteria();
            criteria.DivisionId = "Automat_press";// this.divisionId;
            criteria.MachineId = "117";
            criteria.SystemError = false;
            criteria.StartTime = new SmartDate(new DateTime(2011, 8, 1, 0, 0, 0)); //DateTime.Today.AddDays(-2);
            criteria.EndTime = new SmartDate(new DateTime(2011, 9, 1, 0, 0, 0)); //DateTime.Today.AddDays(1);
            StoppageDataList stoppages = StoppageDataList.GetStoppageDataList(criteria);
            Console.WriteLine(DateTime.Now.Subtract(start).TotalMilliseconds);

            start = DateTime.Now;
            List<AggregatedStoppageDataListItem> topCount = stoppages.GetTopCount(groupCount, true);
            List<AggregatedStoppageDataListItem> topTimes = stoppages.GetTopTimes(groupCount, true);
            Console.WriteLine(DateTime.Now.Subtract(start).TotalMilliseconds);
            Console.WriteLine(stoppages.Count);

            Console.WriteLine("------------------------------");
            //foreach (StoppageDataListItem item in topCount1)
            //    Console.WriteLine("{0}.{1}.{2} - {3}", item.DivisionId, item.MachineId, item.StopReason, item.NumberOfStops);
            //Console.WriteLine("Total - {0}", topCount1.Sum(a => a.NumberOfStops));
            //Console.WriteLine("------------------------------");
            //foreach (StoppageDataListItem item in topTimes1)
            //    Console.WriteLine("{0}.{1}.{2} - {3}", item.DivisionId, item.MachineId, item.StopReason, item.ElapsedTime);
            //Console.WriteLine("Total - {0}", topTimes1.Sum(a => a.ElapsedTime));
            //Console.WriteLine("------------------------------");
            foreach (AggregatedStoppageDataListItem item in topCount)
                Console.WriteLine("{0}.{1}.{2} - {3}", item.DivisionId, item.MachineId, item.Reason, item.NumberOfStops);
            Console.WriteLine("Total - {0}", topCount.Sum(a => a.NumberOfStops));
            Console.WriteLine("------------------------------");
            foreach (AggregatedStoppageDataListItem item in topTimes)
                Console.WriteLine("{0}.{1}.{2} - {3}", item.DivisionId, item.MachineId, item.Reason, item.ElapsedTimeInSeconds);
            Console.WriteLine("Total - {0}", topTimes.Sum(a => a.ElapsedTimeInSeconds));
                        
        }
    }
}