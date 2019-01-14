using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Model;

namespace Parking.UnitTests.Model {
    [TestClass]
    public class PaymentTests {
        [TestMethod]
        public void CorrectlyInitialize() {
            Vehicle vehicle = new Vehicle("yyy", Vehicle.VehicleTypes.Motorcycle);
            DateTimeOffset datetime = DateTimeOffset.Now.AddHours(-2);
            Visit visit = new Visit(1, vehicle, datetime);
            Payment payment = new Payment(1, visit, 100d);
        }
    }
}
