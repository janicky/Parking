using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;

namespace Parking.Services {
    public partial class DataRepository {
        
        public List<Payment> GetAllPayments() {
            return new List<Payment>();
        }

        public Payment GetPayment(int id) {
            return null;
        }

        public void CreatePayment(Payment payment) {

        }

        public void UpdatePayment(Payment payment) {

        }

        public void DeletePayment(int id) {

        }
    }
}
