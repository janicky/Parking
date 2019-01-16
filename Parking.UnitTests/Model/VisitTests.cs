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
            vehicle = new Vehicle(1, "xxx", Vehicle.Type.Car);
            DateTimeOffset datetime = DateTimeOffset.Now.AddHours(-5);
            visit = new Visit(1, vehicle.Id, datetime.ToUnixTimeSeconds());
        }

        [TestMethod]
        public void IsNotFinished() {
            Assert.AreEqual(false, visit.Finished);
        }

        [TestMethod]
        public void CorrectlyReturnsDuration() {
            var now = DateTimeOffset.Now;
            Assert.AreEqual(5, visit.GetDuration());
        }

        [TestMethod]
        public void CorrectlyFinish() {
            var payment = new Payment(2, 100d);
            Assert.AreEqual(false, visit.Finished);
            visit.Finish();
            Assert.AreEqual(true, visit.Finished);
        }
    }
}
