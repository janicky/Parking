using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    public class Visit {
        private int id;
        private Vehicle vehicle;
        private DateTimeOffset startDate;
        private DateTimeOffset endDate;
        private Payment payment = null;
        private bool finished = false;

        public Visit(int id, Vehicle vehicle, DateTimeOffset startDate, DateTimeOffset endDate = default(DateTimeOffset)) {
            this.id = id;
            this.vehicle = vehicle;
            this.startDate = startDate;
            this.endDate = endDate;
            this.vehicle.AddVisit(this);
        }

        public int GetId() {
            return id;
        }

        public Vehicle GetVehicle() {
            return vehicle;
        }

        public DateTimeOffset GetStartDate() {
            return startDate;
        }

        public DateTimeOffset GetEndDate() {
            return endDate;
        }

        public Payment GetPayment() {
            return payment;
        }

        public bool IsFinished() {
            return finished;
        }

        public void Finish(Payment payment) {
            if (finished) {
                throw new Exception("The visit has already been finished.");
            }
            this.payment = payment;
            finished = true;
            endDate = DateTimeOffset.Now;
        }
    }
}
