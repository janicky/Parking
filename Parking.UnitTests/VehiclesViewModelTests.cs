using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.ViewModel;
using Parking.Model;
using System.Collections.Generic;

namespace Parking.UnitTests {
    [TestClass]
    public class VehiclesViewModelTests {

        private VehiclesViewModel vvm;
        private Visits Visits = new Visits();
        private Vehicles Vehicles = new Vehicles();

        [TestInitialize]
        public void TestInitialize() {
            vvm = new VehiclesViewModel();
        }

        [TestMethod]
        public void CorrectVisitStatesOnStartup() {
            Assert.AreEqual(false, vvm.CanStartVisit);
            Assert.AreEqual(false, vvm.CanEndVisit);
            Assert.AreEqual(null, vvm.SelectedVehicle);
            Assert.AreEqual(null, vvm.AddVehicleWindow);
            Assert.AreEqual(null, vvm.EditVehicleWindow);
        }

        [TestMethod]
        public void CorrectVisitForSelectedVehicle() {
            Assert.AreEqual(null, vvm.GetVisitForSelectedVehicle());
            vvm.SelectedVehicle = vvm.VehiclesCollection[0];
            Visit visit = Visits.GetForVehicle(vvm.SelectedVehicle.Id);
            vvm.UpdateVehicleDetails(visit);
            if (visit != null) {
                Assert.AreEqual(visit.Finished, vvm.CanStartVisit);
                Assert.AreEqual(!visit.Finished, vvm.CanEndVisit);
                Assert.AreEqual(visit.Id, vvm.GetVisitForSelectedVehicle().Id);
            }
        }

        [TestMethod]
        public void CorrectlyUpdateVehicleDetails() {
            vvm.UpdateVehicleDetails(null);
            Assert.AreEqual(true, vvm.CanStartVisit);
            Assert.AreEqual(false, vvm.CanEndVisit);
        }

        [TestMethod]
        public void CorrectStartAndEndVisit() {
            Vehicle vehicle = vvm.VehiclesCollection[0];
            if (vehicle == null) Assert.Fail();
            vvm.SelectedVehicle = vehicle;

            Visit visit = vvm.GetVisitForSelectedVehicle();
            if (visit == null || visit.Finished) {
                vvm.StartVisit();
            }
            visit = vvm.GetVisitForSelectedVehicle();

            Assert.AreNotEqual(null, visit);
            Assert.AreEqual(false, visit.Finished);

            vvm.EndVisit(visit);
            Assert.AreEqual(true, visit.Finished);
        }

        [TestMethod]
        public void CorrectlyDeleteVehicle() {
            Vehicle vehicle = Vehicles.Create("98ASD871NFLS91", 1);

            var beforeAdd = vvm.VehiclesCollection.IndexOf(vehicle);
            Assert.AreEqual(-1, beforeAdd);
            Assert.AreEqual(Vehicles.Get(vehicle.Id).Id, vehicle.Id);

            vvm.VehiclesCollection.Add(vehicle);
            var beforeDelete = vvm.VehiclesCollection.IndexOf(vehicle);
            Assert.AreNotEqual(-1, beforeDelete);
            vvm.SelectedVehicle = vehicle;
            vvm.DeleteVehicle();

            var afterDelete = vvm.VehiclesCollection.IndexOf(vehicle);
            Assert.AreEqual(-1, afterDelete);
        }

        [TestMethod]
        public void CorrectlyAddVehicle() {
            string plate = "912389SADAB1JSK";

            int vehiclesInList = vvm.VehiclesCollection.Count;
            int vehiclesInModel = new List<Vehicle>(Vehicles.All()).Count;
            vvm.AddVehicle(true);
            Assert.AreNotEqual(null, vvm.AddVehicleWindow);
            vvm.HandleAddVehicle(plate, 1);

            Assert.AreEqual(vehiclesInList + 1, vvm.VehiclesCollection.Count);
            Assert.AreEqual(vehiclesInModel + 1, new List<Vehicle>(Vehicles.All()).Count);

            List<Vehicle> vehiclesList = new List<Vehicle>(Vehicles.All());
            Vehicle vehicle = vehiclesList.FindLast(i => i.Plate == plate);

            if (vehicle == null) {
                Assert.Fail();
            }

            vvm.SelectedVehicle = vehicle;
            Vehicles.Delete(vehicle.Id);
        }

        [TestMethod]
        public void CorrectlyEditVehicle() {
            string plate = "164X41C891ASDA";
            Vehicle vehicle = Vehicles.Create(plate, 1);
            vvm.VehiclesCollection.Add(vehicle);
            vvm.SelectedVehicle = vehicle;
            vvm.EditVehicle(true);
            Assert.AreNotEqual(null, vvm.EditVehicleWindow);

            string newPlate = "164X41C891ASDB";
            vvm.HandleEditVehicle(newPlate, 1);

            Vehicle updatedVehicle = Vehicles.Get(vehicle.Id);
            Assert.AreEqual(newPlate, updatedVehicle.Plate);

            Vehicles.Delete(vehicle.Id);
        }
    }
}
