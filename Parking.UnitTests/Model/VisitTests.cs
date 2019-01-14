using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Model;

namespace Parking.UnitTests.Model {
    [TestClass]
    public class VisitTests {

        private Vehicle vehicle;
        private Visit visit;

        [TestInitialize]
        public void TestInitialize() {
            vehicle = new Vehicle("xxx", Vehicle.VehicleType.Car);
            visit = new Visit(1, vehicle, DateTimeOffset.Now);
        }

        [TestMethod]
        public void IsNotFinished() {
            Assert.AreEqual(false, visit.IsFinished());
        }
    }
}
