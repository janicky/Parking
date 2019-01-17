using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Parking.Services;

namespace Parking.Model {
    public class Payments {
        DataRepository dataRepository = new DataRepository();

        public IEnumerable<Payment> All() {
            return dataRepository.GetAllPayments();
        }

        public Payment Get(int id) {
            return dataRepository.GetPayment(id);
        }

        public Payment Create(double price) {
            Payment payment = new Payment(-1, price);
            dataRepository.CreatePayment(payment);
            return payment;
        }

        public void Update(Payment payment) {
            dataRepository.UpdatePayment(payment);
        }

        public void Delete(int id) {
            dataRepository.DeletePayment(id);
        }
    }
}