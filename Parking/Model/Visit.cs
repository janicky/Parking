using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    class Visit {
        private static int index = 0;
        private int id;
        private Vehicle vehicle;
        private DateTimeOffset startDate;
        private DateTimeOffset endDate;
        private Payment payment;

        public Visit(Vehicle vehicle, DateTimeOffset startDate, DateTimeOffset endDate = default(DateTimeOffset)) {
            id = index++;
            this.vehicle = vehicle;
            this.startDate = startDate;
            this.endDate = endDate;
            payment = null;
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

        public void End() {

        }
    }
}
