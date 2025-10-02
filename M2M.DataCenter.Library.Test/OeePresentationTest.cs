using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Telerik.Web.UI;

namespace M2M.DataCenter.Library.Test
{
    [TestFixture]
    public class OeePresentationTest
    {
        private readonly string divisionId = "DivisionForTest";
        private readonly string machineId1 = "MTest1";
        private readonly string machineId2 = "MTest2";
        private readonly string machineId3 = "MTest3";
        
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
            machine.IdealRunRate = 1800;
            machine.AggregateCounter = true;
            machine.Save();

            machine = Machine.NewMachine();
            machine.MachineId = this.machineId2;
            machine.DivisionId = this.divisionId;
            machine.IdealRunRate = 1800;
            machine.Save();

            machine = Machine.NewMachine();
            machine.MachineId = this.machineId3;
            machine.DivisionId = this.divisionId;
            machine.IdealRunRate = 1800;
            machine.Save();
            
            Appointment apt = new Appointment();
            apt.Start =  DateTime.Today.AddHours(8);
            apt.End = DateTime.Today.AddHours(17);
            RecurrenceRange rrange = new RecurrenceRange();
            rrange.Start = apt.Start;
            rrange.EventDuration = apt.End - apt.Start;
            rrange.MaxOccurrences = 3;
            RecurrenceRule rrule = new DailyRecurrenceRule(1, rrange);
            rrule.Exceptions.Add(apt.Start.AddDays(1));
            apt.RecurrenceRule = rrule.ToString();
            
            ProductionSchemeItem item = ProductionSchemeItem.NewProductionSchemeItem();
            item.Shift = 0;
            item.StartTime = apt.Start;
            item.EndTime = apt.End;
            item.RecurrenceRule = apt.RecurrenceRule;
            item.DivisionId = this.divisionId;
            item.Save();

            OeeData oeeData = OeeData.NewOeeDataRoot();
            oeeData.DivisionId = this.divisionId;
            oeeData.MachineId = this.machineId1;
            oeeData.StartTime = new Csla.SmartDate(DateTime.Today.AddHours(9));
            oeeData.EndTime = new Csla.SmartDate(DateTime.Today.AddHours(12));
            oeeData.AutoTime = 5000;
            oeeData.ProducedItems = 1500;
            oeeData.DiscardedItems = 150;
            oeeData.Save();

            oeeData = OeeData.NewOeeDataRoot();
            oeeData.DivisionId = this.divisionId;
            oeeData.MachineId = this.machineId2;
            oeeData.StartTime = new Csla.SmartDate(DateTime.Today.AddHours(9));
            oeeData.EndTime = new Csla.SmartDate(DateTime.Today.AddHours(12));
            oeeData.AutoTime = 5000;
            oeeData.ProducedItems = 1500;
            oeeData.DiscardedItems = 150;
            oeeData.Save();

            oeeData = OeeData.NewOeeDataRoot();
            oeeData.DivisionId = this.divisionId;
            oeeData.MachineId = this.machineId3;
            oeeData.StartTime = new Csla.SmartDate(DateTime.Today.AddHours(9));
            oeeData.EndTime = new Csla.SmartDate(DateTime.Today.AddHours(12));
            oeeData.AutoTime = 5400;
            oeeData.ProducedItems = 1500;
            oeeData.DiscardedItems = 0;
            oeeData.Save();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            ProductionSchemeItemCollection collection = ProductionSchemeItemCollection.GetProductionSchemeItemCollection(this.divisionId);
            collection.Clear();
            collection.Save();

            OeeDataCollection oeeData = OeeDataCollection.GetOeeDataCollection(this.divisionId, new Csla.SmartDate(DateTime.Today), new Csla.SmartDate(DateTime.Today.AddDays(1)));
            oeeData.Clear();
            oeeData.Save();

            Machine machine = Machine.GetMachine(this.machineId1);
            machine.Delete();
            machine.Save();

            machine = Machine.GetMachine(this.machineId2);
            machine.Delete();
            machine.Save();

            machine = Machine.GetMachine(this.machineId3);
            machine.Delete();
            machine.Save();

            Division division = Division.GetDivision(this.divisionId);
            division.Delete();
            division.Save();
        }

        [Test]
        public void TestOeeForDivision()
        {
            OEEForMachine.Criteria criteria = new OEEForMachine.Criteria();
            criteria.StartDate = new Csla.SmartDate(DateTime.Today);
            criteria.EndDate = new Csla.SmartDate(DateTime.Today.AddDays(1));
            criteria.ChartSettings = new ChartSettings(criteria.StartDate.Date.Date, criteria.EndDate.Date.Date, (criteria.EndDate - criteria.StartDate).TotalDays > 40 ? Intervals.Weekly : Intervals.Daily);
            OEEForFacility facility = OEEForFacility.GetOEEForFacility(criteria);

            
            foreach (OEEForFacilityTimePart division in facility)
            {
                Assert.AreEqual(0.5m, division.Availability);
                Assert.AreEqual(0.5m, division.Performance);
                Assert.AreEqual(0.8m, division.Quality); 
            }

            
        }

        [Test]
        public void TestOeeList()
        {
            MachineList.Criteria criteria = new MachineList.Criteria();
            criteria.DivisionId = this.divisionId;
            criteria.StartDate = new Csla.SmartDate(DateTime.Today);
            criteria.EndDate = new Csla.SmartDate(DateTime.Today.AddDays(1));
            DivisionListItem division = DivisionListItem.GetDivisionListItem(criteria);

            Assert.AreEqual(0.5m, division.Availability);
            Assert.AreEqual(0.5m, division.Performance);
            Assert.AreEqual(0.8m, division.Quality); 
            
        }
    }
}
