using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.ViewModel;
using Parking.Model;

namespace Parking.UnitTests {
    [TestClass]
    public class VehicleFormViewModelTests {

        private VehicleFormViewModel vfvm;
        private bool saveHandled = false;
        private bool correctData = false;

        public void SaveVehicleForm(string plate, int vehicleType) {
            saveHandled = true;

            correctData = plate == "TEST-001" && vehicleType == 2;
        }

        [TestInitialize]
        public void TestInitialize() {
            vfvm = new VehicleFormViewModel(SaveVehicleForm);
        }

        [TestMethod]
        public void CorrectlyFillProperties() {
            Vehicle vehicle = new Vehicle(-1, "FFF-001", Vehicle.Type.Car);
            VehicleFormViewModel v = new VehicleFormViewModel(SaveVehicleForm, null, null, vehicle);
            Assert.AreEqual(vehicle.Plate, v.Plate);
            Assert.AreEqual(vehicle.VehicleType, v.VehicleType + 1);
        }

        [TestMethod]
        public void CorrectlyHandleSave() {
            vfvm.Plate = "TEST-001";
            vfvm.VehicleType = 1;
            Assert.AreEqual(false, saveHandled);
            Assert.AreEqual(false, correctData);

            vfvm.HandleSave(true);
            Assert.AreEqual(true, saveHandled);
            Assert.AreEqual(true, correctData);
        }
    }
}
