using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;
using SQLite;

namespace Parking.Services {
    public partial class DataRepository {
        public List<Visit> GetAllVisits() {
            List<Visit> visits = new List<Visit>();
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            return new List<Visit>(conn.Table<Visit>());
        }

        public Visit GetVisit(int id) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            Visit visit = conn.Query<Visit>("SELECT * FROM Visit WHERE Id = ?", id).FirstOrDefault();
            if (visit == null) {
                throw new Exception("Visit not found.");
            }
            return visit;
        }

        public void CreateVisit(Visit visit) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.RunInTransaction(() => {
                conn.Insert(visit);
            });
        }

        public void UpdateVisit(Visit visit) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            var existingVisit = GetVisit(visit.Id);
            if (existingVisit != null) {
                existingVisit.VehicleId = visit.VehicleId;
                existingVisit.StartDate = visit.StartDate;
                existingVisit.EndDate = visit.EndDate;
                existingVisit.PaymentId = visit.PaymentId;
                existingVisit.Finished = visit.Finished;
                conn.RunInTransaction(() => {
                    conn.Update(existingVisit);
                });
            }
        }

        public void DeleteVisit(int id) {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            var existingVisit = GetVisit(id);
            if (existingVisit != null) {
                conn.RunInTransaction(() => {
                    conn.Delete(existingVisit);
                });
            }
        }
    }
}
