using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    public class Payment {
        public static int index = 0;
        private int id;
        private Visit visit;
        private double value;
        private DateTimeOffset date;

        public Payment(Visit visit, double value) {
            id = index++;
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
