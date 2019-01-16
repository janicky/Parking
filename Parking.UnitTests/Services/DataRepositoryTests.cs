using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Services;
using Parking.Model;
using System.Collections.Generic;
using System.Configuration;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class DataRepositoryTests {
        private DataRepository dr;

        [TestInitialize]
        public void InitializeTest() {
            dr = new DataRepository(ConfigurationManager.AppSettings["testDatabase"]);
        }

        [TestMethod]
        public void CorrectlyClearDatabase() {
            dr.Clear();
            Assert.AreEqual(0, dr.GetAllVehicles().Count);
            Assert.AreEqual(0, dr.GetAllVisits().Count);
            Assert.AreEqual(0, dr.GetAllPayments().Count);
        }
    }
}
