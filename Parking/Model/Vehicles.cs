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

        public Vehicle Get(int id) {
            return dataRepository.GetVehicle(id);
        }

        public Vehicle Create(string plate, int vehicleType) {
            Vehicle vehicle = new Vehicle(-1, plate, (Vehicle.Type) vehicleType);
            dataRepository.CreateVehicle(vehicle);
            return vehicle;
        }

        public void Update(Vehicle vehicle) {
            dataRepository.UpdateVehicle(vehicle);
        }

        public void Delete(int id) {
            dataRepository.DeleteVehicle(id);
        }
    }
}
