using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Model;
using Parking.Services;
using System.Collections.Generic;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class VisitsRepositoryTests {
        private DataRepository dr = new DataRepository();

        [TestInitialize]
        public void InitializeTest() {
            dr.Clear();
            dr.CreateVisit(new Visit(1, "XXX001", DateTimeOffset.Now.AddHours(-2).ToUnixTimeSeconds()));
        }

        [TestMethod]
        public void CorrectlyReturnsAllVisits() {
            List<Visit> visits = dr.GetAllVisits();
            Assert.AreEqual(1, visits.Count);
            Assert.AreEqual("XXX001", visits[0].VehicleId);
            Assert.AreEqual(2, visits[0].GetDuration());
        }

        [TestMethod]
        public void CorrectlyReturnsSpecifiedVisit() {
            Visit visit = dr.GetVisit(1);
            Assert.AreEqual(1, visit.Id);
            Assert.AreEqual("XXX001", visit.VehicleId);
            Assert.AreEqual(2, visit.GetDuration());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Visit not found.")]
        public void ThrowsExceptionOnInvalidVisit() {
            Visit visit = dr.GetVisit(-1);
        }

        [TestMethod]
        public void CorrectlyCreateAndDeleteVisit() {
            var start = DateTimeOffset.Now.AddHours(-24);
            Visit visit = new Visit(2, "XXX001", start.ToUnixTimeSeconds(), start.AddHours(1).ToUnixTimeSeconds());
            Assert.AreEqual(1, dr.GetAllVisits().Count);
            dr.CreateVisit(visit);
            Assert.AreEqual(2, dr.GetAllVisits().Count);
            dr.DeleteVisit(visit.Id);
            Assert.AreEqual(1, dr.GetAllVisits().Count);
        }

        [TestMethod]
        public void CorrectlyUpdateVisit() {
            Visit visit = dr.GetVisit(1);
            Assert.AreEqual("XXX001", visit.VehicleId);
            visit.VehicleId = "XXX002";
            dr.UpdateVisit(visit);

            Visit updated_visit = dr.GetVisit(1);
            Assert.AreEqual("XXX002", updated_visit.VehicleId);
        }
    }
}
