using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    public class Payment {
        private DateTimeOffset date;

        public int Id { get; set; }
        public double Value { get; set; }
        public long Date {
            get {
                return date.ToUnixTimeSeconds();
            }
            set {
                date = DateTimeOffset.FromUnixTimeSeconds(value);
            }
        }

        public Payment(int id, double value) {
            Id = id;
            Value = value;
            Date = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}
