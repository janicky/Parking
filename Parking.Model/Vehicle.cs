using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    public class Vehicle {
        public enum Type { Car = 1, Motorcycle = 2 }
  
        public string Id { get; set; }
        public int VehicleType { get; set; }

        public Vehicle(string id, Type type) {
            Id = id;
            VehicleType = (int) type;
        }
    }
}
