using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Csla;
using M2M.DataCenter;

namespace M2M.OeeCalculator.Library.Test
{
    [TestFixture]
    public class OeeCalculatorTest
    {
        private readonly string divisionId = "DivisionForTest";
        
        [TestFixtureSetUp]
        public void Setup()
        {
            TearDown();
            Division division = Division.NewDivision();
            division.DivisionId = this.divisionId;
            division.Save();

        
            division.Save();

            OeeCalculateRequest request = OeeCalculateRequest.NewOeeCalculateRequest();
            request.DivisionId = this.divisionId;
            request.StartDate = new SmartDate(DateTime.Today);
            request.EndDate = new SmartDate(DateTime.Today.AddHours(12));
            request.Save();

        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            OeeCalculateRequestCollection collection = OeeCalculateRequestCollection.GetOeeCalculateRequestCollection(this.divisionId);
            collection.Clear();
            collection.Save();

            Division division = Division.GetDivision(this.divisionId);
            division.Delete();
            division.Save();
        }

        [Test]
        public void TestOeeCalculateRequest()
        {
            OeeCalculateRequestCollection collection = OeeCalculateRequestCollection.GetOeeCalculateRequestCollection(this.divisionId);

            Assert.AreEqual(1, collection.Count);

            OeeCalculateRequest item = collection[0];

            Assert.AreEqual(this.divisionId, item.DivisionId);
            Assert.AreEqual(new SmartDate(DateTime.Today), item.StartDate);
            Assert.AreEqual(new SmartDate(DateTime.Today.AddHours(12)), item.EndDate);
        }
    }
}
