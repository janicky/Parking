using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using SQLite;

namespace Parking.Services {
    public partial class DataRepository {
        private DataContext dataContext = new DataContext();
        private string connectionString;

        public DataRepository(string connectionString = "W:/C#/Parking/Parking.Services/database.db") {
            this.connectionString = connectionString;
            Batteries.Init();
        }

        public void Clear() {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.RunInTransaction(() => {
                conn.Query<int>("DELETE FROM Vehicle");
                conn.Query<int>("DELETE FROM Visit");
                conn.Query<int>("DELETE FROM Payment");
            });
        }
    }
}
