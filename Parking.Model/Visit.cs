using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Parking.Model {
    public class Visit {

        private DateTimeOffset startDate;
        private DateTimeOffset endDate;

        [PrimaryKey]
        public int Id { get; set; }
        // Datetime in unix time
        public long StartDate {
            get {
                return startDate.ToUnixTimeSeconds();
            }
            set {
                startDate = DateTimeOffset.FromUnixTimeSeconds(value);
            }
        }
        public long EndDate {
            get {
                return endDate.ToUnixTimeSeconds();
            }
            set {
                endDate = DateTimeOffset.FromUnixTimeSeconds(value);
            }
        }
        public string VehicleId { get; set; }
        public int PaymentId { get; set; }
        public bool Finished { get; set; }

        public DateTimeOffset StartDateTime {
            get => startDate;
        }

        public DateTimeOffset EndDateTime {
            get => endDate;
        }

        public Visit() {

        }

        public Visit(int id, string vehicleId, long startDate, long endDate = 0, int paymentId = 0) {
            Id = id;
            VehicleId = vehicleId;
            PaymentId = paymentId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int GetDuration() {
            DateTimeOffset range = (EndDate != 0 ? endDate : DateTimeOffset.Now);
            return range.Subtract(startDate).Hours;
        }

        public void Finish(Payment payment) {
            if (Finished) {
                throw new Exception("The visit has already been finished.");
            }
            // todo: this.payment = payment;
            Finished = true;
            endDate = DateTimeOffset.Now;
        }
    }
}
