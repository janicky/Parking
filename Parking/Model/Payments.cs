using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Parking.Services;

namespace Parking.Model {
    class Payments {
        DataRepository dataRepository = new DataRepository();

        public IEnumerable<Payment> All() {
            return dataRepository.GetAllPayments();
        }

        public Payment Get(int id) {
            return dataRepository.GetPayment(id);
        }

        public void Create(Payment payment) {
            dataRepository.CreatePayment(payment);
        }

        public void Update(Payment payment) {
            dataRepository.UpdatePayment(payment);
        }

        public void Delete(int id) {
            dataRepository.DeletePayment(id);
        }
    }
}