using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLitePCL;
using Parking.Model;
using Parking.Services;
using System.Collections.Generic;

namespace Parking.UnitTests.Services {
    [TestClass]
    public class PaymentsRepositoryTests {
        private DataRepository dr = new DataRepository();

        [TestInitialize]
        public void InitializeTest() {
            Batteries_V2.Init();
            dr.Clear();
            dr.CreatePayment(new Payment(1, 100d));
        }

        [TestMethod]
        public void CorrectlyReturnsAllPayments() {
            List<Payment> payments = dr.GetAllPayments();
            Assert.AreEqual(1, payments.Count);
            Assert.AreEqual(1, payments[0].Id);
            Assert.AreEqual(100d, payments[0].Value);
        }

        [TestMethod]
        public void CorrectlyReturnsSpecifiedPayment() {
            Payment payment = dr.GetPayment(1);
            Assert.AreEqual(1, payment.Id);
            Assert.AreEqual(100d, payment.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Payment not found.")]
        public void ThrowsExceptionOnInvalidVisit() {
            Payment payment = dr.GetPayment(-1);
        }

        [TestMethod]
        public void CorrectlyCreateAndDeletePayment() {
            Payment payment = new Payment(2, 200d);
            Assert.AreEqual(1, dr.GetAllPayments().Count);
            dr.CreatePayment(payment);
            Assert.AreEqual(2, dr.GetAllPayments().Count);
            dr.DeletePayment(payment.Id);
            Assert.AreEqual(1, dr.GetAllPayments().Count);
        }

        [TestMethod]
        public void CorrectlyUpdatePayment() {
            Payment payment = dr.GetPayment(1);
            Assert.AreEqual(100d, payment.Value);
            payment.Value = 150d;
            dr.UpdatePayment(payment);

            Payment updated_payment = dr.GetPayment(1);
            Assert.AreEqual(150d, updated_payment.Value);
        }
    }
}
