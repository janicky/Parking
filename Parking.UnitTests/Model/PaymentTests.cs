using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Model;

namespace Parking.UnitTests.Model {
    [TestClass]
    public class PaymentTests {
        [TestMethod]
        public void CorrectlyInitialize() {
            Vehicle vehicle = new Vehicle(1, "yyy", Vehicle.Type.Motorcycle);
            DateTimeOffset datetime = DateTimeOffset.Now.AddHours(-2);
            Payment payment = new Payment(1, 100d);
        }
    }
}
