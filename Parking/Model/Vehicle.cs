using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    class Vehicle {
        public enum VehicleType { Car, Motorcycle }

        private string id;
        private VehicleType type;

        public Vehicle(string id, VehicleType type) {
            this.id = id;
            this.type = type;
        }
    }
}
