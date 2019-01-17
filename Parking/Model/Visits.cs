using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Parking.Model;
using Parking.Services;

namespace Parking.Model {
    public class Visits {
        DataRepository dataRepository = new DataRepository();

        public IEnumerable<Visit> All() {
            return dataRepository.GetAllVisits();
        }

        public Visit Get(int id) {
            return dataRepository.GetVisit(id);
        }

        public Visit GetForVehicle(int id) {
            return dataRepository.GetAllVisits().LastOrDefault(v => v.VehicleId == id);
        }

        public Visit Create(int vehicleId) {
            Visit visit = new Visit(-1, vehicleId, DateTimeOffset.Now.ToUnixTimeSeconds());
            dataRepository.CreateVisit(visit);
            return visit;
        }

        public void Update(Visit visit) {
            dataRepository.UpdateVisit(visit);
        }

        public void Delete(int id) {
            dataRepository.DeleteVisit(id);
        }
    }
}