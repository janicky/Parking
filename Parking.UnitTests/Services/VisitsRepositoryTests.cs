using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Model;
using Parking.Services;
using System.Collections.Generic;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class VisitsRepositoryTests {
        private DataRepository dr = new DataRepository();
        private Visit vis;

        [TestInitialize]
        public void InitializeTest() {
            dr.Clear();
            vis = new Visit(1, 1, DateTimeOffset.Now.AddHours(-2).ToUnixTimeSeconds());
            dr.CreateVisit(vis);
        }

        [TestMethod]
        public void CorrectlyReturnsAllVisits() {
            List<Visit> visits = dr.GetAllVisits();
            Assert.AreEqual(1, visits.Count);
            Assert.AreEqual(2, visits[0].GetDuration());
        }

        [TestMethod]
        public void CorrectlyReturnsSpecifiedVisit() {
            Visit visit = dr.GetVisit(vis.Id);
            Assert.AreEqual(vis.Id, visit.Id);
            Assert.AreEqual(1, visit.VehicleId);
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
            Visit visit = new Visit(2, 1, start.ToUnixTimeSeconds(), start.AddHours(1).ToUnixTimeSeconds());
            Assert.AreEqual(1, dr.GetAllVisits().Count);
            dr.CreateVisit(visit);
            Assert.AreEqual(2, dr.GetAllVisits().Count);
            dr.DeleteVisit(visit.Id);
            Assert.AreEqual(1, dr.GetAllVisits().Count);
        }
    }
}
