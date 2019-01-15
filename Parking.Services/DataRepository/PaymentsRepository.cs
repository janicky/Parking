using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;
using SQLite;

namespace Parking.Services {
    public partial class DataRepository {
        
        public List<Payment> GetAllPayments() {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            return new List<Payment>(conn.Table<Payment>());
        }

        public Payment GetPayment(int id) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            Payment payment = conn.Query<Payment>("SELECT * FROM Payment WHERE Id = ?", id).FirstOrDefault();
            if (payment == null) {
                throw new Exception("Payment not found.");
            }
            return payment;
        }

        public void CreatePayment(Payment payment) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.RunInTransaction(() => {
                conn.Insert(payment);
            });
        }

        public void UpdatePayment(Payment payment) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            var existingPayment = GetPayment(payment.Id);
            if (existingPayment != null) {
                existingPayment.Value = payment.Value;
                conn.RunInTransaction(() => {
                    conn.Update(existingPayment);
                });
            }
        }

        public void DeletePayment(int id) {

        }
    }
}
