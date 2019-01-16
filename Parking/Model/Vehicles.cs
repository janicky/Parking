﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Services;

namespace Parking.Model {

    class Vehicles {

        DataRepository dataRepository = new DataRepository();

        public IEnumerable<Vehicle> All() {
            return dataRepository.GetAllVehicles();
        }

        public Vehicle Get(string id) {
            return dataRepository.GetVehicle(id);
        }

        public Vehicle Create(string id, int vehicleType) {
            Vehicle vehicle = new Vehicle(id, (Vehicle.Type) vehicleType);
            dataRepository.CreateVehicle(vehicle);
            return vehicle;
        }

        public void Update(Vehicle vehicle) {
            dataRepository.UpdateVehicle(vehicle);
        }

        public void Delete(string id) {
            dataRepository.DeleteVehicle(id);
        }
    }
}
