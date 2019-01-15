using System;
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

        public Vehicle GetVehicle(string id) {
            return dataRepository.GetVehicle(id);
        }

        public void CreateVehicle(Vehicle vehicle) {
            dataRepository.CreateVehicle(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle) {
            dataRepository.UpdateVehicle(vehicle);
        }

        public void DeleteVehicle(string id) {
            dataRepository.DeleteVehicle(id);
        }
    }
}
