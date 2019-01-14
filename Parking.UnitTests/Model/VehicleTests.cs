using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Model;

namespace Parking.UnitTests.Model {
    [TestClass]
    public class VehicleTests {
        private Vehicle vehicle;
        private Visit visit;

        [TestInitialize]
        public void TestInitialize() {
            vehicle = new Vehicle("evt2103", Vehicle.VehicleType.Car);
            visit = new Visit(1, vehicle, DateTimeOffset.Now);
        }

        [TestMethod]
        public void CorrectlyAddVisit() {
            Assert.AreEqual(0, vehicle.GetVisits().Count);
            vehicle.AddVisit(visit);
            Assert.AreEqual(1, vehicle.GetVisits().Count);
        }

        [TestMethod]
        public void CorrectlyRemoveVisit() {
            vehicle.AddVisit(visit);
            Assert.AreEqual(1, vehicle.GetVisits().Count);
            vehicle.RemoveVisit(visit);
            Assert.AreEqual(0, vehicle.GetVisits().Count);
        }
    }
}