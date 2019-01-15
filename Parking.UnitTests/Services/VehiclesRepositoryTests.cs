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
            dr.Clear();
            dr.CreateVehicle(new Vehicle("XXX001", Vehicle.Type.Car));
        }

        [TestMethod]
        public void CorrectlyReturnsAllVehicles() {
            List<Vehicle> vehicles = dr.GetAllVehicles();
            Assert.AreEqual(1, vehicles.Count);
            Assert.AreEqual("XXX001", vehicles[0].Id);
            Assert.AreEqual(1, vehicles[0].VehicleType);
        }

        [TestMethod]
        public void CorrectlyReturnsSpecifiedVehicle() {
            Vehicle vehicle = dr.GetVehicle("XXX001");
            Assert.AreEqual("XXX001", vehicle.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Vehicle not found.")]
        public void ThrowsExceptionOnInvalidVehicle() {
            Vehicle vehicle = dr.GetVehicle("INVALID");
        }

        [TestMethod]
        public void CorrectlyCreateAndDeleteVehicle() {
            Vehicle vehicle = new Vehicle("YYY002", Vehicle.Type.Motorcycle);
            Assert.AreEqual(1, dr.GetAllVehicles().Count);
            dr.CreateVehicle(vehicle);
            Assert.AreEqual(2, dr.GetAllVehicles().Count);
            dr.DeleteVehicle(vehicle.Id);
            Assert.AreEqual(1, dr.GetAllVehicles().Count);
        }
    }
}
