using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.ViewModel;
using Parking.Model;

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
        public void DeleteVehicle() {
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
    }
}
