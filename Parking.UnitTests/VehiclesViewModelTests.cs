using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.ViewModel;

namespace Parking.UnitTests {
    [TestClass]
    public class VehiclesViewModelTests {

        private VehiclesViewModel vvm;

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
    }
}
