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
            vehicle = new Vehicle("xxx", Vehicle.Type.Car);
            DateTimeOffset datetime = DateTimeOffset.Now.AddHours(-5);
            visit = new Visit(1, vehicle, datetime);
        }

        [TestMethod]
        public void IsNotFinished() {
            Assert.AreEqual(false, visit.IsFinished());
        }

        [TestMethod]
        public void CorrectlyReturnsDuration() {
            Assert.AreEqual(5, visit.GetDuration());
        }

        [TestMethod]
        public void CorrectlyFinish() {
            var payment = new Payment(2, visit, 100d);
            Assert.AreEqual(false, visit.IsFinished());
            visit.Finish(payment);
            Assert.AreEqual(true, visit.IsFinished());
        }
    }
}
