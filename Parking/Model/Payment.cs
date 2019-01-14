using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    public class Payment {
        private int id;
        private Visit visit;
        private double value;
        private DateTimeOffset date;

        public Payment(int id, Visit visit, double value) {
            this.id = id;
            this.visit = visit;
            this.value = value;
            date = DateTimeOffset.Now;
        }

        public int GetId() {
            return id;
        }

        public Visit GetVisit() {
            return visit;
        }

        public double GetValue() {
            return value;
        }

        public DateTimeOffset GetDate() {
            return date;
        }
    }
}
