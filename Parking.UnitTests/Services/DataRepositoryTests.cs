using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Services;
using Parking.Model;
using System.Collections.Generic;
using SQLitePCL;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class DataRepositoryTests {
        private DataRepository dr = new DataRepository();

        [TestInitialize]
        public void InitializeTest() {
            Batteries_V2.Init();
        }

        [TestMethod]
        public void GetVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>(dr.GetVehicles());
            Assert.AreEqual(1, vehicles.Count);
            Assert.AreEqual("XXX001", vehicles[0].Id);
        }
    }
}
