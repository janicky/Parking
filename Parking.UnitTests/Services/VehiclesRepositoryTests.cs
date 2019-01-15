using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLitePCL;
using Parking.Model;
using Parking.Services;
using System.Collections.Generic;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class VehiclesRepositoryTests {
        private DataRepository dr = new DataRepository();

        [TestInitialize]
        public void InitializeTest() {
            Batteries_V2.Init();
        }

        [TestMethod]
        public void CorrectlyReturnsAllVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>(dr.GetAllVehicles());
            Assert.AreEqual(1, vehicles.Count);
            Assert.AreEqual("XXX001", vehicles[0].Id);
            Assert.AreEqual(1, vehicles[0].VehicleType);
        }

        [TestMethod]
        public void CorrectlyReturnsSpecifiedVehicle() {
            Vehicle vehicle = dr.GetVehicle("XXX001");
            Assert.AreEqual("XXX001", vehicle.Id);

            Vehicle incorrect_vehicle = dr.GetVehicle("XXX002");
            Assert.AreEqual("XXX001", incorrect_vehicle.Id);
        }
    }
}
