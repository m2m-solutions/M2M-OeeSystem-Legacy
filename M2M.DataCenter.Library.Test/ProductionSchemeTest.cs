using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Telerik.Web.UI;

namespace M2M.DataCenter.Library.Test
{
    [TestFixture]
    public class ProductionSchemeTest
    {
        private readonly string divisionId = "DivisionForTest";
        
        [TestFixtureSetUp]
        public void Setup()
        {
            TearDown();
            Division division = Division.NewDivision();
            division.DivisionId = this.divisionId;
            division.Save();

            Appointment apt = new Appointment();
            apt.Start =  DateTime.Today.AddHours(8);
            apt.End = DateTime.Today.AddHours(12);
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
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            ProductionSchemeItemCollection collection = ProductionSchemeItemCollection.GetProductionSchemeItemCollection(this.divisionId);
            collection.Clear();
            collection.Save();

            Division division = Division.GetDivision(this.divisionId);
            division.Delete();
            division.Save();
        }

        [Test]
        public void TestExpandedProductionScheme()
        {
            DateTime start = DateTime.Today.AddDays(2).AddHours(10);
            DateTime end = DateTime.Today.AddDays(2).AddHours(11);
            ExpandedProductionScheme collection = ExpandedProductionScheme.GetExpandedProductionScheme(this.divisionId, start, end);

            Assert.AreEqual(1, collection.Count);

            ExpandedProductionSchemeItem item = collection[0];

            Assert.AreEqual(this.divisionId, item.DivisionId);
            Assert.AreEqual(0, item.Shift);
        }
    }
}
