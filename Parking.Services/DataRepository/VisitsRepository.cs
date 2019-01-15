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
            return null;
        }

        public void CreateVisit(Visit visit) {
        }

        public void UpdateVisit(Visit visit) {
        }

        public void DeleteVisit(int id) {
        }
    }
}
