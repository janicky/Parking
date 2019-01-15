using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Services;
using Parking.Model;
using System.Collections.Generic;
using SQLitePCL;
using System.Configuration;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class DataRepositoryTests {
        private DataRepository dr;

        [TestInitialize]
        public void InitializeTest() {
            Batteries_V2.Init();
            dr = new DataRepository(ConfigurationManager.AppSettings["testDatabase"]);
        }

        [TestMethod]
        public void GetVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>(dr.GetAllVehicles());
            Assert.AreEqual(1, vehicles.Count);
            Assert.AreEqual("XXX001", vehicles[0].Id);
        }
    }
}
