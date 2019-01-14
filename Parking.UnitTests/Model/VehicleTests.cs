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

        [TestInitialize]
        public void TestInitialize() {
            vehicle = new Vehicle("evt2103", Vehicle.VehicleType.Car);
        }

        [TestMethod]
        public void CorrectlyAddVisits() {
            Assert.AreEqual(0, vehicle.GetVisits().Count);
        }
    }
}