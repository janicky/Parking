using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;
using SQLite;
using Microsoft.Data.Sqlite;

namespace Parking.Services {
    public partial class DataRepository {

        public IEnumerable<Vehicle> GetAllVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>();
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            return conn.Table<Vehicle>();
        }

        public Vehicle GetVehicle(string id) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            return conn.Query<Vehicle>("SELECT * FROM Vehicle WHERE Id = ?", id).FirstOrDefault();
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

        public void DeleteVehicle(string id) {
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
