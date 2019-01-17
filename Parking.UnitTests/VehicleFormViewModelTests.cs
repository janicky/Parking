using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.ViewModel;
using Parking.Model;

namespace Parking.UnitTests {
    [TestClass]
    public class VehicleFormViewModelTests {

        private VehicleFormViewModel vfvm;

        public void SaveVehicleForm(string plate, int vehicleType) {
            // todo
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
    }
}
