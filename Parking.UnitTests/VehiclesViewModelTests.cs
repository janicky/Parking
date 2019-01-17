﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.ViewModel;
using Parking.Model;

namespace Parking.UnitTests {
    [TestClass]
    public class VehiclesViewModelTests {

        private VehiclesViewModel vvm;
        private Visits Visits = new Visits();

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
            Assert.AreEqual(visit.Id, vvm.GetVisitForSelectedVehicle().Id);
        }
    }
}
