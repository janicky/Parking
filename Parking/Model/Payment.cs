using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    class Payment {
        private Visit visit;
        private double value;
        private DateTimeOffset date;

        public Payment(Visit visit, double value) {
            this.visit = visit;
            this.value = value;
            date = DateTimeOffset.Now;
        }
    }
}
