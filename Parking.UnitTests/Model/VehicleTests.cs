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

        [TestMethod]
        public void TestInitialize() {
            vehicle = new Vehicle("evt2103", Vehicle.Type.Car);
            visit = new Visit(1, vehicle.Id, 1, DateTimeOffset.Now.ToUnixTimeSeconds());
        }
    }
}