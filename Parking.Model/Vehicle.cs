using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Parking.Model {
    public class Vehicle {
        public enum Type { Car = 1, Motorcycle = 2 }

        private Type vehicleType;
        [PrimaryKey]
        public string Id { get; set; }
        public int VehicleType {
            get => (int) vehicleType;
            set => vehicleType = (Type) value;
        }

        public string VehicleTypeName {
            get {
                switch(vehicleType) {
                    case Type.Car:
                        return "Samochód";
                    case Type.Motorcycle:
                        return "Motocykl";
                    default:
                        return "Nieznany";
                }
            }
        }

        public Vehicle() {

        }

        public Vehicle(string id, Type type) {
            Id = id;
            VehicleType = (int) type;
        }
    }
}
