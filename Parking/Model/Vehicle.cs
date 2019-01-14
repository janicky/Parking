using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model {
    public class Vehicle {
        public enum VehicleType { Car, Motorcycle }

        private string id;
        private VehicleType type;
        private ObservableCollection<Visit> visits;

        public Vehicle(string id, VehicleType type) {
            this.id = id;
            this.type = type;
        }

        public string GetId() {
            return id;
        }

        public VehicleType GetVehicleType() {
            return type;
        }

        public void AddVisit(Visit visit) {
            visits.Add(visit);
        }

        public void RemoveVisit(Visit visit) {
            visits.Remove(visit);
        }
    }
}
