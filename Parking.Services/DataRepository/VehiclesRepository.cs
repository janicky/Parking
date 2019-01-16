using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;
using SQLite;

namespace Parking.Services {
    public partial class DataRepository {

        public List<Vehicle> GetAllVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>();
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            return new List<Vehicle>(conn.Table<Vehicle>());
        }

        public Vehicle GetVehicle(int id) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            Vehicle vehicle = conn.Query<Vehicle>("SELECT * FROM Vehicle WHERE Id = ?", id).FirstOrDefault();
            if (vehicle == null) {
                throw new Exception("Vehicle not found.");
            }
            return vehicle;
        }

        public void CreateVehicle(Vehicle vehicle) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.RunInTransaction(() => {
                conn.Insert(vehicle);
            });
        }

        public void UpdateVehicle(Vehicle vehicle) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            var existingVehicle = GetVehicle(vehicle.Id);
            if (existingVehicle != null) {
                existingVehicle.VehicleType = vehicle.VehicleType;
                conn.RunInTransaction(() => {
                    conn.Update(existingVehicle);
                });
            }
        }

        public void DeleteVehicle(int id) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            var existingVehicle = GetVehicle(id);
            if (existingVehicle != null) {
                conn.RunInTransaction(() => {
                    conn.Delete(existingVehicle);
                });
            }
        }
    }
}
