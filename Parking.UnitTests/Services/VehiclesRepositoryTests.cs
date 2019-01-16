using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Model;
using Parking.Services;
using System.Collections.Generic;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class VehiclesRepositoryTests {
        private DataRepository dr = new DataRepository();
        private Vehicle veh;

        [TestInitialize]
        public void InitializeTest() {
            dr.Clear();
            veh = new Vehicle(1, "XXX001", Vehicle.Type.Car);
            dr.CreateVehicle(veh);
        }

        [TestMethod]
        public void CorrectlyReturnsAllVehicles() {
            List<Vehicle> vehicles = dr.GetAllVehicles();
            Assert.AreEqual(1, vehicles.Count);
            Assert.AreEqual("XXX001", vehicles[0].Plate);
            Assert.AreEqual(1, vehicles[0].VehicleType);
        }

        [TestMethod]
        public void CorrectlyReturnsSpecifiedVehicle() {
            Vehicle vehicle = dr.GetVehicle(veh.Id);
            Assert.AreEqual("XXX001", vehicle.Plate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Vehicle not found.")]
        public void ThrowsExceptionOnInvalidVehicle() {
            Vehicle vehicle = dr.GetVehicle(-1);
        }

        [TestMethod]
        public void CorrectlyCreateAndDeleteVehicle() {
            Vehicle vehicle = new Vehicle(2, "YYY002", Vehicle.Type.Motorcycle);
            Assert.AreEqual(1, dr.GetAllVehicles().Count);
            dr.CreateVehicle(vehicle);
            Assert.AreEqual(2, dr.GetAllVehicles().Count);
            dr.DeleteVehicle(vehicle.Id);
            Assert.AreEqual(1, dr.GetAllVehicles().Count);
        }

        [TestMethod]
        public void CorrectlyUpdateVehicle() {
            Vehicle vehicle = dr.GetVehicle(veh.Id);
            Assert.AreEqual(1, vehicle.VehicleType);
            vehicle.VehicleType = (int) Vehicle.Type.Motorcycle;
            dr.UpdateVehicle(vehicle);

            Vehicle updated_vehicle = dr.GetVehicle(veh.Id);
            Assert.AreEqual(2, updated_vehicle.VehicleType);
        }
    }
}
