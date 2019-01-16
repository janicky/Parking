using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Parking.Model {
    public class Vehicle : Model {
        public enum Type { Car = 1, Motorcycle = 2 }

        private string plate;
        private Type vehicleType;
        
        [PrimaryKey]
        public int Id { get; set; }

        public string Plate {
            get => plate;
            set { plate = value; OnPropertyChanged("Plate"); }
        }

        public int VehicleType {
            get => (int) vehicleType;
            set { vehicleType = (Type)value; OnPropertyChanged("VehicleType"); }
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

        public Vehicle(int id, string plate, Type type) {
            Id = id;
            Plate = plate;
            VehicleType = (int) type;
        }
    }
}
